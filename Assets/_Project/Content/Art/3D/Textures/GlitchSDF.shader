Shader "Custom/GlitchSDF"
{
    Properties
    {
        _MainTex ("Font Atlas", 2D) = "white" {}
        _Color ("Text Color", Color) = (1,1,1,1)
        _EmissionColor ("Emission Color", Color) = (0,0,0,0)
        _EmissionStrength ("Emission Strength", Float) = 1.0
        [Toggle] _AlphaClip ("Alpha Clip", Float) = 0
        _Cutoff ("Alpha Cutoff", Range(0,1)) = 0.5
        
        [Header(Glitch)]
        _GlitchStrength ("Glitch Strength", Range(0, 0.1)) = 0.02
        _GlitchSpeed ("Glitch Speed", Float) = 1.0
        _GlitchAmount ("Glitch Amount", Range(0, 1)) = 0.5
        _ColorShiftStrength ("Color Shift Strength", Range(0, 0.1)) = 0.02
        _ScanlinesStrength ("Scanlines Strength", Range(0, 1)) = 0.3
        _NoiseStrength ("Noise Strength", Range(0, 0.5)) = 0.1
    }
    
    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }
        Blend SrcAlpha OneMinusSrcAlpha
        Cull Off
        ZWrite Off
        
        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma shader_feature_local _ _ALPHACLIP_ON
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            
            struct Attributes
            {
                float4 positionOS : POSITION;
                float2 uv : TEXCOORD0;
                float4 color : COLOR;
            };
            
            struct Varyings
            {
                float4 positionHCS : SV_POSITION;
                float2 uv : TEXCOORD0;
                float4 color : COLOR;
            };
            
            TEXTURE2D(_MainTex);
            SAMPLER(sampler_MainTex);
            
            CBUFFER_START(UnityPerMaterial)
                float4 _Color;
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
            
            float random(float2 uv)
            {
                return frac(sin(dot(uv, float2(12.9898, 78.233))) * 43758.5453123);
            }
            
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
                output.uv = input.uv;
                output.color = input.color;
                return output;
            }
            
            half4 frag(Varyings input) : SV_Target
            {
                float2 uv = input.uv;
                float t = _Time.y * _GlitchSpeed;
                
                // Glitch UV distortion
                float2 glitchUV = uv;
                float gline = sin(uv.y * 100.0 + t * 10.0) * 0.5 + 0.5;
                gline = pow(gline, 2.0);
                float offsetX = sin(uv.y * 50.0 + t * 20.0) * _GlitchStrength * gline;
                glitchUV.x += offsetX;
                float bigGlitch = step(0.99, frac(uv.y * 5.0 - t * 2.0));
                glitchUV.x += bigGlitch * _GlitchStrength * 0.1;
                glitchUV = clamp(glitchUV, 0.0, 1.0);
                
                half4 col = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, glitchUV);
                col *= input.color * _Color;
                
                // Color shift
                float shiftR = _ColorShiftStrength * sin(t * 5.0);
                float shiftB = _ColorShiftStrength * cos(t * 4.7);
                half3 shiftedColor = col.rgb;
                shiftedColor.r += (shiftR * 0.5 + 0.5) * 0.1;
                shiftedColor.b -= (shiftB * 0.5 + 0.5) * 0.1;
                col.rgb = lerp(col.rgb, shiftedColor, _GlitchAmount);
                
                // Scanlines
                float scanline = sin(uv.y * 800.0) * _ScanlinesStrength;
                col.rgb += scanline;
                
                // Noise
                float n = noise(uv * 500.0 + t * 10.0) * _NoiseStrength;
                col.rgb += n;
                
                // Emission
                col.rgb += _EmissionColor.rgb * _EmissionStrength;
                
                #ifdef _ALPHACLIP_ON
                    clip(col.a - _Cutoff);
                #endif
                
                return col;
            }
            ENDHLSL
        }
    }
    FallBack "Universal Render Pipeline/Unlit"
}