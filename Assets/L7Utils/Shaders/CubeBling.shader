// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unlit/SimpleBling"
{
	Properties
	{
		_MainColor ("MainColor", Color) = (1,0,0,1)
		_BlingColor ("BlingColor", Color) = (1,1,1,1)
		_CenterAlpha ("CenterAlpha ", Range(0,1)) = 0.1
		_EdgeAlpha ("EdgeAlpha ", Range(0,1)) = 0.5
		_Speed ("Speed",Range(0,50)) = 10
	}
	SubShader
	{
		Tags {
			"RenderType"="Transparent" 
            "IgnoreProjector" = "True"
            "RenderType" = "Transparent"
		}

		Pass
		{
			Blend SrcAlpha OneMinusSrcAlpha
			Cull Back 
			ZWrite Off 

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv 	  : TEXCOORD0; 
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				float2 uv 	  : TEXCOORD0; 
			};

			uniform fixed4 _MainColor;
			uniform fixed4 _BlingColor;
			uniform fixed _CenterAlpha;
			uniform fixed _EdgeAlpha;
			uniform fixed _Speed;

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv - 0.5;
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				fixed dis = abs(i.uv.x) * abs(i.uv.x) + abs(i.uv.y) * abs(i.uv.y);
				fixed time = saturate (sin(_Time.y * _Speed));
				fixed4 col = lerp(_BlingColor,_MainColor,time);
				// fixed4 col = _MainColor;
				col.a = lerp(_CenterAlpha,_EdgeAlpha,dis*2);
				return col;
			}
			ENDCG
		}

	}
}
