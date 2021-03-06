half4       _Color;

sampler2D   _MainTex;

sampler2D   _BumpMap;
half        _BumpScale;

sampler2D _DFMask;
UNITY_DECLARE_TEX2DARRAY(_MatTex);

sampler2D   _SpecGlossMap;
sampler2D   _MetallicGlossMap;
half        _Metallic;
half        _Glossiness;
half        _GlossMapScale;

sampler2D   _OcclusionMap;
half        _OcclusionStrength;

half4       _EmissionColor;
sampler2D   _EmissionMap;

UNITY_INSTANCING_CBUFFER_START(MyProperties)
UNITY_DEFINE_INSTANCED_PROP(fixed4, _MatColor)
UNITY_DEFINE_INSTANCED_PROP(int, _MatIndex)
UNITY_INSTANCING_CBUFFER_END