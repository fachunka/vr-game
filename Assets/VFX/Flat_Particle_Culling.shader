// Simplified Alpha Blended Particle shader. Differences from regular Alpha Blended Particle one:
// - no Tint color
// - no Smooth particle support
// - no AlphaTest
// - no ColorMask

Shader "Custom/Particle Alpha Blended with Culling" {
	Properties{
		_MainTex("Particle Texture", 2D) = "white" {}
	}

	SubShader{
		Tags{
			"Queue" = "Transparent"
			"IgnoreProjector" = "True"
			"RenderType" = "Transparent"
			"PreviewType" = "Plane"
			"FlatReplaceTag" = "Particle"
		}
		Blend SrcAlpha OneMinusSrcAlpha
		Lighting Off ZWrite Off Fog{ Color(0,0,0,0) }

		BindChannels{
			Bind "Color", color
			Bind "Vertex", vertex
			Bind "TexCoord", texcoord
		}

		Pass{
			SetTexture[_MainTex]{
				combine texture * primary
			}
		}
	}
}
