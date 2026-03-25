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
        
        _ReflectionCube ("Reflection Cube", Cube) = "white" {}
        _ReflectionIntensity ("Reflection Intensity", Range(0, 1)) = 0.5
        _ReflectionFresnelPower ("Reflection Fresnel Power", Range(0, 10)) = 2.0
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

            Cull Off
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off

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
                float3 positionWS : TEXCOORD4;
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
                float _ReflectionIntensity;
                float _ReflectionFresnelPower;
            CBUFFER_END

            TEXTURE2D(_NoiseTexture);
            SAMPLER(sampler_NoiseTexture);
            TEXTURE2D(_CameraOpaqueTexture);
            SAMPLER(sampler_CameraOpaqueTexture);
            TEXTURECUBE(_ReflectionCube);
            SAMPLER(sampler_ReflectionCube);

            Varyings vert(Attributes input)
            {
                Varyings output;
                output.positionCS = TransformObjectToHClip(input.positionOS.xyz);
                output.uv = TRANSFORM_TEX(input.uv, _NoiseTexture);
                output.normalWS = TransformObjectToWorldNormal(input.normalOS);
                output.positionWS = TransformObjectToWorld(input.positionOS.xyz);
                output.screenPos = ComputeScreenPos(output.positionCS);
                output.viewDirWS = GetWorldSpaceViewDir(output.positionWS);
                return output;
            }

            half4 frag(Varyings input) : SV_Target
            {
                float3 normalWS = normalize(input.normalWS);
                float3 viewDirWS = normalize(input.viewDirWS);

                // Симметричный френель (абсолютное значение)
                float NdotV = abs(dot(normalWS, viewDirWS));

                // Френель для прозрачности воды
                float fresnel = pow(1.0 - NdotV, _FresnelPower);
                fresnel = lerp(_FresnelBias, 1.0, fresnel);

                // Преломление – защита UV от выхода за границы (с небольшим отступом)
                float2 screenUV = input.screenPos.xy / input.screenPos.w;
                float2 noiseUV = input.uv + _Time.y * _DistortionSpeed;
                float2 noise = SAMPLE_TEXTURE2D(_NoiseTexture, sampler_NoiseTexture, noiseUV).rg * 2.0 - 1.0;
                noise *= _DistortionStrength;

                float3 normalVS = TransformWorldToViewDir(normalWS);
                float2 normalDistortion = normalVS.xy * _RefractionScale;
                float2 distortion = noise + normalDistortion;
                float2 distortedUV = screenUV + distortion;

                // Жёсткое ограничение UV с отступом от краёв
                distortedUV = clamp(distortedUV, 0.001, 0.999);

                half3 bgColor = SAMPLE_TEXTURE2D(_CameraOpaqueTexture, sampler_CameraOpaqueTexture, distortedUV).rgb;
                half3 waterColor = _Color.rgb;

                // Смешивание воды с фоном
                half alphaWater = _Color.a * fresnel;
                half3 combinedColor = lerp(bgColor, waterColor, alphaWater);

                // Отражения – используем только если куб назначен (иначе не добавляем)
                half3 reflectionColor = 0;
                #ifdef TEXTURECUBE_ON
                float3 reflectionDir = reflect(-viewDirWS, normalWS);
                reflectionColor = SAMPLE_TEXTURECUBE(_ReflectionCube, sampler_ReflectionCube, reflectionDir).rgb;
                #endif
                float reflectionFresnel = pow(1.0 - NdotV, _ReflectionFresnelPower);
                reflectionFresnel = saturate(reflectionFresnel);
                half3 finalColor = lerp(combinedColor, reflectionColor, _ReflectionIntensity * reflectionFresnel);

                // Спекуляр – ограничиваем яркость
                Light mainLight = GetMainLight();
                float3 lightDir = mainLight.direction;
                float3 halfVec = normalize(lightDir + viewDirWS);
                half specular = pow(saturate(dot(normalWS, halfVec)), 64);
                specular = min(specular, 1.0) * _SpecularIntensity;
                finalColor += specular;

                // Финальная защита от пересвета
                finalColor = saturate(finalColor);

                return half4(finalColor, 1.0);
            }
            ENDHLSL
        }
    }
    FallBack "Universal Render Pipeline/Unlit"
}