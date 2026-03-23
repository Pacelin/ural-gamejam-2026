Shader "Custom/Hole"
{
    Properties
    {
        _StartDepth ("Start Depth", Float) = 5.0
        _EndDepth ("End Depth", Float) = 20.0
        _DarknessMax ("Max Darkness", Range(0, 1)) = 0.8
    }

    SubShader
    {
        Tags { "RenderType" = "Transparent" "Queue" = "Transparent" "RenderPipeline" = "UniversalPipeline" }
        Blend SrcAlpha OneMinusSrcAlpha
        ZWrite Off
        Cull Off

        Pass
        {
            Name "DepthDarkenPlane"
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/DeclareDepthTexture.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/DeclareOpaqueTexture.hlsl"

            struct Attributes
            {
                float4 positionOS : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionCS : SV_POSITION;
                float2 uv : TEXCOORD0;
                float4 screenPos : TEXCOORD1;
            };

            float _StartDepth;
            float _EndDepth;
            float _DarknessMax;

            Varyings vert(Attributes input)
            {
                Varyings output;
                output.positionCS = TransformObjectToHClip(input.positionOS.xyz);
                output.uv = input.uv;
                // Для выборки текстур экрана
                output.screenPos = ComputeScreenPos(output.positionCS);
                return output;
            }

            half4 frag(Varyings input) : SV_Target
            {
                // Координаты экрана
                float2 screenUV = input.screenPos.xy / input.screenPos.w;

                // Цвет сцены за плоскостью (непрозрачные объекты)
                half3 sceneColor = SampleSceneColor(screenUV).rgb;

                // Глубина сцены (расстояние от камеры в метрах)
                float depth = SampleSceneDepth(screenUV);
                float linearDepth = LinearEyeDepth(depth, _ZBufferParams);

                // Коэффициент затемнения: 0 – нет, _DarknessMax – полное
                float darkness = saturate((linearDepth - _StartDepth) / (_EndDepth - _StartDepth));
                darkness *= _DarknessMax;

                // Итоговый цвет: смешиваем сцену с чёрным
                half3 finalColor = lerp(sceneColor, half3(0, 0, 0), darkness);

                // Альфа не обязательна, но для прозрачности можно вернуть 1 (или darkness)
                return half4(finalColor, 1.0);
            }
            ENDHLSL
        }
    }
}