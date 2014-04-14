// combination of:
// 1) Glass Shader from http://wiki.unity3d.com/index.php/Glass_Shader
// 2) Rim Light from http://docs.unity3d.com/Documentation/Components/SL-SurfaceShaderExamples.html

Shader "SuperRobertShaders/Glass" {
	Properties {
		_SpecColor ("Specular Color", Color) = (0.5, 0.5, 0.5, 1)
		_Shininess ("Shininess", Range (0.01, 1)) = 0.078125
		_RimColor ("Rim Color", Color) = (0.26,0.19,0.16,0.0)
      	_RimPower ("Rim Power", Range(0.5,8.0)) = 3.0
	}
	SubShader {
		Tags {
			"Queue"="Transparent"
			"IgnoreProjector"="True"
			"RenderType"="Transparent"
		}
		LOD 300
		
		CGPROGRAM
			#pragma surface surf BlinnPhong decal:add nolightmap
			
			half _Shininess;
			float4 _RimColor;
      		float _RimPower;
			
			struct Input {
				float dummy;
				float3 viewDir;
			};
			
			void surf (Input IN, inout SurfaceOutput o) {
				o.Albedo = 0;
				o.Gloss = 1;
				o.Specular = _Shininess;
				o.Alpha = 0;
				half rim = 1.0 - saturate(dot (normalize(IN.viewDir), o.Normal));
          		o.Emission = _RimColor.rgb * pow (rim, _RimPower);
			}
		ENDCG
	}
	FallBack "Transparent/VertexLit"
}
