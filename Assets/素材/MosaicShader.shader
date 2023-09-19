Shader "Custom/MosaicShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _MosaicSize ("Mosaic Size", Range(1, 100)) = 10
    }
 
    SubShader
    {
        Tags { "Queue" = "Transparent" }
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
 
            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };
 
            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };
 
            sampler2D _MainTex;
            float _MosaicSize;
 
            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }
 
            half4 frag (v2f i) : SV_Target
            {
                float2 mosaicUV = i.uv * _MosaicSize;
                mosaicUV = floor(mosaicUV);
                mosaicUV /= _MosaicSize;
                return tex2D(_MainTex, mosaicUV);
            }
            ENDCG
        }
    }
}