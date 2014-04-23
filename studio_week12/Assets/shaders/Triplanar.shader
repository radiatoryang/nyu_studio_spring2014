Shader "RobertRocks/Triplanar" {
	Properties {
		_MainTex ("BaseY (RGB)", 2D) = "white" {} // top (Y)
		_MainTexSideX ("BaseX (RGB)", 2D) = "white" {} // side X, side
		_MainTexSideZ ("BaseZ (RGB)", 2D) = "white" {} // side Z, front
		_Scale ("Scale", Float) = 0.1
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert

		sampler2D _MainTex;
		sampler2D _MainTexSideX;
		sampler2D _MainTexSideZ;
		float _Scale;

		struct Input {
			float2 uv_MainTex;
			float3 worldNormal; // direction a piece of our mesh is pointing
			float3 worldPos; // position a piece of our mesh is
		};

		void surf (Input IN, inout SurfaceOutput o) {
			//half4 c = tex2D (_MainTex, IN.uv_MainTex);
			fixed4 c;
			
			// is this piece of the mesh pointing mainly X?
			if ( abs( IN.worldNormal.x ) > 0.5f ) {
				c = tex2D( _MainTexSideX, IN.worldPos.yz * _Scale); // project on X plane
			} else if ( abs( IN.worldNormal.z ) > 0.5f ) {
				c = tex2D( _MainTexSideZ, IN.worldPos.xy * _Scale); // project on Z plane
			} else { // is it pointing up or down?
				c = tex2D( _MainTex, IN.worldPos.xz * _Scale); // project on Y plane
			}
			
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
