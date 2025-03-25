Shader "Babylon/Terrain/Diffuse"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _NormalMap ("Normal Map", 2D) = "bump" {}
        _AOTex ("Ambient Occlusion (AO)", 2D) = "white" {}
        _AOIntensity ("AO Intensity", Range(0, 2)) = 1.0
    }
    SubShader
    {
        Tags { "Queue"="Geometry" "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Lambert

        sampler2D _MainTex;
        sampler2D _NormalMap;
        sampler2D _AOTex;
        float _AOIntensity;

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_NormalMap;
            float2 uv_AOTex;
        };

        void surf (Input IN, inout SurfaceOutput o)
        {
            fixed4 albedoTex = tex2D(_MainTex, IN.uv_MainTex);
            o.Albedo = albedoTex.rgb;

            o.Normal = UnpackNormal(tex2D(_NormalMap, IN.uv_NormalMap));

            float ao = tex2D(_AOTex, IN.uv_AOTex).r;
            o.Albedo *= lerp(1, ao, _AOIntensity); // AO darkens the texture
        }
        ENDCG
    }
    FallBack "Diffuse"
}

