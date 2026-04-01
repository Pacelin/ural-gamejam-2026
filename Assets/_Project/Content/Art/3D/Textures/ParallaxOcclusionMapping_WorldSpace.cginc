void Parallax_Occlusion_Mapping_World_Space_float(
    float2 UV,
    float3 WorldViewDir,
    float3 WorldNormal,
    float HeightScale,
    float MinSteps,
    float MaxSteps,
    UnityTexture2D HeightMap,
    out float2 OffsetUV
)
{
    // --- Нормализация входных данных ---
    float3 N = normalize(WorldNormal);
    float3 V = normalize(WorldViewDir);

    // --- Компонента взгляда вдоль нормали (общая для всех зон) ---
    float Vn = dot(V, N);

    // Если смотрим с обратной стороны — параллакс не нужен
    if (Vn <= 0.001)
    {
        OffsetUV = UV;
        return;
    }

    // ----------------------------------------------------------------
    // --- TBN для каждой из трёх зон (X, Y, Z) ---
    // Те же векторы что работали на кубе
    // ----------------------------------------------------------------

    // Y-зона (пол / потолок)
    float3 T_Y = float3(-sign(N.y), 0, 0);
    float3 B_Y = float3(0, 0, -1);

    // X-зона (левая / правая грань)
    float3 T_X = float3(0, 0, -sign(N.x));
    float3 B_X = float3(0, -1, 0);

    // Z-зона (передняя / задняя грань)
    float3 T_Z = float3(sign(N.z), 0, 0);
    float3 B_Z = float3(0, -1, 0);

    // ----------------------------------------------------------------
    // --- Проецируем V в каждую TBN-зону отдельно ---
    // ----------------------------------------------------------------
    float2 VtVb_Y = float2(dot(V, T_Y), dot(V, B_Y));
    float2 VtVb_X = float2(dot(V, T_X), dot(V, B_X));
    float2 VtVb_Z = float2(dot(V, T_Z), dot(V, B_Z));

    // ----------------------------------------------------------------
    // --- Веса зон: чем больше компонента нормали — тем сильнее зона
    // Степень blend контролирует ширину зоны перехода:
    //   степень 1 = широкий переход (мягче, но чуть менее точно)
    //   степень 4 = узкий переход  (резче, ближе к поведению куба)
    // ----------------------------------------------------------------
    float3 absN = abs(N);

    float blend = 4.0;
    float wX = pow(absN.x, blend);
    float wY = pow(absN.y, blend);
    float wZ = pow(absN.z, blend);

    float wSum = wX + wY + wZ;
    // Защита от деления на ноль (не должна срабатывать при нормализованном N,
    // но на всякий случай)
    wSum = max(wSum, 0.00001);

    wX /= wSum;
    wY /= wSum;
    wZ /= wSum;

    // ----------------------------------------------------------------
    // --- Смешиваем проекции взгляда по весам зон ---
    // ----------------------------------------------------------------
    float2 VtVb = VtVb_X * wX + VtVb_Y * wY + VtVb_Z * wZ;

    // ----------------------------------------------------------------
    // --- Количество шагов ---
    // ----------------------------------------------------------------
    int numSteps = (int)clamp(
        lerp(MaxSteps, MinSteps, Vn),
        MinSteps, MaxSteps
    );

    // ----------------------------------------------------------------
    // --- Вектор смещения UV за один полный проход ---
    // ----------------------------------------------------------------
    float2 uvDelta        = (VtVb / Vn) * HeightScale;
    float  layerDepthStep = 1.0 / (float)numSteps;
    float2 uvStep         = uvDelta * layerDepthStep;

    // ----------------------------------------------------------------
    // --- Трассировка от поверхности (depth=0) вглубь (depth=1) ---
    // ----------------------------------------------------------------
    float  currentLayerDepth = 0.0;
    float2 currentUV         = UV;
    float  currentHeight     = SAMPLE_TEXTURE2D_LOD(
                                   HeightMap.tex,
                                   HeightMap.samplerstate,
                                   currentUV, 0).r;

    float  prevLayerDepth = 0.0;
    float2 prevUV         = currentUV;
    float  prevHeight     = currentHeight;

    UNITY_LOOP
    for (int i = 0; i < numSteps; i++)
    {
        prevLayerDepth = currentLayerDepth;
        prevUV         = currentUV;
        prevHeight     = currentHeight;

        currentLayerDepth += layerDepthStep;
        currentUV         -= uvStep;
        currentHeight      = SAMPLE_TEXTURE2D_LOD(
                                 HeightMap.tex,
                                 HeightMap.samplerstate,
                                 currentUV, 0).r;

        if (currentLayerDepth >= currentHeight)
            break;
    }

    // ----------------------------------------------------------------
    // --- Refinement ---
    // ----------------------------------------------------------------
    float prevDiff = prevHeight    - prevLayerDepth;
    float currDiff = currentHeight - currentLayerDepth;

    float denom  = prevDiff - currDiff;
    float weight = (abs(denom) > 0.00001) ? (prevDiff / denom) : 0.0;

    OffsetUV = lerp(prevUV, currentUV, weight);
}