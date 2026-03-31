void TriplanarParallax_float(
    float3 PositionWS,
    float3 NormalWS,
    float3 ViewDirWS,               // Вектор от фрагмента к камере (инвертированный View Direction)
    UnityTexture2D HeightMap,
    float HeightScale,              // Положительное значение (0.05–0.5)
    float HeightBias,               // Обычно 0
    int NumSteps,                   // 1 – простой сдвиг, 4–8 – steep parallax
    out float2 UV_X,
    out float2 UV_Y,
    out float2 UV_Z)
{
    // Исходные UV для каждой оси
    float2 uvX_raw = PositionWS.zy;
    float2 uvY_raw = PositionWS.xz;
    float2 uvZ_raw = PositionWS.xy;

    // Базисы для оси X
    float3 tangentX = float3(0, 1, 0);
    float3 bitangentX = float3(0, 0, 1);
    float3 normalX = float3(1, 0, 0);

    // Базисы для оси Y
    float3 tangentY = float3(1, 0, 0);
    float3 bitangentY = float3(0, 0, 1);
    float3 normalY = float3(0, 1, 0);

    // Базисы для оси Z
    float3 tangentZ = float3(1, 0, 0);
    float3 bitangentZ = float3(0, 1, 0);
    float3 normalZ = float3(0, 0, 1);

    // Извлекаем текстуру и сэмплер
    Texture2D tex = HeightMap.tex;
    SamplerState samp = HeightMap.samplerstate;

    // --- Ось X ---
    float2 uvX = uvX_raw;
    {
        float3 viewDirTS;
        viewDirTS.x = dot(ViewDirWS, tangentX);
        viewDirTS.y = dot(ViewDirWS, bitangentX);
        viewDirTS.z = dot(ViewDirWS, normalX);
        viewDirTS = normalize(viewDirTS);

        float viewZ = max(abs(viewDirTS.z), 0.001);
        viewZ = (viewDirTS.z > 0) ? viewZ : -viewZ;

        float height = tex.SampleLevel(samp, uvX, 0).r;
        float offsetMag = (height * HeightScale + HeightBias) / viewZ;
        float2 offset = viewDirTS.xy * offsetMag;

        if (NumSteps > 1)
        {
            float stepSize = 1.0 / NumSteps;
            float curDepth = 0.0;
            float2 deltaUV = viewDirTS.xy / (viewZ * NumSteps);
            float2 uvStep = uvX;

            for (int i = 0; i < NumSteps; i++)
            {
                float stepH = tex.SampleLevel(samp, uvStep, 0).r;
                stepH = stepH * HeightScale + HeightBias;
                if (curDepth < stepH)
                {
                    offset = uvStep - uvX;
                    break;
                }
                uvStep += deltaUV;
                curDepth += stepSize;
            }
        }

        uvX = uvX + offset;
    }
    UV_X = uvX;

    // --- Ось Y ---
    float2 uvY = uvY_raw;
    {
        float3 viewDirTS;
        viewDirTS.x = dot(ViewDirWS, tangentY);
        viewDirTS.y = dot(ViewDirWS, bitangentY);
        viewDirTS.z = dot(ViewDirWS, normalY);
        viewDirTS = normalize(viewDirTS);

        float viewZ = max(abs(viewDirTS.z), 0.001);
        viewZ = (viewDirTS.z > 0) ? viewZ : -viewZ;

        float height = tex.SampleLevel(samp, uvY, 0).r;
        float offsetMag = (height * HeightScale + HeightBias) / viewZ;
        float2 offset = viewDirTS.xy * offsetMag;

        if (NumSteps > 1)
        {
            float stepSize = 1.0 / NumSteps;
            float curDepth = 0.0;
            float2 deltaUV = viewDirTS.xy / (viewZ * NumSteps);
            float2 uvStep = uvY;

            for (int i = 0; i < NumSteps; i++)
            {
                float stepH = tex.SampleLevel(samp, uvStep, 0).r;
                stepH = stepH * HeightScale + HeightBias;
                if (curDepth < stepH)
                {
                    offset = uvStep - uvY;
                    break;
                }
                uvStep += deltaUV;
                curDepth += stepSize;
            }
        }

        uvY = uvY + offset;
    }
    UV_Y = uvY;

    // --- Ось Z ---
    float2 uvZ = uvZ_raw;
    {
        float3 viewDirTS;
        viewDirTS.x = dot(ViewDirWS, tangentZ);
        viewDirTS.y = dot(ViewDirWS, bitangentZ);
        viewDirTS.z = dot(ViewDirWS, normalZ);
        viewDirTS = normalize(viewDirTS);

        float viewZ = max(abs(viewDirTS.z), 0.001);
        viewZ = (viewDirTS.z > 0) ? viewZ : -viewZ;

        float height = tex.SampleLevel(samp, uvZ, 0).r;
        float offsetMag = (height * HeightScale + HeightBias) / viewZ;
        float2 offset = viewDirTS.xy * offsetMag;

        if (NumSteps > 1)
        {
            float stepSize = 1.0 / NumSteps;
            float curDepth = 0.0;
            float2 deltaUV = viewDirTS.xy / (viewZ * NumSteps);
            float2 uvStep = uvZ;

            for (int i = 0; i < NumSteps; i++)
            {
                float stepH = tex.SampleLevel(samp, uvStep, 0).r;
                stepH = stepH * HeightScale + HeightBias;
                if (curDepth < stepH)
                {
                    offset = uvStep - uvZ;
                    break;
                }
                uvStep += deltaUV;
                curDepth += stepSize;
            }
        }

        uvZ = uvZ + offset;
    }
    UV_Z = uvZ;
}