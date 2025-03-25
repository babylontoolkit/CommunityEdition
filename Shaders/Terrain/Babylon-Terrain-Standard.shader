Shader "Babylon/Terrain/Standard"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _NormalMap ("Normal Map", 2D) = "bump" {}
        _AOTex ("Ambient Occlusion (AO)", 2D) = "white" {}
        _AOIntensity ("AO Intensity", Range(0, 2)) = 1.0
        _Metallic ("Metallic", Range(0,1)) = 0.0
        _Smoothness ("Smoothness", Range(0,1)) = 0.5
    }
    SubShader
    {
        Tags { "Queue"="Geometry" "RenderType"="Opaque" }
        LOD 300

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows

        sampler2D _MainTex;
        sampler2D _NormalMap;
        sampler2D _AOTex;
        float _AOIntensity;
        float _Metallic;
        float _Smoothness;

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_NormalMap;
            float2 uv_AOTex;
        };

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 albedoTex = tex2D(_MainTex, IN.uv_MainTex);
            o.Albedo = albedoTex.rgb;

            o.Normal = UnpackNormal(tex2D(_NormalMap, IN.uv_NormalMap));

            float ao = tex2D(_AOTex, IN.uv_AOTex).r;
            o.Occlusion = lerp(1, ao, _AOIntensity); // AO applied to occlusion

            o.Metallic = _Metallic;
            o.Smoothness = _Smoothness;
        }
        ENDCG
    }
    FallBack "Standard"
}

