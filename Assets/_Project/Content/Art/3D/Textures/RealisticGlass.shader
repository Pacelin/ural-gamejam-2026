Shader "Custom/RealisticGlass"
{
    Properties
    {
        _Color ("Color Tint", Color) = (1, 1, 1, 0.8)
        _RefractionStrength ("Refraction Strength", Range(0, 0.1)) = 0.02
        _FresnelPower ("Fresnel Power", Range(0, 10)) = 2.0
        _FresnelBias ("Fresnel Bias", Range(0, 1)) = 0.1
        _ReflectionCube ("Reflection Cube", Cube) = "white" {}
        _ReflectionIntensity ("Reflection Intensity", Range(0, 1)) = 0.3
        _ReflectionFresnelPower ("Reflection Fresnel Power", Range(0, 10)) = 2.0
        _NormalMap ("Normal Map", 2D) = "bump" {}
        _NormalStrength ("Normal Strength", Range(0, 2)) = 1.0
        _Roughness ("Roughness", Range(0, 1)) = 0.2
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
            Name "GlassPass"
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
                float4 tangentOS : TANGENT;
            };

            struct Varyings
            {
                float4 positionCS : SV_POSITION;
                float2 uv : TEXCOORD0;
                float3 normalWS : TEXCOORD1;
                float3 tangentWS : TEXCOORD2;
                float3 bitangentWS : TEXCOORD3;
                float4 screenPos : TEXCOORD4;
                float3 viewDirWS : TEXCOORD5;
                float3 positionWS : TEXCOORD6;
            };

            CBUFFER_START(UnityPerMaterial)
                float4 _Color;
                float _RefractionStrength;
                float _FresnelPower;
                float _FresnelBias;
                float _ReflectionIntensity;
                float _ReflectionFresnelPower;
                float4 _NormalMap_ST;
                float _NormalStrength;
                float _Roughness;
            CBUFFER_END

            TEXTURE2D(_NormalMap);
            SAMPLER(sampler_NormalMap);
            TEXTURE2D(_CameraOpaqueTexture);
            SAMPLER(sampler_CameraOpaqueTexture);
            TEXTURECUBE(_ReflectionCube);
            SAMPLER(sampler_ReflectionCube);

            Varyings vert(Attributes input)
            {
                Varyings output;
                output.positionCS = TransformObjectToHClip(input.positionOS.xyz);
                output.uv = TRANSFORM_TEX(input.uv, _NormalMap);
                output.positionWS = TransformObjectToWorld(input.positionOS.xyz);
                output.normalWS = TransformObjectToWorldNormal(input.normalOS);
                output.tangentWS = TransformObjectToWorldDir(input.tangentOS.xyz);
                output.bitangentWS = cross(output.normalWS, output.tangentWS) * input.tangentOS.w;
                output.screenPos = ComputeScreenPos(output.positionCS);
                output.viewDirWS = GetWorldSpaceViewDir(output.positionWS);
                return output;
            }

            half4 frag(Varyings input) : SV_Target
            {
                // Нормализация
                float3 normalWS = normalize(input.normalWS);
                float3 viewDirWS = normalize(input.viewDirWS);

                // Получение нормалей из карты нормалей (если есть)
                float3 normalTS = UnpackNormal(SAMPLE_TEXTURE2D(_NormalMap, sampler_NormalMap, input.uv));
                normalTS.xy *= _NormalStrength;
                normalTS.z = sqrt(1.0 - saturate(dot(normalTS.xy, normalTS.xy)));
                
                float3x3 TBN = float3x3(input.tangentWS, input.bitangentWS, normalWS);
                float3 perturbedNormalWS = normalize(mul(normalTS, TBN));

                // Френель для прозрачности и цвета (края стекла более плотные)
                float fresnel = pow(1.0 - saturate(dot(perturbedNormalWS, viewDirWS)), _FresnelPower);
                fresnel = lerp(_FresnelBias, 1.0, fresnel);

                // Искажение экранных координат (преломление)
                float2 screenUV = input.screenPos.xy / input.screenPos.w;
                float2 normalDistortion = perturbedNormalWS.xy * _RefractionStrength;
                float2 distortedUV = screenUV + normalDistortion;

                // Цвет фона (текстура камеры) — преломлённый
                half3 bgColor = SAMPLE_TEXTURE2D(_CameraOpaqueTexture, sampler_CameraOpaqueTexture, distortedUV).rgb;

                // Отражения
                float3 reflectionDir = reflect(-viewDirWS, perturbedNormalWS);
                half3 reflectionColor = SAMPLE_TEXTURECUBE(_ReflectionCube, sampler_ReflectionCube, reflectionDir).rgb;

                // Френель для отражений (отражения сильнее на скользящих углах)
                float reflectionFresnel = pow(1.0 - saturate(dot(perturbedNormalWS, viewDirWS)), _ReflectionFresnelPower);
                reflectionFresnel = saturate(reflectionFresnel);

                // Смешивание: сначала фон с цветом стекла, затем отражения
                half alphaGlass = _Color.a * fresnel;
                half3 tintedBg = lerp(bgColor, bgColor * _Color.rgb, _Color.a);
                half3 combinedColor = lerp(tintedBg, reflectionColor, _ReflectionIntensity * reflectionFresnel);

                // Блик (простой спекуляр) на основе шероховатости
                half3 lightDir = normalize(_MainLightPosition.xyz);
                half3 halfVec = normalize(lightDir + viewDirWS);
                half specular = pow(saturate(dot(perturbedNormalWS, halfVec)), lerp(64, 256, 1.0 - _Roughness)) * (1.0 - _Roughness);
                combinedColor += specular * 0.5;

                return half4(combinedColor, alphaGlass);
            }
            ENDHLSL
        }
    }
    FallBack "Universal Render Pipeline/Unlit"
}