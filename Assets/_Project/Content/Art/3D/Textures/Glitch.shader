Shader "Custom/Glitch"
{
    Properties
    {
        [MainTexture] _MainTex ("Albedo Texture", 2D) = "white" {}
        [MainColor] _AlbedoColor ("Albedo Color", Color) = (1,1,1,1)
        _EmissionColor ("Emission Color", Color) = (0,0,0,0)
        _EmissionStrength ("Emission Strength", Float) = 1.0
        [Toggle] _AlphaClip ("Alpha Clip", Float) = 0
        _Cutoff ("Alpha Cutoff", Range(0,1)) = 0.5

        // Glitch settings
        _GlitchStrength ("Glitch Strength", Range(0, 0.1)) = 0.02
        _GlitchSpeed ("Glitch Speed", Float) = 1.0
        _GlitchAmount ("Glitch Amount", Range(0, 1)) = 0.5
        _ColorShiftStrength ("Color Shift Strength", Range(0, 0.1)) = 0.02
        _ScanlinesStrength ("Scanlines Strength", Range(0, 1)) = 0.3
        _NoiseStrength ("Noise Strength", Range(0, 0.5)) = 0.1
    }

    SubShader
    {
        Tags
        {
            "RenderType" = "Opaque"
            "Queue" = "Geometry"
            "RenderPipeline" = "UniversalPipeline"
        }
        LOD 100

        Pass
        {
            Name "ForwardUnlit"
            Tags
            {
                "LightMode" = "UniversalForward"
            }

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma shader_feature _ _ALPHACLIP_ON

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct Attributes
            {
                float4 positionOS : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionHCS : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            TEXTURE2D(_MainTex);
            SAMPLER(sampler_MainTex);

            CBUFFER_START(UnityPerMaterial)
                float4 _MainTex_ST;
                float4 _AlbedoColor;
                float4 _EmissionColor;
                float _EmissionStrength;
                float _AlphaClip;
                float _Cutoff;
                float _GlitchStrength;
                float _GlitchSpeed;
                float _GlitchAmount;
                float _ColorShiftStrength;
                float _ScanlinesStrength;
                float _NoiseStrength;
            CBUFFER_END

            // Simple pseudo-random function
            float random(float2 uv)
            {
                return frac(sin(dot(uv, float2(12.9898, 78.233))) * 43758.5453123);
            }

            // Noise function for glitch
            float noise(float2 uv)
            {
                float2 i = floor(uv);
                float2 f = frac(uv);
                float2 u = f * f * (3.0 - 2.0 * f);
                return lerp(lerp(random(i + float2(0,0)), random(i + float2(1,0)), u.x),
                            lerp(random(i + float2(0,1)), random(i + float2(1,1)), u.x), u.y);
            }

            Varyings vert(Attributes input)
            {
                Varyings output;
                output.positionHCS = TransformObjectToHClip(input.positionOS.xyz);
                output.uv = TRANSFORM_TEX(input.uv, _MainTex);
                return output;
            }

            half4 frag(Varyings input) : SV_Target
            {
                float2 uv = input.uv;

                // Time for animation
                float t = _Time.y * _GlitchSpeed;

                // 1. UV distortion (horizontal and vertical glitch lines)
                float2 glitchUV = uv;
                float glitchAmount = _GlitchStrength * _GlitchAmount;

                // Horizontal glitch lines (y‑based)
                float gline = sin(uv.y * 100.0 + t * 10.0) * 0.5 + 0.5;
                gline = pow(gline, 2.0);
                float offsetX = sin(uv.y * 50.0 + t * 20.0) * glitchAmount * gline;
                glitchUV.x += offsetX;

                // Additional periodic big glitch (sudden jumps)
                float bigGlitch = step(0.99, frac(uv.y * 5.0 - t * 2.0));
                glitchUV.x += bigGlitch * _GlitchStrength * 0.1;

                // Vertical glitch (optional)
                float offsetY = cos(uv.x * 30.0 + t * 15.0) * glitchAmount * 0.5;
                glitchUV.y += offsetY;

                // Clamp UV to avoid artifacts
                glitchUV = clamp(glitchUV, 0.0, 1.0);

                // 2. Color channel shifting (separate UV for each channel)
                float2 uvR = glitchUV + float2(_ColorShiftStrength * sin(t * 5.0), 0);
                float2 uvG = glitchUV;
                float2 uvB = glitchUV - float2(_ColorShiftStrength * cos(t * 4.7), 0);

                half4 colR = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, uvR);
                half4 colG = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, uvG);
                half4 colB = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, uvB);

                half4 col = half4(colR.r, colG.g, colB.b, (colR.a + colG.a + colB.a) / 3.0);
                col *= _AlbedoColor;

                // 3. Scanlines effect
                float scanline = sin(uv.y * 800.0) * _ScanlinesStrength;
                col.rgb += scanline;

                // 4. Noise overlay
                float n = noise(uv * 500.0 + t * 10.0) * _NoiseStrength;
                col.rgb += n;

                // Alpha clipping
                #ifdef _ALPHACLIP_ON
                    clip(col.a - _Cutoff);
                #endif

                // Emission: simply added to final color (bloom will pick it up if HDR enabled)
                half3 emission = _EmissionColor.rgb * _EmissionStrength;
                col.rgb += emission;

                return col;
            }
            ENDHLSL
        }
    }
    FallBack "Universal Render Pipeline/Unlit"
}