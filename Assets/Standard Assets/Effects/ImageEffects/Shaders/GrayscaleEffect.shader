Shader "Hidden/Grayscale Effect" {
Properties {
	_MainTex ("Base (RGB)", 2D) = "white" {}
	_RampTex ("Base (RGB)", 2D) = "grayscaleRamp" {}
}

SubShader {
	Pass {
		ZTest Always Cull Off ZWrite Off
        Fog { Mode off }		

		CGPROGRAM
			#pragma vertex vert_img
			#pragma fragment frag
	        #pragma fragmentoption ARB_precision_hint_fastest
			#include "UnityCG.cginc"

			uniform sampler2D _MainTex;
			uniform sampler2D _RampTex;
			uniform half _RampOffset;
			uniform float _Strength;
			half4 _MainTex_ST;

			float4 frag (v2f_img i) : COLOR {
			    float4 c = tex2D(_MainTex, i.uv);
			    float4 g = (c.r+c.g+c.b)/3.0;
			    c.rgb = lerp(c, g, _Strength);
			    return c;
			}

			/*
			fixed4 frag (v2f_img i) : SV_Target
			{
				fixed4 original = tex2D(_MainTex, UnityStereoScreenSpaceUVAdjust(i.uv, _MainTex_ST));
				fixed grayscale = Luminance(original.rgb);
				half2 remap = half2 (grayscale + _RampOffset, .5);
				fixed4 output = tex2D(_RampTex, remap);
				output.a = original.a;
				return output;
			}*/
	
		ENDCG

	}
}

Fallback off

}
