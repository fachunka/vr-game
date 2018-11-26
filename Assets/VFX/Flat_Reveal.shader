Shader "Custom/Revealed Texture" {
	Properties{
		_MainTex("Texture", 2D) = "white" {}
		_CutoffX("CutoffX", Range(0.0,1.0)) = 1
		_Alpha("Alpha", Float) = 1
		_Color("Physical World Tint", Color) = (1, 1, 1, 1)
		_SpiritColor("Spirit World Tint", Color) = (1, 1, 1, 1)
	}

	SubShader{
		Tags{ 
			"Queue" = "Transparent" 
			"RenderType" = "Transparent" 
			"FlatReplaceTag" = "Reveal"
		}

		Cull Off
		Blend SrcAlpha OneMinusSrcAlpha
		Lighting Off

		Fog{ Mode Off }

		CGPROGRAM

		#pragma surface surf Unlit alpha

		half4 LightingUnlit(SurfaceOutput s, half3 lightDir, half atten) {
			half4 c;
			c.rgb = s.Albedo;
			c.a = s.Alpha;
			return c;
		}

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
			float4 color : Color;
		};

		fixed _CutoffX;
		fixed4 _Color;
		fixed4 _SpiritColor;
		float _Alpha;

		void surf(Input IN, inout SurfaceOutput o) {

			half4 tex = tex2D(_MainTex, IN.uv_MainTex);

			o.Albedo = IN.color.rgb * tex.rgb * _Color.rgb;
			o.Alpha = _Alpha * (IN.uv_MainTex.x > _CutoffX ? 0 : IN.color.a*tex.a);
		}

		ENDCG
	}
	
}