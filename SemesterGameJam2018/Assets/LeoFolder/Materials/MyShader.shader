
Shader "Custom/SonarWaveReceiver"
{
	Properties
	{
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
	_Glossiness("Smoothness", Range(0,1)) = 0.5
		_Metallic("Metallic", Range(0,1)) = 0.0
		//_Waves("Metallic", Range(0,1000)) = 100
		_WaveY("WaveY", Range(-10, 10)) = 0
		_WaveHeight("WaveHeight", Range(0,1)) = 0.1
		_Debug("Debug", Range(0,1)) = 1
		_WavePos("WavePos", Vector) = (0, 0, 0)

	}
		SubShader
	{
		Tags{ "Queue" = "Transparent" "RenderType" = "Transparent" }
		LOD 200       
		Cull Back
		CGPROGRAM   

//#pragma surface surf Standard alpha:fade vertex:vert
#pragma surface surf Standard fullforwardshadows alpha:fade vertex:vert
#pragma target 3.0

		sampler2D _MainTex;

	struct Input {
		float2 uv_MainTex;
		float4 globalPos;
	};

	half _Glossiness;
	half _Metallic;
	fixed4 _Color;
	half _WaveHeight;
	//half _Waves;
	half _WaveY;
	float3 _WavePos;
	half _Debug;

	void vert(inout appdata_full v, out Input o) {
		UNITY_INITIALIZE_OUTPUT(Input, o);
		//o.globalPos = UnityObjectToClipPos(v.vertex);
		o.globalPos = mul(unity_ObjectToWorld, v.vertex);
	}

	void surf(Input IN, inout SurfaceOutputStandard o)
	{
		fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
		o.Albedo = _Color * 2;
		o.Metallic = _Metallic;
		o.Smoothness = _Glossiness;
		float mask = _LightColor0.a;
		float height = IN.globalPos.y;
		height = height - _WaveY;
		height = abs(height) / _WaveHeight;
		height = 1 - clamp(height, 0.0, 1.0);
		//o.Alpha = clamp(mask + height, 0.0, 1.0);

		o.Alpha = mask + _Debug;
	}

	ENDCG
	}
		FallBack "Standard"
}