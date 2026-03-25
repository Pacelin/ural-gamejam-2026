Shader "Custom/RealisticWater"
{
    Properties
    {
        _Color ("Water Color", Color) = (0.2, 0.5, 0.7, 0.8)
        _DistortionStrength ("Distortion Strength", Range(0, 0.1)) = 0.02
        _DistortionSpeed ("Distortion Speed", Float) = 1.0
        _RefractionScale ("Refraction Scale", Range(0, 0.1)) = 0.02
        _FresnelPower ("Fresnel Power", Range(0, 10)) = 2.0
        _FresnelBias ("Fresnel Bias", Range(0, 1)) = 0.2
        _SpecularIntensity ("Specular Intensity", Range(0, 1)) = 0.3
        _NoiseTexture ("Noise Texture", 2D) = "white" {}
    }

    SubShader
    {
        Tags
        {
            "RenderPipeline" = "UniversalPipeline"
            "Queue" = "Transparent"
            "RenderType" = "Transparent"
        }

        Pass
        {
            Name "WaterPass"
            Tags { "LightMode" = "UniversalForward" }

            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            Cull Back

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

            struct Attributes
            {
                float4 positionOS : POSITION;
                float3 normalOS : NORMAL;
                float2 uv : TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionCS : SV_POSITION;
                float2 uv : TEXCOORD0;
                float3 normalWS : TEXCOORD1;
                float4 screenPos : TEXCOORD2;
                float3 viewDirWS : TEXCOORD3;
            };

            CBUFFER_START(UnityPerMaterial)
                float4 _Color;
                float _DistortionStrength;
                float _DistortionSpeed;
                float _RefractionScale;
                float _FresnelPower;
                float _FresnelBias;
                float _SpecularIntensity;
                float4 _NoiseTexture_ST;
            CBUFFER_END

            TEXTURE2D(_NoiseTexture);
            SAMPLER(sampler_NoiseTexture);
            TEXTURE2D(_CameraOpaqueTexture);
            SAMPLER(sampler_CameraOpaqueTexture);

            Varyings vert(Attributes input)
            {
                Varyings output;
                output.positionCS = TransformObjectToHClip(input.positionOS.xyz);
                output.uv = TRANSFORM_TEX(input.uv, _NoiseTexture);
                output.normalWS = TransformObjectToWorldNormal(input.normalOS);
                output.screenPos = ComputeScreenPos(output.positionCS);
                output.viewDirWS = GetWorldSpaceViewDir(TransformObjectToWorld(input.positionOS.xyz));
                return output;
            }

            half4 frag(Varyings input) : SV_Target
            {
                // Нормализация
                float3 normalWS = normalize(input.normalWS);
                float3 viewDirWS = normalize(input.viewDirWS);

                // Эффект Френеля (прозрачность краёв)
                float fresnel = pow(1.0 - saturate(dot(normalWS, viewDirWS)), _FresnelPower);
                fresnel = lerp(_FresnelBias, 1.0, fresnel);

                // Искажение экранных координат
                float2 screenUV = input.screenPos.xy / input.screenPos.w;

                // Шумовое искажение (движение)
                float2 noiseUV = input.uv + _Time.y * _DistortionSpeed;
                float2 noise = SAMPLE_TEXTURE2D(_NoiseTexture, sampler_NoiseTexture, noiseUV).rg * 2.0 - 1.0;
                noise *= _DistortionStrength;

                // Искажение на основе нормалей в экранном пространстве
                float3 normalVS = TransformWorldToViewDir(normalWS);
                float2 normalDistortion = normalVS.xy * _RefractionScale;
                
                // Суммарное смещение
                float2 distortion = noise + normalDistortion;
                float2 distortedUV = screenUV + distortion;

                // Цвет фона (текстура камеры)
                half3 bgColor = SAMPLE_TEXTURE2D(_CameraOpaqueTexture, sampler_CameraOpaqueTexture, distortedUV).rgb;

                // Цвет воды
                half3 waterColor = _Color.rgb;

                // Смешивание с учётом Френеля и прозрачности
                half alpha = _Color.a * fresnel;
                half3 finalColor = lerp(bgColor, waterColor, alpha);

                // Простой блик (спекуляр)
                half3 lightDir = normalize(_MainLightPosition.xyz);
                half3 halfVec = normalize(lightDir + viewDirWS);
                half specular = pow(saturate(dot(normalWS, halfVec)), 64) * _SpecularIntensity;
                finalColor += specular;

                return half4(finalColor, 1.0);
            }
            ENDHLSL
        }
    }
    FallBack "Universal Render Pipeline/Unlit"
}