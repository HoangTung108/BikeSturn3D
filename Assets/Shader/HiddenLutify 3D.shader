Shader "Hidden/Lutify 3D" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
	}
	SubShader {
		Pass {
			ZTest Always
			ZWrite Off
			Cull Off
			Fog {
				Mode Off
			}
			GpuProgramID 57658
			Program "vp" {
				SubProgram "gles hw_tier00 " {
					"!!GLES
					#version 100
					
					#ifdef VERTEX
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 30
					#endif
					#ifndef SHADER_REQUIRE_INTERPOLATORS10
					    #define SHADER_REQUIRE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_REQUIRE_SAMPLELOD
					    #define SHADER_REQUIRE_SAMPLELOD 1
					#endif
					#ifndef SHADER_REQUIRE_FRAGCOORD
					    #define SHADER_REQUIRE_FRAGCOORD 1
					#endif
					#ifndef UNITY_NO_DXT5nm
					    #define UNITY_NO_DXT5nm 1
					#endif
					#ifndef UNITY_NO_RGBM
					    #define UNITY_NO_RGBM 1
					#endif
					#ifndef UNITY_ENABLE_REFLECTION_BUFFERS
					    #define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#endif
					#ifndef UNITY_FRAMEBUFFER_FETCH_AVAILABLE
					    #define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#endif
					#ifndef UNITY_NO_CUBEMAP_ARRAY
					    #define UNITY_NO_CUBEMAP_ARRAY 1
					#endif
					#ifndef UNITY_NO_SCREENSPACE_SHADOWS
					    #define UNITY_NO_SCREENSPACE_SHADOWS 1
					#endif
					#ifndef UNITY_PBS_USE_BRDF3
					    #define UNITY_PBS_USE_BRDF3 1
					#endif
					#ifndef UNITY_NO_FULL_STANDARD_SHADER
					    #define UNITY_NO_FULL_STANDARD_SHADER 1
					#endif
					#ifndef SHADER_API_MOBILE
					    #define SHADER_API_MOBILE 1
					#endif
					#ifndef UNITY_HARDWARE_TIER1
					    #define UNITY_HARDWARE_TIER1 1
					#endif
					#ifndef UNITY_COLORSPACE_GAMMA
					    #define UNITY_COLORSPACE_GAMMA 1
					#endif
					#ifndef UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS
					    #define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#endif
					#ifndef UNITY_LIGHTMAP_DLDR_ENCODING
					    #define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#endif
					#ifndef UNITY_VERSION
					    #define UNITY_VERSION 201834
					#endif
					#ifndef SHADER_STAGE_VERTEX
					    #define SHADER_STAGE_VERTEX 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 30
					#endif
					#ifndef SHADER_AVAILABLE_INTERPOLATORS10
					    #define SHADER_AVAILABLE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_SAMPLELOD
					    #define SHADER_AVAILABLE_SAMPLELOD 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#define gl_Vertex _glesVertex
					attribute vec4 _glesVertex;
					#define gl_MultiTexCoord0 _glesMultiTexCoord0
					attribute vec4 _glesMultiTexCoord0;
					mat2 xll_transpose_mf2x2(mat2 m) {
					  return mat2( m[0][0], m[1][0], m[0][1], m[1][1]);
					}
					mat3 xll_transpose_mf3x3(mat3 m) {
					  return mat3( m[0][0], m[1][0], m[2][0],
					               m[0][1], m[1][1], m[2][1],
					               m[0][2], m[1][2], m[2][2]);
					}
					mat4 xll_transpose_mf4x4(mat4 m) {
					  return mat4( m[0][0], m[1][0], m[2][0], m[3][0],
					               m[0][1], m[1][1], m[2][1], m[3][1],
					               m[0][2], m[1][2], m[2][2], m[3][2],
					               m[0][3], m[1][3], m[2][3], m[3][3]);
					}
					#line 447
					struct v2f_vertex_lit {
					    highp vec2 uv;
					    lowp vec4 diff;
					    lowp vec4 spec;
					};
					#line 756
					struct v2f_img {
					    highp vec4 pos;
					    mediump vec2 uv;
					};
					#line 749
					struct appdata_img {
					    highp vec4 vertex;
					    mediump vec2 texcoord;
					};
					#line 40
					uniform highp vec4 _Time;
					uniform highp vec4 _SinTime;
					uniform highp vec4 _CosTime;
					uniform highp vec4 unity_DeltaTime;
					#line 46
					uniform highp vec3 _WorldSpaceCameraPos;
					#line 53
					uniform highp vec4 _ProjectionParams;
					#line 59
					uniform highp vec4 _ScreenParams;
					#line 71
					uniform highp vec4 _ZBufferParams;
					#line 77
					uniform highp vec4 unity_OrthoParams;
					#line 86
					uniform highp vec4 unity_CameraWorldClipPlanes[6];
					#line 92
					uniform highp mat4 unity_CameraProjection;
					uniform highp mat4 unity_CameraInvProjection;
					uniform highp mat4 unity_WorldToCamera;
					uniform highp mat4 unity_CameraToWorld;
					#line 108
					uniform highp vec4 _WorldSpaceLightPos0;
					uniform highp vec4 _LightPositionRange;
					#line 112
					uniform highp vec4 _LightProjectionParams;
					uniform highp vec4 unity_4LightPosX0;
					uniform highp vec4 unity_4LightPosY0;
					#line 116
					uniform highp vec4 unity_4LightPosZ0;
					uniform mediump vec4 unity_4LightAtten0;
					uniform mediump vec4 unity_LightColor[8];
					#line 122
					uniform highp vec4 unity_LightPosition[8];
					#line 127
					uniform mediump vec4 unity_LightAtten[8];
					uniform highp vec4 unity_SpotDirection[8];
					#line 131
					uniform mediump vec4 unity_SHAr;
					uniform mediump vec4 unity_SHAg;
					uniform mediump vec4 unity_SHAb;
					uniform mediump vec4 unity_SHBr;
					#line 135
					uniform mediump vec4 unity_SHBg;
					uniform mediump vec4 unity_SHBb;
					uniform mediump vec4 unity_SHC;
					#line 140
					uniform lowp vec4 unity_OcclusionMaskSelector;
					uniform lowp vec4 unity_ProbesOcclusion;
					#line 145
					uniform mediump vec3 unity_LightColor0;
					uniform mediump vec3 unity_LightColor1;
					uniform mediump vec3 unity_LightColor2;
					uniform mediump vec3 unity_LightColor3;
					#line 152
					uniform highp vec4 unity_ShadowSplitSpheres[4];
					uniform highp vec4 unity_ShadowSplitSqRadii;
					uniform highp vec4 unity_LightShadowBias;
					uniform highp vec4 _LightSplitsNear;
					#line 156
					uniform highp vec4 _LightSplitsFar;
					uniform highp mat4 unity_WorldToShadow[4];
					uniform mediump vec4 _LightShadowData;
					uniform highp vec4 unity_ShadowFadeCenterAndType;
					#line 165
					uniform highp mat4 unity_ObjectToWorld;
					uniform highp mat4 unity_WorldToObject;
					uniform highp vec4 unity_LODFade;
					uniform highp vec4 unity_WorldTransformParams;
					#line 206
					uniform highp mat4 glstate_matrix_transpose_modelview0;
					#line 214
					uniform lowp vec4 glstate_lightmodel_ambient;
					uniform lowp vec4 unity_AmbientSky;
					uniform lowp vec4 unity_AmbientEquator;
					uniform lowp vec4 unity_AmbientGround;
					#line 218
					uniform lowp vec4 unity_IndirectSpecColor;
					uniform highp mat4 glstate_matrix_projection;
					#line 222
					uniform highp mat4 unity_MatrixV;
					uniform highp mat4 unity_MatrixInvV;
					uniform highp mat4 unity_MatrixVP;
					uniform highp int unity_StereoEyeIndex;
					#line 228
					uniform lowp vec4 unity_ShadowColor;
					#line 235
					uniform lowp vec4 unity_FogColor;
					#line 240
					uniform highp vec4 unity_FogParams;
					#line 248
					uniform mediump sampler2D unity_Lightmap;
					uniform mediump sampler2D unity_LightmapInd;
					#line 252
					uniform sampler2D unity_ShadowMask;
					uniform sampler2D unity_DynamicLightmap;
					#line 256
					uniform sampler2D unity_DynamicDirectionality;
					uniform sampler2D unity_DynamicNormal;
					#line 260
					uniform highp vec4 unity_LightmapST;
					uniform highp vec4 unity_DynamicLightmapST;
					#line 268
					uniform samplerCube unity_SpecCube0;
					uniform samplerCube unity_SpecCube1;
					#line 272
					uniform highp vec4 unity_SpecCube0_BoxMax;
					uniform highp vec4 unity_SpecCube0_BoxMin;
					uniform highp vec4 unity_SpecCube0_ProbePosition;
					uniform mediump vec4 unity_SpecCube0_HDR;
					#line 277
					uniform highp vec4 unity_SpecCube1_BoxMax;
					uniform highp vec4 unity_SpecCube1_BoxMin;
					uniform highp vec4 unity_SpecCube1_ProbePosition;
					uniform mediump vec4 unity_SpecCube1_HDR;
					#line 317
					highp mat4 unity_MatrixMVP;
					highp mat4 unity_MatrixMV;
					highp mat4 unity_MatrixTMV;
					highp mat4 unity_MatrixITMV;
					#line 8
					#line 30
					#line 44
					#line 84
					#line 93
					#line 103
					#line 112
					#line 124
					#line 135
					#line 141
					#line 147
					#line 151
					#line 157
					#line 163
					#line 169
					#line 175
					#line 186
					#line 201
					#line 208
					#line 223
					#line 230
					#line 237
					#line 255
					#line 291
					#line 320
					#line 326
					#line 339
					#line 357
					#line 373
					#line 427
					#line 453
					#line 464
					#line 473
					#line 480
					#line 485
					#line 502
					#line 522
					#line 537
					#line 543
					#line 554
					uniform mediump vec4 unity_Lightmap_HDR;
					uniform mediump vec4 unity_DynamicLightmap_HDR;
					#line 568
					#line 578
					#line 593
					#line 602
					#line 609
					#line 618
					#line 626
					#line 635
					#line 654
					#line 660
					#line 670
					#line 680
					#line 691
					#line 696
					#line 702
					#line 707
					#line 764
					#line 770
					#line 785
					#line 816
					#line 830
					#line 834
					#line 840
					#line 849
					#line 859
					#line 885
					#line 891
					#line 7
					uniform sampler2D _MainTex;
					uniform lowp sampler3D _LookupTex3D;
					uniform sampler2D _LookupTex2D;
					uniform highp vec4 _Params;
					#line 17
					#line 23
					#line 29
					#line 35
					#line 41
					#line 47
					#line 67
					#line 91
					#line 97
					#line 44
					highp vec4 UnityObjectToClipPos( in highp vec3 pos ) {
					    #line 50
					    return (unity_MatrixVP * (unity_ObjectToWorld * vec4( pos, 1.0)));
					}
					#line 53
					highp vec4 UnityObjectToClipPos( in highp vec4 pos ) {
					    #line 55
					    return UnityObjectToClipPos( pos.xyz);
					}
					#line 770
					v2f_img vert_img( in appdata_img v ) {
					    v2f_img o;
					    #line 777
					    o.pos = UnityObjectToClipPos( v.vertex);
					    o.uv = v.texcoord;
					    return o;
					}
					varying mediump vec2 xlv_TEXCOORD0;
					void main() {
					unity_MatrixMVP = (unity_MatrixVP * unity_ObjectToWorld);
					unity_MatrixMV = (unity_MatrixV * unity_ObjectToWorld);
					unity_MatrixTMV = xll_transpose_mf4x4(unity_MatrixMV);
					unity_MatrixITMV = xll_transpose_mf4x4((unity_WorldToObject * unity_MatrixInvV));
					    v2f_img xl_retval;
					    appdata_img xlt_v;
					    xlt_v.vertex = vec4(gl_Vertex);
					    xlt_v.texcoord = vec2(gl_MultiTexCoord0);
					    xl_retval = vert_img( xlt_v);
					    gl_Position = vec4(xl_retval.pos);
					    xlv_TEXCOORD0 = vec2(xl_retval.uv);
					}
					/* HLSL2GLSL - NOTE: GLSL optimization failed
					(9,1): error: invalid type `sampler3D' in declaration of `_LookupTex3D'
					*/
					
					#endif
					#ifdef FRAGMENT
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 30
					#endif
					#ifndef SHADER_REQUIRE_INTERPOLATORS10
					    #define SHADER_REQUIRE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_REQUIRE_SAMPLELOD
					    #define SHADER_REQUIRE_SAMPLELOD 1
					#endif
					#ifndef SHADER_REQUIRE_FRAGCOORD
					    #define SHADER_REQUIRE_FRAGCOORD 1
					#endif
					#ifndef UNITY_NO_DXT5nm
					    #define UNITY_NO_DXT5nm 1
					#endif
					#ifndef UNITY_NO_RGBM
					    #define UNITY_NO_RGBM 1
					#endif
					#ifndef UNITY_ENABLE_REFLECTION_BUFFERS
					    #define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#endif
					#ifndef UNITY_FRAMEBUFFER_FETCH_AVAILABLE
					    #define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#endif
					#ifndef UNITY_NO_CUBEMAP_ARRAY
					    #define UNITY_NO_CUBEMAP_ARRAY 1
					#endif
					#ifndef UNITY_NO_SCREENSPACE_SHADOWS
					    #define UNITY_NO_SCREENSPACE_SHADOWS 1
					#endif
					#ifndef UNITY_PBS_USE_BRDF3
					    #define UNITY_PBS_USE_BRDF3 1
					#endif
					#ifndef UNITY_NO_FULL_STANDARD_SHADER
					    #define UNITY_NO_FULL_STANDARD_SHADER 1
					#endif
					#ifndef SHADER_API_MOBILE
					    #define SHADER_API_MOBILE 1
					#endif
					#ifndef UNITY_HARDWARE_TIER1
					    #define UNITY_HARDWARE_TIER1 1
					#endif
					#ifndef UNITY_COLORSPACE_GAMMA
					    #define UNITY_COLORSPACE_GAMMA 1
					#endif
					#ifndef UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS
					    #define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#endif
					#ifndef UNITY_LIGHTMAP_DLDR_ENCODING
					    #define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#endif
					#ifndef UNITY_VERSION
					    #define UNITY_VERSION 201834
					#endif
					#ifndef SHADER_STAGE_VERTEX
					    #define SHADER_STAGE_VERTEX 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 30
					#endif
					#ifndef SHADER_AVAILABLE_INTERPOLATORS10
					    #define SHADER_AVAILABLE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_SAMPLELOD
					    #define SHADER_AVAILABLE_SAMPLELOD 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					mat2 xll_transpose_mf2x2(mat2 m) {
					  return mat2( m[0][0], m[1][0], m[0][1], m[1][1]);
					}
					mat3 xll_transpose_mf3x3(mat3 m) {
					  return mat3( m[0][0], m[1][0], m[2][0],
					               m[0][1], m[1][1], m[2][1],
					               m[0][2], m[1][2], m[2][2]);
					}
					mat4 xll_transpose_mf4x4(mat4 m) {
					  return mat4( m[0][0], m[1][0], m[2][0], m[3][0],
					               m[0][1], m[1][1], m[2][1], m[3][1],
					               m[0][2], m[1][2], m[2][2], m[3][2],
					               m[0][3], m[1][3], m[2][3], m[3][3]);
					}
					float xll_saturate_f( float x) {
					  return clamp( x, 0.0, 1.0);
					}
					vec2 xll_saturate_vf2( vec2 x) {
					  return clamp( x, 0.0, 1.0);
					}
					vec3 xll_saturate_vf3( vec3 x) {
					  return clamp( x, 0.0, 1.0);
					}
					vec4 xll_saturate_vf4( vec4 x) {
					  return clamp( x, 0.0, 1.0);
					}
					mat2 xll_saturate_mf2x2(mat2 m) {
					  return mat2( clamp(m[0], 0.0, 1.0), clamp(m[1], 0.0, 1.0));
					}
					mat3 xll_saturate_mf3x3(mat3 m) {
					  return mat3( clamp(m[0], 0.0, 1.0), clamp(m[1], 0.0, 1.0), clamp(m[2], 0.0, 1.0));
					}
					mat4 xll_saturate_mf4x4(mat4 m) {
					  return mat4( clamp(m[0], 0.0, 1.0), clamp(m[1], 0.0, 1.0), clamp(m[2], 0.0, 1.0), clamp(m[3], 0.0, 1.0));
					}
					#line 447
					struct v2f_vertex_lit {
					    highp vec2 uv;
					    lowp vec4 diff;
					    lowp vec4 spec;
					};
					#line 756
					struct v2f_img {
					    highp vec4 pos;
					    mediump vec2 uv;
					};
					#line 749
					struct appdata_img {
					    highp vec4 vertex;
					    mediump vec2 texcoord;
					};
					#line 40
					uniform highp vec4 _Time;
					uniform highp vec4 _SinTime;
					uniform highp vec4 _CosTime;
					uniform highp vec4 unity_DeltaTime;
					#line 46
					uniform highp vec3 _WorldSpaceCameraPos;
					#line 53
					uniform highp vec4 _ProjectionParams;
					#line 59
					uniform highp vec4 _ScreenParams;
					#line 71
					uniform highp vec4 _ZBufferParams;
					#line 77
					uniform highp vec4 unity_OrthoParams;
					#line 86
					uniform highp vec4 unity_CameraWorldClipPlanes[6];
					#line 92
					uniform highp mat4 unity_CameraProjection;
					uniform highp mat4 unity_CameraInvProjection;
					uniform highp mat4 unity_WorldToCamera;
					uniform highp mat4 unity_CameraToWorld;
					#line 108
					uniform highp vec4 _WorldSpaceLightPos0;
					uniform highp vec4 _LightPositionRange;
					#line 112
					uniform highp vec4 _LightProjectionParams;
					uniform highp vec4 unity_4LightPosX0;
					uniform highp vec4 unity_4LightPosY0;
					#line 116
					uniform highp vec4 unity_4LightPosZ0;
					uniform mediump vec4 unity_4LightAtten0;
					uniform mediump vec4 unity_LightColor[8];
					#line 122
					uniform highp vec4 unity_LightPosition[8];
					#line 127
					uniform mediump vec4 unity_LightAtten[8];
					uniform highp vec4 unity_SpotDirection[8];
					#line 131
					uniform mediump vec4 unity_SHAr;
					uniform mediump vec4 unity_SHAg;
					uniform mediump vec4 unity_SHAb;
					uniform mediump vec4 unity_SHBr;
					#line 135
					uniform mediump vec4 unity_SHBg;
					uniform mediump vec4 unity_SHBb;
					uniform mediump vec4 unity_SHC;
					#line 140
					uniform lowp vec4 unity_OcclusionMaskSelector;
					uniform lowp vec4 unity_ProbesOcclusion;
					#line 145
					uniform mediump vec3 unity_LightColor0;
					uniform mediump vec3 unity_LightColor1;
					uniform mediump vec3 unity_LightColor2;
					uniform mediump vec3 unity_LightColor3;
					#line 152
					uniform highp vec4 unity_ShadowSplitSpheres[4];
					uniform highp vec4 unity_ShadowSplitSqRadii;
					uniform highp vec4 unity_LightShadowBias;
					uniform highp vec4 _LightSplitsNear;
					#line 156
					uniform highp vec4 _LightSplitsFar;
					uniform highp mat4 unity_WorldToShadow[4];
					uniform mediump vec4 _LightShadowData;
					uniform highp vec4 unity_ShadowFadeCenterAndType;
					#line 165
					uniform highp mat4 unity_ObjectToWorld;
					uniform highp mat4 unity_WorldToObject;
					uniform highp vec4 unity_LODFade;
					uniform highp vec4 unity_WorldTransformParams;
					#line 206
					uniform highp mat4 glstate_matrix_transpose_modelview0;
					#line 214
					uniform lowp vec4 glstate_lightmodel_ambient;
					uniform lowp vec4 unity_AmbientSky;
					uniform lowp vec4 unity_AmbientEquator;
					uniform lowp vec4 unity_AmbientGround;
					#line 218
					uniform lowp vec4 unity_IndirectSpecColor;
					uniform highp mat4 glstate_matrix_projection;
					#line 222
					uniform highp mat4 unity_MatrixV;
					uniform highp mat4 unity_MatrixInvV;
					uniform highp mat4 unity_MatrixVP;
					uniform highp int unity_StereoEyeIndex;
					#line 228
					uniform lowp vec4 unity_ShadowColor;
					#line 235
					uniform lowp vec4 unity_FogColor;
					#line 240
					uniform highp vec4 unity_FogParams;
					#line 248
					uniform mediump sampler2D unity_Lightmap;
					uniform mediump sampler2D unity_LightmapInd;
					#line 252
					uniform sampler2D unity_ShadowMask;
					uniform sampler2D unity_DynamicLightmap;
					#line 256
					uniform sampler2D unity_DynamicDirectionality;
					uniform sampler2D unity_DynamicNormal;
					#line 260
					uniform highp vec4 unity_LightmapST;
					uniform highp vec4 unity_DynamicLightmapST;
					#line 268
					uniform samplerCube unity_SpecCube0;
					uniform samplerCube unity_SpecCube1;
					#line 272
					uniform highp vec4 unity_SpecCube0_BoxMax;
					uniform highp vec4 unity_SpecCube0_BoxMin;
					uniform highp vec4 unity_SpecCube0_ProbePosition;
					uniform mediump vec4 unity_SpecCube0_HDR;
					#line 277
					uniform highp vec4 unity_SpecCube1_BoxMax;
					uniform highp vec4 unity_SpecCube1_BoxMin;
					uniform highp vec4 unity_SpecCube1_ProbePosition;
					uniform mediump vec4 unity_SpecCube1_HDR;
					#line 317
					highp mat4 unity_MatrixMVP;
					highp mat4 unity_MatrixMV;
					highp mat4 unity_MatrixTMV;
					highp mat4 unity_MatrixITMV;
					#line 8
					#line 30
					#line 44
					#line 84
					#line 93
					#line 103
					#line 112
					#line 124
					#line 135
					#line 141
					#line 147
					#line 151
					#line 157
					#line 163
					#line 169
					#line 175
					#line 186
					#line 201
					#line 208
					#line 223
					#line 230
					#line 237
					#line 255
					#line 291
					#line 320
					#line 326
					#line 339
					#line 357
					#line 373
					#line 427
					#line 453
					#line 464
					#line 473
					#line 480
					#line 485
					#line 502
					#line 522
					#line 537
					#line 543
					#line 554
					uniform mediump vec4 unity_Lightmap_HDR;
					uniform mediump vec4 unity_DynamicLightmap_HDR;
					#line 568
					#line 578
					#line 593
					#line 602
					#line 609
					#line 618
					#line 626
					#line 635
					#line 654
					#line 660
					#line 670
					#line 680
					#line 691
					#line 696
					#line 702
					#line 707
					#line 764
					#line 770
					#line 785
					#line 816
					#line 830
					#line 834
					#line 840
					#line 849
					#line 859
					#line 885
					#line 891
					#line 7
					uniform sampler2D _MainTex;
					uniform lowp sampler3D _LookupTex3D;
					uniform sampler2D _LookupTex2D;
					uniform highp vec4 _Params;
					#line 17
					#line 23
					#line 29
					#line 35
					#line 41
					#line 47
					#line 67
					#line 91
					#line 97
					#line 35
					highp vec4 lookup_gamma( in highp vec4 o ) {
					    o.xyz = texture3D( _LookupTex3D, ((o.xyz * _Params.x) + _Params.y)).xyz;
					    return o;
					}
					#line 47
					highp vec4 frag( in v2f_img i ) {
					    highp vec4 color = xll_saturate_vf4(texture2D( _MainTex, i.uv));
					    highp vec4 x;
					    #line 55
					    x = lookup_gamma( color);
					    #line 63
					    return mix( color, x, vec4( _Params.z));
					}
					varying mediump vec2 xlv_TEXCOORD0;
					void main() {
					unity_MatrixMVP = (unity_MatrixVP * unity_ObjectToWorld);
					unity_MatrixMV = (unity_MatrixV * unity_ObjectToWorld);
					unity_MatrixTMV = xll_transpose_mf4x4(unity_MatrixMV);
					unity_MatrixITMV = xll_transpose_mf4x4((unity_WorldToObject * unity_MatrixInvV));
					    highp vec4 xl_retval;
					    v2f_img xlt_i;
					    xlt_i.pos = vec4(0.0);
					    xlt_i.uv = vec2(xlv_TEXCOORD0);
					    xl_retval = frag( xlt_i);
					    gl_FragData[0] = vec4(xl_retval);
					}
					/* HLSL2GLSL - NOTE: GLSL optimization failed
					(9,1): error: invalid type `sampler3D' in declaration of `_LookupTex3D'
					(37,21): error: `_LookupTex3D' undeclared
					(37,10): error: no matching function for call to `texture3D(error, vec3)'; candidates are:
					(37,10): error: type mismatch
					*/
					
					#endif"
				}
				SubProgram "gles hw_tier01 " {
					"!!GLES
					#version 100
					
					#ifdef VERTEX
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 30
					#endif
					#ifndef SHADER_REQUIRE_INTERPOLATORS10
					    #define SHADER_REQUIRE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_REQUIRE_SAMPLELOD
					    #define SHADER_REQUIRE_SAMPLELOD 1
					#endif
					#ifndef SHADER_REQUIRE_FRAGCOORD
					    #define SHADER_REQUIRE_FRAGCOORD 1
					#endif
					#ifndef UNITY_NO_DXT5nm
					    #define UNITY_NO_DXT5nm 1
					#endif
					#ifndef UNITY_NO_RGBM
					    #define UNITY_NO_RGBM 1
					#endif
					#ifndef UNITY_ENABLE_REFLECTION_BUFFERS
					    #define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#endif
					#ifndef UNITY_FRAMEBUFFER_FETCH_AVAILABLE
					    #define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#endif
					#ifndef UNITY_NO_CUBEMAP_ARRAY
					    #define UNITY_NO_CUBEMAP_ARRAY 1
					#endif
					#ifndef UNITY_NO_SCREENSPACE_SHADOWS
					    #define UNITY_NO_SCREENSPACE_SHADOWS 1
					#endif
					#ifndef UNITY_PBS_USE_BRDF2
					    #define UNITY_PBS_USE_BRDF2 1
					#endif
					#ifndef SHADER_API_MOBILE
					    #define SHADER_API_MOBILE 1
					#endif
					#ifndef UNITY_HARDWARE_TIER2
					    #define UNITY_HARDWARE_TIER2 1
					#endif
					#ifndef UNITY_COLORSPACE_GAMMA
					    #define UNITY_COLORSPACE_GAMMA 1
					#endif
					#ifndef UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS
					    #define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#endif
					#ifndef UNITY_LIGHTMAP_DLDR_ENCODING
					    #define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#endif
					#ifndef UNITY_VERSION
					    #define UNITY_VERSION 201834
					#endif
					#ifndef SHADER_STAGE_VERTEX
					    #define SHADER_STAGE_VERTEX 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 30
					#endif
					#ifndef SHADER_AVAILABLE_INTERPOLATORS10
					    #define SHADER_AVAILABLE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_SAMPLELOD
					    #define SHADER_AVAILABLE_SAMPLELOD 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#define gl_Vertex _glesVertex
					attribute vec4 _glesVertex;
					#define gl_MultiTexCoord0 _glesMultiTexCoord0
					attribute vec4 _glesMultiTexCoord0;
					mat2 xll_transpose_mf2x2(mat2 m) {
					  return mat2( m[0][0], m[1][0], m[0][1], m[1][1]);
					}
					mat3 xll_transpose_mf3x3(mat3 m) {
					  return mat3( m[0][0], m[1][0], m[2][0],
					               m[0][1], m[1][1], m[2][1],
					               m[0][2], m[1][2], m[2][2]);
					}
					mat4 xll_transpose_mf4x4(mat4 m) {
					  return mat4( m[0][0], m[1][0], m[2][0], m[3][0],
					               m[0][1], m[1][1], m[2][1], m[3][1],
					               m[0][2], m[1][2], m[2][2], m[3][2],
					               m[0][3], m[1][3], m[2][3], m[3][3]);
					}
					#line 447
					struct v2f_vertex_lit {
					    highp vec2 uv;
					    lowp vec4 diff;
					    lowp vec4 spec;
					};
					#line 756
					struct v2f_img {
					    highp vec4 pos;
					    mediump vec2 uv;
					};
					#line 749
					struct appdata_img {
					    highp vec4 vertex;
					    mediump vec2 texcoord;
					};
					#line 40
					uniform highp vec4 _Time;
					uniform highp vec4 _SinTime;
					uniform highp vec4 _CosTime;
					uniform highp vec4 unity_DeltaTime;
					#line 46
					uniform highp vec3 _WorldSpaceCameraPos;
					#line 53
					uniform highp vec4 _ProjectionParams;
					#line 59
					uniform highp vec4 _ScreenParams;
					#line 71
					uniform highp vec4 _ZBufferParams;
					#line 77
					uniform highp vec4 unity_OrthoParams;
					#line 86
					uniform highp vec4 unity_CameraWorldClipPlanes[6];
					#line 92
					uniform highp mat4 unity_CameraProjection;
					uniform highp mat4 unity_CameraInvProjection;
					uniform highp mat4 unity_WorldToCamera;
					uniform highp mat4 unity_CameraToWorld;
					#line 108
					uniform highp vec4 _WorldSpaceLightPos0;
					uniform highp vec4 _LightPositionRange;
					#line 112
					uniform highp vec4 _LightProjectionParams;
					uniform highp vec4 unity_4LightPosX0;
					uniform highp vec4 unity_4LightPosY0;
					#line 116
					uniform highp vec4 unity_4LightPosZ0;
					uniform mediump vec4 unity_4LightAtten0;
					uniform mediump vec4 unity_LightColor[8];
					#line 122
					uniform highp vec4 unity_LightPosition[8];
					#line 127
					uniform mediump vec4 unity_LightAtten[8];
					uniform highp vec4 unity_SpotDirection[8];
					#line 131
					uniform mediump vec4 unity_SHAr;
					uniform mediump vec4 unity_SHAg;
					uniform mediump vec4 unity_SHAb;
					uniform mediump vec4 unity_SHBr;
					#line 135
					uniform mediump vec4 unity_SHBg;
					uniform mediump vec4 unity_SHBb;
					uniform mediump vec4 unity_SHC;
					#line 140
					uniform lowp vec4 unity_OcclusionMaskSelector;
					uniform lowp vec4 unity_ProbesOcclusion;
					#line 145
					uniform mediump vec3 unity_LightColor0;
					uniform mediump vec3 unity_LightColor1;
					uniform mediump vec3 unity_LightColor2;
					uniform mediump vec3 unity_LightColor3;
					#line 152
					uniform highp vec4 unity_ShadowSplitSpheres[4];
					uniform highp vec4 unity_ShadowSplitSqRadii;
					uniform highp vec4 unity_LightShadowBias;
					uniform highp vec4 _LightSplitsNear;
					#line 156
					uniform highp vec4 _LightSplitsFar;
					uniform highp mat4 unity_WorldToShadow[4];
					uniform mediump vec4 _LightShadowData;
					uniform highp vec4 unity_ShadowFadeCenterAndType;
					#line 165
					uniform highp mat4 unity_ObjectToWorld;
					uniform highp mat4 unity_WorldToObject;
					uniform highp vec4 unity_LODFade;
					uniform highp vec4 unity_WorldTransformParams;
					#line 206
					uniform highp mat4 glstate_matrix_transpose_modelview0;
					#line 214
					uniform lowp vec4 glstate_lightmodel_ambient;
					uniform lowp vec4 unity_AmbientSky;
					uniform lowp vec4 unity_AmbientEquator;
					uniform lowp vec4 unity_AmbientGround;
					#line 218
					uniform lowp vec4 unity_IndirectSpecColor;
					uniform highp mat4 glstate_matrix_projection;
					#line 222
					uniform highp mat4 unity_MatrixV;
					uniform highp mat4 unity_MatrixInvV;
					uniform highp mat4 unity_MatrixVP;
					uniform highp int unity_StereoEyeIndex;
					#line 228
					uniform lowp vec4 unity_ShadowColor;
					#line 235
					uniform lowp vec4 unity_FogColor;
					#line 240
					uniform highp vec4 unity_FogParams;
					#line 248
					uniform mediump sampler2D unity_Lightmap;
					uniform mediump sampler2D unity_LightmapInd;
					#line 252
					uniform sampler2D unity_ShadowMask;
					uniform sampler2D unity_DynamicLightmap;
					#line 256
					uniform sampler2D unity_DynamicDirectionality;
					uniform sampler2D unity_DynamicNormal;
					#line 260
					uniform highp vec4 unity_LightmapST;
					uniform highp vec4 unity_DynamicLightmapST;
					#line 268
					uniform samplerCube unity_SpecCube0;
					uniform samplerCube unity_SpecCube1;
					#line 272
					uniform highp vec4 unity_SpecCube0_BoxMax;
					uniform highp vec4 unity_SpecCube0_BoxMin;
					uniform highp vec4 unity_SpecCube0_ProbePosition;
					uniform mediump vec4 unity_SpecCube0_HDR;
					#line 277
					uniform highp vec4 unity_SpecCube1_BoxMax;
					uniform highp vec4 unity_SpecCube1_BoxMin;
					uniform highp vec4 unity_SpecCube1_ProbePosition;
					uniform mediump vec4 unity_SpecCube1_HDR;
					#line 317
					highp mat4 unity_MatrixMVP;
					highp mat4 unity_MatrixMV;
					highp mat4 unity_MatrixTMV;
					highp mat4 unity_MatrixITMV;
					#line 8
					#line 30
					#line 44
					#line 84
					#line 93
					#line 103
					#line 112
					#line 124
					#line 135
					#line 141
					#line 147
					#line 151
					#line 157
					#line 163
					#line 169
					#line 175
					#line 186
					#line 201
					#line 208
					#line 223
					#line 230
					#line 237
					#line 255
					#line 291
					#line 320
					#line 326
					#line 339
					#line 357
					#line 373
					#line 427
					#line 453
					#line 464
					#line 473
					#line 480
					#line 485
					#line 502
					#line 522
					#line 537
					#line 543
					#line 554
					uniform mediump vec4 unity_Lightmap_HDR;
					uniform mediump vec4 unity_DynamicLightmap_HDR;
					#line 568
					#line 578
					#line 593
					#line 602
					#line 609
					#line 618
					#line 626
					#line 635
					#line 654
					#line 660
					#line 670
					#line 680
					#line 691
					#line 696
					#line 702
					#line 707
					#line 764
					#line 770
					#line 785
					#line 816
					#line 830
					#line 834
					#line 840
					#line 849
					#line 859
					#line 885
					#line 891
					#line 7
					uniform sampler2D _MainTex;
					uniform lowp sampler3D _LookupTex3D;
					uniform sampler2D _LookupTex2D;
					uniform highp vec4 _Params;
					#line 17
					#line 23
					#line 29
					#line 35
					#line 41
					#line 47
					#line 67
					#line 91
					#line 97
					#line 44
					highp vec4 UnityObjectToClipPos( in highp vec3 pos ) {
					    #line 50
					    return (unity_MatrixVP * (unity_ObjectToWorld * vec4( pos, 1.0)));
					}
					#line 53
					highp vec4 UnityObjectToClipPos( in highp vec4 pos ) {
					    #line 55
					    return UnityObjectToClipPos( pos.xyz);
					}
					#line 770
					v2f_img vert_img( in appdata_img v ) {
					    v2f_img o;
					    #line 777
					    o.pos = UnityObjectToClipPos( v.vertex);
					    o.uv = v.texcoord;
					    return o;
					}
					varying mediump vec2 xlv_TEXCOORD0;
					void main() {
					unity_MatrixMVP = (unity_MatrixVP * unity_ObjectToWorld);
					unity_MatrixMV = (unity_MatrixV * unity_ObjectToWorld);
					unity_MatrixTMV = xll_transpose_mf4x4(unity_MatrixMV);
					unity_MatrixITMV = xll_transpose_mf4x4((unity_WorldToObject * unity_MatrixInvV));
					    v2f_img xl_retval;
					    appdata_img xlt_v;
					    xlt_v.vertex = vec4(gl_Vertex);
					    xlt_v.texcoord = vec2(gl_MultiTexCoord0);
					    xl_retval = vert_img( xlt_v);
					    gl_Position = vec4(xl_retval.pos);
					    xlv_TEXCOORD0 = vec2(xl_retval.uv);
					}
					/* HLSL2GLSL - NOTE: GLSL optimization failed
					(9,1): error: invalid type `sampler3D' in declaration of `_LookupTex3D'
					*/
					
					#endif
					#ifdef FRAGMENT
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 30
					#endif
					#ifndef SHADER_REQUIRE_INTERPOLATORS10
					    #define SHADER_REQUIRE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_REQUIRE_SAMPLELOD
					    #define SHADER_REQUIRE_SAMPLELOD 1
					#endif
					#ifndef SHADER_REQUIRE_FRAGCOORD
					    #define SHADER_REQUIRE_FRAGCOORD 1
					#endif
					#ifndef UNITY_NO_DXT5nm
					    #define UNITY_NO_DXT5nm 1
					#endif
					#ifndef UNITY_NO_RGBM
					    #define UNITY_NO_RGBM 1
					#endif
					#ifndef UNITY_ENABLE_REFLECTION_BUFFERS
					    #define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#endif
					#ifndef UNITY_FRAMEBUFFER_FETCH_AVAILABLE
					    #define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#endif
					#ifndef UNITY_NO_CUBEMAP_ARRAY
					    #define UNITY_NO_CUBEMAP_ARRAY 1
					#endif
					#ifndef UNITY_NO_SCREENSPACE_SHADOWS
					    #define UNITY_NO_SCREENSPACE_SHADOWS 1
					#endif
					#ifndef UNITY_PBS_USE_BRDF2
					    #define UNITY_PBS_USE_BRDF2 1
					#endif
					#ifndef SHADER_API_MOBILE
					    #define SHADER_API_MOBILE 1
					#endif
					#ifndef UNITY_HARDWARE_TIER2
					    #define UNITY_HARDWARE_TIER2 1
					#endif
					#ifndef UNITY_COLORSPACE_GAMMA
					    #define UNITY_COLORSPACE_GAMMA 1
					#endif
					#ifndef UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS
					    #define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#endif
					#ifndef UNITY_LIGHTMAP_DLDR_ENCODING
					    #define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#endif
					#ifndef UNITY_VERSION
					    #define UNITY_VERSION 201834
					#endif
					#ifndef SHADER_STAGE_VERTEX
					    #define SHADER_STAGE_VERTEX 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 30
					#endif
					#ifndef SHADER_AVAILABLE_INTERPOLATORS10
					    #define SHADER_AVAILABLE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_SAMPLELOD
					    #define SHADER_AVAILABLE_SAMPLELOD 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					mat2 xll_transpose_mf2x2(mat2 m) {
					  return mat2( m[0][0], m[1][0], m[0][1], m[1][1]);
					}
					mat3 xll_transpose_mf3x3(mat3 m) {
					  return mat3( m[0][0], m[1][0], m[2][0],
					               m[0][1], m[1][1], m[2][1],
					               m[0][2], m[1][2], m[2][2]);
					}
					mat4 xll_transpose_mf4x4(mat4 m) {
					  return mat4( m[0][0], m[1][0], m[2][0], m[3][0],
					               m[0][1], m[1][1], m[2][1], m[3][1],
					               m[0][2], m[1][2], m[2][2], m[3][2],
					               m[0][3], m[1][3], m[2][3], m[3][3]);
					}
					float xll_saturate_f( float x) {
					  return clamp( x, 0.0, 1.0);
					}
					vec2 xll_saturate_vf2( vec2 x) {
					  return clamp( x, 0.0, 1.0);
					}
					vec3 xll_saturate_vf3( vec3 x) {
					  return clamp( x, 0.0, 1.0);
					}
					vec4 xll_saturate_vf4( vec4 x) {
					  return clamp( x, 0.0, 1.0);
					}
					mat2 xll_saturate_mf2x2(mat2 m) {
					  return mat2( clamp(m[0], 0.0, 1.0), clamp(m[1], 0.0, 1.0));
					}
					mat3 xll_saturate_mf3x3(mat3 m) {
					  return mat3( clamp(m[0], 0.0, 1.0), clamp(m[1], 0.0, 1.0), clamp(m[2], 0.0, 1.0));
					}
					mat4 xll_saturate_mf4x4(mat4 m) {
					  return mat4( clamp(m[0], 0.0, 1.0), clamp(m[1], 0.0, 1.0), clamp(m[2], 0.0, 1.0), clamp(m[3], 0.0, 1.0));
					}
					#line 447
					struct v2f_vertex_lit {
					    highp vec2 uv;
					    lowp vec4 diff;
					    lowp vec4 spec;
					};
					#line 756
					struct v2f_img {
					    highp vec4 pos;
					    mediump vec2 uv;
					};
					#line 749
					struct appdata_img {
					    highp vec4 vertex;
					    mediump vec2 texcoord;
					};
					#line 40
					uniform highp vec4 _Time;
					uniform highp vec4 _SinTime;
					uniform highp vec4 _CosTime;
					uniform highp vec4 unity_DeltaTime;
					#line 46
					uniform highp vec3 _WorldSpaceCameraPos;
					#line 53
					uniform highp vec4 _ProjectionParams;
					#line 59
					uniform highp vec4 _ScreenParams;
					#line 71
					uniform highp vec4 _ZBufferParams;
					#line 77
					uniform highp vec4 unity_OrthoParams;
					#line 86
					uniform highp vec4 unity_CameraWorldClipPlanes[6];
					#line 92
					uniform highp mat4 unity_CameraProjection;
					uniform highp mat4 unity_CameraInvProjection;
					uniform highp mat4 unity_WorldToCamera;
					uniform highp mat4 unity_CameraToWorld;
					#line 108
					uniform highp vec4 _WorldSpaceLightPos0;
					uniform highp vec4 _LightPositionRange;
					#line 112
					uniform highp vec4 _LightProjectionParams;
					uniform highp vec4 unity_4LightPosX0;
					uniform highp vec4 unity_4LightPosY0;
					#line 116
					uniform highp vec4 unity_4LightPosZ0;
					uniform mediump vec4 unity_4LightAtten0;
					uniform mediump vec4 unity_LightColor[8];
					#line 122
					uniform highp vec4 unity_LightPosition[8];
					#line 127
					uniform mediump vec4 unity_LightAtten[8];
					uniform highp vec4 unity_SpotDirection[8];
					#line 131
					uniform mediump vec4 unity_SHAr;
					uniform mediump vec4 unity_SHAg;
					uniform mediump vec4 unity_SHAb;
					uniform mediump vec4 unity_SHBr;
					#line 135
					uniform mediump vec4 unity_SHBg;
					uniform mediump vec4 unity_SHBb;
					uniform mediump vec4 unity_SHC;
					#line 140
					uniform lowp vec4 unity_OcclusionMaskSelector;
					uniform lowp vec4 unity_ProbesOcclusion;
					#line 145
					uniform mediump vec3 unity_LightColor0;
					uniform mediump vec3 unity_LightColor1;
					uniform mediump vec3 unity_LightColor2;
					uniform mediump vec3 unity_LightColor3;
					#line 152
					uniform highp vec4 unity_ShadowSplitSpheres[4];
					uniform highp vec4 unity_ShadowSplitSqRadii;
					uniform highp vec4 unity_LightShadowBias;
					uniform highp vec4 _LightSplitsNear;
					#line 156
					uniform highp vec4 _LightSplitsFar;
					uniform highp mat4 unity_WorldToShadow[4];
					uniform mediump vec4 _LightShadowData;
					uniform highp vec4 unity_ShadowFadeCenterAndType;
					#line 165
					uniform highp mat4 unity_ObjectToWorld;
					uniform highp mat4 unity_WorldToObject;
					uniform highp vec4 unity_LODFade;
					uniform highp vec4 unity_WorldTransformParams;
					#line 206
					uniform highp mat4 glstate_matrix_transpose_modelview0;
					#line 214
					uniform lowp vec4 glstate_lightmodel_ambient;
					uniform lowp vec4 unity_AmbientSky;
					uniform lowp vec4 unity_AmbientEquator;
					uniform lowp vec4 unity_AmbientGround;
					#line 218
					uniform lowp vec4 unity_IndirectSpecColor;
					uniform highp mat4 glstate_matrix_projection;
					#line 222
					uniform highp mat4 unity_MatrixV;
					uniform highp mat4 unity_MatrixInvV;
					uniform highp mat4 unity_MatrixVP;
					uniform highp int unity_StereoEyeIndex;
					#line 228
					uniform lowp vec4 unity_ShadowColor;
					#line 235
					uniform lowp vec4 unity_FogColor;
					#line 240
					uniform highp vec4 unity_FogParams;
					#line 248
					uniform mediump sampler2D unity_Lightmap;
					uniform mediump sampler2D unity_LightmapInd;
					#line 252
					uniform sampler2D unity_ShadowMask;
					uniform sampler2D unity_DynamicLightmap;
					#line 256
					uniform sampler2D unity_DynamicDirectionality;
					uniform sampler2D unity_DynamicNormal;
					#line 260
					uniform highp vec4 unity_LightmapST;
					uniform highp vec4 unity_DynamicLightmapST;
					#line 268
					uniform samplerCube unity_SpecCube0;
					uniform samplerCube unity_SpecCube1;
					#line 272
					uniform highp vec4 unity_SpecCube0_BoxMax;
					uniform highp vec4 unity_SpecCube0_BoxMin;
					uniform highp vec4 unity_SpecCube0_ProbePosition;
					uniform mediump vec4 unity_SpecCube0_HDR;
					#line 277
					uniform highp vec4 unity_SpecCube1_BoxMax;
					uniform highp vec4 unity_SpecCube1_BoxMin;
					uniform highp vec4 unity_SpecCube1_ProbePosition;
					uniform mediump vec4 unity_SpecCube1_HDR;
					#line 317
					highp mat4 unity_MatrixMVP;
					highp mat4 unity_MatrixMV;
					highp mat4 unity_MatrixTMV;
					highp mat4 unity_MatrixITMV;
					#line 8
					#line 30
					#line 44
					#line 84
					#line 93
					#line 103
					#line 112
					#line 124
					#line 135
					#line 141
					#line 147
					#line 151
					#line 157
					#line 163
					#line 169
					#line 175
					#line 186
					#line 201
					#line 208
					#line 223
					#line 230
					#line 237
					#line 255
					#line 291
					#line 320
					#line 326
					#line 339
					#line 357
					#line 373
					#line 427
					#line 453
					#line 464
					#line 473
					#line 480
					#line 485
					#line 502
					#line 522
					#line 537
					#line 543
					#line 554
					uniform mediump vec4 unity_Lightmap_HDR;
					uniform mediump vec4 unity_DynamicLightmap_HDR;
					#line 568
					#line 578
					#line 593
					#line 602
					#line 609
					#line 618
					#line 626
					#line 635
					#line 654
					#line 660
					#line 670
					#line 680
					#line 691
					#line 696
					#line 702
					#line 707
					#line 764
					#line 770
					#line 785
					#line 816
					#line 830
					#line 834
					#line 840
					#line 849
					#line 859
					#line 885
					#line 891
					#line 7
					uniform sampler2D _MainTex;
					uniform lowp sampler3D _LookupTex3D;
					uniform sampler2D _LookupTex2D;
					uniform highp vec4 _Params;
					#line 17
					#line 23
					#line 29
					#line 35
					#line 41
					#line 47
					#line 67
					#line 91
					#line 97
					#line 35
					highp vec4 lookup_gamma( in highp vec4 o ) {
					    o.xyz = texture3D( _LookupTex3D, ((o.xyz * _Params.x) + _Params.y)).xyz;
					    return o;
					}
					#line 47
					highp vec4 frag( in v2f_img i ) {
					    highp vec4 color = xll_saturate_vf4(texture2D( _MainTex, i.uv));
					    highp vec4 x;
					    #line 55
					    x = lookup_gamma( color);
					    #line 63
					    return mix( color, x, vec4( _Params.z));
					}
					varying mediump vec2 xlv_TEXCOORD0;
					void main() {
					unity_MatrixMVP = (unity_MatrixVP * unity_ObjectToWorld);
					unity_MatrixMV = (unity_MatrixV * unity_ObjectToWorld);
					unity_MatrixTMV = xll_transpose_mf4x4(unity_MatrixMV);
					unity_MatrixITMV = xll_transpose_mf4x4((unity_WorldToObject * unity_MatrixInvV));
					    highp vec4 xl_retval;
					    v2f_img xlt_i;
					    xlt_i.pos = vec4(0.0);
					    xlt_i.uv = vec2(xlv_TEXCOORD0);
					    xl_retval = frag( xlt_i);
					    gl_FragData[0] = vec4(xl_retval);
					}
					/* HLSL2GLSL - NOTE: GLSL optimization failed
					(9,1): error: invalid type `sampler3D' in declaration of `_LookupTex3D'
					(37,21): error: `_LookupTex3D' undeclared
					(37,10): error: no matching function for call to `texture3D(error, vec3)'; candidates are:
					(37,10): error: type mismatch
					*/
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {
					"!!GLES
					#version 100
					
					#ifdef VERTEX
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 30
					#endif
					#ifndef SHADER_REQUIRE_INTERPOLATORS10
					    #define SHADER_REQUIRE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_REQUIRE_SAMPLELOD
					    #define SHADER_REQUIRE_SAMPLELOD 1
					#endif
					#ifndef SHADER_REQUIRE_FRAGCOORD
					    #define SHADER_REQUIRE_FRAGCOORD 1
					#endif
					#ifndef UNITY_NO_DXT5nm
					    #define UNITY_NO_DXT5nm 1
					#endif
					#ifndef UNITY_NO_RGBM
					    #define UNITY_NO_RGBM 1
					#endif
					#ifndef UNITY_ENABLE_REFLECTION_BUFFERS
					    #define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#endif
					#ifndef UNITY_FRAMEBUFFER_FETCH_AVAILABLE
					    #define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#endif
					#ifndef UNITY_NO_CUBEMAP_ARRAY
					    #define UNITY_NO_CUBEMAP_ARRAY 1
					#endif
					#ifndef UNITY_NO_SCREENSPACE_SHADOWS
					    #define UNITY_NO_SCREENSPACE_SHADOWS 1
					#endif
					#ifndef UNITY_PBS_USE_BRDF2
					    #define UNITY_PBS_USE_BRDF2 1
					#endif
					#ifndef SHADER_API_MOBILE
					    #define SHADER_API_MOBILE 1
					#endif
					#ifndef UNITY_HARDWARE_TIER3
					    #define UNITY_HARDWARE_TIER3 1
					#endif
					#ifndef UNITY_COLORSPACE_GAMMA
					    #define UNITY_COLORSPACE_GAMMA 1
					#endif
					#ifndef UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS
					    #define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#endif
					#ifndef UNITY_LIGHTMAP_DLDR_ENCODING
					    #define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#endif
					#ifndef UNITY_VERSION
					    #define UNITY_VERSION 201834
					#endif
					#ifndef SHADER_STAGE_VERTEX
					    #define SHADER_STAGE_VERTEX 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 30
					#endif
					#ifndef SHADER_AVAILABLE_INTERPOLATORS10
					    #define SHADER_AVAILABLE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_SAMPLELOD
					    #define SHADER_AVAILABLE_SAMPLELOD 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#define gl_Vertex _glesVertex
					attribute vec4 _glesVertex;
					#define gl_MultiTexCoord0 _glesMultiTexCoord0
					attribute vec4 _glesMultiTexCoord0;
					mat2 xll_transpose_mf2x2(mat2 m) {
					  return mat2( m[0][0], m[1][0], m[0][1], m[1][1]);
					}
					mat3 xll_transpose_mf3x3(mat3 m) {
					  return mat3( m[0][0], m[1][0], m[2][0],
					               m[0][1], m[1][1], m[2][1],
					               m[0][2], m[1][2], m[2][2]);
					}
					mat4 xll_transpose_mf4x4(mat4 m) {
					  return mat4( m[0][0], m[1][0], m[2][0], m[3][0],
					               m[0][1], m[1][1], m[2][1], m[3][1],
					               m[0][2], m[1][2], m[2][2], m[3][2],
					               m[0][3], m[1][3], m[2][3], m[3][3]);
					}
					#line 447
					struct v2f_vertex_lit {
					    highp vec2 uv;
					    lowp vec4 diff;
					    lowp vec4 spec;
					};
					#line 756
					struct v2f_img {
					    highp vec4 pos;
					    mediump vec2 uv;
					};
					#line 749
					struct appdata_img {
					    highp vec4 vertex;
					    mediump vec2 texcoord;
					};
					#line 40
					uniform highp vec4 _Time;
					uniform highp vec4 _SinTime;
					uniform highp vec4 _CosTime;
					uniform highp vec4 unity_DeltaTime;
					#line 46
					uniform highp vec3 _WorldSpaceCameraPos;
					#line 53
					uniform highp vec4 _ProjectionParams;
					#line 59
					uniform highp vec4 _ScreenParams;
					#line 71
					uniform highp vec4 _ZBufferParams;
					#line 77
					uniform highp vec4 unity_OrthoParams;
					#line 86
					uniform highp vec4 unity_CameraWorldClipPlanes[6];
					#line 92
					uniform highp mat4 unity_CameraProjection;
					uniform highp mat4 unity_CameraInvProjection;
					uniform highp mat4 unity_WorldToCamera;
					uniform highp mat4 unity_CameraToWorld;
					#line 108
					uniform highp vec4 _WorldSpaceLightPos0;
					uniform highp vec4 _LightPositionRange;
					#line 112
					uniform highp vec4 _LightProjectionParams;
					uniform highp vec4 unity_4LightPosX0;
					uniform highp vec4 unity_4LightPosY0;
					#line 116
					uniform highp vec4 unity_4LightPosZ0;
					uniform mediump vec4 unity_4LightAtten0;
					uniform mediump vec4 unity_LightColor[8];
					#line 122
					uniform highp vec4 unity_LightPosition[8];
					#line 127
					uniform mediump vec4 unity_LightAtten[8];
					uniform highp vec4 unity_SpotDirection[8];
					#line 131
					uniform mediump vec4 unity_SHAr;
					uniform mediump vec4 unity_SHAg;
					uniform mediump vec4 unity_SHAb;
					uniform mediump vec4 unity_SHBr;
					#line 135
					uniform mediump vec4 unity_SHBg;
					uniform mediump vec4 unity_SHBb;
					uniform mediump vec4 unity_SHC;
					#line 140
					uniform lowp vec4 unity_OcclusionMaskSelector;
					uniform lowp vec4 unity_ProbesOcclusion;
					#line 145
					uniform mediump vec3 unity_LightColor0;
					uniform mediump vec3 unity_LightColor1;
					uniform mediump vec3 unity_LightColor2;
					uniform mediump vec3 unity_LightColor3;
					#line 152
					uniform highp vec4 unity_ShadowSplitSpheres[4];
					uniform highp vec4 unity_ShadowSplitSqRadii;
					uniform highp vec4 unity_LightShadowBias;
					uniform highp vec4 _LightSplitsNear;
					#line 156
					uniform highp vec4 _LightSplitsFar;
					uniform highp mat4 unity_WorldToShadow[4];
					uniform mediump vec4 _LightShadowData;
					uniform highp vec4 unity_ShadowFadeCenterAndType;
					#line 165
					uniform highp mat4 unity_ObjectToWorld;
					uniform highp mat4 unity_WorldToObject;
					uniform highp vec4 unity_LODFade;
					uniform highp vec4 unity_WorldTransformParams;
					#line 206
					uniform highp mat4 glstate_matrix_transpose_modelview0;
					#line 214
					uniform lowp vec4 glstate_lightmodel_ambient;
					uniform lowp vec4 unity_AmbientSky;
					uniform lowp vec4 unity_AmbientEquator;
					uniform lowp vec4 unity_AmbientGround;
					#line 218
					uniform lowp vec4 unity_IndirectSpecColor;
					uniform highp mat4 glstate_matrix_projection;
					#line 222
					uniform highp mat4 unity_MatrixV;
					uniform highp mat4 unity_MatrixInvV;
					uniform highp mat4 unity_MatrixVP;
					uniform highp int unity_StereoEyeIndex;
					#line 228
					uniform lowp vec4 unity_ShadowColor;
					#line 235
					uniform lowp vec4 unity_FogColor;
					#line 240
					uniform highp vec4 unity_FogParams;
					#line 248
					uniform mediump sampler2D unity_Lightmap;
					uniform mediump sampler2D unity_LightmapInd;
					#line 252
					uniform sampler2D unity_ShadowMask;
					uniform sampler2D unity_DynamicLightmap;
					#line 256
					uniform sampler2D unity_DynamicDirectionality;
					uniform sampler2D unity_DynamicNormal;
					#line 260
					uniform highp vec4 unity_LightmapST;
					uniform highp vec4 unity_DynamicLightmapST;
					#line 268
					uniform samplerCube unity_SpecCube0;
					uniform samplerCube unity_SpecCube1;
					#line 272
					uniform highp vec4 unity_SpecCube0_BoxMax;
					uniform highp vec4 unity_SpecCube0_BoxMin;
					uniform highp vec4 unity_SpecCube0_ProbePosition;
					uniform mediump vec4 unity_SpecCube0_HDR;
					#line 277
					uniform highp vec4 unity_SpecCube1_BoxMax;
					uniform highp vec4 unity_SpecCube1_BoxMin;
					uniform highp vec4 unity_SpecCube1_ProbePosition;
					uniform mediump vec4 unity_SpecCube1_HDR;
					#line 317
					highp mat4 unity_MatrixMVP;
					highp mat4 unity_MatrixMV;
					highp mat4 unity_MatrixTMV;
					highp mat4 unity_MatrixITMV;
					#line 8
					#line 30
					#line 44
					#line 84
					#line 93
					#line 103
					#line 112
					#line 124
					#line 135
					#line 141
					#line 147
					#line 151
					#line 157
					#line 163
					#line 169
					#line 175
					#line 186
					#line 201
					#line 208
					#line 223
					#line 230
					#line 237
					#line 255
					#line 291
					#line 320
					#line 326
					#line 339
					#line 357
					#line 373
					#line 427
					#line 453
					#line 464
					#line 473
					#line 480
					#line 485
					#line 502
					#line 522
					#line 537
					#line 543
					#line 554
					uniform mediump vec4 unity_Lightmap_HDR;
					uniform mediump vec4 unity_DynamicLightmap_HDR;
					#line 568
					#line 578
					#line 593
					#line 602
					#line 609
					#line 618
					#line 626
					#line 635
					#line 654
					#line 660
					#line 670
					#line 680
					#line 691
					#line 696
					#line 702
					#line 707
					#line 764
					#line 770
					#line 785
					#line 816
					#line 830
					#line 834
					#line 840
					#line 849
					#line 859
					#line 885
					#line 891
					#line 7
					uniform sampler2D _MainTex;
					uniform lowp sampler3D _LookupTex3D;
					uniform sampler2D _LookupTex2D;
					uniform highp vec4 _Params;
					#line 17
					#line 23
					#line 29
					#line 35
					#line 41
					#line 47
					#line 67
					#line 91
					#line 97
					#line 44
					highp vec4 UnityObjectToClipPos( in highp vec3 pos ) {
					    #line 50
					    return (unity_MatrixVP * (unity_ObjectToWorld * vec4( pos, 1.0)));
					}
					#line 53
					highp vec4 UnityObjectToClipPos( in highp vec4 pos ) {
					    #line 55
					    return UnityObjectToClipPos( pos.xyz);
					}
					#line 770
					v2f_img vert_img( in appdata_img v ) {
					    v2f_img o;
					    #line 777
					    o.pos = UnityObjectToClipPos( v.vertex);
					    o.uv = v.texcoord;
					    return o;
					}
					varying mediump vec2 xlv_TEXCOORD0;
					void main() {
					unity_MatrixMVP = (unity_MatrixVP * unity_ObjectToWorld);
					unity_MatrixMV = (unity_MatrixV * unity_ObjectToWorld);
					unity_MatrixTMV = xll_transpose_mf4x4(unity_MatrixMV);
					unity_MatrixITMV = xll_transpose_mf4x4((unity_WorldToObject * unity_MatrixInvV));
					    v2f_img xl_retval;
					    appdata_img xlt_v;
					    xlt_v.vertex = vec4(gl_Vertex);
					    xlt_v.texcoord = vec2(gl_MultiTexCoord0);
					    xl_retval = vert_img( xlt_v);
					    gl_Position = vec4(xl_retval.pos);
					    xlv_TEXCOORD0 = vec2(xl_retval.uv);
					}
					/* HLSL2GLSL - NOTE: GLSL optimization failed
					(9,1): error: invalid type `sampler3D' in declaration of `_LookupTex3D'
					*/
					
					#endif
					#ifdef FRAGMENT
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 30
					#endif
					#ifndef SHADER_REQUIRE_INTERPOLATORS10
					    #define SHADER_REQUIRE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_REQUIRE_SAMPLELOD
					    #define SHADER_REQUIRE_SAMPLELOD 1
					#endif
					#ifndef SHADER_REQUIRE_FRAGCOORD
					    #define SHADER_REQUIRE_FRAGCOORD 1
					#endif
					#ifndef UNITY_NO_DXT5nm
					    #define UNITY_NO_DXT5nm 1
					#endif
					#ifndef UNITY_NO_RGBM
					    #define UNITY_NO_RGBM 1
					#endif
					#ifndef UNITY_ENABLE_REFLECTION_BUFFERS
					    #define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#endif
					#ifndef UNITY_FRAMEBUFFER_FETCH_AVAILABLE
					    #define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#endif
					#ifndef UNITY_NO_CUBEMAP_ARRAY
					    #define UNITY_NO_CUBEMAP_ARRAY 1
					#endif
					#ifndef UNITY_NO_SCREENSPACE_SHADOWS
					    #define UNITY_NO_SCREENSPACE_SHADOWS 1
					#endif
					#ifndef UNITY_PBS_USE_BRDF2
					    #define UNITY_PBS_USE_BRDF2 1
					#endif
					#ifndef SHADER_API_MOBILE
					    #define SHADER_API_MOBILE 1
					#endif
					#ifndef UNITY_HARDWARE_TIER3
					    #define UNITY_HARDWARE_TIER3 1
					#endif
					#ifndef UNITY_COLORSPACE_GAMMA
					    #define UNITY_COLORSPACE_GAMMA 1
					#endif
					#ifndef UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS
					    #define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#endif
					#ifndef UNITY_LIGHTMAP_DLDR_ENCODING
					    #define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#endif
					#ifndef UNITY_VERSION
					    #define UNITY_VERSION 201834
					#endif
					#ifndef SHADER_STAGE_VERTEX
					    #define SHADER_STAGE_VERTEX 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 30
					#endif
					#ifndef SHADER_AVAILABLE_INTERPOLATORS10
					    #define SHADER_AVAILABLE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_SAMPLELOD
					    #define SHADER_AVAILABLE_SAMPLELOD 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					mat2 xll_transpose_mf2x2(mat2 m) {
					  return mat2( m[0][0], m[1][0], m[0][1], m[1][1]);
					}
					mat3 xll_transpose_mf3x3(mat3 m) {
					  return mat3( m[0][0], m[1][0], m[2][0],
					               m[0][1], m[1][1], m[2][1],
					               m[0][2], m[1][2], m[2][2]);
					}
					mat4 xll_transpose_mf4x4(mat4 m) {
					  return mat4( m[0][0], m[1][0], m[2][0], m[3][0],
					               m[0][1], m[1][1], m[2][1], m[3][1],
					               m[0][2], m[1][2], m[2][2], m[3][2],
					               m[0][3], m[1][3], m[2][3], m[3][3]);
					}
					float xll_saturate_f( float x) {
					  return clamp( x, 0.0, 1.0);
					}
					vec2 xll_saturate_vf2( vec2 x) {
					  return clamp( x, 0.0, 1.0);
					}
					vec3 xll_saturate_vf3( vec3 x) {
					  return clamp( x, 0.0, 1.0);
					}
					vec4 xll_saturate_vf4( vec4 x) {
					  return clamp( x, 0.0, 1.0);
					}
					mat2 xll_saturate_mf2x2(mat2 m) {
					  return mat2( clamp(m[0], 0.0, 1.0), clamp(m[1], 0.0, 1.0));
					}
					mat3 xll_saturate_mf3x3(mat3 m) {
					  return mat3( clamp(m[0], 0.0, 1.0), clamp(m[1], 0.0, 1.0), clamp(m[2], 0.0, 1.0));
					}
					mat4 xll_saturate_mf4x4(mat4 m) {
					  return mat4( clamp(m[0], 0.0, 1.0), clamp(m[1], 0.0, 1.0), clamp(m[2], 0.0, 1.0), clamp(m[3], 0.0, 1.0));
					}
					#line 447
					struct v2f_vertex_lit {
					    highp vec2 uv;
					    lowp vec4 diff;
					    lowp vec4 spec;
					};
					#line 756
					struct v2f_img {
					    highp vec4 pos;
					    mediump vec2 uv;
					};
					#line 749
					struct appdata_img {
					    highp vec4 vertex;
					    mediump vec2 texcoord;
					};
					#line 40
					uniform highp vec4 _Time;
					uniform highp vec4 _SinTime;
					uniform highp vec4 _CosTime;
					uniform highp vec4 unity_DeltaTime;
					#line 46
					uniform highp vec3 _WorldSpaceCameraPos;
					#line 53
					uniform highp vec4 _ProjectionParams;
					#line 59
					uniform highp vec4 _ScreenParams;
					#line 71
					uniform highp vec4 _ZBufferParams;
					#line 77
					uniform highp vec4 unity_OrthoParams;
					#line 86
					uniform highp vec4 unity_CameraWorldClipPlanes[6];
					#line 92
					uniform highp mat4 unity_CameraProjection;
					uniform highp mat4 unity_CameraInvProjection;
					uniform highp mat4 unity_WorldToCamera;
					uniform highp mat4 unity_CameraToWorld;
					#line 108
					uniform highp vec4 _WorldSpaceLightPos0;
					uniform highp vec4 _LightPositionRange;
					#line 112
					uniform highp vec4 _LightProjectionParams;
					uniform highp vec4 unity_4LightPosX0;
					uniform highp vec4 unity_4LightPosY0;
					#line 116
					uniform highp vec4 unity_4LightPosZ0;
					uniform mediump vec4 unity_4LightAtten0;
					uniform mediump vec4 unity_LightColor[8];
					#line 122
					uniform highp vec4 unity_LightPosition[8];
					#line 127
					uniform mediump vec4 unity_LightAtten[8];
					uniform highp vec4 unity_SpotDirection[8];
					#line 131
					uniform mediump vec4 unity_SHAr;
					uniform mediump vec4 unity_SHAg;
					uniform mediump vec4 unity_SHAb;
					uniform mediump vec4 unity_SHBr;
					#line 135
					uniform mediump vec4 unity_SHBg;
					uniform mediump vec4 unity_SHBb;
					uniform mediump vec4 unity_SHC;
					#line 140
					uniform lowp vec4 unity_OcclusionMaskSelector;
					uniform lowp vec4 unity_ProbesOcclusion;
					#line 145
					uniform mediump vec3 unity_LightColor0;
					uniform mediump vec3 unity_LightColor1;
					uniform mediump vec3 unity_LightColor2;
					uniform mediump vec3 unity_LightColor3;
					#line 152
					uniform highp vec4 unity_ShadowSplitSpheres[4];
					uniform highp vec4 unity_ShadowSplitSqRadii;
					uniform highp vec4 unity_LightShadowBias;
					uniform highp vec4 _LightSplitsNear;
					#line 156
					uniform highp vec4 _LightSplitsFar;
					uniform highp mat4 unity_WorldToShadow[4];
					uniform mediump vec4 _LightShadowData;
					uniform highp vec4 unity_ShadowFadeCenterAndType;
					#line 165
					uniform highp mat4 unity_ObjectToWorld;
					uniform highp mat4 unity_WorldToObject;
					uniform highp vec4 unity_LODFade;
					uniform highp vec4 unity_WorldTransformParams;
					#line 206
					uniform highp mat4 glstate_matrix_transpose_modelview0;
					#line 214
					uniform lowp vec4 glstate_lightmodel_ambient;
					uniform lowp vec4 unity_AmbientSky;
					uniform lowp vec4 unity_AmbientEquator;
					uniform lowp vec4 unity_AmbientGround;
					#line 218
					uniform lowp vec4 unity_IndirectSpecColor;
					uniform highp mat4 glstate_matrix_projection;
					#line 222
					uniform highp mat4 unity_MatrixV;
					uniform highp mat4 unity_MatrixInvV;
					uniform highp mat4 unity_MatrixVP;
					uniform highp int unity_StereoEyeIndex;
					#line 228
					uniform lowp vec4 unity_ShadowColor;
					#line 235
					uniform lowp vec4 unity_FogColor;
					#line 240
					uniform highp vec4 unity_FogParams;
					#line 248
					uniform mediump sampler2D unity_Lightmap;
					uniform mediump sampler2D unity_LightmapInd;
					#line 252
					uniform sampler2D unity_ShadowMask;
					uniform sampler2D unity_DynamicLightmap;
					#line 256
					uniform sampler2D unity_DynamicDirectionality;
					uniform sampler2D unity_DynamicNormal;
					#line 260
					uniform highp vec4 unity_LightmapST;
					uniform highp vec4 unity_DynamicLightmapST;
					#line 268
					uniform samplerCube unity_SpecCube0;
					uniform samplerCube unity_SpecCube1;
					#line 272
					uniform highp vec4 unity_SpecCube0_BoxMax;
					uniform highp vec4 unity_SpecCube0_BoxMin;
					uniform highp vec4 unity_SpecCube0_ProbePosition;
					uniform mediump vec4 unity_SpecCube0_HDR;
					#line 277
					uniform highp vec4 unity_SpecCube1_BoxMax;
					uniform highp vec4 unity_SpecCube1_BoxMin;
					uniform highp vec4 unity_SpecCube1_ProbePosition;
					uniform mediump vec4 unity_SpecCube1_HDR;
					#line 317
					highp mat4 unity_MatrixMVP;
					highp mat4 unity_MatrixMV;
					highp mat4 unity_MatrixTMV;
					highp mat4 unity_MatrixITMV;
					#line 8
					#line 30
					#line 44
					#line 84
					#line 93
					#line 103
					#line 112
					#line 124
					#line 135
					#line 141
					#line 147
					#line 151
					#line 157
					#line 163
					#line 169
					#line 175
					#line 186
					#line 201
					#line 208
					#line 223
					#line 230
					#line 237
					#line 255
					#line 291
					#line 320
					#line 326
					#line 339
					#line 357
					#line 373
					#line 427
					#line 453
					#line 464
					#line 473
					#line 480
					#line 485
					#line 502
					#line 522
					#line 537
					#line 543
					#line 554
					uniform mediump vec4 unity_Lightmap_HDR;
					uniform mediump vec4 unity_DynamicLightmap_HDR;
					#line 568
					#line 578
					#line 593
					#line 602
					#line 609
					#line 618
					#line 626
					#line 635
					#line 654
					#line 660
					#line 670
					#line 680
					#line 691
					#line 696
					#line 702
					#line 707
					#line 764
					#line 770
					#line 785
					#line 816
					#line 830
					#line 834
					#line 840
					#line 849
					#line 859
					#line 885
					#line 891
					#line 7
					uniform sampler2D _MainTex;
					uniform lowp sampler3D _LookupTex3D;
					uniform sampler2D _LookupTex2D;
					uniform highp vec4 _Params;
					#line 17
					#line 23
					#line 29
					#line 35
					#line 41
					#line 47
					#line 67
					#line 91
					#line 97
					#line 35
					highp vec4 lookup_gamma( in highp vec4 o ) {
					    o.xyz = texture3D( _LookupTex3D, ((o.xyz * _Params.x) + _Params.y)).xyz;
					    return o;
					}
					#line 47
					highp vec4 frag( in v2f_img i ) {
					    highp vec4 color = xll_saturate_vf4(texture2D( _MainTex, i.uv));
					    highp vec4 x;
					    #line 55
					    x = lookup_gamma( color);
					    #line 63
					    return mix( color, x, vec4( _Params.z));
					}
					varying mediump vec2 xlv_TEXCOORD0;
					void main() {
					unity_MatrixMVP = (unity_MatrixVP * unity_ObjectToWorld);
					unity_MatrixMV = (unity_MatrixV * unity_ObjectToWorld);
					unity_MatrixTMV = xll_transpose_mf4x4(unity_MatrixMV);
					unity_MatrixITMV = xll_transpose_mf4x4((unity_WorldToObject * unity_MatrixInvV));
					    highp vec4 xl_retval;
					    v2f_img xlt_i;
					    xlt_i.pos = vec4(0.0);
					    xlt_i.uv = vec2(xlv_TEXCOORD0);
					    xl_retval = frag( xlt_i);
					    gl_FragData[0] = vec4(xl_retval);
					}
					/* HLSL2GLSL - NOTE: GLSL optimization failed
					(9,1): error: invalid type `sampler3D' in declaration of `_LookupTex3D'
					(37,21): error: `_LookupTex3D' undeclared
					(37,10): error: no matching function for call to `texture3D(error, vec3)'; candidates are:
					(37,10): error: type mismatch
					*/
					
					#endif"
				}
				SubProgram "gles3 hw_tier00 " {
					"!!GLES3
					#ifdef VERTEX
					#version 300 es
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					in highp vec4 in_POSITION0;
					in mediump vec2 in_TEXCOORD0;
					out mediump vec2 vs_TEXCOORD0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					void main()
					{
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy;
					    return;
					}
					
					#endif
					#ifdef FRAGMENT
					#version 300 es
					
					precision highp int;
					uniform 	vec4 _Params;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler3D _LookupTex3D;
					in mediump vec2 vs_TEXCOORD0;
					layout(location = 0) out highp vec4 SV_Target0;
					mediump vec4 u_xlat16_0;
					lowp vec4 u_xlat10_0;
					vec4 u_xlat1;
					lowp vec3 u_xlat10_1;
					void main()
					{
					    u_xlat10_0 = texture(_MainTex, vs_TEXCOORD0.xy);
					    u_xlat16_0 = u_xlat10_0;
					#ifdef UNITY_ADRENO_ES3
					    u_xlat16_0 = min(max(u_xlat16_0, 0.0), 1.0);
					#else
					    u_xlat16_0 = clamp(u_xlat16_0, 0.0, 1.0);
					#endif
					    u_xlat1.xyz = u_xlat16_0.xyz * _Params.xxx + _Params.yyy;
					    u_xlat10_1.xyz = texture(_LookupTex3D, u_xlat1.xyz).xyz;
					    u_xlat1.xyz = (-u_xlat16_0.xyz) + u_xlat10_1.xyz;
					    u_xlat1.w = 0.0;
					    SV_Target0 = _Params.zzzz * u_xlat1 + u_xlat16_0;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles3 hw_tier01 " {
					"!!GLES3
					#ifdef VERTEX
					#version 300 es
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					in highp vec4 in_POSITION0;
					in mediump vec2 in_TEXCOORD0;
					out mediump vec2 vs_TEXCOORD0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					void main()
					{
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy;
					    return;
					}
					
					#endif
					#ifdef FRAGMENT
					#version 300 es
					
					precision highp int;
					uniform 	vec4 _Params;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler3D _LookupTex3D;
					in mediump vec2 vs_TEXCOORD0;
					layout(location = 0) out highp vec4 SV_Target0;
					mediump vec4 u_xlat16_0;
					lowp vec4 u_xlat10_0;
					vec4 u_xlat1;
					lowp vec3 u_xlat10_1;
					void main()
					{
					    u_xlat10_0 = texture(_MainTex, vs_TEXCOORD0.xy);
					    u_xlat16_0 = u_xlat10_0;
					#ifdef UNITY_ADRENO_ES3
					    u_xlat16_0 = min(max(u_xlat16_0, 0.0), 1.0);
					#else
					    u_xlat16_0 = clamp(u_xlat16_0, 0.0, 1.0);
					#endif
					    u_xlat1.xyz = u_xlat16_0.xyz * _Params.xxx + _Params.yyy;
					    u_xlat10_1.xyz = texture(_LookupTex3D, u_xlat1.xyz).xyz;
					    u_xlat1.xyz = (-u_xlat16_0.xyz) + u_xlat10_1.xyz;
					    u_xlat1.w = 0.0;
					    SV_Target0 = _Params.zzzz * u_xlat1 + u_xlat16_0;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles3 hw_tier02 " {
					"!!GLES3
					#ifdef VERTEX
					#version 300 es
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					in highp vec4 in_POSITION0;
					in mediump vec2 in_TEXCOORD0;
					out mediump vec2 vs_TEXCOORD0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					void main()
					{
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy;
					    return;
					}
					
					#endif
					#ifdef FRAGMENT
					#version 300 es
					
					precision highp int;
					uniform 	vec4 _Params;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler3D _LookupTex3D;
					in mediump vec2 vs_TEXCOORD0;
					layout(location = 0) out highp vec4 SV_Target0;
					mediump vec4 u_xlat16_0;
					lowp vec4 u_xlat10_0;
					vec4 u_xlat1;
					lowp vec3 u_xlat10_1;
					void main()
					{
					    u_xlat10_0 = texture(_MainTex, vs_TEXCOORD0.xy);
					    u_xlat16_0 = u_xlat10_0;
					#ifdef UNITY_ADRENO_ES3
					    u_xlat16_0 = min(max(u_xlat16_0, 0.0), 1.0);
					#else
					    u_xlat16_0 = clamp(u_xlat16_0, 0.0, 1.0);
					#endif
					    u_xlat1.xyz = u_xlat16_0.xyz * _Params.xxx + _Params.yyy;
					    u_xlat10_1.xyz = texture(_LookupTex3D, u_xlat1.xyz).xyz;
					    u_xlat1.xyz = (-u_xlat16_0.xyz) + u_xlat10_1.xyz;
					    u_xlat1.w = 0.0;
					    SV_Target0 = _Params.zzzz * u_xlat1 + u_xlat16_0;
					    return;
					}
					
					#endif"
				}
			}
			Program "fp" {
				SubProgram "gles hw_tier00 " {
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					"!!GLES"
				}
				SubProgram "gles3 hw_tier00 " {
					"!!GLES3"
				}
				SubProgram "gles3 hw_tier01 " {
					"!!GLES3"
				}
				SubProgram "gles3 hw_tier02 " {
					"!!GLES3"
				}
			}
		}
		Pass {
			ZTest Always
			ZWrite Off
			Cull Off
			Fog {
				Mode Off
			}
			GpuProgramID 113851
			Program "vp" {
				SubProgram "gles hw_tier00 " {
					"!!GLES
					#version 100
					
					#ifdef VERTEX
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 30
					#endif
					#ifndef SHADER_REQUIRE_INTERPOLATORS10
					    #define SHADER_REQUIRE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_REQUIRE_SAMPLELOD
					    #define SHADER_REQUIRE_SAMPLELOD 1
					#endif
					#ifndef SHADER_REQUIRE_FRAGCOORD
					    #define SHADER_REQUIRE_FRAGCOORD 1
					#endif
					#ifndef UNITY_NO_DXT5nm
					    #define UNITY_NO_DXT5nm 1
					#endif
					#ifndef UNITY_NO_RGBM
					    #define UNITY_NO_RGBM 1
					#endif
					#ifndef UNITY_ENABLE_REFLECTION_BUFFERS
					    #define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#endif
					#ifndef UNITY_FRAMEBUFFER_FETCH_AVAILABLE
					    #define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#endif
					#ifndef UNITY_NO_CUBEMAP_ARRAY
					    #define UNITY_NO_CUBEMAP_ARRAY 1
					#endif
					#ifndef UNITY_NO_SCREENSPACE_SHADOWS
					    #define UNITY_NO_SCREENSPACE_SHADOWS 1
					#endif
					#ifndef UNITY_PBS_USE_BRDF3
					    #define UNITY_PBS_USE_BRDF3 1
					#endif
					#ifndef UNITY_NO_FULL_STANDARD_SHADER
					    #define UNITY_NO_FULL_STANDARD_SHADER 1
					#endif
					#ifndef SHADER_API_MOBILE
					    #define SHADER_API_MOBILE 1
					#endif
					#ifndef UNITY_HARDWARE_TIER1
					    #define UNITY_HARDWARE_TIER1 1
					#endif
					#ifndef UNITY_COLORSPACE_GAMMA
					    #define UNITY_COLORSPACE_GAMMA 1
					#endif
					#ifndef UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS
					    #define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#endif
					#ifndef UNITY_LIGHTMAP_DLDR_ENCODING
					    #define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#endif
					#ifndef UNITY_VERSION
					    #define UNITY_VERSION 201834
					#endif
					#ifndef SHADER_STAGE_VERTEX
					    #define SHADER_STAGE_VERTEX 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 30
					#endif
					#ifndef SHADER_AVAILABLE_INTERPOLATORS10
					    #define SHADER_AVAILABLE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_SAMPLELOD
					    #define SHADER_AVAILABLE_SAMPLELOD 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#define gl_Vertex _glesVertex
					attribute vec4 _glesVertex;
					#define gl_MultiTexCoord0 _glesMultiTexCoord0
					attribute vec4 _glesMultiTexCoord0;
					mat2 xll_transpose_mf2x2(mat2 m) {
					  return mat2( m[0][0], m[1][0], m[0][1], m[1][1]);
					}
					mat3 xll_transpose_mf3x3(mat3 m) {
					  return mat3( m[0][0], m[1][0], m[2][0],
					               m[0][1], m[1][1], m[2][1],
					               m[0][2], m[1][2], m[2][2]);
					}
					mat4 xll_transpose_mf4x4(mat4 m) {
					  return mat4( m[0][0], m[1][0], m[2][0], m[3][0],
					               m[0][1], m[1][1], m[2][1], m[3][1],
					               m[0][2], m[1][2], m[2][2], m[3][2],
					               m[0][3], m[1][3], m[2][3], m[3][3]);
					}
					#line 447
					struct v2f_vertex_lit {
					    highp vec2 uv;
					    lowp vec4 diff;
					    lowp vec4 spec;
					};
					#line 756
					struct v2f_img {
					    highp vec4 pos;
					    mediump vec2 uv;
					};
					#line 749
					struct appdata_img {
					    highp vec4 vertex;
					    mediump vec2 texcoord;
					};
					#line 40
					uniform highp vec4 _Time;
					uniform highp vec4 _SinTime;
					uniform highp vec4 _CosTime;
					uniform highp vec4 unity_DeltaTime;
					#line 46
					uniform highp vec3 _WorldSpaceCameraPos;
					#line 53
					uniform highp vec4 _ProjectionParams;
					#line 59
					uniform highp vec4 _ScreenParams;
					#line 71
					uniform highp vec4 _ZBufferParams;
					#line 77
					uniform highp vec4 unity_OrthoParams;
					#line 86
					uniform highp vec4 unity_CameraWorldClipPlanes[6];
					#line 92
					uniform highp mat4 unity_CameraProjection;
					uniform highp mat4 unity_CameraInvProjection;
					uniform highp mat4 unity_WorldToCamera;
					uniform highp mat4 unity_CameraToWorld;
					#line 108
					uniform highp vec4 _WorldSpaceLightPos0;
					uniform highp vec4 _LightPositionRange;
					#line 112
					uniform highp vec4 _LightProjectionParams;
					uniform highp vec4 unity_4LightPosX0;
					uniform highp vec4 unity_4LightPosY0;
					#line 116
					uniform highp vec4 unity_4LightPosZ0;
					uniform mediump vec4 unity_4LightAtten0;
					uniform mediump vec4 unity_LightColor[8];
					#line 122
					uniform highp vec4 unity_LightPosition[8];
					#line 127
					uniform mediump vec4 unity_LightAtten[8];
					uniform highp vec4 unity_SpotDirection[8];
					#line 131
					uniform mediump vec4 unity_SHAr;
					uniform mediump vec4 unity_SHAg;
					uniform mediump vec4 unity_SHAb;
					uniform mediump vec4 unity_SHBr;
					#line 135
					uniform mediump vec4 unity_SHBg;
					uniform mediump vec4 unity_SHBb;
					uniform mediump vec4 unity_SHC;
					#line 140
					uniform lowp vec4 unity_OcclusionMaskSelector;
					uniform lowp vec4 unity_ProbesOcclusion;
					#line 145
					uniform mediump vec3 unity_LightColor0;
					uniform mediump vec3 unity_LightColor1;
					uniform mediump vec3 unity_LightColor2;
					uniform mediump vec3 unity_LightColor3;
					#line 152
					uniform highp vec4 unity_ShadowSplitSpheres[4];
					uniform highp vec4 unity_ShadowSplitSqRadii;
					uniform highp vec4 unity_LightShadowBias;
					uniform highp vec4 _LightSplitsNear;
					#line 156
					uniform highp vec4 _LightSplitsFar;
					uniform highp mat4 unity_WorldToShadow[4];
					uniform mediump vec4 _LightShadowData;
					uniform highp vec4 unity_ShadowFadeCenterAndType;
					#line 165
					uniform highp mat4 unity_ObjectToWorld;
					uniform highp mat4 unity_WorldToObject;
					uniform highp vec4 unity_LODFade;
					uniform highp vec4 unity_WorldTransformParams;
					#line 206
					uniform highp mat4 glstate_matrix_transpose_modelview0;
					#line 214
					uniform lowp vec4 glstate_lightmodel_ambient;
					uniform lowp vec4 unity_AmbientSky;
					uniform lowp vec4 unity_AmbientEquator;
					uniform lowp vec4 unity_AmbientGround;
					#line 218
					uniform lowp vec4 unity_IndirectSpecColor;
					uniform highp mat4 glstate_matrix_projection;
					#line 222
					uniform highp mat4 unity_MatrixV;
					uniform highp mat4 unity_MatrixInvV;
					uniform highp mat4 unity_MatrixVP;
					uniform highp int unity_StereoEyeIndex;
					#line 228
					uniform lowp vec4 unity_ShadowColor;
					#line 235
					uniform lowp vec4 unity_FogColor;
					#line 240
					uniform highp vec4 unity_FogParams;
					#line 248
					uniform mediump sampler2D unity_Lightmap;
					uniform mediump sampler2D unity_LightmapInd;
					#line 252
					uniform sampler2D unity_ShadowMask;
					uniform sampler2D unity_DynamicLightmap;
					#line 256
					uniform sampler2D unity_DynamicDirectionality;
					uniform sampler2D unity_DynamicNormal;
					#line 260
					uniform highp vec4 unity_LightmapST;
					uniform highp vec4 unity_DynamicLightmapST;
					#line 268
					uniform samplerCube unity_SpecCube0;
					uniform samplerCube unity_SpecCube1;
					#line 272
					uniform highp vec4 unity_SpecCube0_BoxMax;
					uniform highp vec4 unity_SpecCube0_BoxMin;
					uniform highp vec4 unity_SpecCube0_ProbePosition;
					uniform mediump vec4 unity_SpecCube0_HDR;
					#line 277
					uniform highp vec4 unity_SpecCube1_BoxMax;
					uniform highp vec4 unity_SpecCube1_BoxMin;
					uniform highp vec4 unity_SpecCube1_ProbePosition;
					uniform mediump vec4 unity_SpecCube1_HDR;
					#line 317
					highp mat4 unity_MatrixMVP;
					highp mat4 unity_MatrixMV;
					highp mat4 unity_MatrixTMV;
					highp mat4 unity_MatrixITMV;
					#line 8
					#line 30
					#line 44
					#line 84
					#line 93
					#line 103
					#line 112
					#line 124
					#line 135
					#line 141
					#line 147
					#line 151
					#line 157
					#line 163
					#line 169
					#line 175
					#line 186
					#line 201
					#line 208
					#line 223
					#line 230
					#line 237
					#line 255
					#line 291
					#line 320
					#line 326
					#line 339
					#line 357
					#line 373
					#line 427
					#line 453
					#line 464
					#line 473
					#line 480
					#line 485
					#line 502
					#line 522
					#line 537
					#line 543
					#line 554
					uniform mediump vec4 unity_Lightmap_HDR;
					uniform mediump vec4 unity_DynamicLightmap_HDR;
					#line 568
					#line 578
					#line 593
					#line 602
					#line 609
					#line 618
					#line 626
					#line 635
					#line 654
					#line 660
					#line 670
					#line 680
					#line 691
					#line 696
					#line 702
					#line 707
					#line 764
					#line 770
					#line 785
					#line 816
					#line 830
					#line 834
					#line 840
					#line 849
					#line 859
					#line 885
					#line 891
					#line 7
					uniform sampler2D _MainTex;
					uniform lowp sampler3D _LookupTex3D;
					uniform sampler2D _LookupTex2D;
					uniform highp vec4 _Params;
					#line 17
					#line 23
					#line 29
					#line 35
					#line 41
					#line 47
					#line 67
					#line 91
					#line 97
					#line 44
					highp vec4 UnityObjectToClipPos( in highp vec3 pos ) {
					    #line 50
					    return (unity_MatrixVP * (unity_ObjectToWorld * vec4( pos, 1.0)));
					}
					#line 53
					highp vec4 UnityObjectToClipPos( in highp vec4 pos ) {
					    #line 55
					    return UnityObjectToClipPos( pos.xyz);
					}
					#line 770
					v2f_img vert_img( in appdata_img v ) {
					    v2f_img o;
					    #line 777
					    o.pos = UnityObjectToClipPos( v.vertex);
					    o.uv = v.texcoord;
					    return o;
					}
					varying mediump vec2 xlv_TEXCOORD0;
					void main() {
					unity_MatrixMVP = (unity_MatrixVP * unity_ObjectToWorld);
					unity_MatrixMV = (unity_MatrixV * unity_ObjectToWorld);
					unity_MatrixTMV = xll_transpose_mf4x4(unity_MatrixMV);
					unity_MatrixITMV = xll_transpose_mf4x4((unity_WorldToObject * unity_MatrixInvV));
					    v2f_img xl_retval;
					    appdata_img xlt_v;
					    xlt_v.vertex = vec4(gl_Vertex);
					    xlt_v.texcoord = vec2(gl_MultiTexCoord0);
					    xl_retval = vert_img( xlt_v);
					    gl_Position = vec4(xl_retval.pos);
					    xlv_TEXCOORD0 = vec2(xl_retval.uv);
					}
					/* HLSL2GLSL - NOTE: GLSL optimization failed
					(9,1): error: invalid type `sampler3D' in declaration of `_LookupTex3D'
					*/
					
					#endif
					#ifdef FRAGMENT
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 30
					#endif
					#ifndef SHADER_REQUIRE_INTERPOLATORS10
					    #define SHADER_REQUIRE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_REQUIRE_SAMPLELOD
					    #define SHADER_REQUIRE_SAMPLELOD 1
					#endif
					#ifndef SHADER_REQUIRE_FRAGCOORD
					    #define SHADER_REQUIRE_FRAGCOORD 1
					#endif
					#ifndef UNITY_NO_DXT5nm
					    #define UNITY_NO_DXT5nm 1
					#endif
					#ifndef UNITY_NO_RGBM
					    #define UNITY_NO_RGBM 1
					#endif
					#ifndef UNITY_ENABLE_REFLECTION_BUFFERS
					    #define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#endif
					#ifndef UNITY_FRAMEBUFFER_FETCH_AVAILABLE
					    #define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#endif
					#ifndef UNITY_NO_CUBEMAP_ARRAY
					    #define UNITY_NO_CUBEMAP_ARRAY 1
					#endif
					#ifndef UNITY_NO_SCREENSPACE_SHADOWS
					    #define UNITY_NO_SCREENSPACE_SHADOWS 1
					#endif
					#ifndef UNITY_PBS_USE_BRDF3
					    #define UNITY_PBS_USE_BRDF3 1
					#endif
					#ifndef UNITY_NO_FULL_STANDARD_SHADER
					    #define UNITY_NO_FULL_STANDARD_SHADER 1
					#endif
					#ifndef SHADER_API_MOBILE
					    #define SHADER_API_MOBILE 1
					#endif
					#ifndef UNITY_HARDWARE_TIER1
					    #define UNITY_HARDWARE_TIER1 1
					#endif
					#ifndef UNITY_COLORSPACE_GAMMA
					    #define UNITY_COLORSPACE_GAMMA 1
					#endif
					#ifndef UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS
					    #define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#endif
					#ifndef UNITY_LIGHTMAP_DLDR_ENCODING
					    #define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#endif
					#ifndef UNITY_VERSION
					    #define UNITY_VERSION 201834
					#endif
					#ifndef SHADER_STAGE_VERTEX
					    #define SHADER_STAGE_VERTEX 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 30
					#endif
					#ifndef SHADER_AVAILABLE_INTERPOLATORS10
					    #define SHADER_AVAILABLE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_SAMPLELOD
					    #define SHADER_AVAILABLE_SAMPLELOD 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					mat2 xll_transpose_mf2x2(mat2 m) {
					  return mat2( m[0][0], m[1][0], m[0][1], m[1][1]);
					}
					mat3 xll_transpose_mf3x3(mat3 m) {
					  return mat3( m[0][0], m[1][0], m[2][0],
					               m[0][1], m[1][1], m[2][1],
					               m[0][2], m[1][2], m[2][2]);
					}
					mat4 xll_transpose_mf4x4(mat4 m) {
					  return mat4( m[0][0], m[1][0], m[2][0], m[3][0],
					               m[0][1], m[1][1], m[2][1], m[3][1],
					               m[0][2], m[1][2], m[2][2], m[3][2],
					               m[0][3], m[1][3], m[2][3], m[3][3]);
					}
					float xll_saturate_f( float x) {
					  return clamp( x, 0.0, 1.0);
					}
					vec2 xll_saturate_vf2( vec2 x) {
					  return clamp( x, 0.0, 1.0);
					}
					vec3 xll_saturate_vf3( vec3 x) {
					  return clamp( x, 0.0, 1.0);
					}
					vec4 xll_saturate_vf4( vec4 x) {
					  return clamp( x, 0.0, 1.0);
					}
					mat2 xll_saturate_mf2x2(mat2 m) {
					  return mat2( clamp(m[0], 0.0, 1.0), clamp(m[1], 0.0, 1.0));
					}
					mat3 xll_saturate_mf3x3(mat3 m) {
					  return mat3( clamp(m[0], 0.0, 1.0), clamp(m[1], 0.0, 1.0), clamp(m[2], 0.0, 1.0));
					}
					mat4 xll_saturate_mf4x4(mat4 m) {
					  return mat4( clamp(m[0], 0.0, 1.0), clamp(m[1], 0.0, 1.0), clamp(m[2], 0.0, 1.0), clamp(m[3], 0.0, 1.0));
					}
					vec2 xll_vecTSel_vb2_vf2_vf2 (bvec2 a, vec2 b, vec2 c) {
					  return vec2 (a.x ? b.x : c.x, a.y ? b.y : c.y);
					}
					vec3 xll_vecTSel_vb3_vf3_vf3 (bvec3 a, vec3 b, vec3 c) {
					  return vec3 (a.x ? b.x : c.x, a.y ? b.y : c.y, a.z ? b.z : c.z);
					}
					vec4 xll_vecTSel_vb4_vf4_vf4 (bvec4 a, vec4 b, vec4 c) {
					  return vec4 (a.x ? b.x : c.x, a.y ? b.y : c.y, a.z ? b.z : c.z, a.w ? b.w : c.w);
					}
					#line 447
					struct v2f_vertex_lit {
					    highp vec2 uv;
					    lowp vec4 diff;
					    lowp vec4 spec;
					};
					#line 756
					struct v2f_img {
					    highp vec4 pos;
					    mediump vec2 uv;
					};
					#line 749
					struct appdata_img {
					    highp vec4 vertex;
					    mediump vec2 texcoord;
					};
					#line 40
					uniform highp vec4 _Time;
					uniform highp vec4 _SinTime;
					uniform highp vec4 _CosTime;
					uniform highp vec4 unity_DeltaTime;
					#line 46
					uniform highp vec3 _WorldSpaceCameraPos;
					#line 53
					uniform highp vec4 _ProjectionParams;
					#line 59
					uniform highp vec4 _ScreenParams;
					#line 71
					uniform highp vec4 _ZBufferParams;
					#line 77
					uniform highp vec4 unity_OrthoParams;
					#line 86
					uniform highp vec4 unity_CameraWorldClipPlanes[6];
					#line 92
					uniform highp mat4 unity_CameraProjection;
					uniform highp mat4 unity_CameraInvProjection;
					uniform highp mat4 unity_WorldToCamera;
					uniform highp mat4 unity_CameraToWorld;
					#line 108
					uniform highp vec4 _WorldSpaceLightPos0;
					uniform highp vec4 _LightPositionRange;
					#line 112
					uniform highp vec4 _LightProjectionParams;
					uniform highp vec4 unity_4LightPosX0;
					uniform highp vec4 unity_4LightPosY0;
					#line 116
					uniform highp vec4 unity_4LightPosZ0;
					uniform mediump vec4 unity_4LightAtten0;
					uniform mediump vec4 unity_LightColor[8];
					#line 122
					uniform highp vec4 unity_LightPosition[8];
					#line 127
					uniform mediump vec4 unity_LightAtten[8];
					uniform highp vec4 unity_SpotDirection[8];
					#line 131
					uniform mediump vec4 unity_SHAr;
					uniform mediump vec4 unity_SHAg;
					uniform mediump vec4 unity_SHAb;
					uniform mediump vec4 unity_SHBr;
					#line 135
					uniform mediump vec4 unity_SHBg;
					uniform mediump vec4 unity_SHBb;
					uniform mediump vec4 unity_SHC;
					#line 140
					uniform lowp vec4 unity_OcclusionMaskSelector;
					uniform lowp vec4 unity_ProbesOcclusion;
					#line 145
					uniform mediump vec3 unity_LightColor0;
					uniform mediump vec3 unity_LightColor1;
					uniform mediump vec3 unity_LightColor2;
					uniform mediump vec3 unity_LightColor3;
					#line 152
					uniform highp vec4 unity_ShadowSplitSpheres[4];
					uniform highp vec4 unity_ShadowSplitSqRadii;
					uniform highp vec4 unity_LightShadowBias;
					uniform highp vec4 _LightSplitsNear;
					#line 156
					uniform highp vec4 _LightSplitsFar;
					uniform highp mat4 unity_WorldToShadow[4];
					uniform mediump vec4 _LightShadowData;
					uniform highp vec4 unity_ShadowFadeCenterAndType;
					#line 165
					uniform highp mat4 unity_ObjectToWorld;
					uniform highp mat4 unity_WorldToObject;
					uniform highp vec4 unity_LODFade;
					uniform highp vec4 unity_WorldTransformParams;
					#line 206
					uniform highp mat4 glstate_matrix_transpose_modelview0;
					#line 214
					uniform lowp vec4 glstate_lightmodel_ambient;
					uniform lowp vec4 unity_AmbientSky;
					uniform lowp vec4 unity_AmbientEquator;
					uniform lowp vec4 unity_AmbientGround;
					#line 218
					uniform lowp vec4 unity_IndirectSpecColor;
					uniform highp mat4 glstate_matrix_projection;
					#line 222
					uniform highp mat4 unity_MatrixV;
					uniform highp mat4 unity_MatrixInvV;
					uniform highp mat4 unity_MatrixVP;
					uniform highp int unity_StereoEyeIndex;
					#line 228
					uniform lowp vec4 unity_ShadowColor;
					#line 235
					uniform lowp vec4 unity_FogColor;
					#line 240
					uniform highp vec4 unity_FogParams;
					#line 248
					uniform mediump sampler2D unity_Lightmap;
					uniform mediump sampler2D unity_LightmapInd;
					#line 252
					uniform sampler2D unity_ShadowMask;
					uniform sampler2D unity_DynamicLightmap;
					#line 256
					uniform sampler2D unity_DynamicDirectionality;
					uniform sampler2D unity_DynamicNormal;
					#line 260
					uniform highp vec4 unity_LightmapST;
					uniform highp vec4 unity_DynamicLightmapST;
					#line 268
					uniform samplerCube unity_SpecCube0;
					uniform samplerCube unity_SpecCube1;
					#line 272
					uniform highp vec4 unity_SpecCube0_BoxMax;
					uniform highp vec4 unity_SpecCube0_BoxMin;
					uniform highp vec4 unity_SpecCube0_ProbePosition;
					uniform mediump vec4 unity_SpecCube0_HDR;
					#line 277
					uniform highp vec4 unity_SpecCube1_BoxMax;
					uniform highp vec4 unity_SpecCube1_BoxMin;
					uniform highp vec4 unity_SpecCube1_ProbePosition;
					uniform mediump vec4 unity_SpecCube1_HDR;
					#line 317
					highp mat4 unity_MatrixMVP;
					highp mat4 unity_MatrixMV;
					highp mat4 unity_MatrixTMV;
					highp mat4 unity_MatrixITMV;
					#line 8
					#line 30
					#line 44
					#line 84
					#line 93
					#line 103
					#line 112
					#line 124
					#line 135
					#line 141
					#line 147
					#line 151
					#line 157
					#line 163
					#line 169
					#line 175
					#line 186
					#line 201
					#line 208
					#line 223
					#line 230
					#line 237
					#line 255
					#line 291
					#line 320
					#line 326
					#line 339
					#line 357
					#line 373
					#line 427
					#line 453
					#line 464
					#line 473
					#line 480
					#line 485
					#line 502
					#line 522
					#line 537
					#line 543
					#line 554
					uniform mediump vec4 unity_Lightmap_HDR;
					uniform mediump vec4 unity_DynamicLightmap_HDR;
					#line 568
					#line 578
					#line 593
					#line 602
					#line 609
					#line 618
					#line 626
					#line 635
					#line 654
					#line 660
					#line 670
					#line 680
					#line 691
					#line 696
					#line 702
					#line 707
					#line 764
					#line 770
					#line 785
					#line 816
					#line 830
					#line 834
					#line 840
					#line 849
					#line 859
					#line 885
					#line 891
					#line 7
					uniform sampler2D _MainTex;
					uniform lowp sampler3D _LookupTex3D;
					uniform sampler2D _LookupTex2D;
					uniform highp vec4 _Params;
					#line 17
					#line 23
					#line 29
					#line 35
					#line 41
					#line 47
					#line 67
					#line 91
					#line 97
					#line 29
					highp vec4 Linear( in highp vec4 color ) {
					    color.xyz = xll_vecTSel_vb3_vf3_vf3 (lessThanEqual( color.xyz, vec3( 0.0404482, 0.0404482, 0.0404482)), (color.xyz / 12.92321), pow( ((color.xyz + 0.055) * 0.9478672), vec3( 2.4)));
					    return color;
					}
					#line 17
					highp vec3 sRGB( in highp vec3 color ) {
					    color = xll_vecTSel_vb3_vf3_vf3 (lessThanEqual( color, vec3( 0.0031308, 0.0031308, 0.0031308)), (color * 12.92321), ((1.055 * pow( color, vec3( 0.41666))) - 0.055));
					    return color;
					}
					#line 41
					highp vec4 lookup_linear( in highp vec4 o ) {
					    o.xyz = texture3D( _LookupTex3D, ((sRGB( o.xyz) * _Params.x) + _Params.y)).xyz;
					    return Linear( o);
					}
					#line 47
					highp vec4 frag( in v2f_img i ) {
					    highp vec4 color = xll_saturate_vf4(texture2D( _MainTex, i.uv));
					    highp vec4 x;
					    #line 53
					    x = lookup_linear( color);
					    #line 63
					    return mix( color, x, vec4( _Params.z));
					}
					varying mediump vec2 xlv_TEXCOORD0;
					void main() {
					unity_MatrixMVP = (unity_MatrixVP * unity_ObjectToWorld);
					unity_MatrixMV = (unity_MatrixV * unity_ObjectToWorld);
					unity_MatrixTMV = xll_transpose_mf4x4(unity_MatrixMV);
					unity_MatrixITMV = xll_transpose_mf4x4((unity_WorldToObject * unity_MatrixInvV));
					    highp vec4 xl_retval;
					    v2f_img xlt_i;
					    xlt_i.pos = vec4(0.0);
					    xlt_i.uv = vec2(xlv_TEXCOORD0);
					    xl_retval = frag( xlt_i);
					    gl_FragData[0] = vec4(xl_retval);
					}
					/* HLSL2GLSL - NOTE: GLSL optimization failed
					(9,1): error: invalid type `sampler3D' in declaration of `_LookupTex3D'
					(43,21): error: `_LookupTex3D' undeclared
					(43,10): error: no matching function for call to `texture3D(error, vec3)'; candidates are:
					(43,10): error: type mismatch
					*/
					
					#endif"
				}
				SubProgram "gles hw_tier01 " {
					"!!GLES
					#version 100
					
					#ifdef VERTEX
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 30
					#endif
					#ifndef SHADER_REQUIRE_INTERPOLATORS10
					    #define SHADER_REQUIRE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_REQUIRE_SAMPLELOD
					    #define SHADER_REQUIRE_SAMPLELOD 1
					#endif
					#ifndef SHADER_REQUIRE_FRAGCOORD
					    #define SHADER_REQUIRE_FRAGCOORD 1
					#endif
					#ifndef UNITY_NO_DXT5nm
					    #define UNITY_NO_DXT5nm 1
					#endif
					#ifndef UNITY_NO_RGBM
					    #define UNITY_NO_RGBM 1
					#endif
					#ifndef UNITY_ENABLE_REFLECTION_BUFFERS
					    #define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#endif
					#ifndef UNITY_FRAMEBUFFER_FETCH_AVAILABLE
					    #define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#endif
					#ifndef UNITY_NO_CUBEMAP_ARRAY
					    #define UNITY_NO_CUBEMAP_ARRAY 1
					#endif
					#ifndef UNITY_NO_SCREENSPACE_SHADOWS
					    #define UNITY_NO_SCREENSPACE_SHADOWS 1
					#endif
					#ifndef UNITY_PBS_USE_BRDF2
					    #define UNITY_PBS_USE_BRDF2 1
					#endif
					#ifndef SHADER_API_MOBILE
					    #define SHADER_API_MOBILE 1
					#endif
					#ifndef UNITY_HARDWARE_TIER2
					    #define UNITY_HARDWARE_TIER2 1
					#endif
					#ifndef UNITY_COLORSPACE_GAMMA
					    #define UNITY_COLORSPACE_GAMMA 1
					#endif
					#ifndef UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS
					    #define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#endif
					#ifndef UNITY_LIGHTMAP_DLDR_ENCODING
					    #define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#endif
					#ifndef UNITY_VERSION
					    #define UNITY_VERSION 201834
					#endif
					#ifndef SHADER_STAGE_VERTEX
					    #define SHADER_STAGE_VERTEX 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 30
					#endif
					#ifndef SHADER_AVAILABLE_INTERPOLATORS10
					    #define SHADER_AVAILABLE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_SAMPLELOD
					    #define SHADER_AVAILABLE_SAMPLELOD 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#define gl_Vertex _glesVertex
					attribute vec4 _glesVertex;
					#define gl_MultiTexCoord0 _glesMultiTexCoord0
					attribute vec4 _glesMultiTexCoord0;
					mat2 xll_transpose_mf2x2(mat2 m) {
					  return mat2( m[0][0], m[1][0], m[0][1], m[1][1]);
					}
					mat3 xll_transpose_mf3x3(mat3 m) {
					  return mat3( m[0][0], m[1][0], m[2][0],
					               m[0][1], m[1][1], m[2][1],
					               m[0][2], m[1][2], m[2][2]);
					}
					mat4 xll_transpose_mf4x4(mat4 m) {
					  return mat4( m[0][0], m[1][0], m[2][0], m[3][0],
					               m[0][1], m[1][1], m[2][1], m[3][1],
					               m[0][2], m[1][2], m[2][2], m[3][2],
					               m[0][3], m[1][3], m[2][3], m[3][3]);
					}
					#line 447
					struct v2f_vertex_lit {
					    highp vec2 uv;
					    lowp vec4 diff;
					    lowp vec4 spec;
					};
					#line 756
					struct v2f_img {
					    highp vec4 pos;
					    mediump vec2 uv;
					};
					#line 749
					struct appdata_img {
					    highp vec4 vertex;
					    mediump vec2 texcoord;
					};
					#line 40
					uniform highp vec4 _Time;
					uniform highp vec4 _SinTime;
					uniform highp vec4 _CosTime;
					uniform highp vec4 unity_DeltaTime;
					#line 46
					uniform highp vec3 _WorldSpaceCameraPos;
					#line 53
					uniform highp vec4 _ProjectionParams;
					#line 59
					uniform highp vec4 _ScreenParams;
					#line 71
					uniform highp vec4 _ZBufferParams;
					#line 77
					uniform highp vec4 unity_OrthoParams;
					#line 86
					uniform highp vec4 unity_CameraWorldClipPlanes[6];
					#line 92
					uniform highp mat4 unity_CameraProjection;
					uniform highp mat4 unity_CameraInvProjection;
					uniform highp mat4 unity_WorldToCamera;
					uniform highp mat4 unity_CameraToWorld;
					#line 108
					uniform highp vec4 _WorldSpaceLightPos0;
					uniform highp vec4 _LightPositionRange;
					#line 112
					uniform highp vec4 _LightProjectionParams;
					uniform highp vec4 unity_4LightPosX0;
					uniform highp vec4 unity_4LightPosY0;
					#line 116
					uniform highp vec4 unity_4LightPosZ0;
					uniform mediump vec4 unity_4LightAtten0;
					uniform mediump vec4 unity_LightColor[8];
					#line 122
					uniform highp vec4 unity_LightPosition[8];
					#line 127
					uniform mediump vec4 unity_LightAtten[8];
					uniform highp vec4 unity_SpotDirection[8];
					#line 131
					uniform mediump vec4 unity_SHAr;
					uniform mediump vec4 unity_SHAg;
					uniform mediump vec4 unity_SHAb;
					uniform mediump vec4 unity_SHBr;
					#line 135
					uniform mediump vec4 unity_SHBg;
					uniform mediump vec4 unity_SHBb;
					uniform mediump vec4 unity_SHC;
					#line 140
					uniform lowp vec4 unity_OcclusionMaskSelector;
					uniform lowp vec4 unity_ProbesOcclusion;
					#line 145
					uniform mediump vec3 unity_LightColor0;
					uniform mediump vec3 unity_LightColor1;
					uniform mediump vec3 unity_LightColor2;
					uniform mediump vec3 unity_LightColor3;
					#line 152
					uniform highp vec4 unity_ShadowSplitSpheres[4];
					uniform highp vec4 unity_ShadowSplitSqRadii;
					uniform highp vec4 unity_LightShadowBias;
					uniform highp vec4 _LightSplitsNear;
					#line 156
					uniform highp vec4 _LightSplitsFar;
					uniform highp mat4 unity_WorldToShadow[4];
					uniform mediump vec4 _LightShadowData;
					uniform highp vec4 unity_ShadowFadeCenterAndType;
					#line 165
					uniform highp mat4 unity_ObjectToWorld;
					uniform highp mat4 unity_WorldToObject;
					uniform highp vec4 unity_LODFade;
					uniform highp vec4 unity_WorldTransformParams;
					#line 206
					uniform highp mat4 glstate_matrix_transpose_modelview0;
					#line 214
					uniform lowp vec4 glstate_lightmodel_ambient;
					uniform lowp vec4 unity_AmbientSky;
					uniform lowp vec4 unity_AmbientEquator;
					uniform lowp vec4 unity_AmbientGround;
					#line 218
					uniform lowp vec4 unity_IndirectSpecColor;
					uniform highp mat4 glstate_matrix_projection;
					#line 222
					uniform highp mat4 unity_MatrixV;
					uniform highp mat4 unity_MatrixInvV;
					uniform highp mat4 unity_MatrixVP;
					uniform highp int unity_StereoEyeIndex;
					#line 228
					uniform lowp vec4 unity_ShadowColor;
					#line 235
					uniform lowp vec4 unity_FogColor;
					#line 240
					uniform highp vec4 unity_FogParams;
					#line 248
					uniform mediump sampler2D unity_Lightmap;
					uniform mediump sampler2D unity_LightmapInd;
					#line 252
					uniform sampler2D unity_ShadowMask;
					uniform sampler2D unity_DynamicLightmap;
					#line 256
					uniform sampler2D unity_DynamicDirectionality;
					uniform sampler2D unity_DynamicNormal;
					#line 260
					uniform highp vec4 unity_LightmapST;
					uniform highp vec4 unity_DynamicLightmapST;
					#line 268
					uniform samplerCube unity_SpecCube0;
					uniform samplerCube unity_SpecCube1;
					#line 272
					uniform highp vec4 unity_SpecCube0_BoxMax;
					uniform highp vec4 unity_SpecCube0_BoxMin;
					uniform highp vec4 unity_SpecCube0_ProbePosition;
					uniform mediump vec4 unity_SpecCube0_HDR;
					#line 277
					uniform highp vec4 unity_SpecCube1_BoxMax;
					uniform highp vec4 unity_SpecCube1_BoxMin;
					uniform highp vec4 unity_SpecCube1_ProbePosition;
					uniform mediump vec4 unity_SpecCube1_HDR;
					#line 317
					highp mat4 unity_MatrixMVP;
					highp mat4 unity_MatrixMV;
					highp mat4 unity_MatrixTMV;
					highp mat4 unity_MatrixITMV;
					#line 8
					#line 30
					#line 44
					#line 84
					#line 93
					#line 103
					#line 112
					#line 124
					#line 135
					#line 141
					#line 147
					#line 151
					#line 157
					#line 163
					#line 169
					#line 175
					#line 186
					#line 201
					#line 208
					#line 223
					#line 230
					#line 237
					#line 255
					#line 291
					#line 320
					#line 326
					#line 339
					#line 357
					#line 373
					#line 427
					#line 453
					#line 464
					#line 473
					#line 480
					#line 485
					#line 502
					#line 522
					#line 537
					#line 543
					#line 554
					uniform mediump vec4 unity_Lightmap_HDR;
					uniform mediump vec4 unity_DynamicLightmap_HDR;
					#line 568
					#line 578
					#line 593
					#line 602
					#line 609
					#line 618
					#line 626
					#line 635
					#line 654
					#line 660
					#line 670
					#line 680
					#line 691
					#line 696
					#line 702
					#line 707
					#line 764
					#line 770
					#line 785
					#line 816
					#line 830
					#line 834
					#line 840
					#line 849
					#line 859
					#line 885
					#line 891
					#line 7
					uniform sampler2D _MainTex;
					uniform lowp sampler3D _LookupTex3D;
					uniform sampler2D _LookupTex2D;
					uniform highp vec4 _Params;
					#line 17
					#line 23
					#line 29
					#line 35
					#line 41
					#line 47
					#line 67
					#line 91
					#line 97
					#line 44
					highp vec4 UnityObjectToClipPos( in highp vec3 pos ) {
					    #line 50
					    return (unity_MatrixVP * (unity_ObjectToWorld * vec4( pos, 1.0)));
					}
					#line 53
					highp vec4 UnityObjectToClipPos( in highp vec4 pos ) {
					    #line 55
					    return UnityObjectToClipPos( pos.xyz);
					}
					#line 770
					v2f_img vert_img( in appdata_img v ) {
					    v2f_img o;
					    #line 777
					    o.pos = UnityObjectToClipPos( v.vertex);
					    o.uv = v.texcoord;
					    return o;
					}
					varying mediump vec2 xlv_TEXCOORD0;
					void main() {
					unity_MatrixMVP = (unity_MatrixVP * unity_ObjectToWorld);
					unity_MatrixMV = (unity_MatrixV * unity_ObjectToWorld);
					unity_MatrixTMV = xll_transpose_mf4x4(unity_MatrixMV);
					unity_MatrixITMV = xll_transpose_mf4x4((unity_WorldToObject * unity_MatrixInvV));
					    v2f_img xl_retval;
					    appdata_img xlt_v;
					    xlt_v.vertex = vec4(gl_Vertex);
					    xlt_v.texcoord = vec2(gl_MultiTexCoord0);
					    xl_retval = vert_img( xlt_v);
					    gl_Position = vec4(xl_retval.pos);
					    xlv_TEXCOORD0 = vec2(xl_retval.uv);
					}
					/* HLSL2GLSL - NOTE: GLSL optimization failed
					(9,1): error: invalid type `sampler3D' in declaration of `_LookupTex3D'
					*/
					
					#endif
					#ifdef FRAGMENT
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 30
					#endif
					#ifndef SHADER_REQUIRE_INTERPOLATORS10
					    #define SHADER_REQUIRE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_REQUIRE_SAMPLELOD
					    #define SHADER_REQUIRE_SAMPLELOD 1
					#endif
					#ifndef SHADER_REQUIRE_FRAGCOORD
					    #define SHADER_REQUIRE_FRAGCOORD 1
					#endif
					#ifndef UNITY_NO_DXT5nm
					    #define UNITY_NO_DXT5nm 1
					#endif
					#ifndef UNITY_NO_RGBM
					    #define UNITY_NO_RGBM 1
					#endif
					#ifndef UNITY_ENABLE_REFLECTION_BUFFERS
					    #define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#endif
					#ifndef UNITY_FRAMEBUFFER_FETCH_AVAILABLE
					    #define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#endif
					#ifndef UNITY_NO_CUBEMAP_ARRAY
					    #define UNITY_NO_CUBEMAP_ARRAY 1
					#endif
					#ifndef UNITY_NO_SCREENSPACE_SHADOWS
					    #define UNITY_NO_SCREENSPACE_SHADOWS 1
					#endif
					#ifndef UNITY_PBS_USE_BRDF2
					    #define UNITY_PBS_USE_BRDF2 1
					#endif
					#ifndef SHADER_API_MOBILE
					    #define SHADER_API_MOBILE 1
					#endif
					#ifndef UNITY_HARDWARE_TIER2
					    #define UNITY_HARDWARE_TIER2 1
					#endif
					#ifndef UNITY_COLORSPACE_GAMMA
					    #define UNITY_COLORSPACE_GAMMA 1
					#endif
					#ifndef UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS
					    #define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#endif
					#ifndef UNITY_LIGHTMAP_DLDR_ENCODING
					    #define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#endif
					#ifndef UNITY_VERSION
					    #define UNITY_VERSION 201834
					#endif
					#ifndef SHADER_STAGE_VERTEX
					    #define SHADER_STAGE_VERTEX 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 30
					#endif
					#ifndef SHADER_AVAILABLE_INTERPOLATORS10
					    #define SHADER_AVAILABLE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_SAMPLELOD
					    #define SHADER_AVAILABLE_SAMPLELOD 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					mat2 xll_transpose_mf2x2(mat2 m) {
					  return mat2( m[0][0], m[1][0], m[0][1], m[1][1]);
					}
					mat3 xll_transpose_mf3x3(mat3 m) {
					  return mat3( m[0][0], m[1][0], m[2][0],
					               m[0][1], m[1][1], m[2][1],
					               m[0][2], m[1][2], m[2][2]);
					}
					mat4 xll_transpose_mf4x4(mat4 m) {
					  return mat4( m[0][0], m[1][0], m[2][0], m[3][0],
					               m[0][1], m[1][1], m[2][1], m[3][1],
					               m[0][2], m[1][2], m[2][2], m[3][2],
					               m[0][3], m[1][3], m[2][3], m[3][3]);
					}
					float xll_saturate_f( float x) {
					  return clamp( x, 0.0, 1.0);
					}
					vec2 xll_saturate_vf2( vec2 x) {
					  return clamp( x, 0.0, 1.0);
					}
					vec3 xll_saturate_vf3( vec3 x) {
					  return clamp( x, 0.0, 1.0);
					}
					vec4 xll_saturate_vf4( vec4 x) {
					  return clamp( x, 0.0, 1.0);
					}
					mat2 xll_saturate_mf2x2(mat2 m) {
					  return mat2( clamp(m[0], 0.0, 1.0), clamp(m[1], 0.0, 1.0));
					}
					mat3 xll_saturate_mf3x3(mat3 m) {
					  return mat3( clamp(m[0], 0.0, 1.0), clamp(m[1], 0.0, 1.0), clamp(m[2], 0.0, 1.0));
					}
					mat4 xll_saturate_mf4x4(mat4 m) {
					  return mat4( clamp(m[0], 0.0, 1.0), clamp(m[1], 0.0, 1.0), clamp(m[2], 0.0, 1.0), clamp(m[3], 0.0, 1.0));
					}
					vec2 xll_vecTSel_vb2_vf2_vf2 (bvec2 a, vec2 b, vec2 c) {
					  return vec2 (a.x ? b.x : c.x, a.y ? b.y : c.y);
					}
					vec3 xll_vecTSel_vb3_vf3_vf3 (bvec3 a, vec3 b, vec3 c) {
					  return vec3 (a.x ? b.x : c.x, a.y ? b.y : c.y, a.z ? b.z : c.z);
					}
					vec4 xll_vecTSel_vb4_vf4_vf4 (bvec4 a, vec4 b, vec4 c) {
					  return vec4 (a.x ? b.x : c.x, a.y ? b.y : c.y, a.z ? b.z : c.z, a.w ? b.w : c.w);
					}
					#line 447
					struct v2f_vertex_lit {
					    highp vec2 uv;
					    lowp vec4 diff;
					    lowp vec4 spec;
					};
					#line 756
					struct v2f_img {
					    highp vec4 pos;
					    mediump vec2 uv;
					};
					#line 749
					struct appdata_img {
					    highp vec4 vertex;
					    mediump vec2 texcoord;
					};
					#line 40
					uniform highp vec4 _Time;
					uniform highp vec4 _SinTime;
					uniform highp vec4 _CosTime;
					uniform highp vec4 unity_DeltaTime;
					#line 46
					uniform highp vec3 _WorldSpaceCameraPos;
					#line 53
					uniform highp vec4 _ProjectionParams;
					#line 59
					uniform highp vec4 _ScreenParams;
					#line 71
					uniform highp vec4 _ZBufferParams;
					#line 77
					uniform highp vec4 unity_OrthoParams;
					#line 86
					uniform highp vec4 unity_CameraWorldClipPlanes[6];
					#line 92
					uniform highp mat4 unity_CameraProjection;
					uniform highp mat4 unity_CameraInvProjection;
					uniform highp mat4 unity_WorldToCamera;
					uniform highp mat4 unity_CameraToWorld;
					#line 108
					uniform highp vec4 _WorldSpaceLightPos0;
					uniform highp vec4 _LightPositionRange;
					#line 112
					uniform highp vec4 _LightProjectionParams;
					uniform highp vec4 unity_4LightPosX0;
					uniform highp vec4 unity_4LightPosY0;
					#line 116
					uniform highp vec4 unity_4LightPosZ0;
					uniform mediump vec4 unity_4LightAtten0;
					uniform mediump vec4 unity_LightColor[8];
					#line 122
					uniform highp vec4 unity_LightPosition[8];
					#line 127
					uniform mediump vec4 unity_LightAtten[8];
					uniform highp vec4 unity_SpotDirection[8];
					#line 131
					uniform mediump vec4 unity_SHAr;
					uniform mediump vec4 unity_SHAg;
					uniform mediump vec4 unity_SHAb;
					uniform mediump vec4 unity_SHBr;
					#line 135
					uniform mediump vec4 unity_SHBg;
					uniform mediump vec4 unity_SHBb;
					uniform mediump vec4 unity_SHC;
					#line 140
					uniform lowp vec4 unity_OcclusionMaskSelector;
					uniform lowp vec4 unity_ProbesOcclusion;
					#line 145
					uniform mediump vec3 unity_LightColor0;
					uniform mediump vec3 unity_LightColor1;
					uniform mediump vec3 unity_LightColor2;
					uniform mediump vec3 unity_LightColor3;
					#line 152
					uniform highp vec4 unity_ShadowSplitSpheres[4];
					uniform highp vec4 unity_ShadowSplitSqRadii;
					uniform highp vec4 unity_LightShadowBias;
					uniform highp vec4 _LightSplitsNear;
					#line 156
					uniform highp vec4 _LightSplitsFar;
					uniform highp mat4 unity_WorldToShadow[4];
					uniform mediump vec4 _LightShadowData;
					uniform highp vec4 unity_ShadowFadeCenterAndType;
					#line 165
					uniform highp mat4 unity_ObjectToWorld;
					uniform highp mat4 unity_WorldToObject;
					uniform highp vec4 unity_LODFade;
					uniform highp vec4 unity_WorldTransformParams;
					#line 206
					uniform highp mat4 glstate_matrix_transpose_modelview0;
					#line 214
					uniform lowp vec4 glstate_lightmodel_ambient;
					uniform lowp vec4 unity_AmbientSky;
					uniform lowp vec4 unity_AmbientEquator;
					uniform lowp vec4 unity_AmbientGround;
					#line 218
					uniform lowp vec4 unity_IndirectSpecColor;
					uniform highp mat4 glstate_matrix_projection;
					#line 222
					uniform highp mat4 unity_MatrixV;
					uniform highp mat4 unity_MatrixInvV;
					uniform highp mat4 unity_MatrixVP;
					uniform highp int unity_StereoEyeIndex;
					#line 228
					uniform lowp vec4 unity_ShadowColor;
					#line 235
					uniform lowp vec4 unity_FogColor;
					#line 240
					uniform highp vec4 unity_FogParams;
					#line 248
					uniform mediump sampler2D unity_Lightmap;
					uniform mediump sampler2D unity_LightmapInd;
					#line 252
					uniform sampler2D unity_ShadowMask;
					uniform sampler2D unity_DynamicLightmap;
					#line 256
					uniform sampler2D unity_DynamicDirectionality;
					uniform sampler2D unity_DynamicNormal;
					#line 260
					uniform highp vec4 unity_LightmapST;
					uniform highp vec4 unity_DynamicLightmapST;
					#line 268
					uniform samplerCube unity_SpecCube0;
					uniform samplerCube unity_SpecCube1;
					#line 272
					uniform highp vec4 unity_SpecCube0_BoxMax;
					uniform highp vec4 unity_SpecCube0_BoxMin;
					uniform highp vec4 unity_SpecCube0_ProbePosition;
					uniform mediump vec4 unity_SpecCube0_HDR;
					#line 277
					uniform highp vec4 unity_SpecCube1_BoxMax;
					uniform highp vec4 unity_SpecCube1_BoxMin;
					uniform highp vec4 unity_SpecCube1_ProbePosition;
					uniform mediump vec4 unity_SpecCube1_HDR;
					#line 317
					highp mat4 unity_MatrixMVP;
					highp mat4 unity_MatrixMV;
					highp mat4 unity_MatrixTMV;
					highp mat4 unity_MatrixITMV;
					#line 8
					#line 30
					#line 44
					#line 84
					#line 93
					#line 103
					#line 112
					#line 124
					#line 135
					#line 141
					#line 147
					#line 151
					#line 157
					#line 163
					#line 169
					#line 175
					#line 186
					#line 201
					#line 208
					#line 223
					#line 230
					#line 237
					#line 255
					#line 291
					#line 320
					#line 326
					#line 339
					#line 357
					#line 373
					#line 427
					#line 453
					#line 464
					#line 473
					#line 480
					#line 485
					#line 502
					#line 522
					#line 537
					#line 543
					#line 554
					uniform mediump vec4 unity_Lightmap_HDR;
					uniform mediump vec4 unity_DynamicLightmap_HDR;
					#line 568
					#line 578
					#line 593
					#line 602
					#line 609
					#line 618
					#line 626
					#line 635
					#line 654
					#line 660
					#line 670
					#line 680
					#line 691
					#line 696
					#line 702
					#line 707
					#line 764
					#line 770
					#line 785
					#line 816
					#line 830
					#line 834
					#line 840
					#line 849
					#line 859
					#line 885
					#line 891
					#line 7
					uniform sampler2D _MainTex;
					uniform lowp sampler3D _LookupTex3D;
					uniform sampler2D _LookupTex2D;
					uniform highp vec4 _Params;
					#line 17
					#line 23
					#line 29
					#line 35
					#line 41
					#line 47
					#line 67
					#line 91
					#line 97
					#line 29
					highp vec4 Linear( in highp vec4 color ) {
					    color.xyz = xll_vecTSel_vb3_vf3_vf3 (lessThanEqual( color.xyz, vec3( 0.0404482, 0.0404482, 0.0404482)), (color.xyz / 12.92321), pow( ((color.xyz + 0.055) * 0.9478672), vec3( 2.4)));
					    return color;
					}
					#line 17
					highp vec3 sRGB( in highp vec3 color ) {
					    color = xll_vecTSel_vb3_vf3_vf3 (lessThanEqual( color, vec3( 0.0031308, 0.0031308, 0.0031308)), (color * 12.92321), ((1.055 * pow( color, vec3( 0.41666))) - 0.055));
					    return color;
					}
					#line 41
					highp vec4 lookup_linear( in highp vec4 o ) {
					    o.xyz = texture3D( _LookupTex3D, ((sRGB( o.xyz) * _Params.x) + _Params.y)).xyz;
					    return Linear( o);
					}
					#line 47
					highp vec4 frag( in v2f_img i ) {
					    highp vec4 color = xll_saturate_vf4(texture2D( _MainTex, i.uv));
					    highp vec4 x;
					    #line 53
					    x = lookup_linear( color);
					    #line 63
					    return mix( color, x, vec4( _Params.z));
					}
					varying mediump vec2 xlv_TEXCOORD0;
					void main() {
					unity_MatrixMVP = (unity_MatrixVP * unity_ObjectToWorld);
					unity_MatrixMV = (unity_MatrixV * unity_ObjectToWorld);
					unity_MatrixTMV = xll_transpose_mf4x4(unity_MatrixMV);
					unity_MatrixITMV = xll_transpose_mf4x4((unity_WorldToObject * unity_MatrixInvV));
					    highp vec4 xl_retval;
					    v2f_img xlt_i;
					    xlt_i.pos = vec4(0.0);
					    xlt_i.uv = vec2(xlv_TEXCOORD0);
					    xl_retval = frag( xlt_i);
					    gl_FragData[0] = vec4(xl_retval);
					}
					/* HLSL2GLSL - NOTE: GLSL optimization failed
					(9,1): error: invalid type `sampler3D' in declaration of `_LookupTex3D'
					(43,21): error: `_LookupTex3D' undeclared
					(43,10): error: no matching function for call to `texture3D(error, vec3)'; candidates are:
					(43,10): error: type mismatch
					*/
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {
					"!!GLES
					#version 100
					
					#ifdef VERTEX
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 30
					#endif
					#ifndef SHADER_REQUIRE_INTERPOLATORS10
					    #define SHADER_REQUIRE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_REQUIRE_SAMPLELOD
					    #define SHADER_REQUIRE_SAMPLELOD 1
					#endif
					#ifndef SHADER_REQUIRE_FRAGCOORD
					    #define SHADER_REQUIRE_FRAGCOORD 1
					#endif
					#ifndef UNITY_NO_DXT5nm
					    #define UNITY_NO_DXT5nm 1
					#endif
					#ifndef UNITY_NO_RGBM
					    #define UNITY_NO_RGBM 1
					#endif
					#ifndef UNITY_ENABLE_REFLECTION_BUFFERS
					    #define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#endif
					#ifndef UNITY_FRAMEBUFFER_FETCH_AVAILABLE
					    #define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#endif
					#ifndef UNITY_NO_CUBEMAP_ARRAY
					    #define UNITY_NO_CUBEMAP_ARRAY 1
					#endif
					#ifndef UNITY_NO_SCREENSPACE_SHADOWS
					    #define UNITY_NO_SCREENSPACE_SHADOWS 1
					#endif
					#ifndef UNITY_PBS_USE_BRDF2
					    #define UNITY_PBS_USE_BRDF2 1
					#endif
					#ifndef SHADER_API_MOBILE
					    #define SHADER_API_MOBILE 1
					#endif
					#ifndef UNITY_HARDWARE_TIER3
					    #define UNITY_HARDWARE_TIER3 1
					#endif
					#ifndef UNITY_COLORSPACE_GAMMA
					    #define UNITY_COLORSPACE_GAMMA 1
					#endif
					#ifndef UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS
					    #define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#endif
					#ifndef UNITY_LIGHTMAP_DLDR_ENCODING
					    #define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#endif
					#ifndef UNITY_VERSION
					    #define UNITY_VERSION 201834
					#endif
					#ifndef SHADER_STAGE_VERTEX
					    #define SHADER_STAGE_VERTEX 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 30
					#endif
					#ifndef SHADER_AVAILABLE_INTERPOLATORS10
					    #define SHADER_AVAILABLE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_SAMPLELOD
					    #define SHADER_AVAILABLE_SAMPLELOD 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#define gl_Vertex _glesVertex
					attribute vec4 _glesVertex;
					#define gl_MultiTexCoord0 _glesMultiTexCoord0
					attribute vec4 _glesMultiTexCoord0;
					mat2 xll_transpose_mf2x2(mat2 m) {
					  return mat2( m[0][0], m[1][0], m[0][1], m[1][1]);
					}
					mat3 xll_transpose_mf3x3(mat3 m) {
					  return mat3( m[0][0], m[1][0], m[2][0],
					               m[0][1], m[1][1], m[2][1],
					               m[0][2], m[1][2], m[2][2]);
					}
					mat4 xll_transpose_mf4x4(mat4 m) {
					  return mat4( m[0][0], m[1][0], m[2][0], m[3][0],
					               m[0][1], m[1][1], m[2][1], m[3][1],
					               m[0][2], m[1][2], m[2][2], m[3][2],
					               m[0][3], m[1][3], m[2][3], m[3][3]);
					}
					#line 447
					struct v2f_vertex_lit {
					    highp vec2 uv;
					    lowp vec4 diff;
					    lowp vec4 spec;
					};
					#line 756
					struct v2f_img {
					    highp vec4 pos;
					    mediump vec2 uv;
					};
					#line 749
					struct appdata_img {
					    highp vec4 vertex;
					    mediump vec2 texcoord;
					};
					#line 40
					uniform highp vec4 _Time;
					uniform highp vec4 _SinTime;
					uniform highp vec4 _CosTime;
					uniform highp vec4 unity_DeltaTime;
					#line 46
					uniform highp vec3 _WorldSpaceCameraPos;
					#line 53
					uniform highp vec4 _ProjectionParams;
					#line 59
					uniform highp vec4 _ScreenParams;
					#line 71
					uniform highp vec4 _ZBufferParams;
					#line 77
					uniform highp vec4 unity_OrthoParams;
					#line 86
					uniform highp vec4 unity_CameraWorldClipPlanes[6];
					#line 92
					uniform highp mat4 unity_CameraProjection;
					uniform highp mat4 unity_CameraInvProjection;
					uniform highp mat4 unity_WorldToCamera;
					uniform highp mat4 unity_CameraToWorld;
					#line 108
					uniform highp vec4 _WorldSpaceLightPos0;
					uniform highp vec4 _LightPositionRange;
					#line 112
					uniform highp vec4 _LightProjectionParams;
					uniform highp vec4 unity_4LightPosX0;
					uniform highp vec4 unity_4LightPosY0;
					#line 116
					uniform highp vec4 unity_4LightPosZ0;
					uniform mediump vec4 unity_4LightAtten0;
					uniform mediump vec4 unity_LightColor[8];
					#line 122
					uniform highp vec4 unity_LightPosition[8];
					#line 127
					uniform mediump vec4 unity_LightAtten[8];
					uniform highp vec4 unity_SpotDirection[8];
					#line 131
					uniform mediump vec4 unity_SHAr;
					uniform mediump vec4 unity_SHAg;
					uniform mediump vec4 unity_SHAb;
					uniform mediump vec4 unity_SHBr;
					#line 135
					uniform mediump vec4 unity_SHBg;
					uniform mediump vec4 unity_SHBb;
					uniform mediump vec4 unity_SHC;
					#line 140
					uniform lowp vec4 unity_OcclusionMaskSelector;
					uniform lowp vec4 unity_ProbesOcclusion;
					#line 145
					uniform mediump vec3 unity_LightColor0;
					uniform mediump vec3 unity_LightColor1;
					uniform mediump vec3 unity_LightColor2;
					uniform mediump vec3 unity_LightColor3;
					#line 152
					uniform highp vec4 unity_ShadowSplitSpheres[4];
					uniform highp vec4 unity_ShadowSplitSqRadii;
					uniform highp vec4 unity_LightShadowBias;
					uniform highp vec4 _LightSplitsNear;
					#line 156
					uniform highp vec4 _LightSplitsFar;
					uniform highp mat4 unity_WorldToShadow[4];
					uniform mediump vec4 _LightShadowData;
					uniform highp vec4 unity_ShadowFadeCenterAndType;
					#line 165
					uniform highp mat4 unity_ObjectToWorld;
					uniform highp mat4 unity_WorldToObject;
					uniform highp vec4 unity_LODFade;
					uniform highp vec4 unity_WorldTransformParams;
					#line 206
					uniform highp mat4 glstate_matrix_transpose_modelview0;
					#line 214
					uniform lowp vec4 glstate_lightmodel_ambient;
					uniform lowp vec4 unity_AmbientSky;
					uniform lowp vec4 unity_AmbientEquator;
					uniform lowp vec4 unity_AmbientGround;
					#line 218
					uniform lowp vec4 unity_IndirectSpecColor;
					uniform highp mat4 glstate_matrix_projection;
					#line 222
					uniform highp mat4 unity_MatrixV;
					uniform highp mat4 unity_MatrixInvV;
					uniform highp mat4 unity_MatrixVP;
					uniform highp int unity_StereoEyeIndex;
					#line 228
					uniform lowp vec4 unity_ShadowColor;
					#line 235
					uniform lowp vec4 unity_FogColor;
					#line 240
					uniform highp vec4 unity_FogParams;
					#line 248
					uniform mediump sampler2D unity_Lightmap;
					uniform mediump sampler2D unity_LightmapInd;
					#line 252
					uniform sampler2D unity_ShadowMask;
					uniform sampler2D unity_DynamicLightmap;
					#line 256
					uniform sampler2D unity_DynamicDirectionality;
					uniform sampler2D unity_DynamicNormal;
					#line 260
					uniform highp vec4 unity_LightmapST;
					uniform highp vec4 unity_DynamicLightmapST;
					#line 268
					uniform samplerCube unity_SpecCube0;
					uniform samplerCube unity_SpecCube1;
					#line 272
					uniform highp vec4 unity_SpecCube0_BoxMax;
					uniform highp vec4 unity_SpecCube0_BoxMin;
					uniform highp vec4 unity_SpecCube0_ProbePosition;
					uniform mediump vec4 unity_SpecCube0_HDR;
					#line 277
					uniform highp vec4 unity_SpecCube1_BoxMax;
					uniform highp vec4 unity_SpecCube1_BoxMin;
					uniform highp vec4 unity_SpecCube1_ProbePosition;
					uniform mediump vec4 unity_SpecCube1_HDR;
					#line 317
					highp mat4 unity_MatrixMVP;
					highp mat4 unity_MatrixMV;
					highp mat4 unity_MatrixTMV;
					highp mat4 unity_MatrixITMV;
					#line 8
					#line 30
					#line 44
					#line 84
					#line 93
					#line 103
					#line 112
					#line 124
					#line 135
					#line 141
					#line 147
					#line 151
					#line 157
					#line 163
					#line 169
					#line 175
					#line 186
					#line 201
					#line 208
					#line 223
					#line 230
					#line 237
					#line 255
					#line 291
					#line 320
					#line 326
					#line 339
					#line 357
					#line 373
					#line 427
					#line 453
					#line 464
					#line 473
					#line 480
					#line 485
					#line 502
					#line 522
					#line 537
					#line 543
					#line 554
					uniform mediump vec4 unity_Lightmap_HDR;
					uniform mediump vec4 unity_DynamicLightmap_HDR;
					#line 568
					#line 578
					#line 593
					#line 602
					#line 609
					#line 618
					#line 626
					#line 635
					#line 654
					#line 660
					#line 670
					#line 680
					#line 691
					#line 696
					#line 702
					#line 707
					#line 764
					#line 770
					#line 785
					#line 816
					#line 830
					#line 834
					#line 840
					#line 849
					#line 859
					#line 885
					#line 891
					#line 7
					uniform sampler2D _MainTex;
					uniform lowp sampler3D _LookupTex3D;
					uniform sampler2D _LookupTex2D;
					uniform highp vec4 _Params;
					#line 17
					#line 23
					#line 29
					#line 35
					#line 41
					#line 47
					#line 67
					#line 91
					#line 97
					#line 44
					highp vec4 UnityObjectToClipPos( in highp vec3 pos ) {
					    #line 50
					    return (unity_MatrixVP * (unity_ObjectToWorld * vec4( pos, 1.0)));
					}
					#line 53
					highp vec4 UnityObjectToClipPos( in highp vec4 pos ) {
					    #line 55
					    return UnityObjectToClipPos( pos.xyz);
					}
					#line 770
					v2f_img vert_img( in appdata_img v ) {
					    v2f_img o;
					    #line 777
					    o.pos = UnityObjectToClipPos( v.vertex);
					    o.uv = v.texcoord;
					    return o;
					}
					varying mediump vec2 xlv_TEXCOORD0;
					void main() {
					unity_MatrixMVP = (unity_MatrixVP * unity_ObjectToWorld);
					unity_MatrixMV = (unity_MatrixV * unity_ObjectToWorld);
					unity_MatrixTMV = xll_transpose_mf4x4(unity_MatrixMV);
					unity_MatrixITMV = xll_transpose_mf4x4((unity_WorldToObject * unity_MatrixInvV));
					    v2f_img xl_retval;
					    appdata_img xlt_v;
					    xlt_v.vertex = vec4(gl_Vertex);
					    xlt_v.texcoord = vec2(gl_MultiTexCoord0);
					    xl_retval = vert_img( xlt_v);
					    gl_Position = vec4(xl_retval.pos);
					    xlv_TEXCOORD0 = vec2(xl_retval.uv);
					}
					/* HLSL2GLSL - NOTE: GLSL optimization failed
					(9,1): error: invalid type `sampler3D' in declaration of `_LookupTex3D'
					*/
					
					#endif
					#ifdef FRAGMENT
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 30
					#endif
					#ifndef SHADER_REQUIRE_INTERPOLATORS10
					    #define SHADER_REQUIRE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_REQUIRE_SAMPLELOD
					    #define SHADER_REQUIRE_SAMPLELOD 1
					#endif
					#ifndef SHADER_REQUIRE_FRAGCOORD
					    #define SHADER_REQUIRE_FRAGCOORD 1
					#endif
					#ifndef UNITY_NO_DXT5nm
					    #define UNITY_NO_DXT5nm 1
					#endif
					#ifndef UNITY_NO_RGBM
					    #define UNITY_NO_RGBM 1
					#endif
					#ifndef UNITY_ENABLE_REFLECTION_BUFFERS
					    #define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#endif
					#ifndef UNITY_FRAMEBUFFER_FETCH_AVAILABLE
					    #define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#endif
					#ifndef UNITY_NO_CUBEMAP_ARRAY
					    #define UNITY_NO_CUBEMAP_ARRAY 1
					#endif
					#ifndef UNITY_NO_SCREENSPACE_SHADOWS
					    #define UNITY_NO_SCREENSPACE_SHADOWS 1
					#endif
					#ifndef UNITY_PBS_USE_BRDF2
					    #define UNITY_PBS_USE_BRDF2 1
					#endif
					#ifndef SHADER_API_MOBILE
					    #define SHADER_API_MOBILE 1
					#endif
					#ifndef UNITY_HARDWARE_TIER3
					    #define UNITY_HARDWARE_TIER3 1
					#endif
					#ifndef UNITY_COLORSPACE_GAMMA
					    #define UNITY_COLORSPACE_GAMMA 1
					#endif
					#ifndef UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS
					    #define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#endif
					#ifndef UNITY_LIGHTMAP_DLDR_ENCODING
					    #define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#endif
					#ifndef UNITY_VERSION
					    #define UNITY_VERSION 201834
					#endif
					#ifndef SHADER_STAGE_VERTEX
					    #define SHADER_STAGE_VERTEX 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 30
					#endif
					#ifndef SHADER_AVAILABLE_INTERPOLATORS10
					    #define SHADER_AVAILABLE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_SAMPLELOD
					    #define SHADER_AVAILABLE_SAMPLELOD 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					mat2 xll_transpose_mf2x2(mat2 m) {
					  return mat2( m[0][0], m[1][0], m[0][1], m[1][1]);
					}
					mat3 xll_transpose_mf3x3(mat3 m) {
					  return mat3( m[0][0], m[1][0], m[2][0],
					               m[0][1], m[1][1], m[2][1],
					               m[0][2], m[1][2], m[2][2]);
					}
					mat4 xll_transpose_mf4x4(mat4 m) {
					  return mat4( m[0][0], m[1][0], m[2][0], m[3][0],
					               m[0][1], m[1][1], m[2][1], m[3][1],
					               m[0][2], m[1][2], m[2][2], m[3][2],
					               m[0][3], m[1][3], m[2][3], m[3][3]);
					}
					float xll_saturate_f( float x) {
					  return clamp( x, 0.0, 1.0);
					}
					vec2 xll_saturate_vf2( vec2 x) {
					  return clamp( x, 0.0, 1.0);
					}
					vec3 xll_saturate_vf3( vec3 x) {
					  return clamp( x, 0.0, 1.0);
					}
					vec4 xll_saturate_vf4( vec4 x) {
					  return clamp( x, 0.0, 1.0);
					}
					mat2 xll_saturate_mf2x2(mat2 m) {
					  return mat2( clamp(m[0], 0.0, 1.0), clamp(m[1], 0.0, 1.0));
					}
					mat3 xll_saturate_mf3x3(mat3 m) {
					  return mat3( clamp(m[0], 0.0, 1.0), clamp(m[1], 0.0, 1.0), clamp(m[2], 0.0, 1.0));
					}
					mat4 xll_saturate_mf4x4(mat4 m) {
					  return mat4( clamp(m[0], 0.0, 1.0), clamp(m[1], 0.0, 1.0), clamp(m[2], 0.0, 1.0), clamp(m[3], 0.0, 1.0));
					}
					vec2 xll_vecTSel_vb2_vf2_vf2 (bvec2 a, vec2 b, vec2 c) {
					  return vec2 (a.x ? b.x : c.x, a.y ? b.y : c.y);
					}
					vec3 xll_vecTSel_vb3_vf3_vf3 (bvec3 a, vec3 b, vec3 c) {
					  return vec3 (a.x ? b.x : c.x, a.y ? b.y : c.y, a.z ? b.z : c.z);
					}
					vec4 xll_vecTSel_vb4_vf4_vf4 (bvec4 a, vec4 b, vec4 c) {
					  return vec4 (a.x ? b.x : c.x, a.y ? b.y : c.y, a.z ? b.z : c.z, a.w ? b.w : c.w);
					}
					#line 447
					struct v2f_vertex_lit {
					    highp vec2 uv;
					    lowp vec4 diff;
					    lowp vec4 spec;
					};
					#line 756
					struct v2f_img {
					    highp vec4 pos;
					    mediump vec2 uv;
					};
					#line 749
					struct appdata_img {
					    highp vec4 vertex;
					    mediump vec2 texcoord;
					};
					#line 40
					uniform highp vec4 _Time;
					uniform highp vec4 _SinTime;
					uniform highp vec4 _CosTime;
					uniform highp vec4 unity_DeltaTime;
					#line 46
					uniform highp vec3 _WorldSpaceCameraPos;
					#line 53
					uniform highp vec4 _ProjectionParams;
					#line 59
					uniform highp vec4 _ScreenParams;
					#line 71
					uniform highp vec4 _ZBufferParams;
					#line 77
					uniform highp vec4 unity_OrthoParams;
					#line 86
					uniform highp vec4 unity_CameraWorldClipPlanes[6];
					#line 92
					uniform highp mat4 unity_CameraProjection;
					uniform highp mat4 unity_CameraInvProjection;
					uniform highp mat4 unity_WorldToCamera;
					uniform highp mat4 unity_CameraToWorld;
					#line 108
					uniform highp vec4 _WorldSpaceLightPos0;
					uniform highp vec4 _LightPositionRange;
					#line 112
					uniform highp vec4 _LightProjectionParams;
					uniform highp vec4 unity_4LightPosX0;
					uniform highp vec4 unity_4LightPosY0;
					#line 116
					uniform highp vec4 unity_4LightPosZ0;
					uniform mediump vec4 unity_4LightAtten0;
					uniform mediump vec4 unity_LightColor[8];
					#line 122
					uniform highp vec4 unity_LightPosition[8];
					#line 127
					uniform mediump vec4 unity_LightAtten[8];
					uniform highp vec4 unity_SpotDirection[8];
					#line 131
					uniform mediump vec4 unity_SHAr;
					uniform mediump vec4 unity_SHAg;
					uniform mediump vec4 unity_SHAb;
					uniform mediump vec4 unity_SHBr;
					#line 135
					uniform mediump vec4 unity_SHBg;
					uniform mediump vec4 unity_SHBb;
					uniform mediump vec4 unity_SHC;
					#line 140
					uniform lowp vec4 unity_OcclusionMaskSelector;
					uniform lowp vec4 unity_ProbesOcclusion;
					#line 145
					uniform mediump vec3 unity_LightColor0;
					uniform mediump vec3 unity_LightColor1;
					uniform mediump vec3 unity_LightColor2;
					uniform mediump vec3 unity_LightColor3;
					#line 152
					uniform highp vec4 unity_ShadowSplitSpheres[4];
					uniform highp vec4 unity_ShadowSplitSqRadii;
					uniform highp vec4 unity_LightShadowBias;
					uniform highp vec4 _LightSplitsNear;
					#line 156
					uniform highp vec4 _LightSplitsFar;
					uniform highp mat4 unity_WorldToShadow[4];
					uniform mediump vec4 _LightShadowData;
					uniform highp vec4 unity_ShadowFadeCenterAndType;
					#line 165
					uniform highp mat4 unity_ObjectToWorld;
					uniform highp mat4 unity_WorldToObject;
					uniform highp vec4 unity_LODFade;
					uniform highp vec4 unity_WorldTransformParams;
					#line 206
					uniform highp mat4 glstate_matrix_transpose_modelview0;
					#line 214
					uniform lowp vec4 glstate_lightmodel_ambient;
					uniform lowp vec4 unity_AmbientSky;
					uniform lowp vec4 unity_AmbientEquator;
					uniform lowp vec4 unity_AmbientGround;
					#line 218
					uniform lowp vec4 unity_IndirectSpecColor;
					uniform highp mat4 glstate_matrix_projection;
					#line 222
					uniform highp mat4 unity_MatrixV;
					uniform highp mat4 unity_MatrixInvV;
					uniform highp mat4 unity_MatrixVP;
					uniform highp int unity_StereoEyeIndex;
					#line 228
					uniform lowp vec4 unity_ShadowColor;
					#line 235
					uniform lowp vec4 unity_FogColor;
					#line 240
					uniform highp vec4 unity_FogParams;
					#line 248
					uniform mediump sampler2D unity_Lightmap;
					uniform mediump sampler2D unity_LightmapInd;
					#line 252
					uniform sampler2D unity_ShadowMask;
					uniform sampler2D unity_DynamicLightmap;
					#line 256
					uniform sampler2D unity_DynamicDirectionality;
					uniform sampler2D unity_DynamicNormal;
					#line 260
					uniform highp vec4 unity_LightmapST;
					uniform highp vec4 unity_DynamicLightmapST;
					#line 268
					uniform samplerCube unity_SpecCube0;
					uniform samplerCube unity_SpecCube1;
					#line 272
					uniform highp vec4 unity_SpecCube0_BoxMax;
					uniform highp vec4 unity_SpecCube0_BoxMin;
					uniform highp vec4 unity_SpecCube0_ProbePosition;
					uniform mediump vec4 unity_SpecCube0_HDR;
					#line 277
					uniform highp vec4 unity_SpecCube1_BoxMax;
					uniform highp vec4 unity_SpecCube1_BoxMin;
					uniform highp vec4 unity_SpecCube1_ProbePosition;
					uniform mediump vec4 unity_SpecCube1_HDR;
					#line 317
					highp mat4 unity_MatrixMVP;
					highp mat4 unity_MatrixMV;
					highp mat4 unity_MatrixTMV;
					highp mat4 unity_MatrixITMV;
					#line 8
					#line 30
					#line 44
					#line 84
					#line 93
					#line 103
					#line 112
					#line 124
					#line 135
					#line 141
					#line 147
					#line 151
					#line 157
					#line 163
					#line 169
					#line 175
					#line 186
					#line 201
					#line 208
					#line 223
					#line 230
					#line 237
					#line 255
					#line 291
					#line 320
					#line 326
					#line 339
					#line 357
					#line 373
					#line 427
					#line 453
					#line 464
					#line 473
					#line 480
					#line 485
					#line 502
					#line 522
					#line 537
					#line 543
					#line 554
					uniform mediump vec4 unity_Lightmap_HDR;
					uniform mediump vec4 unity_DynamicLightmap_HDR;
					#line 568
					#line 578
					#line 593
					#line 602
					#line 609
					#line 618
					#line 626
					#line 635
					#line 654
					#line 660
					#line 670
					#line 680
					#line 691
					#line 696
					#line 702
					#line 707
					#line 764
					#line 770
					#line 785
					#line 816
					#line 830
					#line 834
					#line 840
					#line 849
					#line 859
					#line 885
					#line 891
					#line 7
					uniform sampler2D _MainTex;
					uniform lowp sampler3D _LookupTex3D;
					uniform sampler2D _LookupTex2D;
					uniform highp vec4 _Params;
					#line 17
					#line 23
					#line 29
					#line 35
					#line 41
					#line 47
					#line 67
					#line 91
					#line 97
					#line 29
					highp vec4 Linear( in highp vec4 color ) {
					    color.xyz = xll_vecTSel_vb3_vf3_vf3 (lessThanEqual( color.xyz, vec3( 0.0404482, 0.0404482, 0.0404482)), (color.xyz / 12.92321), pow( ((color.xyz + 0.055) * 0.9478672), vec3( 2.4)));
					    return color;
					}
					#line 17
					highp vec3 sRGB( in highp vec3 color ) {
					    color = xll_vecTSel_vb3_vf3_vf3 (lessThanEqual( color, vec3( 0.0031308, 0.0031308, 0.0031308)), (color * 12.92321), ((1.055 * pow( color, vec3( 0.41666))) - 0.055));
					    return color;
					}
					#line 41
					highp vec4 lookup_linear( in highp vec4 o ) {
					    o.xyz = texture3D( _LookupTex3D, ((sRGB( o.xyz) * _Params.x) + _Params.y)).xyz;
					    return Linear( o);
					}
					#line 47
					highp vec4 frag( in v2f_img i ) {
					    highp vec4 color = xll_saturate_vf4(texture2D( _MainTex, i.uv));
					    highp vec4 x;
					    #line 53
					    x = lookup_linear( color);
					    #line 63
					    return mix( color, x, vec4( _Params.z));
					}
					varying mediump vec2 xlv_TEXCOORD0;
					void main() {
					unity_MatrixMVP = (unity_MatrixVP * unity_ObjectToWorld);
					unity_MatrixMV = (unity_MatrixV * unity_ObjectToWorld);
					unity_MatrixTMV = xll_transpose_mf4x4(unity_MatrixMV);
					unity_MatrixITMV = xll_transpose_mf4x4((unity_WorldToObject * unity_MatrixInvV));
					    highp vec4 xl_retval;
					    v2f_img xlt_i;
					    xlt_i.pos = vec4(0.0);
					    xlt_i.uv = vec2(xlv_TEXCOORD0);
					    xl_retval = frag( xlt_i);
					    gl_FragData[0] = vec4(xl_retval);
					}
					/* HLSL2GLSL - NOTE: GLSL optimization failed
					(9,1): error: invalid type `sampler3D' in declaration of `_LookupTex3D'
					(43,21): error: `_LookupTex3D' undeclared
					(43,10): error: no matching function for call to `texture3D(error, vec3)'; candidates are:
					(43,10): error: type mismatch
					*/
					
					#endif"
				}
				SubProgram "gles3 hw_tier00 " {
					"!!GLES3
					#ifdef VERTEX
					#version 300 es
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					in highp vec4 in_POSITION0;
					in mediump vec2 in_TEXCOORD0;
					out mediump vec2 vs_TEXCOORD0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					void main()
					{
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy;
					    return;
					}
					
					#endif
					#ifdef FRAGMENT
					#version 300 es
					
					precision highp int;
					uniform 	vec4 _Params;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler3D _LookupTex3D;
					in mediump vec2 vs_TEXCOORD0;
					layout(location = 0) out highp vec4 SV_Target0;
					mediump vec4 u_xlat16_0;
					lowp vec4 u_xlat10_0;
					vec4 u_xlat1;
					mediump vec3 u_xlat16_1;
					vec3 u_xlat2;
					bvec3 u_xlatb2;
					vec3 u_xlat3;
					bvec3 u_xlatb3;
					void main()
					{
					    u_xlat10_0 = texture(_MainTex, vs_TEXCOORD0.xy);
					    u_xlat16_0 = u_xlat10_0;
					#ifdef UNITY_ADRENO_ES3
					    u_xlat16_0 = min(max(u_xlat16_0, 0.0), 1.0);
					#else
					    u_xlat16_0 = clamp(u_xlat16_0, 0.0, 1.0);
					#endif
					    u_xlat16_1.xyz = log2(u_xlat16_0.xyz);
					    u_xlat16_1.xyz = u_xlat16_1.xyz * vec3(0.416660011, 0.416660011, 0.416660011);
					    u_xlat16_1.xyz = exp2(u_xlat16_1.xyz);
					    u_xlat1.xyz = u_xlat16_1.xyz * vec3(1.05499995, 1.05499995, 1.05499995) + vec3(-0.0549999997, -0.0549999997, -0.0549999997);
					    u_xlatb2.xyz = greaterThanEqual(vec4(0.00313080009, 0.00313080009, 0.00313080009, 0.0), u_xlat16_0.xyzx).xyz;
					    u_xlat3.xyz = u_xlat16_0.xyz * vec3(12.9232101, 12.9232101, 12.9232101);
					    {
					        vec4 hlslcc_movcTemp = u_xlat1;
					        u_xlat1.x = (u_xlatb2.x) ? u_xlat3.x : hlslcc_movcTemp.x;
					        u_xlat1.y = (u_xlatb2.y) ? u_xlat3.y : hlslcc_movcTemp.y;
					        u_xlat1.z = (u_xlatb2.z) ? u_xlat3.z : hlslcc_movcTemp.z;
					    }
					    u_xlat1.xyz = u_xlat1.xyz * _Params.xxx + _Params.yyy;
					    u_xlat1.xyz = texture(_LookupTex3D, u_xlat1.xyz).xyz;
					    u_xlat2.xyz = u_xlat1.xyz + vec3(0.0549999997, 0.0549999997, 0.0549999997);
					    u_xlat2.xyz = u_xlat2.xyz * vec3(0.947867215, 0.947867215, 0.947867215);
					    u_xlat2.xyz = log2(u_xlat2.xyz);
					    u_xlat2.xyz = u_xlat2.xyz * vec3(2.4000001, 2.4000001, 2.4000001);
					    u_xlat2.xyz = exp2(u_xlat2.xyz);
					    u_xlatb3.xyz = greaterThanEqual(vec4(0.0404482, 0.0404482, 0.0404482, 0.0), u_xlat1.xyzx).xyz;
					    u_xlat1.xyz = u_xlat1.xyz * vec3(0.077380158, 0.077380158, 0.077380158);
					    {
					        vec4 hlslcc_movcTemp = u_xlat1;
					        u_xlat1.x = (u_xlatb3.x) ? hlslcc_movcTemp.x : u_xlat2.x;
					        u_xlat1.y = (u_xlatb3.y) ? hlslcc_movcTemp.y : u_xlat2.y;
					        u_xlat1.z = (u_xlatb3.z) ? hlslcc_movcTemp.z : u_xlat2.z;
					    }
					    u_xlat1.xyz = (-u_xlat16_0.xyz) + u_xlat1.xyz;
					    u_xlat1.w = 0.0;
					    SV_Target0 = _Params.zzzz * u_xlat1 + u_xlat16_0;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles3 hw_tier01 " {
					"!!GLES3
					#ifdef VERTEX
					#version 300 es
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					in highp vec4 in_POSITION0;
					in mediump vec2 in_TEXCOORD0;
					out mediump vec2 vs_TEXCOORD0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					void main()
					{
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy;
					    return;
					}
					
					#endif
					#ifdef FRAGMENT
					#version 300 es
					
					precision highp int;
					uniform 	vec4 _Params;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler3D _LookupTex3D;
					in mediump vec2 vs_TEXCOORD0;
					layout(location = 0) out highp vec4 SV_Target0;
					mediump vec4 u_xlat16_0;
					lowp vec4 u_xlat10_0;
					vec4 u_xlat1;
					mediump vec3 u_xlat16_1;
					vec3 u_xlat2;
					bvec3 u_xlatb2;
					vec3 u_xlat3;
					bvec3 u_xlatb3;
					void main()
					{
					    u_xlat10_0 = texture(_MainTex, vs_TEXCOORD0.xy);
					    u_xlat16_0 = u_xlat10_0;
					#ifdef UNITY_ADRENO_ES3
					    u_xlat16_0 = min(max(u_xlat16_0, 0.0), 1.0);
					#else
					    u_xlat16_0 = clamp(u_xlat16_0, 0.0, 1.0);
					#endif
					    u_xlat16_1.xyz = log2(u_xlat16_0.xyz);
					    u_xlat16_1.xyz = u_xlat16_1.xyz * vec3(0.416660011, 0.416660011, 0.416660011);
					    u_xlat16_1.xyz = exp2(u_xlat16_1.xyz);
					    u_xlat1.xyz = u_xlat16_1.xyz * vec3(1.05499995, 1.05499995, 1.05499995) + vec3(-0.0549999997, -0.0549999997, -0.0549999997);
					    u_xlatb2.xyz = greaterThanEqual(vec4(0.00313080009, 0.00313080009, 0.00313080009, 0.0), u_xlat16_0.xyzx).xyz;
					    u_xlat3.xyz = u_xlat16_0.xyz * vec3(12.9232101, 12.9232101, 12.9232101);
					    {
					        vec4 hlslcc_movcTemp = u_xlat1;
					        u_xlat1.x = (u_xlatb2.x) ? u_xlat3.x : hlslcc_movcTemp.x;
					        u_xlat1.y = (u_xlatb2.y) ? u_xlat3.y : hlslcc_movcTemp.y;
					        u_xlat1.z = (u_xlatb2.z) ? u_xlat3.z : hlslcc_movcTemp.z;
					    }
					    u_xlat1.xyz = u_xlat1.xyz * _Params.xxx + _Params.yyy;
					    u_xlat1.xyz = texture(_LookupTex3D, u_xlat1.xyz).xyz;
					    u_xlat2.xyz = u_xlat1.xyz + vec3(0.0549999997, 0.0549999997, 0.0549999997);
					    u_xlat2.xyz = u_xlat2.xyz * vec3(0.947867215, 0.947867215, 0.947867215);
					    u_xlat2.xyz = log2(u_xlat2.xyz);
					    u_xlat2.xyz = u_xlat2.xyz * vec3(2.4000001, 2.4000001, 2.4000001);
					    u_xlat2.xyz = exp2(u_xlat2.xyz);
					    u_xlatb3.xyz = greaterThanEqual(vec4(0.0404482, 0.0404482, 0.0404482, 0.0), u_xlat1.xyzx).xyz;
					    u_xlat1.xyz = u_xlat1.xyz * vec3(0.077380158, 0.077380158, 0.077380158);
					    {
					        vec4 hlslcc_movcTemp = u_xlat1;
					        u_xlat1.x = (u_xlatb3.x) ? hlslcc_movcTemp.x : u_xlat2.x;
					        u_xlat1.y = (u_xlatb3.y) ? hlslcc_movcTemp.y : u_xlat2.y;
					        u_xlat1.z = (u_xlatb3.z) ? hlslcc_movcTemp.z : u_xlat2.z;
					    }
					    u_xlat1.xyz = (-u_xlat16_0.xyz) + u_xlat1.xyz;
					    u_xlat1.w = 0.0;
					    SV_Target0 = _Params.zzzz * u_xlat1 + u_xlat16_0;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles3 hw_tier02 " {
					"!!GLES3
					#ifdef VERTEX
					#version 300 es
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					in highp vec4 in_POSITION0;
					in mediump vec2 in_TEXCOORD0;
					out mediump vec2 vs_TEXCOORD0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					void main()
					{
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy;
					    return;
					}
					
					#endif
					#ifdef FRAGMENT
					#version 300 es
					
					precision highp int;
					uniform 	vec4 _Params;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler3D _LookupTex3D;
					in mediump vec2 vs_TEXCOORD0;
					layout(location = 0) out highp vec4 SV_Target0;
					mediump vec4 u_xlat16_0;
					lowp vec4 u_xlat10_0;
					vec4 u_xlat1;
					mediump vec3 u_xlat16_1;
					vec3 u_xlat2;
					bvec3 u_xlatb2;
					vec3 u_xlat3;
					bvec3 u_xlatb3;
					void main()
					{
					    u_xlat10_0 = texture(_MainTex, vs_TEXCOORD0.xy);
					    u_xlat16_0 = u_xlat10_0;
					#ifdef UNITY_ADRENO_ES3
					    u_xlat16_0 = min(max(u_xlat16_0, 0.0), 1.0);
					#else
					    u_xlat16_0 = clamp(u_xlat16_0, 0.0, 1.0);
					#endif
					    u_xlat16_1.xyz = log2(u_xlat16_0.xyz);
					    u_xlat16_1.xyz = u_xlat16_1.xyz * vec3(0.416660011, 0.416660011, 0.416660011);
					    u_xlat16_1.xyz = exp2(u_xlat16_1.xyz);
					    u_xlat1.xyz = u_xlat16_1.xyz * vec3(1.05499995, 1.05499995, 1.05499995) + vec3(-0.0549999997, -0.0549999997, -0.0549999997);
					    u_xlatb2.xyz = greaterThanEqual(vec4(0.00313080009, 0.00313080009, 0.00313080009, 0.0), u_xlat16_0.xyzx).xyz;
					    u_xlat3.xyz = u_xlat16_0.xyz * vec3(12.9232101, 12.9232101, 12.9232101);
					    {
					        vec4 hlslcc_movcTemp = u_xlat1;
					        u_xlat1.x = (u_xlatb2.x) ? u_xlat3.x : hlslcc_movcTemp.x;
					        u_xlat1.y = (u_xlatb2.y) ? u_xlat3.y : hlslcc_movcTemp.y;
					        u_xlat1.z = (u_xlatb2.z) ? u_xlat3.z : hlslcc_movcTemp.z;
					    }
					    u_xlat1.xyz = u_xlat1.xyz * _Params.xxx + _Params.yyy;
					    u_xlat1.xyz = texture(_LookupTex3D, u_xlat1.xyz).xyz;
					    u_xlat2.xyz = u_xlat1.xyz + vec3(0.0549999997, 0.0549999997, 0.0549999997);
					    u_xlat2.xyz = u_xlat2.xyz * vec3(0.947867215, 0.947867215, 0.947867215);
					    u_xlat2.xyz = log2(u_xlat2.xyz);
					    u_xlat2.xyz = u_xlat2.xyz * vec3(2.4000001, 2.4000001, 2.4000001);
					    u_xlat2.xyz = exp2(u_xlat2.xyz);
					    u_xlatb3.xyz = greaterThanEqual(vec4(0.0404482, 0.0404482, 0.0404482, 0.0), u_xlat1.xyzx).xyz;
					    u_xlat1.xyz = u_xlat1.xyz * vec3(0.077380158, 0.077380158, 0.077380158);
					    {
					        vec4 hlslcc_movcTemp = u_xlat1;
					        u_xlat1.x = (u_xlatb3.x) ? hlslcc_movcTemp.x : u_xlat2.x;
					        u_xlat1.y = (u_xlatb3.y) ? hlslcc_movcTemp.y : u_xlat2.y;
					        u_xlat1.z = (u_xlatb3.z) ? hlslcc_movcTemp.z : u_xlat2.z;
					    }
					    u_xlat1.xyz = (-u_xlat16_0.xyz) + u_xlat1.xyz;
					    u_xlat1.w = 0.0;
					    SV_Target0 = _Params.zzzz * u_xlat1 + u_xlat16_0;
					    return;
					}
					
					#endif"
				}
			}
			Program "fp" {
				SubProgram "gles hw_tier00 " {
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					"!!GLES"
				}
				SubProgram "gles3 hw_tier00 " {
					"!!GLES3"
				}
				SubProgram "gles3 hw_tier01 " {
					"!!GLES3"
				}
				SubProgram "gles3 hw_tier02 " {
					"!!GLES3"
				}
			}
		}
		Pass {
			ZTest Always
			ZWrite Off
			Cull Off
			Fog {
				Mode Off
			}
			GpuProgramID 159984
			Program "vp" {
				SubProgram "gles hw_tier00 " {
					"!!GLES
					#version 100
					
					#ifdef VERTEX
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 30
					#endif
					#ifndef SHADER_REQUIRE_INTERPOLATORS10
					    #define SHADER_REQUIRE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_REQUIRE_SAMPLELOD
					    #define SHADER_REQUIRE_SAMPLELOD 1
					#endif
					#ifndef SHADER_REQUIRE_FRAGCOORD
					    #define SHADER_REQUIRE_FRAGCOORD 1
					#endif
					#ifndef UNITY_NO_DXT5nm
					    #define UNITY_NO_DXT5nm 1
					#endif
					#ifndef UNITY_NO_RGBM
					    #define UNITY_NO_RGBM 1
					#endif
					#ifndef UNITY_ENABLE_REFLECTION_BUFFERS
					    #define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#endif
					#ifndef UNITY_FRAMEBUFFER_FETCH_AVAILABLE
					    #define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#endif
					#ifndef UNITY_NO_CUBEMAP_ARRAY
					    #define UNITY_NO_CUBEMAP_ARRAY 1
					#endif
					#ifndef UNITY_NO_SCREENSPACE_SHADOWS
					    #define UNITY_NO_SCREENSPACE_SHADOWS 1
					#endif
					#ifndef UNITY_PBS_USE_BRDF3
					    #define UNITY_PBS_USE_BRDF3 1
					#endif
					#ifndef UNITY_NO_FULL_STANDARD_SHADER
					    #define UNITY_NO_FULL_STANDARD_SHADER 1
					#endif
					#ifndef SHADER_API_MOBILE
					    #define SHADER_API_MOBILE 1
					#endif
					#ifndef UNITY_HARDWARE_TIER1
					    #define UNITY_HARDWARE_TIER1 1
					#endif
					#ifndef UNITY_COLORSPACE_GAMMA
					    #define UNITY_COLORSPACE_GAMMA 1
					#endif
					#ifndef UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS
					    #define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#endif
					#ifndef UNITY_LIGHTMAP_DLDR_ENCODING
					    #define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#endif
					#ifndef UNITY_VERSION
					    #define UNITY_VERSION 201834
					#endif
					#ifndef SHADER_STAGE_VERTEX
					    #define SHADER_STAGE_VERTEX 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 30
					#endif
					#ifndef SHADER_AVAILABLE_INTERPOLATORS10
					    #define SHADER_AVAILABLE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_SAMPLELOD
					    #define SHADER_AVAILABLE_SAMPLELOD 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#define gl_Vertex _glesVertex
					attribute vec4 _glesVertex;
					#define gl_MultiTexCoord0 _glesMultiTexCoord0
					attribute vec4 _glesMultiTexCoord0;
					mat2 xll_transpose_mf2x2(mat2 m) {
					  return mat2( m[0][0], m[1][0], m[0][1], m[1][1]);
					}
					mat3 xll_transpose_mf3x3(mat3 m) {
					  return mat3( m[0][0], m[1][0], m[2][0],
					               m[0][1], m[1][1], m[2][1],
					               m[0][2], m[1][2], m[2][2]);
					}
					mat4 xll_transpose_mf4x4(mat4 m) {
					  return mat4( m[0][0], m[1][0], m[2][0], m[3][0],
					               m[0][1], m[1][1], m[2][1], m[3][1],
					               m[0][2], m[1][2], m[2][2], m[3][2],
					               m[0][3], m[1][3], m[2][3], m[3][3]);
					}
					#line 447
					struct v2f_vertex_lit {
					    highp vec2 uv;
					    lowp vec4 diff;
					    lowp vec4 spec;
					};
					#line 756
					struct v2f_img {
					    highp vec4 pos;
					    mediump vec2 uv;
					};
					#line 749
					struct appdata_img {
					    highp vec4 vertex;
					    mediump vec2 texcoord;
					};
					#line 40
					uniform highp vec4 _Time;
					uniform highp vec4 _SinTime;
					uniform highp vec4 _CosTime;
					uniform highp vec4 unity_DeltaTime;
					#line 46
					uniform highp vec3 _WorldSpaceCameraPos;
					#line 53
					uniform highp vec4 _ProjectionParams;
					#line 59
					uniform highp vec4 _ScreenParams;
					#line 71
					uniform highp vec4 _ZBufferParams;
					#line 77
					uniform highp vec4 unity_OrthoParams;
					#line 86
					uniform highp vec4 unity_CameraWorldClipPlanes[6];
					#line 92
					uniform highp mat4 unity_CameraProjection;
					uniform highp mat4 unity_CameraInvProjection;
					uniform highp mat4 unity_WorldToCamera;
					uniform highp mat4 unity_CameraToWorld;
					#line 108
					uniform highp vec4 _WorldSpaceLightPos0;
					uniform highp vec4 _LightPositionRange;
					#line 112
					uniform highp vec4 _LightProjectionParams;
					uniform highp vec4 unity_4LightPosX0;
					uniform highp vec4 unity_4LightPosY0;
					#line 116
					uniform highp vec4 unity_4LightPosZ0;
					uniform mediump vec4 unity_4LightAtten0;
					uniform mediump vec4 unity_LightColor[8];
					#line 122
					uniform highp vec4 unity_LightPosition[8];
					#line 127
					uniform mediump vec4 unity_LightAtten[8];
					uniform highp vec4 unity_SpotDirection[8];
					#line 131
					uniform mediump vec4 unity_SHAr;
					uniform mediump vec4 unity_SHAg;
					uniform mediump vec4 unity_SHAb;
					uniform mediump vec4 unity_SHBr;
					#line 135
					uniform mediump vec4 unity_SHBg;
					uniform mediump vec4 unity_SHBb;
					uniform mediump vec4 unity_SHC;
					#line 140
					uniform lowp vec4 unity_OcclusionMaskSelector;
					uniform lowp vec4 unity_ProbesOcclusion;
					#line 145
					uniform mediump vec3 unity_LightColor0;
					uniform mediump vec3 unity_LightColor1;
					uniform mediump vec3 unity_LightColor2;
					uniform mediump vec3 unity_LightColor3;
					#line 152
					uniform highp vec4 unity_ShadowSplitSpheres[4];
					uniform highp vec4 unity_ShadowSplitSqRadii;
					uniform highp vec4 unity_LightShadowBias;
					uniform highp vec4 _LightSplitsNear;
					#line 156
					uniform highp vec4 _LightSplitsFar;
					uniform highp mat4 unity_WorldToShadow[4];
					uniform mediump vec4 _LightShadowData;
					uniform highp vec4 unity_ShadowFadeCenterAndType;
					#line 165
					uniform highp mat4 unity_ObjectToWorld;
					uniform highp mat4 unity_WorldToObject;
					uniform highp vec4 unity_LODFade;
					uniform highp vec4 unity_WorldTransformParams;
					#line 206
					uniform highp mat4 glstate_matrix_transpose_modelview0;
					#line 214
					uniform lowp vec4 glstate_lightmodel_ambient;
					uniform lowp vec4 unity_AmbientSky;
					uniform lowp vec4 unity_AmbientEquator;
					uniform lowp vec4 unity_AmbientGround;
					#line 218
					uniform lowp vec4 unity_IndirectSpecColor;
					uniform highp mat4 glstate_matrix_projection;
					#line 222
					uniform highp mat4 unity_MatrixV;
					uniform highp mat4 unity_MatrixInvV;
					uniform highp mat4 unity_MatrixVP;
					uniform highp int unity_StereoEyeIndex;
					#line 228
					uniform lowp vec4 unity_ShadowColor;
					#line 235
					uniform lowp vec4 unity_FogColor;
					#line 240
					uniform highp vec4 unity_FogParams;
					#line 248
					uniform mediump sampler2D unity_Lightmap;
					uniform mediump sampler2D unity_LightmapInd;
					#line 252
					uniform sampler2D unity_ShadowMask;
					uniform sampler2D unity_DynamicLightmap;
					#line 256
					uniform sampler2D unity_DynamicDirectionality;
					uniform sampler2D unity_DynamicNormal;
					#line 260
					uniform highp vec4 unity_LightmapST;
					uniform highp vec4 unity_DynamicLightmapST;
					#line 268
					uniform samplerCube unity_SpecCube0;
					uniform samplerCube unity_SpecCube1;
					#line 272
					uniform highp vec4 unity_SpecCube0_BoxMax;
					uniform highp vec4 unity_SpecCube0_BoxMin;
					uniform highp vec4 unity_SpecCube0_ProbePosition;
					uniform mediump vec4 unity_SpecCube0_HDR;
					#line 277
					uniform highp vec4 unity_SpecCube1_BoxMax;
					uniform highp vec4 unity_SpecCube1_BoxMin;
					uniform highp vec4 unity_SpecCube1_ProbePosition;
					uniform mediump vec4 unity_SpecCube1_HDR;
					#line 317
					highp mat4 unity_MatrixMVP;
					highp mat4 unity_MatrixMV;
					highp mat4 unity_MatrixTMV;
					highp mat4 unity_MatrixITMV;
					#line 8
					#line 30
					#line 44
					#line 84
					#line 93
					#line 103
					#line 112
					#line 124
					#line 135
					#line 141
					#line 147
					#line 151
					#line 157
					#line 163
					#line 169
					#line 175
					#line 186
					#line 201
					#line 208
					#line 223
					#line 230
					#line 237
					#line 255
					#line 291
					#line 320
					#line 326
					#line 339
					#line 357
					#line 373
					#line 427
					#line 453
					#line 464
					#line 473
					#line 480
					#line 485
					#line 502
					#line 522
					#line 537
					#line 543
					#line 554
					uniform mediump vec4 unity_Lightmap_HDR;
					uniform mediump vec4 unity_DynamicLightmap_HDR;
					#line 568
					#line 578
					#line 593
					#line 602
					#line 609
					#line 618
					#line 626
					#line 635
					#line 654
					#line 660
					#line 670
					#line 680
					#line 691
					#line 696
					#line 702
					#line 707
					#line 764
					#line 770
					#line 785
					#line 816
					#line 830
					#line 834
					#line 840
					#line 849
					#line 859
					#line 885
					#line 891
					#line 7
					uniform sampler2D _MainTex;
					uniform lowp sampler3D _LookupTex3D;
					uniform sampler2D _LookupTex2D;
					uniform highp vec4 _Params;
					#line 17
					#line 23
					#line 29
					#line 35
					#line 41
					#line 47
					#line 67
					#line 91
					#line 97
					#line 44
					highp vec4 UnityObjectToClipPos( in highp vec3 pos ) {
					    #line 50
					    return (unity_MatrixVP * (unity_ObjectToWorld * vec4( pos, 1.0)));
					}
					#line 53
					highp vec4 UnityObjectToClipPos( in highp vec4 pos ) {
					    #line 55
					    return UnityObjectToClipPos( pos.xyz);
					}
					#line 770
					v2f_img vert_img( in appdata_img v ) {
					    v2f_img o;
					    #line 777
					    o.pos = UnityObjectToClipPos( v.vertex);
					    o.uv = v.texcoord;
					    return o;
					}
					varying mediump vec2 xlv_TEXCOORD0;
					void main() {
					unity_MatrixMVP = (unity_MatrixVP * unity_ObjectToWorld);
					unity_MatrixMV = (unity_MatrixV * unity_ObjectToWorld);
					unity_MatrixTMV = xll_transpose_mf4x4(unity_MatrixMV);
					unity_MatrixITMV = xll_transpose_mf4x4((unity_WorldToObject * unity_MatrixInvV));
					    v2f_img xl_retval;
					    appdata_img xlt_v;
					    xlt_v.vertex = vec4(gl_Vertex);
					    xlt_v.texcoord = vec2(gl_MultiTexCoord0);
					    xl_retval = vert_img( xlt_v);
					    gl_Position = vec4(xl_retval.pos);
					    xlv_TEXCOORD0 = vec2(xl_retval.uv);
					}
					/* HLSL2GLSL - NOTE: GLSL optimization failed
					(9,1): error: invalid type `sampler3D' in declaration of `_LookupTex3D'
					*/
					
					#endif
					#ifdef FRAGMENT
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 30
					#endif
					#ifndef SHADER_REQUIRE_INTERPOLATORS10
					    #define SHADER_REQUIRE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_REQUIRE_SAMPLELOD
					    #define SHADER_REQUIRE_SAMPLELOD 1
					#endif
					#ifndef SHADER_REQUIRE_FRAGCOORD
					    #define SHADER_REQUIRE_FRAGCOORD 1
					#endif
					#ifndef UNITY_NO_DXT5nm
					    #define UNITY_NO_DXT5nm 1
					#endif
					#ifndef UNITY_NO_RGBM
					    #define UNITY_NO_RGBM 1
					#endif
					#ifndef UNITY_ENABLE_REFLECTION_BUFFERS
					    #define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#endif
					#ifndef UNITY_FRAMEBUFFER_FETCH_AVAILABLE
					    #define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#endif
					#ifndef UNITY_NO_CUBEMAP_ARRAY
					    #define UNITY_NO_CUBEMAP_ARRAY 1
					#endif
					#ifndef UNITY_NO_SCREENSPACE_SHADOWS
					    #define UNITY_NO_SCREENSPACE_SHADOWS 1
					#endif
					#ifndef UNITY_PBS_USE_BRDF3
					    #define UNITY_PBS_USE_BRDF3 1
					#endif
					#ifndef UNITY_NO_FULL_STANDARD_SHADER
					    #define UNITY_NO_FULL_STANDARD_SHADER 1
					#endif
					#ifndef SHADER_API_MOBILE
					    #define SHADER_API_MOBILE 1
					#endif
					#ifndef UNITY_HARDWARE_TIER1
					    #define UNITY_HARDWARE_TIER1 1
					#endif
					#ifndef UNITY_COLORSPACE_GAMMA
					    #define UNITY_COLORSPACE_GAMMA 1
					#endif
					#ifndef UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS
					    #define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#endif
					#ifndef UNITY_LIGHTMAP_DLDR_ENCODING
					    #define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#endif
					#ifndef UNITY_VERSION
					    #define UNITY_VERSION 201834
					#endif
					#ifndef SHADER_STAGE_VERTEX
					    #define SHADER_STAGE_VERTEX 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 30
					#endif
					#ifndef SHADER_AVAILABLE_INTERPOLATORS10
					    #define SHADER_AVAILABLE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_SAMPLELOD
					    #define SHADER_AVAILABLE_SAMPLELOD 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					mat2 xll_transpose_mf2x2(mat2 m) {
					  return mat2( m[0][0], m[1][0], m[0][1], m[1][1]);
					}
					mat3 xll_transpose_mf3x3(mat3 m) {
					  return mat3( m[0][0], m[1][0], m[2][0],
					               m[0][1], m[1][1], m[2][1],
					               m[0][2], m[1][2], m[2][2]);
					}
					mat4 xll_transpose_mf4x4(mat4 m) {
					  return mat4( m[0][0], m[1][0], m[2][0], m[3][0],
					               m[0][1], m[1][1], m[2][1], m[3][1],
					               m[0][2], m[1][2], m[2][2], m[3][2],
					               m[0][3], m[1][3], m[2][3], m[3][3]);
					}
					float xll_saturate_f( float x) {
					  return clamp( x, 0.0, 1.0);
					}
					vec2 xll_saturate_vf2( vec2 x) {
					  return clamp( x, 0.0, 1.0);
					}
					vec3 xll_saturate_vf3( vec3 x) {
					  return clamp( x, 0.0, 1.0);
					}
					vec4 xll_saturate_vf4( vec4 x) {
					  return clamp( x, 0.0, 1.0);
					}
					mat2 xll_saturate_mf2x2(mat2 m) {
					  return mat2( clamp(m[0], 0.0, 1.0), clamp(m[1], 0.0, 1.0));
					}
					mat3 xll_saturate_mf3x3(mat3 m) {
					  return mat3( clamp(m[0], 0.0, 1.0), clamp(m[1], 0.0, 1.0), clamp(m[2], 0.0, 1.0));
					}
					mat4 xll_saturate_mf4x4(mat4 m) {
					  return mat4( clamp(m[0], 0.0, 1.0), clamp(m[1], 0.0, 1.0), clamp(m[2], 0.0, 1.0), clamp(m[3], 0.0, 1.0));
					}
					#line 447
					struct v2f_vertex_lit {
					    highp vec2 uv;
					    lowp vec4 diff;
					    lowp vec4 spec;
					};
					#line 756
					struct v2f_img {
					    highp vec4 pos;
					    mediump vec2 uv;
					};
					#line 749
					struct appdata_img {
					    highp vec4 vertex;
					    mediump vec2 texcoord;
					};
					#line 40
					uniform highp vec4 _Time;
					uniform highp vec4 _SinTime;
					uniform highp vec4 _CosTime;
					uniform highp vec4 unity_DeltaTime;
					#line 46
					uniform highp vec3 _WorldSpaceCameraPos;
					#line 53
					uniform highp vec4 _ProjectionParams;
					#line 59
					uniform highp vec4 _ScreenParams;
					#line 71
					uniform highp vec4 _ZBufferParams;
					#line 77
					uniform highp vec4 unity_OrthoParams;
					#line 86
					uniform highp vec4 unity_CameraWorldClipPlanes[6];
					#line 92
					uniform highp mat4 unity_CameraProjection;
					uniform highp mat4 unity_CameraInvProjection;
					uniform highp mat4 unity_WorldToCamera;
					uniform highp mat4 unity_CameraToWorld;
					#line 108
					uniform highp vec4 _WorldSpaceLightPos0;
					uniform highp vec4 _LightPositionRange;
					#line 112
					uniform highp vec4 _LightProjectionParams;
					uniform highp vec4 unity_4LightPosX0;
					uniform highp vec4 unity_4LightPosY0;
					#line 116
					uniform highp vec4 unity_4LightPosZ0;
					uniform mediump vec4 unity_4LightAtten0;
					uniform mediump vec4 unity_LightColor[8];
					#line 122
					uniform highp vec4 unity_LightPosition[8];
					#line 127
					uniform mediump vec4 unity_LightAtten[8];
					uniform highp vec4 unity_SpotDirection[8];
					#line 131
					uniform mediump vec4 unity_SHAr;
					uniform mediump vec4 unity_SHAg;
					uniform mediump vec4 unity_SHAb;
					uniform mediump vec4 unity_SHBr;
					#line 135
					uniform mediump vec4 unity_SHBg;
					uniform mediump vec4 unity_SHBb;
					uniform mediump vec4 unity_SHC;
					#line 140
					uniform lowp vec4 unity_OcclusionMaskSelector;
					uniform lowp vec4 unity_ProbesOcclusion;
					#line 145
					uniform mediump vec3 unity_LightColor0;
					uniform mediump vec3 unity_LightColor1;
					uniform mediump vec3 unity_LightColor2;
					uniform mediump vec3 unity_LightColor3;
					#line 152
					uniform highp vec4 unity_ShadowSplitSpheres[4];
					uniform highp vec4 unity_ShadowSplitSqRadii;
					uniform highp vec4 unity_LightShadowBias;
					uniform highp vec4 _LightSplitsNear;
					#line 156
					uniform highp vec4 _LightSplitsFar;
					uniform highp mat4 unity_WorldToShadow[4];
					uniform mediump vec4 _LightShadowData;
					uniform highp vec4 unity_ShadowFadeCenterAndType;
					#line 165
					uniform highp mat4 unity_ObjectToWorld;
					uniform highp mat4 unity_WorldToObject;
					uniform highp vec4 unity_LODFade;
					uniform highp vec4 unity_WorldTransformParams;
					#line 206
					uniform highp mat4 glstate_matrix_transpose_modelview0;
					#line 214
					uniform lowp vec4 glstate_lightmodel_ambient;
					uniform lowp vec4 unity_AmbientSky;
					uniform lowp vec4 unity_AmbientEquator;
					uniform lowp vec4 unity_AmbientGround;
					#line 218
					uniform lowp vec4 unity_IndirectSpecColor;
					uniform highp mat4 glstate_matrix_projection;
					#line 222
					uniform highp mat4 unity_MatrixV;
					uniform highp mat4 unity_MatrixInvV;
					uniform highp mat4 unity_MatrixVP;
					uniform highp int unity_StereoEyeIndex;
					#line 228
					uniform lowp vec4 unity_ShadowColor;
					#line 235
					uniform lowp vec4 unity_FogColor;
					#line 240
					uniform highp vec4 unity_FogParams;
					#line 248
					uniform mediump sampler2D unity_Lightmap;
					uniform mediump sampler2D unity_LightmapInd;
					#line 252
					uniform sampler2D unity_ShadowMask;
					uniform sampler2D unity_DynamicLightmap;
					#line 256
					uniform sampler2D unity_DynamicDirectionality;
					uniform sampler2D unity_DynamicNormal;
					#line 260
					uniform highp vec4 unity_LightmapST;
					uniform highp vec4 unity_DynamicLightmapST;
					#line 268
					uniform samplerCube unity_SpecCube0;
					uniform samplerCube unity_SpecCube1;
					#line 272
					uniform highp vec4 unity_SpecCube0_BoxMax;
					uniform highp vec4 unity_SpecCube0_BoxMin;
					uniform highp vec4 unity_SpecCube0_ProbePosition;
					uniform mediump vec4 unity_SpecCube0_HDR;
					#line 277
					uniform highp vec4 unity_SpecCube1_BoxMax;
					uniform highp vec4 unity_SpecCube1_BoxMin;
					uniform highp vec4 unity_SpecCube1_ProbePosition;
					uniform mediump vec4 unity_SpecCube1_HDR;
					#line 317
					highp mat4 unity_MatrixMVP;
					highp mat4 unity_MatrixMV;
					highp mat4 unity_MatrixTMV;
					highp mat4 unity_MatrixITMV;
					#line 8
					#line 30
					#line 44
					#line 84
					#line 93
					#line 103
					#line 112
					#line 124
					#line 135
					#line 141
					#line 147
					#line 151
					#line 157
					#line 163
					#line 169
					#line 175
					#line 186
					#line 201
					#line 208
					#line 223
					#line 230
					#line 237
					#line 255
					#line 291
					#line 320
					#line 326
					#line 339
					#line 357
					#line 373
					#line 427
					#line 453
					#line 464
					#line 473
					#line 480
					#line 485
					#line 502
					#line 522
					#line 537
					#line 543
					#line 554
					uniform mediump vec4 unity_Lightmap_HDR;
					uniform mediump vec4 unity_DynamicLightmap_HDR;
					#line 568
					#line 578
					#line 593
					#line 602
					#line 609
					#line 618
					#line 626
					#line 635
					#line 654
					#line 660
					#line 670
					#line 680
					#line 691
					#line 696
					#line 702
					#line 707
					#line 764
					#line 770
					#line 785
					#line 816
					#line 830
					#line 834
					#line 840
					#line 849
					#line 859
					#line 885
					#line 891
					#line 7
					uniform sampler2D _MainTex;
					uniform lowp sampler3D _LookupTex3D;
					uniform sampler2D _LookupTex2D;
					uniform highp vec4 _Params;
					#line 17
					#line 23
					#line 29
					#line 35
					#line 41
					#line 47
					#line 67
					#line 91
					#line 97
					#line 35
					highp vec4 lookup_gamma( in highp vec4 o ) {
					    o.xyz = texture3D( _LookupTex3D, ((o.xyz * _Params.x) + _Params.y)).xyz;
					    return o;
					}
					#line 47
					highp vec4 frag( in v2f_img i ) {
					    highp vec4 color = xll_saturate_vf4(texture2D( _MainTex, i.uv));
					    highp vec4 x;
					    #line 55
					    x = lookup_gamma( color);
					    #line 59
					    return (( (i.uv.x > 0.5) ) ? ( mix( color, x, vec4( _Params.z)) ) : ( color ));
					}
					varying mediump vec2 xlv_TEXCOORD0;
					void main() {
					unity_MatrixMVP = (unity_MatrixVP * unity_ObjectToWorld);
					unity_MatrixMV = (unity_MatrixV * unity_ObjectToWorld);
					unity_MatrixTMV = xll_transpose_mf4x4(unity_MatrixMV);
					unity_MatrixITMV = xll_transpose_mf4x4((unity_WorldToObject * unity_MatrixInvV));
					    highp vec4 xl_retval;
					    v2f_img xlt_i;
					    xlt_i.pos = vec4(0.0);
					    xlt_i.uv = vec2(xlv_TEXCOORD0);
					    xl_retval = frag( xlt_i);
					    gl_FragData[0] = vec4(xl_retval);
					}
					/* HLSL2GLSL - NOTE: GLSL optimization failed
					(9,1): error: invalid type `sampler3D' in declaration of `_LookupTex3D'
					(37,21): error: `_LookupTex3D' undeclared
					(37,10): error: no matching function for call to `texture3D(error, vec3)'; candidates are:
					(37,10): error: type mismatch
					*/
					
					#endif"
				}
				SubProgram "gles hw_tier01 " {
					"!!GLES
					#version 100
					
					#ifdef VERTEX
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 30
					#endif
					#ifndef SHADER_REQUIRE_INTERPOLATORS10
					    #define SHADER_REQUIRE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_REQUIRE_SAMPLELOD
					    #define SHADER_REQUIRE_SAMPLELOD 1
					#endif
					#ifndef SHADER_REQUIRE_FRAGCOORD
					    #define SHADER_REQUIRE_FRAGCOORD 1
					#endif
					#ifndef UNITY_NO_DXT5nm
					    #define UNITY_NO_DXT5nm 1
					#endif
					#ifndef UNITY_NO_RGBM
					    #define UNITY_NO_RGBM 1
					#endif
					#ifndef UNITY_ENABLE_REFLECTION_BUFFERS
					    #define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#endif
					#ifndef UNITY_FRAMEBUFFER_FETCH_AVAILABLE
					    #define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#endif
					#ifndef UNITY_NO_CUBEMAP_ARRAY
					    #define UNITY_NO_CUBEMAP_ARRAY 1
					#endif
					#ifndef UNITY_NO_SCREENSPACE_SHADOWS
					    #define UNITY_NO_SCREENSPACE_SHADOWS 1
					#endif
					#ifndef UNITY_PBS_USE_BRDF2
					    #define UNITY_PBS_USE_BRDF2 1
					#endif
					#ifndef SHADER_API_MOBILE
					    #define SHADER_API_MOBILE 1
					#endif
					#ifndef UNITY_HARDWARE_TIER2
					    #define UNITY_HARDWARE_TIER2 1
					#endif
					#ifndef UNITY_COLORSPACE_GAMMA
					    #define UNITY_COLORSPACE_GAMMA 1
					#endif
					#ifndef UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS
					    #define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#endif
					#ifndef UNITY_LIGHTMAP_DLDR_ENCODING
					    #define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#endif
					#ifndef UNITY_VERSION
					    #define UNITY_VERSION 201834
					#endif
					#ifndef SHADER_STAGE_VERTEX
					    #define SHADER_STAGE_VERTEX 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 30
					#endif
					#ifndef SHADER_AVAILABLE_INTERPOLATORS10
					    #define SHADER_AVAILABLE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_SAMPLELOD
					    #define SHADER_AVAILABLE_SAMPLELOD 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#define gl_Vertex _glesVertex
					attribute vec4 _glesVertex;
					#define gl_MultiTexCoord0 _glesMultiTexCoord0
					attribute vec4 _glesMultiTexCoord0;
					mat2 xll_transpose_mf2x2(mat2 m) {
					  return mat2( m[0][0], m[1][0], m[0][1], m[1][1]);
					}
					mat3 xll_transpose_mf3x3(mat3 m) {
					  return mat3( m[0][0], m[1][0], m[2][0],
					               m[0][1], m[1][1], m[2][1],
					               m[0][2], m[1][2], m[2][2]);
					}
					mat4 xll_transpose_mf4x4(mat4 m) {
					  return mat4( m[0][0], m[1][0], m[2][0], m[3][0],
					               m[0][1], m[1][1], m[2][1], m[3][1],
					               m[0][2], m[1][2], m[2][2], m[3][2],
					               m[0][3], m[1][3], m[2][3], m[3][3]);
					}
					#line 447
					struct v2f_vertex_lit {
					    highp vec2 uv;
					    lowp vec4 diff;
					    lowp vec4 spec;
					};
					#line 756
					struct v2f_img {
					    highp vec4 pos;
					    mediump vec2 uv;
					};
					#line 749
					struct appdata_img {
					    highp vec4 vertex;
					    mediump vec2 texcoord;
					};
					#line 40
					uniform highp vec4 _Time;
					uniform highp vec4 _SinTime;
					uniform highp vec4 _CosTime;
					uniform highp vec4 unity_DeltaTime;
					#line 46
					uniform highp vec3 _WorldSpaceCameraPos;
					#line 53
					uniform highp vec4 _ProjectionParams;
					#line 59
					uniform highp vec4 _ScreenParams;
					#line 71
					uniform highp vec4 _ZBufferParams;
					#line 77
					uniform highp vec4 unity_OrthoParams;
					#line 86
					uniform highp vec4 unity_CameraWorldClipPlanes[6];
					#line 92
					uniform highp mat4 unity_CameraProjection;
					uniform highp mat4 unity_CameraInvProjection;
					uniform highp mat4 unity_WorldToCamera;
					uniform highp mat4 unity_CameraToWorld;
					#line 108
					uniform highp vec4 _WorldSpaceLightPos0;
					uniform highp vec4 _LightPositionRange;
					#line 112
					uniform highp vec4 _LightProjectionParams;
					uniform highp vec4 unity_4LightPosX0;
					uniform highp vec4 unity_4LightPosY0;
					#line 116
					uniform highp vec4 unity_4LightPosZ0;
					uniform mediump vec4 unity_4LightAtten0;
					uniform mediump vec4 unity_LightColor[8];
					#line 122
					uniform highp vec4 unity_LightPosition[8];
					#line 127
					uniform mediump vec4 unity_LightAtten[8];
					uniform highp vec4 unity_SpotDirection[8];
					#line 131
					uniform mediump vec4 unity_SHAr;
					uniform mediump vec4 unity_SHAg;
					uniform mediump vec4 unity_SHAb;
					uniform mediump vec4 unity_SHBr;
					#line 135
					uniform mediump vec4 unity_SHBg;
					uniform mediump vec4 unity_SHBb;
					uniform mediump vec4 unity_SHC;
					#line 140
					uniform lowp vec4 unity_OcclusionMaskSelector;
					uniform lowp vec4 unity_ProbesOcclusion;
					#line 145
					uniform mediump vec3 unity_LightColor0;
					uniform mediump vec3 unity_LightColor1;
					uniform mediump vec3 unity_LightColor2;
					uniform mediump vec3 unity_LightColor3;
					#line 152
					uniform highp vec4 unity_ShadowSplitSpheres[4];
					uniform highp vec4 unity_ShadowSplitSqRadii;
					uniform highp vec4 unity_LightShadowBias;
					uniform highp vec4 _LightSplitsNear;
					#line 156
					uniform highp vec4 _LightSplitsFar;
					uniform highp mat4 unity_WorldToShadow[4];
					uniform mediump vec4 _LightShadowData;
					uniform highp vec4 unity_ShadowFadeCenterAndType;
					#line 165
					uniform highp mat4 unity_ObjectToWorld;
					uniform highp mat4 unity_WorldToObject;
					uniform highp vec4 unity_LODFade;
					uniform highp vec4 unity_WorldTransformParams;
					#line 206
					uniform highp mat4 glstate_matrix_transpose_modelview0;
					#line 214
					uniform lowp vec4 glstate_lightmodel_ambient;
					uniform lowp vec4 unity_AmbientSky;
					uniform lowp vec4 unity_AmbientEquator;
					uniform lowp vec4 unity_AmbientGround;
					#line 218
					uniform lowp vec4 unity_IndirectSpecColor;
					uniform highp mat4 glstate_matrix_projection;
					#line 222
					uniform highp mat4 unity_MatrixV;
					uniform highp mat4 unity_MatrixInvV;
					uniform highp mat4 unity_MatrixVP;
					uniform highp int unity_StereoEyeIndex;
					#line 228
					uniform lowp vec4 unity_ShadowColor;
					#line 235
					uniform lowp vec4 unity_FogColor;
					#line 240
					uniform highp vec4 unity_FogParams;
					#line 248
					uniform mediump sampler2D unity_Lightmap;
					uniform mediump sampler2D unity_LightmapInd;
					#line 252
					uniform sampler2D unity_ShadowMask;
					uniform sampler2D unity_DynamicLightmap;
					#line 256
					uniform sampler2D unity_DynamicDirectionality;
					uniform sampler2D unity_DynamicNormal;
					#line 260
					uniform highp vec4 unity_LightmapST;
					uniform highp vec4 unity_DynamicLightmapST;
					#line 268
					uniform samplerCube unity_SpecCube0;
					uniform samplerCube unity_SpecCube1;
					#line 272
					uniform highp vec4 unity_SpecCube0_BoxMax;
					uniform highp vec4 unity_SpecCube0_BoxMin;
					uniform highp vec4 unity_SpecCube0_ProbePosition;
					uniform mediump vec4 unity_SpecCube0_HDR;
					#line 277
					uniform highp vec4 unity_SpecCube1_BoxMax;
					uniform highp vec4 unity_SpecCube1_BoxMin;
					uniform highp vec4 unity_SpecCube1_ProbePosition;
					uniform mediump vec4 unity_SpecCube1_HDR;
					#line 317
					highp mat4 unity_MatrixMVP;
					highp mat4 unity_MatrixMV;
					highp mat4 unity_MatrixTMV;
					highp mat4 unity_MatrixITMV;
					#line 8
					#line 30
					#line 44
					#line 84
					#line 93
					#line 103
					#line 112
					#line 124
					#line 135
					#line 141
					#line 147
					#line 151
					#line 157
					#line 163
					#line 169
					#line 175
					#line 186
					#line 201
					#line 208
					#line 223
					#line 230
					#line 237
					#line 255
					#line 291
					#line 320
					#line 326
					#line 339
					#line 357
					#line 373
					#line 427
					#line 453
					#line 464
					#line 473
					#line 480
					#line 485
					#line 502
					#line 522
					#line 537
					#line 543
					#line 554
					uniform mediump vec4 unity_Lightmap_HDR;
					uniform mediump vec4 unity_DynamicLightmap_HDR;
					#line 568
					#line 578
					#line 593
					#line 602
					#line 609
					#line 618
					#line 626
					#line 635
					#line 654
					#line 660
					#line 670
					#line 680
					#line 691
					#line 696
					#line 702
					#line 707
					#line 764
					#line 770
					#line 785
					#line 816
					#line 830
					#line 834
					#line 840
					#line 849
					#line 859
					#line 885
					#line 891
					#line 7
					uniform sampler2D _MainTex;
					uniform lowp sampler3D _LookupTex3D;
					uniform sampler2D _LookupTex2D;
					uniform highp vec4 _Params;
					#line 17
					#line 23
					#line 29
					#line 35
					#line 41
					#line 47
					#line 67
					#line 91
					#line 97
					#line 44
					highp vec4 UnityObjectToClipPos( in highp vec3 pos ) {
					    #line 50
					    return (unity_MatrixVP * (unity_ObjectToWorld * vec4( pos, 1.0)));
					}
					#line 53
					highp vec4 UnityObjectToClipPos( in highp vec4 pos ) {
					    #line 55
					    return UnityObjectToClipPos( pos.xyz);
					}
					#line 770
					v2f_img vert_img( in appdata_img v ) {
					    v2f_img o;
					    #line 777
					    o.pos = UnityObjectToClipPos( v.vertex);
					    o.uv = v.texcoord;
					    return o;
					}
					varying mediump vec2 xlv_TEXCOORD0;
					void main() {
					unity_MatrixMVP = (unity_MatrixVP * unity_ObjectToWorld);
					unity_MatrixMV = (unity_MatrixV * unity_ObjectToWorld);
					unity_MatrixTMV = xll_transpose_mf4x4(unity_MatrixMV);
					unity_MatrixITMV = xll_transpose_mf4x4((unity_WorldToObject * unity_MatrixInvV));
					    v2f_img xl_retval;
					    appdata_img xlt_v;
					    xlt_v.vertex = vec4(gl_Vertex);
					    xlt_v.texcoord = vec2(gl_MultiTexCoord0);
					    xl_retval = vert_img( xlt_v);
					    gl_Position = vec4(xl_retval.pos);
					    xlv_TEXCOORD0 = vec2(xl_retval.uv);
					}
					/* HLSL2GLSL - NOTE: GLSL optimization failed
					(9,1): error: invalid type `sampler3D' in declaration of `_LookupTex3D'
					*/
					
					#endif
					#ifdef FRAGMENT
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 30
					#endif
					#ifndef SHADER_REQUIRE_INTERPOLATORS10
					    #define SHADER_REQUIRE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_REQUIRE_SAMPLELOD
					    #define SHADER_REQUIRE_SAMPLELOD 1
					#endif
					#ifndef SHADER_REQUIRE_FRAGCOORD
					    #define SHADER_REQUIRE_FRAGCOORD 1
					#endif
					#ifndef UNITY_NO_DXT5nm
					    #define UNITY_NO_DXT5nm 1
					#endif
					#ifndef UNITY_NO_RGBM
					    #define UNITY_NO_RGBM 1
					#endif
					#ifndef UNITY_ENABLE_REFLECTION_BUFFERS
					    #define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#endif
					#ifndef UNITY_FRAMEBUFFER_FETCH_AVAILABLE
					    #define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#endif
					#ifndef UNITY_NO_CUBEMAP_ARRAY
					    #define UNITY_NO_CUBEMAP_ARRAY 1
					#endif
					#ifndef UNITY_NO_SCREENSPACE_SHADOWS
					    #define UNITY_NO_SCREENSPACE_SHADOWS 1
					#endif
					#ifndef UNITY_PBS_USE_BRDF2
					    #define UNITY_PBS_USE_BRDF2 1
					#endif
					#ifndef SHADER_API_MOBILE
					    #define SHADER_API_MOBILE 1
					#endif
					#ifndef UNITY_HARDWARE_TIER2
					    #define UNITY_HARDWARE_TIER2 1
					#endif
					#ifndef UNITY_COLORSPACE_GAMMA
					    #define UNITY_COLORSPACE_GAMMA 1
					#endif
					#ifndef UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS
					    #define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#endif
					#ifndef UNITY_LIGHTMAP_DLDR_ENCODING
					    #define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#endif
					#ifndef UNITY_VERSION
					    #define UNITY_VERSION 201834
					#endif
					#ifndef SHADER_STAGE_VERTEX
					    #define SHADER_STAGE_VERTEX 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 30
					#endif
					#ifndef SHADER_AVAILABLE_INTERPOLATORS10
					    #define SHADER_AVAILABLE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_SAMPLELOD
					    #define SHADER_AVAILABLE_SAMPLELOD 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					mat2 xll_transpose_mf2x2(mat2 m) {
					  return mat2( m[0][0], m[1][0], m[0][1], m[1][1]);
					}
					mat3 xll_transpose_mf3x3(mat3 m) {
					  return mat3( m[0][0], m[1][0], m[2][0],
					               m[0][1], m[1][1], m[2][1],
					               m[0][2], m[1][2], m[2][2]);
					}
					mat4 xll_transpose_mf4x4(mat4 m) {
					  return mat4( m[0][0], m[1][0], m[2][0], m[3][0],
					               m[0][1], m[1][1], m[2][1], m[3][1],
					               m[0][2], m[1][2], m[2][2], m[3][2],
					               m[0][3], m[1][3], m[2][3], m[3][3]);
					}
					float xll_saturate_f( float x) {
					  return clamp( x, 0.0, 1.0);
					}
					vec2 xll_saturate_vf2( vec2 x) {
					  return clamp( x, 0.0, 1.0);
					}
					vec3 xll_saturate_vf3( vec3 x) {
					  return clamp( x, 0.0, 1.0);
					}
					vec4 xll_saturate_vf4( vec4 x) {
					  return clamp( x, 0.0, 1.0);
					}
					mat2 xll_saturate_mf2x2(mat2 m) {
					  return mat2( clamp(m[0], 0.0, 1.0), clamp(m[1], 0.0, 1.0));
					}
					mat3 xll_saturate_mf3x3(mat3 m) {
					  return mat3( clamp(m[0], 0.0, 1.0), clamp(m[1], 0.0, 1.0), clamp(m[2], 0.0, 1.0));
					}
					mat4 xll_saturate_mf4x4(mat4 m) {
					  return mat4( clamp(m[0], 0.0, 1.0), clamp(m[1], 0.0, 1.0), clamp(m[2], 0.0, 1.0), clamp(m[3], 0.0, 1.0));
					}
					#line 447
					struct v2f_vertex_lit {
					    highp vec2 uv;
					    lowp vec4 diff;
					    lowp vec4 spec;
					};
					#line 756
					struct v2f_img {
					    highp vec4 pos;
					    mediump vec2 uv;
					};
					#line 749
					struct appdata_img {
					    highp vec4 vertex;
					    mediump vec2 texcoord;
					};
					#line 40
					uniform highp vec4 _Time;
					uniform highp vec4 _SinTime;
					uniform highp vec4 _CosTime;
					uniform highp vec4 unity_DeltaTime;
					#line 46
					uniform highp vec3 _WorldSpaceCameraPos;
					#line 53
					uniform highp vec4 _ProjectionParams;
					#line 59
					uniform highp vec4 _ScreenParams;
					#line 71
					uniform highp vec4 _ZBufferParams;
					#line 77
					uniform highp vec4 unity_OrthoParams;
					#line 86
					uniform highp vec4 unity_CameraWorldClipPlanes[6];
					#line 92
					uniform highp mat4 unity_CameraProjection;
					uniform highp mat4 unity_CameraInvProjection;
					uniform highp mat4 unity_WorldToCamera;
					uniform highp mat4 unity_CameraToWorld;
					#line 108
					uniform highp vec4 _WorldSpaceLightPos0;
					uniform highp vec4 _LightPositionRange;
					#line 112
					uniform highp vec4 _LightProjectionParams;
					uniform highp vec4 unity_4LightPosX0;
					uniform highp vec4 unity_4LightPosY0;
					#line 116
					uniform highp vec4 unity_4LightPosZ0;
					uniform mediump vec4 unity_4LightAtten0;
					uniform mediump vec4 unity_LightColor[8];
					#line 122
					uniform highp vec4 unity_LightPosition[8];
					#line 127
					uniform mediump vec4 unity_LightAtten[8];
					uniform highp vec4 unity_SpotDirection[8];
					#line 131
					uniform mediump vec4 unity_SHAr;
					uniform mediump vec4 unity_SHAg;
					uniform mediump vec4 unity_SHAb;
					uniform mediump vec4 unity_SHBr;
					#line 135
					uniform mediump vec4 unity_SHBg;
					uniform mediump vec4 unity_SHBb;
					uniform mediump vec4 unity_SHC;
					#line 140
					uniform lowp vec4 unity_OcclusionMaskSelector;
					uniform lowp vec4 unity_ProbesOcclusion;
					#line 145
					uniform mediump vec3 unity_LightColor0;
					uniform mediump vec3 unity_LightColor1;
					uniform mediump vec3 unity_LightColor2;
					uniform mediump vec3 unity_LightColor3;
					#line 152
					uniform highp vec4 unity_ShadowSplitSpheres[4];
					uniform highp vec4 unity_ShadowSplitSqRadii;
					uniform highp vec4 unity_LightShadowBias;
					uniform highp vec4 _LightSplitsNear;
					#line 156
					uniform highp vec4 _LightSplitsFar;
					uniform highp mat4 unity_WorldToShadow[4];
					uniform mediump vec4 _LightShadowData;
					uniform highp vec4 unity_ShadowFadeCenterAndType;
					#line 165
					uniform highp mat4 unity_ObjectToWorld;
					uniform highp mat4 unity_WorldToObject;
					uniform highp vec4 unity_LODFade;
					uniform highp vec4 unity_WorldTransformParams;
					#line 206
					uniform highp mat4 glstate_matrix_transpose_modelview0;
					#line 214
					uniform lowp vec4 glstate_lightmodel_ambient;
					uniform lowp vec4 unity_AmbientSky;
					uniform lowp vec4 unity_AmbientEquator;
					uniform lowp vec4 unity_AmbientGround;
					#line 218
					uniform lowp vec4 unity_IndirectSpecColor;
					uniform highp mat4 glstate_matrix_projection;
					#line 222
					uniform highp mat4 unity_MatrixV;
					uniform highp mat4 unity_MatrixInvV;
					uniform highp mat4 unity_MatrixVP;
					uniform highp int unity_StereoEyeIndex;
					#line 228
					uniform lowp vec4 unity_ShadowColor;
					#line 235
					uniform lowp vec4 unity_FogColor;
					#line 240
					uniform highp vec4 unity_FogParams;
					#line 248
					uniform mediump sampler2D unity_Lightmap;
					uniform mediump sampler2D unity_LightmapInd;
					#line 252
					uniform sampler2D unity_ShadowMask;
					uniform sampler2D unity_DynamicLightmap;
					#line 256
					uniform sampler2D unity_DynamicDirectionality;
					uniform sampler2D unity_DynamicNormal;
					#line 260
					uniform highp vec4 unity_LightmapST;
					uniform highp vec4 unity_DynamicLightmapST;
					#line 268
					uniform samplerCube unity_SpecCube0;
					uniform samplerCube unity_SpecCube1;
					#line 272
					uniform highp vec4 unity_SpecCube0_BoxMax;
					uniform highp vec4 unity_SpecCube0_BoxMin;
					uniform highp vec4 unity_SpecCube0_ProbePosition;
					uniform mediump vec4 unity_SpecCube0_HDR;
					#line 277
					uniform highp vec4 unity_SpecCube1_BoxMax;
					uniform highp vec4 unity_SpecCube1_BoxMin;
					uniform highp vec4 unity_SpecCube1_ProbePosition;
					uniform mediump vec4 unity_SpecCube1_HDR;
					#line 317
					highp mat4 unity_MatrixMVP;
					highp mat4 unity_MatrixMV;
					highp mat4 unity_MatrixTMV;
					highp mat4 unity_MatrixITMV;
					#line 8
					#line 30
					#line 44
					#line 84
					#line 93
					#line 103
					#line 112
					#line 124
					#line 135
					#line 141
					#line 147
					#line 151
					#line 157
					#line 163
					#line 169
					#line 175
					#line 186
					#line 201
					#line 208
					#line 223
					#line 230
					#line 237
					#line 255
					#line 291
					#line 320
					#line 326
					#line 339
					#line 357
					#line 373
					#line 427
					#line 453
					#line 464
					#line 473
					#line 480
					#line 485
					#line 502
					#line 522
					#line 537
					#line 543
					#line 554
					uniform mediump vec4 unity_Lightmap_HDR;
					uniform mediump vec4 unity_DynamicLightmap_HDR;
					#line 568
					#line 578
					#line 593
					#line 602
					#line 609
					#line 618
					#line 626
					#line 635
					#line 654
					#line 660
					#line 670
					#line 680
					#line 691
					#line 696
					#line 702
					#line 707
					#line 764
					#line 770
					#line 785
					#line 816
					#line 830
					#line 834
					#line 840
					#line 849
					#line 859
					#line 885
					#line 891
					#line 7
					uniform sampler2D _MainTex;
					uniform lowp sampler3D _LookupTex3D;
					uniform sampler2D _LookupTex2D;
					uniform highp vec4 _Params;
					#line 17
					#line 23
					#line 29
					#line 35
					#line 41
					#line 47
					#line 67
					#line 91
					#line 97
					#line 35
					highp vec4 lookup_gamma( in highp vec4 o ) {
					    o.xyz = texture3D( _LookupTex3D, ((o.xyz * _Params.x) + _Params.y)).xyz;
					    return o;
					}
					#line 47
					highp vec4 frag( in v2f_img i ) {
					    highp vec4 color = xll_saturate_vf4(texture2D( _MainTex, i.uv));
					    highp vec4 x;
					    #line 55
					    x = lookup_gamma( color);
					    #line 59
					    return (( (i.uv.x > 0.5) ) ? ( mix( color, x, vec4( _Params.z)) ) : ( color ));
					}
					varying mediump vec2 xlv_TEXCOORD0;
					void main() {
					unity_MatrixMVP = (unity_MatrixVP * unity_ObjectToWorld);
					unity_MatrixMV = (unity_MatrixV * unity_ObjectToWorld);
					unity_MatrixTMV = xll_transpose_mf4x4(unity_MatrixMV);
					unity_MatrixITMV = xll_transpose_mf4x4((unity_WorldToObject * unity_MatrixInvV));
					    highp vec4 xl_retval;
					    v2f_img xlt_i;
					    xlt_i.pos = vec4(0.0);
					    xlt_i.uv = vec2(xlv_TEXCOORD0);
					    xl_retval = frag( xlt_i);
					    gl_FragData[0] = vec4(xl_retval);
					}
					/* HLSL2GLSL - NOTE: GLSL optimization failed
					(9,1): error: invalid type `sampler3D' in declaration of `_LookupTex3D'
					(37,21): error: `_LookupTex3D' undeclared
					(37,10): error: no matching function for call to `texture3D(error, vec3)'; candidates are:
					(37,10): error: type mismatch
					*/
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {
					"!!GLES
					#version 100
					
					#ifdef VERTEX
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 30
					#endif
					#ifndef SHADER_REQUIRE_INTERPOLATORS10
					    #define SHADER_REQUIRE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_REQUIRE_SAMPLELOD
					    #define SHADER_REQUIRE_SAMPLELOD 1
					#endif
					#ifndef SHADER_REQUIRE_FRAGCOORD
					    #define SHADER_REQUIRE_FRAGCOORD 1
					#endif
					#ifndef UNITY_NO_DXT5nm
					    #define UNITY_NO_DXT5nm 1
					#endif
					#ifndef UNITY_NO_RGBM
					    #define UNITY_NO_RGBM 1
					#endif
					#ifndef UNITY_ENABLE_REFLECTION_BUFFERS
					    #define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#endif
					#ifndef UNITY_FRAMEBUFFER_FETCH_AVAILABLE
					    #define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#endif
					#ifndef UNITY_NO_CUBEMAP_ARRAY
					    #define UNITY_NO_CUBEMAP_ARRAY 1
					#endif
					#ifndef UNITY_NO_SCREENSPACE_SHADOWS
					    #define UNITY_NO_SCREENSPACE_SHADOWS 1
					#endif
					#ifndef UNITY_PBS_USE_BRDF2
					    #define UNITY_PBS_USE_BRDF2 1
					#endif
					#ifndef SHADER_API_MOBILE
					    #define SHADER_API_MOBILE 1
					#endif
					#ifndef UNITY_HARDWARE_TIER3
					    #define UNITY_HARDWARE_TIER3 1
					#endif
					#ifndef UNITY_COLORSPACE_GAMMA
					    #define UNITY_COLORSPACE_GAMMA 1
					#endif
					#ifndef UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS
					    #define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#endif
					#ifndef UNITY_LIGHTMAP_DLDR_ENCODING
					    #define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#endif
					#ifndef UNITY_VERSION
					    #define UNITY_VERSION 201834
					#endif
					#ifndef SHADER_STAGE_VERTEX
					    #define SHADER_STAGE_VERTEX 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 30
					#endif
					#ifndef SHADER_AVAILABLE_INTERPOLATORS10
					    #define SHADER_AVAILABLE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_SAMPLELOD
					    #define SHADER_AVAILABLE_SAMPLELOD 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#define gl_Vertex _glesVertex
					attribute vec4 _glesVertex;
					#define gl_MultiTexCoord0 _glesMultiTexCoord0
					attribute vec4 _glesMultiTexCoord0;
					mat2 xll_transpose_mf2x2(mat2 m) {
					  return mat2( m[0][0], m[1][0], m[0][1], m[1][1]);
					}
					mat3 xll_transpose_mf3x3(mat3 m) {
					  return mat3( m[0][0], m[1][0], m[2][0],
					               m[0][1], m[1][1], m[2][1],
					               m[0][2], m[1][2], m[2][2]);
					}
					mat4 xll_transpose_mf4x4(mat4 m) {
					  return mat4( m[0][0], m[1][0], m[2][0], m[3][0],
					               m[0][1], m[1][1], m[2][1], m[3][1],
					               m[0][2], m[1][2], m[2][2], m[3][2],
					               m[0][3], m[1][3], m[2][3], m[3][3]);
					}
					#line 447
					struct v2f_vertex_lit {
					    highp vec2 uv;
					    lowp vec4 diff;
					    lowp vec4 spec;
					};
					#line 756
					struct v2f_img {
					    highp vec4 pos;
					    mediump vec2 uv;
					};
					#line 749
					struct appdata_img {
					    highp vec4 vertex;
					    mediump vec2 texcoord;
					};
					#line 40
					uniform highp vec4 _Time;
					uniform highp vec4 _SinTime;
					uniform highp vec4 _CosTime;
					uniform highp vec4 unity_DeltaTime;
					#line 46
					uniform highp vec3 _WorldSpaceCameraPos;
					#line 53
					uniform highp vec4 _ProjectionParams;
					#line 59
					uniform highp vec4 _ScreenParams;
					#line 71
					uniform highp vec4 _ZBufferParams;
					#line 77
					uniform highp vec4 unity_OrthoParams;
					#line 86
					uniform highp vec4 unity_CameraWorldClipPlanes[6];
					#line 92
					uniform highp mat4 unity_CameraProjection;
					uniform highp mat4 unity_CameraInvProjection;
					uniform highp mat4 unity_WorldToCamera;
					uniform highp mat4 unity_CameraToWorld;
					#line 108
					uniform highp vec4 _WorldSpaceLightPos0;
					uniform highp vec4 _LightPositionRange;
					#line 112
					uniform highp vec4 _LightProjectionParams;
					uniform highp vec4 unity_4LightPosX0;
					uniform highp vec4 unity_4LightPosY0;
					#line 116
					uniform highp vec4 unity_4LightPosZ0;
					uniform mediump vec4 unity_4LightAtten0;
					uniform mediump vec4 unity_LightColor[8];
					#line 122
					uniform highp vec4 unity_LightPosition[8];
					#line 127
					uniform mediump vec4 unity_LightAtten[8];
					uniform highp vec4 unity_SpotDirection[8];
					#line 131
					uniform mediump vec4 unity_SHAr;
					uniform mediump vec4 unity_SHAg;
					uniform mediump vec4 unity_SHAb;
					uniform mediump vec4 unity_SHBr;
					#line 135
					uniform mediump vec4 unity_SHBg;
					uniform mediump vec4 unity_SHBb;
					uniform mediump vec4 unity_SHC;
					#line 140
					uniform lowp vec4 unity_OcclusionMaskSelector;
					uniform lowp vec4 unity_ProbesOcclusion;
					#line 145
					uniform mediump vec3 unity_LightColor0;
					uniform mediump vec3 unity_LightColor1;
					uniform mediump vec3 unity_LightColor2;
					uniform mediump vec3 unity_LightColor3;
					#line 152
					uniform highp vec4 unity_ShadowSplitSpheres[4];
					uniform highp vec4 unity_ShadowSplitSqRadii;
					uniform highp vec4 unity_LightShadowBias;
					uniform highp vec4 _LightSplitsNear;
					#line 156
					uniform highp vec4 _LightSplitsFar;
					uniform highp mat4 unity_WorldToShadow[4];
					uniform mediump vec4 _LightShadowData;
					uniform highp vec4 unity_ShadowFadeCenterAndType;
					#line 165
					uniform highp mat4 unity_ObjectToWorld;
					uniform highp mat4 unity_WorldToObject;
					uniform highp vec4 unity_LODFade;
					uniform highp vec4 unity_WorldTransformParams;
					#line 206
					uniform highp mat4 glstate_matrix_transpose_modelview0;
					#line 214
					uniform lowp vec4 glstate_lightmodel_ambient;
					uniform lowp vec4 unity_AmbientSky;
					uniform lowp vec4 unity_AmbientEquator;
					uniform lowp vec4 unity_AmbientGround;
					#line 218
					uniform lowp vec4 unity_IndirectSpecColor;
					uniform highp mat4 glstate_matrix_projection;
					#line 222
					uniform highp mat4 unity_MatrixV;
					uniform highp mat4 unity_MatrixInvV;
					uniform highp mat4 unity_MatrixVP;
					uniform highp int unity_StereoEyeIndex;
					#line 228
					uniform lowp vec4 unity_ShadowColor;
					#line 235
					uniform lowp vec4 unity_FogColor;
					#line 240
					uniform highp vec4 unity_FogParams;
					#line 248
					uniform mediump sampler2D unity_Lightmap;
					uniform mediump sampler2D unity_LightmapInd;
					#line 252
					uniform sampler2D unity_ShadowMask;
					uniform sampler2D unity_DynamicLightmap;
					#line 256
					uniform sampler2D unity_DynamicDirectionality;
					uniform sampler2D unity_DynamicNormal;
					#line 260
					uniform highp vec4 unity_LightmapST;
					uniform highp vec4 unity_DynamicLightmapST;
					#line 268
					uniform samplerCube unity_SpecCube0;
					uniform samplerCube unity_SpecCube1;
					#line 272
					uniform highp vec4 unity_SpecCube0_BoxMax;
					uniform highp vec4 unity_SpecCube0_BoxMin;
					uniform highp vec4 unity_SpecCube0_ProbePosition;
					uniform mediump vec4 unity_SpecCube0_HDR;
					#line 277
					uniform highp vec4 unity_SpecCube1_BoxMax;
					uniform highp vec4 unity_SpecCube1_BoxMin;
					uniform highp vec4 unity_SpecCube1_ProbePosition;
					uniform mediump vec4 unity_SpecCube1_HDR;
					#line 317
					highp mat4 unity_MatrixMVP;
					highp mat4 unity_MatrixMV;
					highp mat4 unity_MatrixTMV;
					highp mat4 unity_MatrixITMV;
					#line 8
					#line 30
					#line 44
					#line 84
					#line 93
					#line 103
					#line 112
					#line 124
					#line 135
					#line 141
					#line 147
					#line 151
					#line 157
					#line 163
					#line 169
					#line 175
					#line 186
					#line 201
					#line 208
					#line 223
					#line 230
					#line 237
					#line 255
					#line 291
					#line 320
					#line 326
					#line 339
					#line 357
					#line 373
					#line 427
					#line 453
					#line 464
					#line 473
					#line 480
					#line 485
					#line 502
					#line 522
					#line 537
					#line 543
					#line 554
					uniform mediump vec4 unity_Lightmap_HDR;
					uniform mediump vec4 unity_DynamicLightmap_HDR;
					#line 568
					#line 578
					#line 593
					#line 602
					#line 609
					#line 618
					#line 626
					#line 635
					#line 654
					#line 660
					#line 670
					#line 680
					#line 691
					#line 696
					#line 702
					#line 707
					#line 764
					#line 770
					#line 785
					#line 816
					#line 830
					#line 834
					#line 840
					#line 849
					#line 859
					#line 885
					#line 891
					#line 7
					uniform sampler2D _MainTex;
					uniform lowp sampler3D _LookupTex3D;
					uniform sampler2D _LookupTex2D;
					uniform highp vec4 _Params;
					#line 17
					#line 23
					#line 29
					#line 35
					#line 41
					#line 47
					#line 67
					#line 91
					#line 97
					#line 44
					highp vec4 UnityObjectToClipPos( in highp vec3 pos ) {
					    #line 50
					    return (unity_MatrixVP * (unity_ObjectToWorld * vec4( pos, 1.0)));
					}
					#line 53
					highp vec4 UnityObjectToClipPos( in highp vec4 pos ) {
					    #line 55
					    return UnityObjectToClipPos( pos.xyz);
					}
					#line 770
					v2f_img vert_img( in appdata_img v ) {
					    v2f_img o;
					    #line 777
					    o.pos = UnityObjectToClipPos( v.vertex);
					    o.uv = v.texcoord;
					    return o;
					}
					varying mediump vec2 xlv_TEXCOORD0;
					void main() {
					unity_MatrixMVP = (unity_MatrixVP * unity_ObjectToWorld);
					unity_MatrixMV = (unity_MatrixV * unity_ObjectToWorld);
					unity_MatrixTMV = xll_transpose_mf4x4(unity_MatrixMV);
					unity_MatrixITMV = xll_transpose_mf4x4((unity_WorldToObject * unity_MatrixInvV));
					    v2f_img xl_retval;
					    appdata_img xlt_v;
					    xlt_v.vertex = vec4(gl_Vertex);
					    xlt_v.texcoord = vec2(gl_MultiTexCoord0);
					    xl_retval = vert_img( xlt_v);
					    gl_Position = vec4(xl_retval.pos);
					    xlv_TEXCOORD0 = vec2(xl_retval.uv);
					}
					/* HLSL2GLSL - NOTE: GLSL optimization failed
					(9,1): error: invalid type `sampler3D' in declaration of `_LookupTex3D'
					*/
					
					#endif
					#ifdef FRAGMENT
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 30
					#endif
					#ifndef SHADER_REQUIRE_INTERPOLATORS10
					    #define SHADER_REQUIRE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_REQUIRE_SAMPLELOD
					    #define SHADER_REQUIRE_SAMPLELOD 1
					#endif
					#ifndef SHADER_REQUIRE_FRAGCOORD
					    #define SHADER_REQUIRE_FRAGCOORD 1
					#endif
					#ifndef UNITY_NO_DXT5nm
					    #define UNITY_NO_DXT5nm 1
					#endif
					#ifndef UNITY_NO_RGBM
					    #define UNITY_NO_RGBM 1
					#endif
					#ifndef UNITY_ENABLE_REFLECTION_BUFFERS
					    #define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#endif
					#ifndef UNITY_FRAMEBUFFER_FETCH_AVAILABLE
					    #define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#endif
					#ifndef UNITY_NO_CUBEMAP_ARRAY
					    #define UNITY_NO_CUBEMAP_ARRAY 1
					#endif
					#ifndef UNITY_NO_SCREENSPACE_SHADOWS
					    #define UNITY_NO_SCREENSPACE_SHADOWS 1
					#endif
					#ifndef UNITY_PBS_USE_BRDF2
					    #define UNITY_PBS_USE_BRDF2 1
					#endif
					#ifndef SHADER_API_MOBILE
					    #define SHADER_API_MOBILE 1
					#endif
					#ifndef UNITY_HARDWARE_TIER3
					    #define UNITY_HARDWARE_TIER3 1
					#endif
					#ifndef UNITY_COLORSPACE_GAMMA
					    #define UNITY_COLORSPACE_GAMMA 1
					#endif
					#ifndef UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS
					    #define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#endif
					#ifndef UNITY_LIGHTMAP_DLDR_ENCODING
					    #define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#endif
					#ifndef UNITY_VERSION
					    #define UNITY_VERSION 201834
					#endif
					#ifndef SHADER_STAGE_VERTEX
					    #define SHADER_STAGE_VERTEX 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 30
					#endif
					#ifndef SHADER_AVAILABLE_INTERPOLATORS10
					    #define SHADER_AVAILABLE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_SAMPLELOD
					    #define SHADER_AVAILABLE_SAMPLELOD 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					mat2 xll_transpose_mf2x2(mat2 m) {
					  return mat2( m[0][0], m[1][0], m[0][1], m[1][1]);
					}
					mat3 xll_transpose_mf3x3(mat3 m) {
					  return mat3( m[0][0], m[1][0], m[2][0],
					               m[0][1], m[1][1], m[2][1],
					               m[0][2], m[1][2], m[2][2]);
					}
					mat4 xll_transpose_mf4x4(mat4 m) {
					  return mat4( m[0][0], m[1][0], m[2][0], m[3][0],
					               m[0][1], m[1][1], m[2][1], m[3][1],
					               m[0][2], m[1][2], m[2][2], m[3][2],
					               m[0][3], m[1][3], m[2][3], m[3][3]);
					}
					float xll_saturate_f( float x) {
					  return clamp( x, 0.0, 1.0);
					}
					vec2 xll_saturate_vf2( vec2 x) {
					  return clamp( x, 0.0, 1.0);
					}
					vec3 xll_saturate_vf3( vec3 x) {
					  return clamp( x, 0.0, 1.0);
					}
					vec4 xll_saturate_vf4( vec4 x) {
					  return clamp( x, 0.0, 1.0);
					}
					mat2 xll_saturate_mf2x2(mat2 m) {
					  return mat2( clamp(m[0], 0.0, 1.0), clamp(m[1], 0.0, 1.0));
					}
					mat3 xll_saturate_mf3x3(mat3 m) {
					  return mat3( clamp(m[0], 0.0, 1.0), clamp(m[1], 0.0, 1.0), clamp(m[2], 0.0, 1.0));
					}
					mat4 xll_saturate_mf4x4(mat4 m) {
					  return mat4( clamp(m[0], 0.0, 1.0), clamp(m[1], 0.0, 1.0), clamp(m[2], 0.0, 1.0), clamp(m[3], 0.0, 1.0));
					}
					#line 447
					struct v2f_vertex_lit {
					    highp vec2 uv;
					    lowp vec4 diff;
					    lowp vec4 spec;
					};
					#line 756
					struct v2f_img {
					    highp vec4 pos;
					    mediump vec2 uv;
					};
					#line 749
					struct appdata_img {
					    highp vec4 vertex;
					    mediump vec2 texcoord;
					};
					#line 40
					uniform highp vec4 _Time;
					uniform highp vec4 _SinTime;
					uniform highp vec4 _CosTime;
					uniform highp vec4 unity_DeltaTime;
					#line 46
					uniform highp vec3 _WorldSpaceCameraPos;
					#line 53
					uniform highp vec4 _ProjectionParams;
					#line 59
					uniform highp vec4 _ScreenParams;
					#line 71
					uniform highp vec4 _ZBufferParams;
					#line 77
					uniform highp vec4 unity_OrthoParams;
					#line 86
					uniform highp vec4 unity_CameraWorldClipPlanes[6];
					#line 92
					uniform highp mat4 unity_CameraProjection;
					uniform highp mat4 unity_CameraInvProjection;
					uniform highp mat4 unity_WorldToCamera;
					uniform highp mat4 unity_CameraToWorld;
					#line 108
					uniform highp vec4 _WorldSpaceLightPos0;
					uniform highp vec4 _LightPositionRange;
					#line 112
					uniform highp vec4 _LightProjectionParams;
					uniform highp vec4 unity_4LightPosX0;
					uniform highp vec4 unity_4LightPosY0;
					#line 116
					uniform highp vec4 unity_4LightPosZ0;
					uniform mediump vec4 unity_4LightAtten0;
					uniform mediump vec4 unity_LightColor[8];
					#line 122
					uniform highp vec4 unity_LightPosition[8];
					#line 127
					uniform mediump vec4 unity_LightAtten[8];
					uniform highp vec4 unity_SpotDirection[8];
					#line 131
					uniform mediump vec4 unity_SHAr;
					uniform mediump vec4 unity_SHAg;
					uniform mediump vec4 unity_SHAb;
					uniform mediump vec4 unity_SHBr;
					#line 135
					uniform mediump vec4 unity_SHBg;
					uniform mediump vec4 unity_SHBb;
					uniform mediump vec4 unity_SHC;
					#line 140
					uniform lowp vec4 unity_OcclusionMaskSelector;
					uniform lowp vec4 unity_ProbesOcclusion;
					#line 145
					uniform mediump vec3 unity_LightColor0;
					uniform mediump vec3 unity_LightColor1;
					uniform mediump vec3 unity_LightColor2;
					uniform mediump vec3 unity_LightColor3;
					#line 152
					uniform highp vec4 unity_ShadowSplitSpheres[4];
					uniform highp vec4 unity_ShadowSplitSqRadii;
					uniform highp vec4 unity_LightShadowBias;
					uniform highp vec4 _LightSplitsNear;
					#line 156
					uniform highp vec4 _LightSplitsFar;
					uniform highp mat4 unity_WorldToShadow[4];
					uniform mediump vec4 _LightShadowData;
					uniform highp vec4 unity_ShadowFadeCenterAndType;
					#line 165
					uniform highp mat4 unity_ObjectToWorld;
					uniform highp mat4 unity_WorldToObject;
					uniform highp vec4 unity_LODFade;
					uniform highp vec4 unity_WorldTransformParams;
					#line 206
					uniform highp mat4 glstate_matrix_transpose_modelview0;
					#line 214
					uniform lowp vec4 glstate_lightmodel_ambient;
					uniform lowp vec4 unity_AmbientSky;
					uniform lowp vec4 unity_AmbientEquator;
					uniform lowp vec4 unity_AmbientGround;
					#line 218
					uniform lowp vec4 unity_IndirectSpecColor;
					uniform highp mat4 glstate_matrix_projection;
					#line 222
					uniform highp mat4 unity_MatrixV;
					uniform highp mat4 unity_MatrixInvV;
					uniform highp mat4 unity_MatrixVP;
					uniform highp int unity_StereoEyeIndex;
					#line 228
					uniform lowp vec4 unity_ShadowColor;
					#line 235
					uniform lowp vec4 unity_FogColor;
					#line 240
					uniform highp vec4 unity_FogParams;
					#line 248
					uniform mediump sampler2D unity_Lightmap;
					uniform mediump sampler2D unity_LightmapInd;
					#line 252
					uniform sampler2D unity_ShadowMask;
					uniform sampler2D unity_DynamicLightmap;
					#line 256
					uniform sampler2D unity_DynamicDirectionality;
					uniform sampler2D unity_DynamicNormal;
					#line 260
					uniform highp vec4 unity_LightmapST;
					uniform highp vec4 unity_DynamicLightmapST;
					#line 268
					uniform samplerCube unity_SpecCube0;
					uniform samplerCube unity_SpecCube1;
					#line 272
					uniform highp vec4 unity_SpecCube0_BoxMax;
					uniform highp vec4 unity_SpecCube0_BoxMin;
					uniform highp vec4 unity_SpecCube0_ProbePosition;
					uniform mediump vec4 unity_SpecCube0_HDR;
					#line 277
					uniform highp vec4 unity_SpecCube1_BoxMax;
					uniform highp vec4 unity_SpecCube1_BoxMin;
					uniform highp vec4 unity_SpecCube1_ProbePosition;
					uniform mediump vec4 unity_SpecCube1_HDR;
					#line 317
					highp mat4 unity_MatrixMVP;
					highp mat4 unity_MatrixMV;
					highp mat4 unity_MatrixTMV;
					highp mat4 unity_MatrixITMV;
					#line 8
					#line 30
					#line 44
					#line 84
					#line 93
					#line 103
					#line 112
					#line 124
					#line 135
					#line 141
					#line 147
					#line 151
					#line 157
					#line 163
					#line 169
					#line 175
					#line 186
					#line 201
					#line 208
					#line 223
					#line 230
					#line 237
					#line 255
					#line 291
					#line 320
					#line 326
					#line 339
					#line 357
					#line 373
					#line 427
					#line 453
					#line 464
					#line 473
					#line 480
					#line 485
					#line 502
					#line 522
					#line 537
					#line 543
					#line 554
					uniform mediump vec4 unity_Lightmap_HDR;
					uniform mediump vec4 unity_DynamicLightmap_HDR;
					#line 568
					#line 578
					#line 593
					#line 602
					#line 609
					#line 618
					#line 626
					#line 635
					#line 654
					#line 660
					#line 670
					#line 680
					#line 691
					#line 696
					#line 702
					#line 707
					#line 764
					#line 770
					#line 785
					#line 816
					#line 830
					#line 834
					#line 840
					#line 849
					#line 859
					#line 885
					#line 891
					#line 7
					uniform sampler2D _MainTex;
					uniform lowp sampler3D _LookupTex3D;
					uniform sampler2D _LookupTex2D;
					uniform highp vec4 _Params;
					#line 17
					#line 23
					#line 29
					#line 35
					#line 41
					#line 47
					#line 67
					#line 91
					#line 97
					#line 35
					highp vec4 lookup_gamma( in highp vec4 o ) {
					    o.xyz = texture3D( _LookupTex3D, ((o.xyz * _Params.x) + _Params.y)).xyz;
					    return o;
					}
					#line 47
					highp vec4 frag( in v2f_img i ) {
					    highp vec4 color = xll_saturate_vf4(texture2D( _MainTex, i.uv));
					    highp vec4 x;
					    #line 55
					    x = lookup_gamma( color);
					    #line 59
					    return (( (i.uv.x > 0.5) ) ? ( mix( color, x, vec4( _Params.z)) ) : ( color ));
					}
					varying mediump vec2 xlv_TEXCOORD0;
					void main() {
					unity_MatrixMVP = (unity_MatrixVP * unity_ObjectToWorld);
					unity_MatrixMV = (unity_MatrixV * unity_ObjectToWorld);
					unity_MatrixTMV = xll_transpose_mf4x4(unity_MatrixMV);
					unity_MatrixITMV = xll_transpose_mf4x4((unity_WorldToObject * unity_MatrixInvV));
					    highp vec4 xl_retval;
					    v2f_img xlt_i;
					    xlt_i.pos = vec4(0.0);
					    xlt_i.uv = vec2(xlv_TEXCOORD0);
					    xl_retval = frag( xlt_i);
					    gl_FragData[0] = vec4(xl_retval);
					}
					/* HLSL2GLSL - NOTE: GLSL optimization failed
					(9,1): error: invalid type `sampler3D' in declaration of `_LookupTex3D'
					(37,21): error: `_LookupTex3D' undeclared
					(37,10): error: no matching function for call to `texture3D(error, vec3)'; candidates are:
					(37,10): error: type mismatch
					*/
					
					#endif"
				}
				SubProgram "gles3 hw_tier00 " {
					"!!GLES3
					#ifdef VERTEX
					#version 300 es
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					in highp vec4 in_POSITION0;
					in mediump vec2 in_TEXCOORD0;
					out mediump vec2 vs_TEXCOORD0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					void main()
					{
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy;
					    return;
					}
					
					#endif
					#ifdef FRAGMENT
					#version 300 es
					
					precision highp int;
					uniform 	vec4 _Params;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler3D _LookupTex3D;
					in mediump vec2 vs_TEXCOORD0;
					layout(location = 0) out highp vec4 SV_Target0;
					vec4 u_xlat0;
					lowp vec4 u_xlat10_0;
					vec4 u_xlat1;
					lowp vec3 u_xlat10_1;
					bool u_xlatb2;
					void main()
					{
					    u_xlat10_0 = texture(_MainTex, vs_TEXCOORD0.xy);
					    u_xlat0 = u_xlat10_0;
					#ifdef UNITY_ADRENO_ES3
					    u_xlat0 = min(max(u_xlat0, 0.0), 1.0);
					#else
					    u_xlat0 = clamp(u_xlat0, 0.0, 1.0);
					#endif
					    u_xlat1.xyz = u_xlat0.xyz * _Params.xxx + _Params.yyy;
					    u_xlat10_1.xyz = texture(_LookupTex3D, u_xlat1.xyz).xyz;
					    u_xlat1.xyz = (-u_xlat0.xyz) + u_xlat10_1.xyz;
					    u_xlat1.w = 0.0;
					    u_xlat1 = _Params.zzzz * u_xlat1 + u_xlat0;
					#ifdef UNITY_ADRENO_ES3
					    u_xlatb2 = !!(0.5<vs_TEXCOORD0.x);
					#else
					    u_xlatb2 = 0.5<vs_TEXCOORD0.x;
					#endif
					    SV_Target0 = (bool(u_xlatb2)) ? u_xlat1 : u_xlat0;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles3 hw_tier01 " {
					"!!GLES3
					#ifdef VERTEX
					#version 300 es
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					in highp vec4 in_POSITION0;
					in mediump vec2 in_TEXCOORD0;
					out mediump vec2 vs_TEXCOORD0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					void main()
					{
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy;
					    return;
					}
					
					#endif
					#ifdef FRAGMENT
					#version 300 es
					
					precision highp int;
					uniform 	vec4 _Params;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler3D _LookupTex3D;
					in mediump vec2 vs_TEXCOORD0;
					layout(location = 0) out highp vec4 SV_Target0;
					vec4 u_xlat0;
					lowp vec4 u_xlat10_0;
					vec4 u_xlat1;
					lowp vec3 u_xlat10_1;
					bool u_xlatb2;
					void main()
					{
					    u_xlat10_0 = texture(_MainTex, vs_TEXCOORD0.xy);
					    u_xlat0 = u_xlat10_0;
					#ifdef UNITY_ADRENO_ES3
					    u_xlat0 = min(max(u_xlat0, 0.0), 1.0);
					#else
					    u_xlat0 = clamp(u_xlat0, 0.0, 1.0);
					#endif
					    u_xlat1.xyz = u_xlat0.xyz * _Params.xxx + _Params.yyy;
					    u_xlat10_1.xyz = texture(_LookupTex3D, u_xlat1.xyz).xyz;
					    u_xlat1.xyz = (-u_xlat0.xyz) + u_xlat10_1.xyz;
					    u_xlat1.w = 0.0;
					    u_xlat1 = _Params.zzzz * u_xlat1 + u_xlat0;
					#ifdef UNITY_ADRENO_ES3
					    u_xlatb2 = !!(0.5<vs_TEXCOORD0.x);
					#else
					    u_xlatb2 = 0.5<vs_TEXCOORD0.x;
					#endif
					    SV_Target0 = (bool(u_xlatb2)) ? u_xlat1 : u_xlat0;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles3 hw_tier02 " {
					"!!GLES3
					#ifdef VERTEX
					#version 300 es
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					in highp vec4 in_POSITION0;
					in mediump vec2 in_TEXCOORD0;
					out mediump vec2 vs_TEXCOORD0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					void main()
					{
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy;
					    return;
					}
					
					#endif
					#ifdef FRAGMENT
					#version 300 es
					
					precision highp int;
					uniform 	vec4 _Params;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler3D _LookupTex3D;
					in mediump vec2 vs_TEXCOORD0;
					layout(location = 0) out highp vec4 SV_Target0;
					vec4 u_xlat0;
					lowp vec4 u_xlat10_0;
					vec4 u_xlat1;
					lowp vec3 u_xlat10_1;
					bool u_xlatb2;
					void main()
					{
					    u_xlat10_0 = texture(_MainTex, vs_TEXCOORD0.xy);
					    u_xlat0 = u_xlat10_0;
					#ifdef UNITY_ADRENO_ES3
					    u_xlat0 = min(max(u_xlat0, 0.0), 1.0);
					#else
					    u_xlat0 = clamp(u_xlat0, 0.0, 1.0);
					#endif
					    u_xlat1.xyz = u_xlat0.xyz * _Params.xxx + _Params.yyy;
					    u_xlat10_1.xyz = texture(_LookupTex3D, u_xlat1.xyz).xyz;
					    u_xlat1.xyz = (-u_xlat0.xyz) + u_xlat10_1.xyz;
					    u_xlat1.w = 0.0;
					    u_xlat1 = _Params.zzzz * u_xlat1 + u_xlat0;
					#ifdef UNITY_ADRENO_ES3
					    u_xlatb2 = !!(0.5<vs_TEXCOORD0.x);
					#else
					    u_xlatb2 = 0.5<vs_TEXCOORD0.x;
					#endif
					    SV_Target0 = (bool(u_xlatb2)) ? u_xlat1 : u_xlat0;
					    return;
					}
					
					#endif"
				}
			}
			Program "fp" {
				SubProgram "gles hw_tier00 " {
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					"!!GLES"
				}
				SubProgram "gles3 hw_tier00 " {
					"!!GLES3"
				}
				SubProgram "gles3 hw_tier01 " {
					"!!GLES3"
				}
				SubProgram "gles3 hw_tier02 " {
					"!!GLES3"
				}
			}
		}
		Pass {
			ZTest Always
			ZWrite Off
			Cull Off
			Fog {
				Mode Off
			}
			GpuProgramID 255989
			Program "vp" {
				SubProgram "gles hw_tier00 " {
					"!!GLES
					#version 100
					
					#ifdef VERTEX
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 30
					#endif
					#ifndef SHADER_REQUIRE_INTERPOLATORS10
					    #define SHADER_REQUIRE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_REQUIRE_SAMPLELOD
					    #define SHADER_REQUIRE_SAMPLELOD 1
					#endif
					#ifndef SHADER_REQUIRE_FRAGCOORD
					    #define SHADER_REQUIRE_FRAGCOORD 1
					#endif
					#ifndef UNITY_NO_DXT5nm
					    #define UNITY_NO_DXT5nm 1
					#endif
					#ifndef UNITY_NO_RGBM
					    #define UNITY_NO_RGBM 1
					#endif
					#ifndef UNITY_ENABLE_REFLECTION_BUFFERS
					    #define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#endif
					#ifndef UNITY_FRAMEBUFFER_FETCH_AVAILABLE
					    #define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#endif
					#ifndef UNITY_NO_CUBEMAP_ARRAY
					    #define UNITY_NO_CUBEMAP_ARRAY 1
					#endif
					#ifndef UNITY_NO_SCREENSPACE_SHADOWS
					    #define UNITY_NO_SCREENSPACE_SHADOWS 1
					#endif
					#ifndef UNITY_PBS_USE_BRDF3
					    #define UNITY_PBS_USE_BRDF3 1
					#endif
					#ifndef UNITY_NO_FULL_STANDARD_SHADER
					    #define UNITY_NO_FULL_STANDARD_SHADER 1
					#endif
					#ifndef SHADER_API_MOBILE
					    #define SHADER_API_MOBILE 1
					#endif
					#ifndef UNITY_HARDWARE_TIER1
					    #define UNITY_HARDWARE_TIER1 1
					#endif
					#ifndef UNITY_COLORSPACE_GAMMA
					    #define UNITY_COLORSPACE_GAMMA 1
					#endif
					#ifndef UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS
					    #define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#endif
					#ifndef UNITY_LIGHTMAP_DLDR_ENCODING
					    #define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#endif
					#ifndef UNITY_VERSION
					    #define UNITY_VERSION 201834
					#endif
					#ifndef SHADER_STAGE_VERTEX
					    #define SHADER_STAGE_VERTEX 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 30
					#endif
					#ifndef SHADER_AVAILABLE_INTERPOLATORS10
					    #define SHADER_AVAILABLE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_SAMPLELOD
					    #define SHADER_AVAILABLE_SAMPLELOD 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#define gl_Vertex _glesVertex
					attribute vec4 _glesVertex;
					#define gl_MultiTexCoord0 _glesMultiTexCoord0
					attribute vec4 _glesMultiTexCoord0;
					mat2 xll_transpose_mf2x2(mat2 m) {
					  return mat2( m[0][0], m[1][0], m[0][1], m[1][1]);
					}
					mat3 xll_transpose_mf3x3(mat3 m) {
					  return mat3( m[0][0], m[1][0], m[2][0],
					               m[0][1], m[1][1], m[2][1],
					               m[0][2], m[1][2], m[2][2]);
					}
					mat4 xll_transpose_mf4x4(mat4 m) {
					  return mat4( m[0][0], m[1][0], m[2][0], m[3][0],
					               m[0][1], m[1][1], m[2][1], m[3][1],
					               m[0][2], m[1][2], m[2][2], m[3][2],
					               m[0][3], m[1][3], m[2][3], m[3][3]);
					}
					#line 447
					struct v2f_vertex_lit {
					    highp vec2 uv;
					    lowp vec4 diff;
					    lowp vec4 spec;
					};
					#line 756
					struct v2f_img {
					    highp vec4 pos;
					    mediump vec2 uv;
					};
					#line 749
					struct appdata_img {
					    highp vec4 vertex;
					    mediump vec2 texcoord;
					};
					#line 40
					uniform highp vec4 _Time;
					uniform highp vec4 _SinTime;
					uniform highp vec4 _CosTime;
					uniform highp vec4 unity_DeltaTime;
					#line 46
					uniform highp vec3 _WorldSpaceCameraPos;
					#line 53
					uniform highp vec4 _ProjectionParams;
					#line 59
					uniform highp vec4 _ScreenParams;
					#line 71
					uniform highp vec4 _ZBufferParams;
					#line 77
					uniform highp vec4 unity_OrthoParams;
					#line 86
					uniform highp vec4 unity_CameraWorldClipPlanes[6];
					#line 92
					uniform highp mat4 unity_CameraProjection;
					uniform highp mat4 unity_CameraInvProjection;
					uniform highp mat4 unity_WorldToCamera;
					uniform highp mat4 unity_CameraToWorld;
					#line 108
					uniform highp vec4 _WorldSpaceLightPos0;
					uniform highp vec4 _LightPositionRange;
					#line 112
					uniform highp vec4 _LightProjectionParams;
					uniform highp vec4 unity_4LightPosX0;
					uniform highp vec4 unity_4LightPosY0;
					#line 116
					uniform highp vec4 unity_4LightPosZ0;
					uniform mediump vec4 unity_4LightAtten0;
					uniform mediump vec4 unity_LightColor[8];
					#line 122
					uniform highp vec4 unity_LightPosition[8];
					#line 127
					uniform mediump vec4 unity_LightAtten[8];
					uniform highp vec4 unity_SpotDirection[8];
					#line 131
					uniform mediump vec4 unity_SHAr;
					uniform mediump vec4 unity_SHAg;
					uniform mediump vec4 unity_SHAb;
					uniform mediump vec4 unity_SHBr;
					#line 135
					uniform mediump vec4 unity_SHBg;
					uniform mediump vec4 unity_SHBb;
					uniform mediump vec4 unity_SHC;
					#line 140
					uniform lowp vec4 unity_OcclusionMaskSelector;
					uniform lowp vec4 unity_ProbesOcclusion;
					#line 145
					uniform mediump vec3 unity_LightColor0;
					uniform mediump vec3 unity_LightColor1;
					uniform mediump vec3 unity_LightColor2;
					uniform mediump vec3 unity_LightColor3;
					#line 152
					uniform highp vec4 unity_ShadowSplitSpheres[4];
					uniform highp vec4 unity_ShadowSplitSqRadii;
					uniform highp vec4 unity_LightShadowBias;
					uniform highp vec4 _LightSplitsNear;
					#line 156
					uniform highp vec4 _LightSplitsFar;
					uniform highp mat4 unity_WorldToShadow[4];
					uniform mediump vec4 _LightShadowData;
					uniform highp vec4 unity_ShadowFadeCenterAndType;
					#line 165
					uniform highp mat4 unity_ObjectToWorld;
					uniform highp mat4 unity_WorldToObject;
					uniform highp vec4 unity_LODFade;
					uniform highp vec4 unity_WorldTransformParams;
					#line 206
					uniform highp mat4 glstate_matrix_transpose_modelview0;
					#line 214
					uniform lowp vec4 glstate_lightmodel_ambient;
					uniform lowp vec4 unity_AmbientSky;
					uniform lowp vec4 unity_AmbientEquator;
					uniform lowp vec4 unity_AmbientGround;
					#line 218
					uniform lowp vec4 unity_IndirectSpecColor;
					uniform highp mat4 glstate_matrix_projection;
					#line 222
					uniform highp mat4 unity_MatrixV;
					uniform highp mat4 unity_MatrixInvV;
					uniform highp mat4 unity_MatrixVP;
					uniform highp int unity_StereoEyeIndex;
					#line 228
					uniform lowp vec4 unity_ShadowColor;
					#line 235
					uniform lowp vec4 unity_FogColor;
					#line 240
					uniform highp vec4 unity_FogParams;
					#line 248
					uniform mediump sampler2D unity_Lightmap;
					uniform mediump sampler2D unity_LightmapInd;
					#line 252
					uniform sampler2D unity_ShadowMask;
					uniform sampler2D unity_DynamicLightmap;
					#line 256
					uniform sampler2D unity_DynamicDirectionality;
					uniform sampler2D unity_DynamicNormal;
					#line 260
					uniform highp vec4 unity_LightmapST;
					uniform highp vec4 unity_DynamicLightmapST;
					#line 268
					uniform samplerCube unity_SpecCube0;
					uniform samplerCube unity_SpecCube1;
					#line 272
					uniform highp vec4 unity_SpecCube0_BoxMax;
					uniform highp vec4 unity_SpecCube0_BoxMin;
					uniform highp vec4 unity_SpecCube0_ProbePosition;
					uniform mediump vec4 unity_SpecCube0_HDR;
					#line 277
					uniform highp vec4 unity_SpecCube1_BoxMax;
					uniform highp vec4 unity_SpecCube1_BoxMin;
					uniform highp vec4 unity_SpecCube1_ProbePosition;
					uniform mediump vec4 unity_SpecCube1_HDR;
					#line 317
					highp mat4 unity_MatrixMVP;
					highp mat4 unity_MatrixMV;
					highp mat4 unity_MatrixTMV;
					highp mat4 unity_MatrixITMV;
					#line 8
					#line 30
					#line 44
					#line 84
					#line 93
					#line 103
					#line 112
					#line 124
					#line 135
					#line 141
					#line 147
					#line 151
					#line 157
					#line 163
					#line 169
					#line 175
					#line 186
					#line 201
					#line 208
					#line 223
					#line 230
					#line 237
					#line 255
					#line 291
					#line 320
					#line 326
					#line 339
					#line 357
					#line 373
					#line 427
					#line 453
					#line 464
					#line 473
					#line 480
					#line 485
					#line 502
					#line 522
					#line 537
					#line 543
					#line 554
					uniform mediump vec4 unity_Lightmap_HDR;
					uniform mediump vec4 unity_DynamicLightmap_HDR;
					#line 568
					#line 578
					#line 593
					#line 602
					#line 609
					#line 618
					#line 626
					#line 635
					#line 654
					#line 660
					#line 670
					#line 680
					#line 691
					#line 696
					#line 702
					#line 707
					#line 764
					#line 770
					#line 785
					#line 816
					#line 830
					#line 834
					#line 840
					#line 849
					#line 859
					#line 885
					#line 891
					#line 7
					uniform sampler2D _MainTex;
					uniform lowp sampler3D _LookupTex3D;
					uniform sampler2D _LookupTex2D;
					uniform highp vec4 _Params;
					#line 17
					#line 23
					#line 29
					#line 35
					#line 41
					#line 47
					#line 67
					#line 91
					#line 97
					#line 44
					highp vec4 UnityObjectToClipPos( in highp vec3 pos ) {
					    #line 50
					    return (unity_MatrixVP * (unity_ObjectToWorld * vec4( pos, 1.0)));
					}
					#line 53
					highp vec4 UnityObjectToClipPos( in highp vec4 pos ) {
					    #line 55
					    return UnityObjectToClipPos( pos.xyz);
					}
					#line 770
					v2f_img vert_img( in appdata_img v ) {
					    v2f_img o;
					    #line 777
					    o.pos = UnityObjectToClipPos( v.vertex);
					    o.uv = v.texcoord;
					    return o;
					}
					varying mediump vec2 xlv_TEXCOORD0;
					void main() {
					unity_MatrixMVP = (unity_MatrixVP * unity_ObjectToWorld);
					unity_MatrixMV = (unity_MatrixV * unity_ObjectToWorld);
					unity_MatrixTMV = xll_transpose_mf4x4(unity_MatrixMV);
					unity_MatrixITMV = xll_transpose_mf4x4((unity_WorldToObject * unity_MatrixInvV));
					    v2f_img xl_retval;
					    appdata_img xlt_v;
					    xlt_v.vertex = vec4(gl_Vertex);
					    xlt_v.texcoord = vec2(gl_MultiTexCoord0);
					    xl_retval = vert_img( xlt_v);
					    gl_Position = vec4(xl_retval.pos);
					    xlv_TEXCOORD0 = vec2(xl_retval.uv);
					}
					/* HLSL2GLSL - NOTE: GLSL optimization failed
					(9,1): error: invalid type `sampler3D' in declaration of `_LookupTex3D'
					*/
					
					#endif
					#ifdef FRAGMENT
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 30
					#endif
					#ifndef SHADER_REQUIRE_INTERPOLATORS10
					    #define SHADER_REQUIRE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_REQUIRE_SAMPLELOD
					    #define SHADER_REQUIRE_SAMPLELOD 1
					#endif
					#ifndef SHADER_REQUIRE_FRAGCOORD
					    #define SHADER_REQUIRE_FRAGCOORD 1
					#endif
					#ifndef UNITY_NO_DXT5nm
					    #define UNITY_NO_DXT5nm 1
					#endif
					#ifndef UNITY_NO_RGBM
					    #define UNITY_NO_RGBM 1
					#endif
					#ifndef UNITY_ENABLE_REFLECTION_BUFFERS
					    #define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#endif
					#ifndef UNITY_FRAMEBUFFER_FETCH_AVAILABLE
					    #define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#endif
					#ifndef UNITY_NO_CUBEMAP_ARRAY
					    #define UNITY_NO_CUBEMAP_ARRAY 1
					#endif
					#ifndef UNITY_NO_SCREENSPACE_SHADOWS
					    #define UNITY_NO_SCREENSPACE_SHADOWS 1
					#endif
					#ifndef UNITY_PBS_USE_BRDF3
					    #define UNITY_PBS_USE_BRDF3 1
					#endif
					#ifndef UNITY_NO_FULL_STANDARD_SHADER
					    #define UNITY_NO_FULL_STANDARD_SHADER 1
					#endif
					#ifndef SHADER_API_MOBILE
					    #define SHADER_API_MOBILE 1
					#endif
					#ifndef UNITY_HARDWARE_TIER1
					    #define UNITY_HARDWARE_TIER1 1
					#endif
					#ifndef UNITY_COLORSPACE_GAMMA
					    #define UNITY_COLORSPACE_GAMMA 1
					#endif
					#ifndef UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS
					    #define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#endif
					#ifndef UNITY_LIGHTMAP_DLDR_ENCODING
					    #define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#endif
					#ifndef UNITY_VERSION
					    #define UNITY_VERSION 201834
					#endif
					#ifndef SHADER_STAGE_VERTEX
					    #define SHADER_STAGE_VERTEX 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 30
					#endif
					#ifndef SHADER_AVAILABLE_INTERPOLATORS10
					    #define SHADER_AVAILABLE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_SAMPLELOD
					    #define SHADER_AVAILABLE_SAMPLELOD 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					mat2 xll_transpose_mf2x2(mat2 m) {
					  return mat2( m[0][0], m[1][0], m[0][1], m[1][1]);
					}
					mat3 xll_transpose_mf3x3(mat3 m) {
					  return mat3( m[0][0], m[1][0], m[2][0],
					               m[0][1], m[1][1], m[2][1],
					               m[0][2], m[1][2], m[2][2]);
					}
					mat4 xll_transpose_mf4x4(mat4 m) {
					  return mat4( m[0][0], m[1][0], m[2][0], m[3][0],
					               m[0][1], m[1][1], m[2][1], m[3][1],
					               m[0][2], m[1][2], m[2][2], m[3][2],
					               m[0][3], m[1][3], m[2][3], m[3][3]);
					}
					float xll_saturate_f( float x) {
					  return clamp( x, 0.0, 1.0);
					}
					vec2 xll_saturate_vf2( vec2 x) {
					  return clamp( x, 0.0, 1.0);
					}
					vec3 xll_saturate_vf3( vec3 x) {
					  return clamp( x, 0.0, 1.0);
					}
					vec4 xll_saturate_vf4( vec4 x) {
					  return clamp( x, 0.0, 1.0);
					}
					mat2 xll_saturate_mf2x2(mat2 m) {
					  return mat2( clamp(m[0], 0.0, 1.0), clamp(m[1], 0.0, 1.0));
					}
					mat3 xll_saturate_mf3x3(mat3 m) {
					  return mat3( clamp(m[0], 0.0, 1.0), clamp(m[1], 0.0, 1.0), clamp(m[2], 0.0, 1.0));
					}
					mat4 xll_saturate_mf4x4(mat4 m) {
					  return mat4( clamp(m[0], 0.0, 1.0), clamp(m[1], 0.0, 1.0), clamp(m[2], 0.0, 1.0), clamp(m[3], 0.0, 1.0));
					}
					vec2 xll_vecTSel_vb2_vf2_vf2 (bvec2 a, vec2 b, vec2 c) {
					  return vec2 (a.x ? b.x : c.x, a.y ? b.y : c.y);
					}
					vec3 xll_vecTSel_vb3_vf3_vf3 (bvec3 a, vec3 b, vec3 c) {
					  return vec3 (a.x ? b.x : c.x, a.y ? b.y : c.y, a.z ? b.z : c.z);
					}
					vec4 xll_vecTSel_vb4_vf4_vf4 (bvec4 a, vec4 b, vec4 c) {
					  return vec4 (a.x ? b.x : c.x, a.y ? b.y : c.y, a.z ? b.z : c.z, a.w ? b.w : c.w);
					}
					#line 447
					struct v2f_vertex_lit {
					    highp vec2 uv;
					    lowp vec4 diff;
					    lowp vec4 spec;
					};
					#line 756
					struct v2f_img {
					    highp vec4 pos;
					    mediump vec2 uv;
					};
					#line 749
					struct appdata_img {
					    highp vec4 vertex;
					    mediump vec2 texcoord;
					};
					#line 40
					uniform highp vec4 _Time;
					uniform highp vec4 _SinTime;
					uniform highp vec4 _CosTime;
					uniform highp vec4 unity_DeltaTime;
					#line 46
					uniform highp vec3 _WorldSpaceCameraPos;
					#line 53
					uniform highp vec4 _ProjectionParams;
					#line 59
					uniform highp vec4 _ScreenParams;
					#line 71
					uniform highp vec4 _ZBufferParams;
					#line 77
					uniform highp vec4 unity_OrthoParams;
					#line 86
					uniform highp vec4 unity_CameraWorldClipPlanes[6];
					#line 92
					uniform highp mat4 unity_CameraProjection;
					uniform highp mat4 unity_CameraInvProjection;
					uniform highp mat4 unity_WorldToCamera;
					uniform highp mat4 unity_CameraToWorld;
					#line 108
					uniform highp vec4 _WorldSpaceLightPos0;
					uniform highp vec4 _LightPositionRange;
					#line 112
					uniform highp vec4 _LightProjectionParams;
					uniform highp vec4 unity_4LightPosX0;
					uniform highp vec4 unity_4LightPosY0;
					#line 116
					uniform highp vec4 unity_4LightPosZ0;
					uniform mediump vec4 unity_4LightAtten0;
					uniform mediump vec4 unity_LightColor[8];
					#line 122
					uniform highp vec4 unity_LightPosition[8];
					#line 127
					uniform mediump vec4 unity_LightAtten[8];
					uniform highp vec4 unity_SpotDirection[8];
					#line 131
					uniform mediump vec4 unity_SHAr;
					uniform mediump vec4 unity_SHAg;
					uniform mediump vec4 unity_SHAb;
					uniform mediump vec4 unity_SHBr;
					#line 135
					uniform mediump vec4 unity_SHBg;
					uniform mediump vec4 unity_SHBb;
					uniform mediump vec4 unity_SHC;
					#line 140
					uniform lowp vec4 unity_OcclusionMaskSelector;
					uniform lowp vec4 unity_ProbesOcclusion;
					#line 145
					uniform mediump vec3 unity_LightColor0;
					uniform mediump vec3 unity_LightColor1;
					uniform mediump vec3 unity_LightColor2;
					uniform mediump vec3 unity_LightColor3;
					#line 152
					uniform highp vec4 unity_ShadowSplitSpheres[4];
					uniform highp vec4 unity_ShadowSplitSqRadii;
					uniform highp vec4 unity_LightShadowBias;
					uniform highp vec4 _LightSplitsNear;
					#line 156
					uniform highp vec4 _LightSplitsFar;
					uniform highp mat4 unity_WorldToShadow[4];
					uniform mediump vec4 _LightShadowData;
					uniform highp vec4 unity_ShadowFadeCenterAndType;
					#line 165
					uniform highp mat4 unity_ObjectToWorld;
					uniform highp mat4 unity_WorldToObject;
					uniform highp vec4 unity_LODFade;
					uniform highp vec4 unity_WorldTransformParams;
					#line 206
					uniform highp mat4 glstate_matrix_transpose_modelview0;
					#line 214
					uniform lowp vec4 glstate_lightmodel_ambient;
					uniform lowp vec4 unity_AmbientSky;
					uniform lowp vec4 unity_AmbientEquator;
					uniform lowp vec4 unity_AmbientGround;
					#line 218
					uniform lowp vec4 unity_IndirectSpecColor;
					uniform highp mat4 glstate_matrix_projection;
					#line 222
					uniform highp mat4 unity_MatrixV;
					uniform highp mat4 unity_MatrixInvV;
					uniform highp mat4 unity_MatrixVP;
					uniform highp int unity_StereoEyeIndex;
					#line 228
					uniform lowp vec4 unity_ShadowColor;
					#line 235
					uniform lowp vec4 unity_FogColor;
					#line 240
					uniform highp vec4 unity_FogParams;
					#line 248
					uniform mediump sampler2D unity_Lightmap;
					uniform mediump sampler2D unity_LightmapInd;
					#line 252
					uniform sampler2D unity_ShadowMask;
					uniform sampler2D unity_DynamicLightmap;
					#line 256
					uniform sampler2D unity_DynamicDirectionality;
					uniform sampler2D unity_DynamicNormal;
					#line 260
					uniform highp vec4 unity_LightmapST;
					uniform highp vec4 unity_DynamicLightmapST;
					#line 268
					uniform samplerCube unity_SpecCube0;
					uniform samplerCube unity_SpecCube1;
					#line 272
					uniform highp vec4 unity_SpecCube0_BoxMax;
					uniform highp vec4 unity_SpecCube0_BoxMin;
					uniform highp vec4 unity_SpecCube0_ProbePosition;
					uniform mediump vec4 unity_SpecCube0_HDR;
					#line 277
					uniform highp vec4 unity_SpecCube1_BoxMax;
					uniform highp vec4 unity_SpecCube1_BoxMin;
					uniform highp vec4 unity_SpecCube1_ProbePosition;
					uniform mediump vec4 unity_SpecCube1_HDR;
					#line 317
					highp mat4 unity_MatrixMVP;
					highp mat4 unity_MatrixMV;
					highp mat4 unity_MatrixTMV;
					highp mat4 unity_MatrixITMV;
					#line 8
					#line 30
					#line 44
					#line 84
					#line 93
					#line 103
					#line 112
					#line 124
					#line 135
					#line 141
					#line 147
					#line 151
					#line 157
					#line 163
					#line 169
					#line 175
					#line 186
					#line 201
					#line 208
					#line 223
					#line 230
					#line 237
					#line 255
					#line 291
					#line 320
					#line 326
					#line 339
					#line 357
					#line 373
					#line 427
					#line 453
					#line 464
					#line 473
					#line 480
					#line 485
					#line 502
					#line 522
					#line 537
					#line 543
					#line 554
					uniform mediump vec4 unity_Lightmap_HDR;
					uniform mediump vec4 unity_DynamicLightmap_HDR;
					#line 568
					#line 578
					#line 593
					#line 602
					#line 609
					#line 618
					#line 626
					#line 635
					#line 654
					#line 660
					#line 670
					#line 680
					#line 691
					#line 696
					#line 702
					#line 707
					#line 764
					#line 770
					#line 785
					#line 816
					#line 830
					#line 834
					#line 840
					#line 849
					#line 859
					#line 885
					#line 891
					#line 7
					uniform sampler2D _MainTex;
					uniform lowp sampler3D _LookupTex3D;
					uniform sampler2D _LookupTex2D;
					uniform highp vec4 _Params;
					#line 17
					#line 23
					#line 29
					#line 35
					#line 41
					#line 47
					#line 67
					#line 91
					#line 97
					#line 29
					highp vec4 Linear( in highp vec4 color ) {
					    color.xyz = xll_vecTSel_vb3_vf3_vf3 (lessThanEqual( color.xyz, vec3( 0.0404482, 0.0404482, 0.0404482)), (color.xyz / 12.92321), pow( ((color.xyz + 0.055) * 0.9478672), vec3( 2.4)));
					    return color;
					}
					#line 17
					highp vec3 sRGB( in highp vec3 color ) {
					    color = xll_vecTSel_vb3_vf3_vf3 (lessThanEqual( color, vec3( 0.0031308, 0.0031308, 0.0031308)), (color * 12.92321), ((1.055 * pow( color, vec3( 0.41666))) - 0.055));
					    return color;
					}
					#line 41
					highp vec4 lookup_linear( in highp vec4 o ) {
					    o.xyz = texture3D( _LookupTex3D, ((sRGB( o.xyz) * _Params.x) + _Params.y)).xyz;
					    return Linear( o);
					}
					#line 47
					highp vec4 frag( in v2f_img i ) {
					    highp vec4 color = xll_saturate_vf4(texture2D( _MainTex, i.uv));
					    highp vec4 x;
					    #line 53
					    x = lookup_linear( color);
					    #line 59
					    return (( (i.uv.x > 0.5) ) ? ( mix( color, x, vec4( _Params.z)) ) : ( color ));
					}
					varying mediump vec2 xlv_TEXCOORD0;
					void main() {
					unity_MatrixMVP = (unity_MatrixVP * unity_ObjectToWorld);
					unity_MatrixMV = (unity_MatrixV * unity_ObjectToWorld);
					unity_MatrixTMV = xll_transpose_mf4x4(unity_MatrixMV);
					unity_MatrixITMV = xll_transpose_mf4x4((unity_WorldToObject * unity_MatrixInvV));
					    highp vec4 xl_retval;
					    v2f_img xlt_i;
					    xlt_i.pos = vec4(0.0);
					    xlt_i.uv = vec2(xlv_TEXCOORD0);
					    xl_retval = frag( xlt_i);
					    gl_FragData[0] = vec4(xl_retval);
					}
					/* HLSL2GLSL - NOTE: GLSL optimization failed
					(9,1): error: invalid type `sampler3D' in declaration of `_LookupTex3D'
					(43,21): error: `_LookupTex3D' undeclared
					(43,10): error: no matching function for call to `texture3D(error, vec3)'; candidates are:
					(43,10): error: type mismatch
					*/
					
					#endif"
				}
				SubProgram "gles hw_tier01 " {
					"!!GLES
					#version 100
					
					#ifdef VERTEX
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 30
					#endif
					#ifndef SHADER_REQUIRE_INTERPOLATORS10
					    #define SHADER_REQUIRE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_REQUIRE_SAMPLELOD
					    #define SHADER_REQUIRE_SAMPLELOD 1
					#endif
					#ifndef SHADER_REQUIRE_FRAGCOORD
					    #define SHADER_REQUIRE_FRAGCOORD 1
					#endif
					#ifndef UNITY_NO_DXT5nm
					    #define UNITY_NO_DXT5nm 1
					#endif
					#ifndef UNITY_NO_RGBM
					    #define UNITY_NO_RGBM 1
					#endif
					#ifndef UNITY_ENABLE_REFLECTION_BUFFERS
					    #define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#endif
					#ifndef UNITY_FRAMEBUFFER_FETCH_AVAILABLE
					    #define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#endif
					#ifndef UNITY_NO_CUBEMAP_ARRAY
					    #define UNITY_NO_CUBEMAP_ARRAY 1
					#endif
					#ifndef UNITY_NO_SCREENSPACE_SHADOWS
					    #define UNITY_NO_SCREENSPACE_SHADOWS 1
					#endif
					#ifndef UNITY_PBS_USE_BRDF2
					    #define UNITY_PBS_USE_BRDF2 1
					#endif
					#ifndef SHADER_API_MOBILE
					    #define SHADER_API_MOBILE 1
					#endif
					#ifndef UNITY_HARDWARE_TIER2
					    #define UNITY_HARDWARE_TIER2 1
					#endif
					#ifndef UNITY_COLORSPACE_GAMMA
					    #define UNITY_COLORSPACE_GAMMA 1
					#endif
					#ifndef UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS
					    #define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#endif
					#ifndef UNITY_LIGHTMAP_DLDR_ENCODING
					    #define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#endif
					#ifndef UNITY_VERSION
					    #define UNITY_VERSION 201834
					#endif
					#ifndef SHADER_STAGE_VERTEX
					    #define SHADER_STAGE_VERTEX 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 30
					#endif
					#ifndef SHADER_AVAILABLE_INTERPOLATORS10
					    #define SHADER_AVAILABLE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_SAMPLELOD
					    #define SHADER_AVAILABLE_SAMPLELOD 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#define gl_Vertex _glesVertex
					attribute vec4 _glesVertex;
					#define gl_MultiTexCoord0 _glesMultiTexCoord0
					attribute vec4 _glesMultiTexCoord0;
					mat2 xll_transpose_mf2x2(mat2 m) {
					  return mat2( m[0][0], m[1][0], m[0][1], m[1][1]);
					}
					mat3 xll_transpose_mf3x3(mat3 m) {
					  return mat3( m[0][0], m[1][0], m[2][0],
					               m[0][1], m[1][1], m[2][1],
					               m[0][2], m[1][2], m[2][2]);
					}
					mat4 xll_transpose_mf4x4(mat4 m) {
					  return mat4( m[0][0], m[1][0], m[2][0], m[3][0],
					               m[0][1], m[1][1], m[2][1], m[3][1],
					               m[0][2], m[1][2], m[2][2], m[3][2],
					               m[0][3], m[1][3], m[2][3], m[3][3]);
					}
					#line 447
					struct v2f_vertex_lit {
					    highp vec2 uv;
					    lowp vec4 diff;
					    lowp vec4 spec;
					};
					#line 756
					struct v2f_img {
					    highp vec4 pos;
					    mediump vec2 uv;
					};
					#line 749
					struct appdata_img {
					    highp vec4 vertex;
					    mediump vec2 texcoord;
					};
					#line 40
					uniform highp vec4 _Time;
					uniform highp vec4 _SinTime;
					uniform highp vec4 _CosTime;
					uniform highp vec4 unity_DeltaTime;
					#line 46
					uniform highp vec3 _WorldSpaceCameraPos;
					#line 53
					uniform highp vec4 _ProjectionParams;
					#line 59
					uniform highp vec4 _ScreenParams;
					#line 71
					uniform highp vec4 _ZBufferParams;
					#line 77
					uniform highp vec4 unity_OrthoParams;
					#line 86
					uniform highp vec4 unity_CameraWorldClipPlanes[6];
					#line 92
					uniform highp mat4 unity_CameraProjection;
					uniform highp mat4 unity_CameraInvProjection;
					uniform highp mat4 unity_WorldToCamera;
					uniform highp mat4 unity_CameraToWorld;
					#line 108
					uniform highp vec4 _WorldSpaceLightPos0;
					uniform highp vec4 _LightPositionRange;
					#line 112
					uniform highp vec4 _LightProjectionParams;
					uniform highp vec4 unity_4LightPosX0;
					uniform highp vec4 unity_4LightPosY0;
					#line 116
					uniform highp vec4 unity_4LightPosZ0;
					uniform mediump vec4 unity_4LightAtten0;
					uniform mediump vec4 unity_LightColor[8];
					#line 122
					uniform highp vec4 unity_LightPosition[8];
					#line 127
					uniform mediump vec4 unity_LightAtten[8];
					uniform highp vec4 unity_SpotDirection[8];
					#line 131
					uniform mediump vec4 unity_SHAr;
					uniform mediump vec4 unity_SHAg;
					uniform mediump vec4 unity_SHAb;
					uniform mediump vec4 unity_SHBr;
					#line 135
					uniform mediump vec4 unity_SHBg;
					uniform mediump vec4 unity_SHBb;
					uniform mediump vec4 unity_SHC;
					#line 140
					uniform lowp vec4 unity_OcclusionMaskSelector;
					uniform lowp vec4 unity_ProbesOcclusion;
					#line 145
					uniform mediump vec3 unity_LightColor0;
					uniform mediump vec3 unity_LightColor1;
					uniform mediump vec3 unity_LightColor2;
					uniform mediump vec3 unity_LightColor3;
					#line 152
					uniform highp vec4 unity_ShadowSplitSpheres[4];
					uniform highp vec4 unity_ShadowSplitSqRadii;
					uniform highp vec4 unity_LightShadowBias;
					uniform highp vec4 _LightSplitsNear;
					#line 156
					uniform highp vec4 _LightSplitsFar;
					uniform highp mat4 unity_WorldToShadow[4];
					uniform mediump vec4 _LightShadowData;
					uniform highp vec4 unity_ShadowFadeCenterAndType;
					#line 165
					uniform highp mat4 unity_ObjectToWorld;
					uniform highp mat4 unity_WorldToObject;
					uniform highp vec4 unity_LODFade;
					uniform highp vec4 unity_WorldTransformParams;
					#line 206
					uniform highp mat4 glstate_matrix_transpose_modelview0;
					#line 214
					uniform lowp vec4 glstate_lightmodel_ambient;
					uniform lowp vec4 unity_AmbientSky;
					uniform lowp vec4 unity_AmbientEquator;
					uniform lowp vec4 unity_AmbientGround;
					#line 218
					uniform lowp vec4 unity_IndirectSpecColor;
					uniform highp mat4 glstate_matrix_projection;
					#line 222
					uniform highp mat4 unity_MatrixV;
					uniform highp mat4 unity_MatrixInvV;
					uniform highp mat4 unity_MatrixVP;
					uniform highp int unity_StereoEyeIndex;
					#line 228
					uniform lowp vec4 unity_ShadowColor;
					#line 235
					uniform lowp vec4 unity_FogColor;
					#line 240
					uniform highp vec4 unity_FogParams;
					#line 248
					uniform mediump sampler2D unity_Lightmap;
					uniform mediump sampler2D unity_LightmapInd;
					#line 252
					uniform sampler2D unity_ShadowMask;
					uniform sampler2D unity_DynamicLightmap;
					#line 256
					uniform sampler2D unity_DynamicDirectionality;
					uniform sampler2D unity_DynamicNormal;
					#line 260
					uniform highp vec4 unity_LightmapST;
					uniform highp vec4 unity_DynamicLightmapST;
					#line 268
					uniform samplerCube unity_SpecCube0;
					uniform samplerCube unity_SpecCube1;
					#line 272
					uniform highp vec4 unity_SpecCube0_BoxMax;
					uniform highp vec4 unity_SpecCube0_BoxMin;
					uniform highp vec4 unity_SpecCube0_ProbePosition;
					uniform mediump vec4 unity_SpecCube0_HDR;
					#line 277
					uniform highp vec4 unity_SpecCube1_BoxMax;
					uniform highp vec4 unity_SpecCube1_BoxMin;
					uniform highp vec4 unity_SpecCube1_ProbePosition;
					uniform mediump vec4 unity_SpecCube1_HDR;
					#line 317
					highp mat4 unity_MatrixMVP;
					highp mat4 unity_MatrixMV;
					highp mat4 unity_MatrixTMV;
					highp mat4 unity_MatrixITMV;
					#line 8
					#line 30
					#line 44
					#line 84
					#line 93
					#line 103
					#line 112
					#line 124
					#line 135
					#line 141
					#line 147
					#line 151
					#line 157
					#line 163
					#line 169
					#line 175
					#line 186
					#line 201
					#line 208
					#line 223
					#line 230
					#line 237
					#line 255
					#line 291
					#line 320
					#line 326
					#line 339
					#line 357
					#line 373
					#line 427
					#line 453
					#line 464
					#line 473
					#line 480
					#line 485
					#line 502
					#line 522
					#line 537
					#line 543
					#line 554
					uniform mediump vec4 unity_Lightmap_HDR;
					uniform mediump vec4 unity_DynamicLightmap_HDR;
					#line 568
					#line 578
					#line 593
					#line 602
					#line 609
					#line 618
					#line 626
					#line 635
					#line 654
					#line 660
					#line 670
					#line 680
					#line 691
					#line 696
					#line 702
					#line 707
					#line 764
					#line 770
					#line 785
					#line 816
					#line 830
					#line 834
					#line 840
					#line 849
					#line 859
					#line 885
					#line 891
					#line 7
					uniform sampler2D _MainTex;
					uniform lowp sampler3D _LookupTex3D;
					uniform sampler2D _LookupTex2D;
					uniform highp vec4 _Params;
					#line 17
					#line 23
					#line 29
					#line 35
					#line 41
					#line 47
					#line 67
					#line 91
					#line 97
					#line 44
					highp vec4 UnityObjectToClipPos( in highp vec3 pos ) {
					    #line 50
					    return (unity_MatrixVP * (unity_ObjectToWorld * vec4( pos, 1.0)));
					}
					#line 53
					highp vec4 UnityObjectToClipPos( in highp vec4 pos ) {
					    #line 55
					    return UnityObjectToClipPos( pos.xyz);
					}
					#line 770
					v2f_img vert_img( in appdata_img v ) {
					    v2f_img o;
					    #line 777
					    o.pos = UnityObjectToClipPos( v.vertex);
					    o.uv = v.texcoord;
					    return o;
					}
					varying mediump vec2 xlv_TEXCOORD0;
					void main() {
					unity_MatrixMVP = (unity_MatrixVP * unity_ObjectToWorld);
					unity_MatrixMV = (unity_MatrixV * unity_ObjectToWorld);
					unity_MatrixTMV = xll_transpose_mf4x4(unity_MatrixMV);
					unity_MatrixITMV = xll_transpose_mf4x4((unity_WorldToObject * unity_MatrixInvV));
					    v2f_img xl_retval;
					    appdata_img xlt_v;
					    xlt_v.vertex = vec4(gl_Vertex);
					    xlt_v.texcoord = vec2(gl_MultiTexCoord0);
					    xl_retval = vert_img( xlt_v);
					    gl_Position = vec4(xl_retval.pos);
					    xlv_TEXCOORD0 = vec2(xl_retval.uv);
					}
					/* HLSL2GLSL - NOTE: GLSL optimization failed
					(9,1): error: invalid type `sampler3D' in declaration of `_LookupTex3D'
					*/
					
					#endif
					#ifdef FRAGMENT
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 30
					#endif
					#ifndef SHADER_REQUIRE_INTERPOLATORS10
					    #define SHADER_REQUIRE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_REQUIRE_SAMPLELOD
					    #define SHADER_REQUIRE_SAMPLELOD 1
					#endif
					#ifndef SHADER_REQUIRE_FRAGCOORD
					    #define SHADER_REQUIRE_FRAGCOORD 1
					#endif
					#ifndef UNITY_NO_DXT5nm
					    #define UNITY_NO_DXT5nm 1
					#endif
					#ifndef UNITY_NO_RGBM
					    #define UNITY_NO_RGBM 1
					#endif
					#ifndef UNITY_ENABLE_REFLECTION_BUFFERS
					    #define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#endif
					#ifndef UNITY_FRAMEBUFFER_FETCH_AVAILABLE
					    #define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#endif
					#ifndef UNITY_NO_CUBEMAP_ARRAY
					    #define UNITY_NO_CUBEMAP_ARRAY 1
					#endif
					#ifndef UNITY_NO_SCREENSPACE_SHADOWS
					    #define UNITY_NO_SCREENSPACE_SHADOWS 1
					#endif
					#ifndef UNITY_PBS_USE_BRDF2
					    #define UNITY_PBS_USE_BRDF2 1
					#endif
					#ifndef SHADER_API_MOBILE
					    #define SHADER_API_MOBILE 1
					#endif
					#ifndef UNITY_HARDWARE_TIER2
					    #define UNITY_HARDWARE_TIER2 1
					#endif
					#ifndef UNITY_COLORSPACE_GAMMA
					    #define UNITY_COLORSPACE_GAMMA 1
					#endif
					#ifndef UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS
					    #define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#endif
					#ifndef UNITY_LIGHTMAP_DLDR_ENCODING
					    #define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#endif
					#ifndef UNITY_VERSION
					    #define UNITY_VERSION 201834
					#endif
					#ifndef SHADER_STAGE_VERTEX
					    #define SHADER_STAGE_VERTEX 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 30
					#endif
					#ifndef SHADER_AVAILABLE_INTERPOLATORS10
					    #define SHADER_AVAILABLE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_SAMPLELOD
					    #define SHADER_AVAILABLE_SAMPLELOD 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					mat2 xll_transpose_mf2x2(mat2 m) {
					  return mat2( m[0][0], m[1][0], m[0][1], m[1][1]);
					}
					mat3 xll_transpose_mf3x3(mat3 m) {
					  return mat3( m[0][0], m[1][0], m[2][0],
					               m[0][1], m[1][1], m[2][1],
					               m[0][2], m[1][2], m[2][2]);
					}
					mat4 xll_transpose_mf4x4(mat4 m) {
					  return mat4( m[0][0], m[1][0], m[2][0], m[3][0],
					               m[0][1], m[1][1], m[2][1], m[3][1],
					               m[0][2], m[1][2], m[2][2], m[3][2],
					               m[0][3], m[1][3], m[2][3], m[3][3]);
					}
					float xll_saturate_f( float x) {
					  return clamp( x, 0.0, 1.0);
					}
					vec2 xll_saturate_vf2( vec2 x) {
					  return clamp( x, 0.0, 1.0);
					}
					vec3 xll_saturate_vf3( vec3 x) {
					  return clamp( x, 0.0, 1.0);
					}
					vec4 xll_saturate_vf4( vec4 x) {
					  return clamp( x, 0.0, 1.0);
					}
					mat2 xll_saturate_mf2x2(mat2 m) {
					  return mat2( clamp(m[0], 0.0, 1.0), clamp(m[1], 0.0, 1.0));
					}
					mat3 xll_saturate_mf3x3(mat3 m) {
					  return mat3( clamp(m[0], 0.0, 1.0), clamp(m[1], 0.0, 1.0), clamp(m[2], 0.0, 1.0));
					}
					mat4 xll_saturate_mf4x4(mat4 m) {
					  return mat4( clamp(m[0], 0.0, 1.0), clamp(m[1], 0.0, 1.0), clamp(m[2], 0.0, 1.0), clamp(m[3], 0.0, 1.0));
					}
					vec2 xll_vecTSel_vb2_vf2_vf2 (bvec2 a, vec2 b, vec2 c) {
					  return vec2 (a.x ? b.x : c.x, a.y ? b.y : c.y);
					}
					vec3 xll_vecTSel_vb3_vf3_vf3 (bvec3 a, vec3 b, vec3 c) {
					  return vec3 (a.x ? b.x : c.x, a.y ? b.y : c.y, a.z ? b.z : c.z);
					}
					vec4 xll_vecTSel_vb4_vf4_vf4 (bvec4 a, vec4 b, vec4 c) {
					  return vec4 (a.x ? b.x : c.x, a.y ? b.y : c.y, a.z ? b.z : c.z, a.w ? b.w : c.w);
					}
					#line 447
					struct v2f_vertex_lit {
					    highp vec2 uv;
					    lowp vec4 diff;
					    lowp vec4 spec;
					};
					#line 756
					struct v2f_img {
					    highp vec4 pos;
					    mediump vec2 uv;
					};
					#line 749
					struct appdata_img {
					    highp vec4 vertex;
					    mediump vec2 texcoord;
					};
					#line 40
					uniform highp vec4 _Time;
					uniform highp vec4 _SinTime;
					uniform highp vec4 _CosTime;
					uniform highp vec4 unity_DeltaTime;
					#line 46
					uniform highp vec3 _WorldSpaceCameraPos;
					#line 53
					uniform highp vec4 _ProjectionParams;
					#line 59
					uniform highp vec4 _ScreenParams;
					#line 71
					uniform highp vec4 _ZBufferParams;
					#line 77
					uniform highp vec4 unity_OrthoParams;
					#line 86
					uniform highp vec4 unity_CameraWorldClipPlanes[6];
					#line 92
					uniform highp mat4 unity_CameraProjection;
					uniform highp mat4 unity_CameraInvProjection;
					uniform highp mat4 unity_WorldToCamera;
					uniform highp mat4 unity_CameraToWorld;
					#line 108
					uniform highp vec4 _WorldSpaceLightPos0;
					uniform highp vec4 _LightPositionRange;
					#line 112
					uniform highp vec4 _LightProjectionParams;
					uniform highp vec4 unity_4LightPosX0;
					uniform highp vec4 unity_4LightPosY0;
					#line 116
					uniform highp vec4 unity_4LightPosZ0;
					uniform mediump vec4 unity_4LightAtten0;
					uniform mediump vec4 unity_LightColor[8];
					#line 122
					uniform highp vec4 unity_LightPosition[8];
					#line 127
					uniform mediump vec4 unity_LightAtten[8];
					uniform highp vec4 unity_SpotDirection[8];
					#line 131
					uniform mediump vec4 unity_SHAr;
					uniform mediump vec4 unity_SHAg;
					uniform mediump vec4 unity_SHAb;
					uniform mediump vec4 unity_SHBr;
					#line 135
					uniform mediump vec4 unity_SHBg;
					uniform mediump vec4 unity_SHBb;
					uniform mediump vec4 unity_SHC;
					#line 140
					uniform lowp vec4 unity_OcclusionMaskSelector;
					uniform lowp vec4 unity_ProbesOcclusion;
					#line 145
					uniform mediump vec3 unity_LightColor0;
					uniform mediump vec3 unity_LightColor1;
					uniform mediump vec3 unity_LightColor2;
					uniform mediump vec3 unity_LightColor3;
					#line 152
					uniform highp vec4 unity_ShadowSplitSpheres[4];
					uniform highp vec4 unity_ShadowSplitSqRadii;
					uniform highp vec4 unity_LightShadowBias;
					uniform highp vec4 _LightSplitsNear;
					#line 156
					uniform highp vec4 _LightSplitsFar;
					uniform highp mat4 unity_WorldToShadow[4];
					uniform mediump vec4 _LightShadowData;
					uniform highp vec4 unity_ShadowFadeCenterAndType;
					#line 165
					uniform highp mat4 unity_ObjectToWorld;
					uniform highp mat4 unity_WorldToObject;
					uniform highp vec4 unity_LODFade;
					uniform highp vec4 unity_WorldTransformParams;
					#line 206
					uniform highp mat4 glstate_matrix_transpose_modelview0;
					#line 214
					uniform lowp vec4 glstate_lightmodel_ambient;
					uniform lowp vec4 unity_AmbientSky;
					uniform lowp vec4 unity_AmbientEquator;
					uniform lowp vec4 unity_AmbientGround;
					#line 218
					uniform lowp vec4 unity_IndirectSpecColor;
					uniform highp mat4 glstate_matrix_projection;
					#line 222
					uniform highp mat4 unity_MatrixV;
					uniform highp mat4 unity_MatrixInvV;
					uniform highp mat4 unity_MatrixVP;
					uniform highp int unity_StereoEyeIndex;
					#line 228
					uniform lowp vec4 unity_ShadowColor;
					#line 235
					uniform lowp vec4 unity_FogColor;
					#line 240
					uniform highp vec4 unity_FogParams;
					#line 248
					uniform mediump sampler2D unity_Lightmap;
					uniform mediump sampler2D unity_LightmapInd;
					#line 252
					uniform sampler2D unity_ShadowMask;
					uniform sampler2D unity_DynamicLightmap;
					#line 256
					uniform sampler2D unity_DynamicDirectionality;
					uniform sampler2D unity_DynamicNormal;
					#line 260
					uniform highp vec4 unity_LightmapST;
					uniform highp vec4 unity_DynamicLightmapST;
					#line 268
					uniform samplerCube unity_SpecCube0;
					uniform samplerCube unity_SpecCube1;
					#line 272
					uniform highp vec4 unity_SpecCube0_BoxMax;
					uniform highp vec4 unity_SpecCube0_BoxMin;
					uniform highp vec4 unity_SpecCube0_ProbePosition;
					uniform mediump vec4 unity_SpecCube0_HDR;
					#line 277
					uniform highp vec4 unity_SpecCube1_BoxMax;
					uniform highp vec4 unity_SpecCube1_BoxMin;
					uniform highp vec4 unity_SpecCube1_ProbePosition;
					uniform mediump vec4 unity_SpecCube1_HDR;
					#line 317
					highp mat4 unity_MatrixMVP;
					highp mat4 unity_MatrixMV;
					highp mat4 unity_MatrixTMV;
					highp mat4 unity_MatrixITMV;
					#line 8
					#line 30
					#line 44
					#line 84
					#line 93
					#line 103
					#line 112
					#line 124
					#line 135
					#line 141
					#line 147
					#line 151
					#line 157
					#line 163
					#line 169
					#line 175
					#line 186
					#line 201
					#line 208
					#line 223
					#line 230
					#line 237
					#line 255
					#line 291
					#line 320
					#line 326
					#line 339
					#line 357
					#line 373
					#line 427
					#line 453
					#line 464
					#line 473
					#line 480
					#line 485
					#line 502
					#line 522
					#line 537
					#line 543
					#line 554
					uniform mediump vec4 unity_Lightmap_HDR;
					uniform mediump vec4 unity_DynamicLightmap_HDR;
					#line 568
					#line 578
					#line 593
					#line 602
					#line 609
					#line 618
					#line 626
					#line 635
					#line 654
					#line 660
					#line 670
					#line 680
					#line 691
					#line 696
					#line 702
					#line 707
					#line 764
					#line 770
					#line 785
					#line 816
					#line 830
					#line 834
					#line 840
					#line 849
					#line 859
					#line 885
					#line 891
					#line 7
					uniform sampler2D _MainTex;
					uniform lowp sampler3D _LookupTex3D;
					uniform sampler2D _LookupTex2D;
					uniform highp vec4 _Params;
					#line 17
					#line 23
					#line 29
					#line 35
					#line 41
					#line 47
					#line 67
					#line 91
					#line 97
					#line 29
					highp vec4 Linear( in highp vec4 color ) {
					    color.xyz = xll_vecTSel_vb3_vf3_vf3 (lessThanEqual( color.xyz, vec3( 0.0404482, 0.0404482, 0.0404482)), (color.xyz / 12.92321), pow( ((color.xyz + 0.055) * 0.9478672), vec3( 2.4)));
					    return color;
					}
					#line 17
					highp vec3 sRGB( in highp vec3 color ) {
					    color = xll_vecTSel_vb3_vf3_vf3 (lessThanEqual( color, vec3( 0.0031308, 0.0031308, 0.0031308)), (color * 12.92321), ((1.055 * pow( color, vec3( 0.41666))) - 0.055));
					    return color;
					}
					#line 41
					highp vec4 lookup_linear( in highp vec4 o ) {
					    o.xyz = texture3D( _LookupTex3D, ((sRGB( o.xyz) * _Params.x) + _Params.y)).xyz;
					    return Linear( o);
					}
					#line 47
					highp vec4 frag( in v2f_img i ) {
					    highp vec4 color = xll_saturate_vf4(texture2D( _MainTex, i.uv));
					    highp vec4 x;
					    #line 53
					    x = lookup_linear( color);
					    #line 59
					    return (( (i.uv.x > 0.5) ) ? ( mix( color, x, vec4( _Params.z)) ) : ( color ));
					}
					varying mediump vec2 xlv_TEXCOORD0;
					void main() {
					unity_MatrixMVP = (unity_MatrixVP * unity_ObjectToWorld);
					unity_MatrixMV = (unity_MatrixV * unity_ObjectToWorld);
					unity_MatrixTMV = xll_transpose_mf4x4(unity_MatrixMV);
					unity_MatrixITMV = xll_transpose_mf4x4((unity_WorldToObject * unity_MatrixInvV));
					    highp vec4 xl_retval;
					    v2f_img xlt_i;
					    xlt_i.pos = vec4(0.0);
					    xlt_i.uv = vec2(xlv_TEXCOORD0);
					    xl_retval = frag( xlt_i);
					    gl_FragData[0] = vec4(xl_retval);
					}
					/* HLSL2GLSL - NOTE: GLSL optimization failed
					(9,1): error: invalid type `sampler3D' in declaration of `_LookupTex3D'
					(43,21): error: `_LookupTex3D' undeclared
					(43,10): error: no matching function for call to `texture3D(error, vec3)'; candidates are:
					(43,10): error: type mismatch
					*/
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {
					"!!GLES
					#version 100
					
					#ifdef VERTEX
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 30
					#endif
					#ifndef SHADER_REQUIRE_INTERPOLATORS10
					    #define SHADER_REQUIRE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_REQUIRE_SAMPLELOD
					    #define SHADER_REQUIRE_SAMPLELOD 1
					#endif
					#ifndef SHADER_REQUIRE_FRAGCOORD
					    #define SHADER_REQUIRE_FRAGCOORD 1
					#endif
					#ifndef UNITY_NO_DXT5nm
					    #define UNITY_NO_DXT5nm 1
					#endif
					#ifndef UNITY_NO_RGBM
					    #define UNITY_NO_RGBM 1
					#endif
					#ifndef UNITY_ENABLE_REFLECTION_BUFFERS
					    #define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#endif
					#ifndef UNITY_FRAMEBUFFER_FETCH_AVAILABLE
					    #define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#endif
					#ifndef UNITY_NO_CUBEMAP_ARRAY
					    #define UNITY_NO_CUBEMAP_ARRAY 1
					#endif
					#ifndef UNITY_NO_SCREENSPACE_SHADOWS
					    #define UNITY_NO_SCREENSPACE_SHADOWS 1
					#endif
					#ifndef UNITY_PBS_USE_BRDF2
					    #define UNITY_PBS_USE_BRDF2 1
					#endif
					#ifndef SHADER_API_MOBILE
					    #define SHADER_API_MOBILE 1
					#endif
					#ifndef UNITY_HARDWARE_TIER3
					    #define UNITY_HARDWARE_TIER3 1
					#endif
					#ifndef UNITY_COLORSPACE_GAMMA
					    #define UNITY_COLORSPACE_GAMMA 1
					#endif
					#ifndef UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS
					    #define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#endif
					#ifndef UNITY_LIGHTMAP_DLDR_ENCODING
					    #define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#endif
					#ifndef UNITY_VERSION
					    #define UNITY_VERSION 201834
					#endif
					#ifndef SHADER_STAGE_VERTEX
					    #define SHADER_STAGE_VERTEX 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 30
					#endif
					#ifndef SHADER_AVAILABLE_INTERPOLATORS10
					    #define SHADER_AVAILABLE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_SAMPLELOD
					    #define SHADER_AVAILABLE_SAMPLELOD 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#define gl_Vertex _glesVertex
					attribute vec4 _glesVertex;
					#define gl_MultiTexCoord0 _glesMultiTexCoord0
					attribute vec4 _glesMultiTexCoord0;
					mat2 xll_transpose_mf2x2(mat2 m) {
					  return mat2( m[0][0], m[1][0], m[0][1], m[1][1]);
					}
					mat3 xll_transpose_mf3x3(mat3 m) {
					  return mat3( m[0][0], m[1][0], m[2][0],
					               m[0][1], m[1][1], m[2][1],
					               m[0][2], m[1][2], m[2][2]);
					}
					mat4 xll_transpose_mf4x4(mat4 m) {
					  return mat4( m[0][0], m[1][0], m[2][0], m[3][0],
					               m[0][1], m[1][1], m[2][1], m[3][1],
					               m[0][2], m[1][2], m[2][2], m[3][2],
					               m[0][3], m[1][3], m[2][3], m[3][3]);
					}
					#line 447
					struct v2f_vertex_lit {
					    highp vec2 uv;
					    lowp vec4 diff;
					    lowp vec4 spec;
					};
					#line 756
					struct v2f_img {
					    highp vec4 pos;
					    mediump vec2 uv;
					};
					#line 749
					struct appdata_img {
					    highp vec4 vertex;
					    mediump vec2 texcoord;
					};
					#line 40
					uniform highp vec4 _Time;
					uniform highp vec4 _SinTime;
					uniform highp vec4 _CosTime;
					uniform highp vec4 unity_DeltaTime;
					#line 46
					uniform highp vec3 _WorldSpaceCameraPos;
					#line 53
					uniform highp vec4 _ProjectionParams;
					#line 59
					uniform highp vec4 _ScreenParams;
					#line 71
					uniform highp vec4 _ZBufferParams;
					#line 77
					uniform highp vec4 unity_OrthoParams;
					#line 86
					uniform highp vec4 unity_CameraWorldClipPlanes[6];
					#line 92
					uniform highp mat4 unity_CameraProjection;
					uniform highp mat4 unity_CameraInvProjection;
					uniform highp mat4 unity_WorldToCamera;
					uniform highp mat4 unity_CameraToWorld;
					#line 108
					uniform highp vec4 _WorldSpaceLightPos0;
					uniform highp vec4 _LightPositionRange;
					#line 112
					uniform highp vec4 _LightProjectionParams;
					uniform highp vec4 unity_4LightPosX0;
					uniform highp vec4 unity_4LightPosY0;
					#line 116
					uniform highp vec4 unity_4LightPosZ0;
					uniform mediump vec4 unity_4LightAtten0;
					uniform mediump vec4 unity_LightColor[8];
					#line 122
					uniform highp vec4 unity_LightPosition[8];
					#line 127
					uniform mediump vec4 unity_LightAtten[8];
					uniform highp vec4 unity_SpotDirection[8];
					#line 131
					uniform mediump vec4 unity_SHAr;
					uniform mediump vec4 unity_SHAg;
					uniform mediump vec4 unity_SHAb;
					uniform mediump vec4 unity_SHBr;
					#line 135
					uniform mediump vec4 unity_SHBg;
					uniform mediump vec4 unity_SHBb;
					uniform mediump vec4 unity_SHC;
					#line 140
					uniform lowp vec4 unity_OcclusionMaskSelector;
					uniform lowp vec4 unity_ProbesOcclusion;
					#line 145
					uniform mediump vec3 unity_LightColor0;
					uniform mediump vec3 unity_LightColor1;
					uniform mediump vec3 unity_LightColor2;
					uniform mediump vec3 unity_LightColor3;
					#line 152
					uniform highp vec4 unity_ShadowSplitSpheres[4];
					uniform highp vec4 unity_ShadowSplitSqRadii;
					uniform highp vec4 unity_LightShadowBias;
					uniform highp vec4 _LightSplitsNear;
					#line 156
					uniform highp vec4 _LightSplitsFar;
					uniform highp mat4 unity_WorldToShadow[4];
					uniform mediump vec4 _LightShadowData;
					uniform highp vec4 unity_ShadowFadeCenterAndType;
					#line 165
					uniform highp mat4 unity_ObjectToWorld;
					uniform highp mat4 unity_WorldToObject;
					uniform highp vec4 unity_LODFade;
					uniform highp vec4 unity_WorldTransformParams;
					#line 206
					uniform highp mat4 glstate_matrix_transpose_modelview0;
					#line 214
					uniform lowp vec4 glstate_lightmodel_ambient;
					uniform lowp vec4 unity_AmbientSky;
					uniform lowp vec4 unity_AmbientEquator;
					uniform lowp vec4 unity_AmbientGround;
					#line 218
					uniform lowp vec4 unity_IndirectSpecColor;
					uniform highp mat4 glstate_matrix_projection;
					#line 222
					uniform highp mat4 unity_MatrixV;
					uniform highp mat4 unity_MatrixInvV;
					uniform highp mat4 unity_MatrixVP;
					uniform highp int unity_StereoEyeIndex;
					#line 228
					uniform lowp vec4 unity_ShadowColor;
					#line 235
					uniform lowp vec4 unity_FogColor;
					#line 240
					uniform highp vec4 unity_FogParams;
					#line 248
					uniform mediump sampler2D unity_Lightmap;
					uniform mediump sampler2D unity_LightmapInd;
					#line 252
					uniform sampler2D unity_ShadowMask;
					uniform sampler2D unity_DynamicLightmap;
					#line 256
					uniform sampler2D unity_DynamicDirectionality;
					uniform sampler2D unity_DynamicNormal;
					#line 260
					uniform highp vec4 unity_LightmapST;
					uniform highp vec4 unity_DynamicLightmapST;
					#line 268
					uniform samplerCube unity_SpecCube0;
					uniform samplerCube unity_SpecCube1;
					#line 272
					uniform highp vec4 unity_SpecCube0_BoxMax;
					uniform highp vec4 unity_SpecCube0_BoxMin;
					uniform highp vec4 unity_SpecCube0_ProbePosition;
					uniform mediump vec4 unity_SpecCube0_HDR;
					#line 277
					uniform highp vec4 unity_SpecCube1_BoxMax;
					uniform highp vec4 unity_SpecCube1_BoxMin;
					uniform highp vec4 unity_SpecCube1_ProbePosition;
					uniform mediump vec4 unity_SpecCube1_HDR;
					#line 317
					highp mat4 unity_MatrixMVP;
					highp mat4 unity_MatrixMV;
					highp mat4 unity_MatrixTMV;
					highp mat4 unity_MatrixITMV;
					#line 8
					#line 30
					#line 44
					#line 84
					#line 93
					#line 103
					#line 112
					#line 124
					#line 135
					#line 141
					#line 147
					#line 151
					#line 157
					#line 163
					#line 169
					#line 175
					#line 186
					#line 201
					#line 208
					#line 223
					#line 230
					#line 237
					#line 255
					#line 291
					#line 320
					#line 326
					#line 339
					#line 357
					#line 373
					#line 427
					#line 453
					#line 464
					#line 473
					#line 480
					#line 485
					#line 502
					#line 522
					#line 537
					#line 543
					#line 554
					uniform mediump vec4 unity_Lightmap_HDR;
					uniform mediump vec4 unity_DynamicLightmap_HDR;
					#line 568
					#line 578
					#line 593
					#line 602
					#line 609
					#line 618
					#line 626
					#line 635
					#line 654
					#line 660
					#line 670
					#line 680
					#line 691
					#line 696
					#line 702
					#line 707
					#line 764
					#line 770
					#line 785
					#line 816
					#line 830
					#line 834
					#line 840
					#line 849
					#line 859
					#line 885
					#line 891
					#line 7
					uniform sampler2D _MainTex;
					uniform lowp sampler3D _LookupTex3D;
					uniform sampler2D _LookupTex2D;
					uniform highp vec4 _Params;
					#line 17
					#line 23
					#line 29
					#line 35
					#line 41
					#line 47
					#line 67
					#line 91
					#line 97
					#line 44
					highp vec4 UnityObjectToClipPos( in highp vec3 pos ) {
					    #line 50
					    return (unity_MatrixVP * (unity_ObjectToWorld * vec4( pos, 1.0)));
					}
					#line 53
					highp vec4 UnityObjectToClipPos( in highp vec4 pos ) {
					    #line 55
					    return UnityObjectToClipPos( pos.xyz);
					}
					#line 770
					v2f_img vert_img( in appdata_img v ) {
					    v2f_img o;
					    #line 777
					    o.pos = UnityObjectToClipPos( v.vertex);
					    o.uv = v.texcoord;
					    return o;
					}
					varying mediump vec2 xlv_TEXCOORD0;
					void main() {
					unity_MatrixMVP = (unity_MatrixVP * unity_ObjectToWorld);
					unity_MatrixMV = (unity_MatrixV * unity_ObjectToWorld);
					unity_MatrixTMV = xll_transpose_mf4x4(unity_MatrixMV);
					unity_MatrixITMV = xll_transpose_mf4x4((unity_WorldToObject * unity_MatrixInvV));
					    v2f_img xl_retval;
					    appdata_img xlt_v;
					    xlt_v.vertex = vec4(gl_Vertex);
					    xlt_v.texcoord = vec2(gl_MultiTexCoord0);
					    xl_retval = vert_img( xlt_v);
					    gl_Position = vec4(xl_retval.pos);
					    xlv_TEXCOORD0 = vec2(xl_retval.uv);
					}
					/* HLSL2GLSL - NOTE: GLSL optimization failed
					(9,1): error: invalid type `sampler3D' in declaration of `_LookupTex3D'
					*/
					
					#endif
					#ifdef FRAGMENT
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 30
					#endif
					#ifndef SHADER_REQUIRE_INTERPOLATORS10
					    #define SHADER_REQUIRE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_REQUIRE_SAMPLELOD
					    #define SHADER_REQUIRE_SAMPLELOD 1
					#endif
					#ifndef SHADER_REQUIRE_FRAGCOORD
					    #define SHADER_REQUIRE_FRAGCOORD 1
					#endif
					#ifndef UNITY_NO_DXT5nm
					    #define UNITY_NO_DXT5nm 1
					#endif
					#ifndef UNITY_NO_RGBM
					    #define UNITY_NO_RGBM 1
					#endif
					#ifndef UNITY_ENABLE_REFLECTION_BUFFERS
					    #define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#endif
					#ifndef UNITY_FRAMEBUFFER_FETCH_AVAILABLE
					    #define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#endif
					#ifndef UNITY_NO_CUBEMAP_ARRAY
					    #define UNITY_NO_CUBEMAP_ARRAY 1
					#endif
					#ifndef UNITY_NO_SCREENSPACE_SHADOWS
					    #define UNITY_NO_SCREENSPACE_SHADOWS 1
					#endif
					#ifndef UNITY_PBS_USE_BRDF2
					    #define UNITY_PBS_USE_BRDF2 1
					#endif
					#ifndef SHADER_API_MOBILE
					    #define SHADER_API_MOBILE 1
					#endif
					#ifndef UNITY_HARDWARE_TIER3
					    #define UNITY_HARDWARE_TIER3 1
					#endif
					#ifndef UNITY_COLORSPACE_GAMMA
					    #define UNITY_COLORSPACE_GAMMA 1
					#endif
					#ifndef UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS
					    #define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#endif
					#ifndef UNITY_LIGHTMAP_DLDR_ENCODING
					    #define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#endif
					#ifndef UNITY_VERSION
					    #define UNITY_VERSION 201834
					#endif
					#ifndef SHADER_STAGE_VERTEX
					    #define SHADER_STAGE_VERTEX 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 30
					#endif
					#ifndef SHADER_AVAILABLE_INTERPOLATORS10
					    #define SHADER_AVAILABLE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_SAMPLELOD
					    #define SHADER_AVAILABLE_SAMPLELOD 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					mat2 xll_transpose_mf2x2(mat2 m) {
					  return mat2( m[0][0], m[1][0], m[0][1], m[1][1]);
					}
					mat3 xll_transpose_mf3x3(mat3 m) {
					  return mat3( m[0][0], m[1][0], m[2][0],
					               m[0][1], m[1][1], m[2][1],
					               m[0][2], m[1][2], m[2][2]);
					}
					mat4 xll_transpose_mf4x4(mat4 m) {
					  return mat4( m[0][0], m[1][0], m[2][0], m[3][0],
					               m[0][1], m[1][1], m[2][1], m[3][1],
					               m[0][2], m[1][2], m[2][2], m[3][2],
					               m[0][3], m[1][3], m[2][3], m[3][3]);
					}
					float xll_saturate_f( float x) {
					  return clamp( x, 0.0, 1.0);
					}
					vec2 xll_saturate_vf2( vec2 x) {
					  return clamp( x, 0.0, 1.0);
					}
					vec3 xll_saturate_vf3( vec3 x) {
					  return clamp( x, 0.0, 1.0);
					}
					vec4 xll_saturate_vf4( vec4 x) {
					  return clamp( x, 0.0, 1.0);
					}
					mat2 xll_saturate_mf2x2(mat2 m) {
					  return mat2( clamp(m[0], 0.0, 1.0), clamp(m[1], 0.0, 1.0));
					}
					mat3 xll_saturate_mf3x3(mat3 m) {
					  return mat3( clamp(m[0], 0.0, 1.0), clamp(m[1], 0.0, 1.0), clamp(m[2], 0.0, 1.0));
					}
					mat4 xll_saturate_mf4x4(mat4 m) {
					  return mat4( clamp(m[0], 0.0, 1.0), clamp(m[1], 0.0, 1.0), clamp(m[2], 0.0, 1.0), clamp(m[3], 0.0, 1.0));
					}
					vec2 xll_vecTSel_vb2_vf2_vf2 (bvec2 a, vec2 b, vec2 c) {
					  return vec2 (a.x ? b.x : c.x, a.y ? b.y : c.y);
					}
					vec3 xll_vecTSel_vb3_vf3_vf3 (bvec3 a, vec3 b, vec3 c) {
					  return vec3 (a.x ? b.x : c.x, a.y ? b.y : c.y, a.z ? b.z : c.z);
					}
					vec4 xll_vecTSel_vb4_vf4_vf4 (bvec4 a, vec4 b, vec4 c) {
					  return vec4 (a.x ? b.x : c.x, a.y ? b.y : c.y, a.z ? b.z : c.z, a.w ? b.w : c.w);
					}
					#line 447
					struct v2f_vertex_lit {
					    highp vec2 uv;
					    lowp vec4 diff;
					    lowp vec4 spec;
					};
					#line 756
					struct v2f_img {
					    highp vec4 pos;
					    mediump vec2 uv;
					};
					#line 749
					struct appdata_img {
					    highp vec4 vertex;
					    mediump vec2 texcoord;
					};
					#line 40
					uniform highp vec4 _Time;
					uniform highp vec4 _SinTime;
					uniform highp vec4 _CosTime;
					uniform highp vec4 unity_DeltaTime;
					#line 46
					uniform highp vec3 _WorldSpaceCameraPos;
					#line 53
					uniform highp vec4 _ProjectionParams;
					#line 59
					uniform highp vec4 _ScreenParams;
					#line 71
					uniform highp vec4 _ZBufferParams;
					#line 77
					uniform highp vec4 unity_OrthoParams;
					#line 86
					uniform highp vec4 unity_CameraWorldClipPlanes[6];
					#line 92
					uniform highp mat4 unity_CameraProjection;
					uniform highp mat4 unity_CameraInvProjection;
					uniform highp mat4 unity_WorldToCamera;
					uniform highp mat4 unity_CameraToWorld;
					#line 108
					uniform highp vec4 _WorldSpaceLightPos0;
					uniform highp vec4 _LightPositionRange;
					#line 112
					uniform highp vec4 _LightProjectionParams;
					uniform highp vec4 unity_4LightPosX0;
					uniform highp vec4 unity_4LightPosY0;
					#line 116
					uniform highp vec4 unity_4LightPosZ0;
					uniform mediump vec4 unity_4LightAtten0;
					uniform mediump vec4 unity_LightColor[8];
					#line 122
					uniform highp vec4 unity_LightPosition[8];
					#line 127
					uniform mediump vec4 unity_LightAtten[8];
					uniform highp vec4 unity_SpotDirection[8];
					#line 131
					uniform mediump vec4 unity_SHAr;
					uniform mediump vec4 unity_SHAg;
					uniform mediump vec4 unity_SHAb;
					uniform mediump vec4 unity_SHBr;
					#line 135
					uniform mediump vec4 unity_SHBg;
					uniform mediump vec4 unity_SHBb;
					uniform mediump vec4 unity_SHC;
					#line 140
					uniform lowp vec4 unity_OcclusionMaskSelector;
					uniform lowp vec4 unity_ProbesOcclusion;
					#line 145
					uniform mediump vec3 unity_LightColor0;
					uniform mediump vec3 unity_LightColor1;
					uniform mediump vec3 unity_LightColor2;
					uniform mediump vec3 unity_LightColor3;
					#line 152
					uniform highp vec4 unity_ShadowSplitSpheres[4];
					uniform highp vec4 unity_ShadowSplitSqRadii;
					uniform highp vec4 unity_LightShadowBias;
					uniform highp vec4 _LightSplitsNear;
					#line 156
					uniform highp vec4 _LightSplitsFar;
					uniform highp mat4 unity_WorldToShadow[4];
					uniform mediump vec4 _LightShadowData;
					uniform highp vec4 unity_ShadowFadeCenterAndType;
					#line 165
					uniform highp mat4 unity_ObjectToWorld;
					uniform highp mat4 unity_WorldToObject;
					uniform highp vec4 unity_LODFade;
					uniform highp vec4 unity_WorldTransformParams;
					#line 206
					uniform highp mat4 glstate_matrix_transpose_modelview0;
					#line 214
					uniform lowp vec4 glstate_lightmodel_ambient;
					uniform lowp vec4 unity_AmbientSky;
					uniform lowp vec4 unity_AmbientEquator;
					uniform lowp vec4 unity_AmbientGround;
					#line 218
					uniform lowp vec4 unity_IndirectSpecColor;
					uniform highp mat4 glstate_matrix_projection;
					#line 222
					uniform highp mat4 unity_MatrixV;
					uniform highp mat4 unity_MatrixInvV;
					uniform highp mat4 unity_MatrixVP;
					uniform highp int unity_StereoEyeIndex;
					#line 228
					uniform lowp vec4 unity_ShadowColor;
					#line 235
					uniform lowp vec4 unity_FogColor;
					#line 240
					uniform highp vec4 unity_FogParams;
					#line 248
					uniform mediump sampler2D unity_Lightmap;
					uniform mediump sampler2D unity_LightmapInd;
					#line 252
					uniform sampler2D unity_ShadowMask;
					uniform sampler2D unity_DynamicLightmap;
					#line 256
					uniform sampler2D unity_DynamicDirectionality;
					uniform sampler2D unity_DynamicNormal;
					#line 260
					uniform highp vec4 unity_LightmapST;
					uniform highp vec4 unity_DynamicLightmapST;
					#line 268
					uniform samplerCube unity_SpecCube0;
					uniform samplerCube unity_SpecCube1;
					#line 272
					uniform highp vec4 unity_SpecCube0_BoxMax;
					uniform highp vec4 unity_SpecCube0_BoxMin;
					uniform highp vec4 unity_SpecCube0_ProbePosition;
					uniform mediump vec4 unity_SpecCube0_HDR;
					#line 277
					uniform highp vec4 unity_SpecCube1_BoxMax;
					uniform highp vec4 unity_SpecCube1_BoxMin;
					uniform highp vec4 unity_SpecCube1_ProbePosition;
					uniform mediump vec4 unity_SpecCube1_HDR;
					#line 317
					highp mat4 unity_MatrixMVP;
					highp mat4 unity_MatrixMV;
					highp mat4 unity_MatrixTMV;
					highp mat4 unity_MatrixITMV;
					#line 8
					#line 30
					#line 44
					#line 84
					#line 93
					#line 103
					#line 112
					#line 124
					#line 135
					#line 141
					#line 147
					#line 151
					#line 157
					#line 163
					#line 169
					#line 175
					#line 186
					#line 201
					#line 208
					#line 223
					#line 230
					#line 237
					#line 255
					#line 291
					#line 320
					#line 326
					#line 339
					#line 357
					#line 373
					#line 427
					#line 453
					#line 464
					#line 473
					#line 480
					#line 485
					#line 502
					#line 522
					#line 537
					#line 543
					#line 554
					uniform mediump vec4 unity_Lightmap_HDR;
					uniform mediump vec4 unity_DynamicLightmap_HDR;
					#line 568
					#line 578
					#line 593
					#line 602
					#line 609
					#line 618
					#line 626
					#line 635
					#line 654
					#line 660
					#line 670
					#line 680
					#line 691
					#line 696
					#line 702
					#line 707
					#line 764
					#line 770
					#line 785
					#line 816
					#line 830
					#line 834
					#line 840
					#line 849
					#line 859
					#line 885
					#line 891
					#line 7
					uniform sampler2D _MainTex;
					uniform lowp sampler3D _LookupTex3D;
					uniform sampler2D _LookupTex2D;
					uniform highp vec4 _Params;
					#line 17
					#line 23
					#line 29
					#line 35
					#line 41
					#line 47
					#line 67
					#line 91
					#line 97
					#line 29
					highp vec4 Linear( in highp vec4 color ) {
					    color.xyz = xll_vecTSel_vb3_vf3_vf3 (lessThanEqual( color.xyz, vec3( 0.0404482, 0.0404482, 0.0404482)), (color.xyz / 12.92321), pow( ((color.xyz + 0.055) * 0.9478672), vec3( 2.4)));
					    return color;
					}
					#line 17
					highp vec3 sRGB( in highp vec3 color ) {
					    color = xll_vecTSel_vb3_vf3_vf3 (lessThanEqual( color, vec3( 0.0031308, 0.0031308, 0.0031308)), (color * 12.92321), ((1.055 * pow( color, vec3( 0.41666))) - 0.055));
					    return color;
					}
					#line 41
					highp vec4 lookup_linear( in highp vec4 o ) {
					    o.xyz = texture3D( _LookupTex3D, ((sRGB( o.xyz) * _Params.x) + _Params.y)).xyz;
					    return Linear( o);
					}
					#line 47
					highp vec4 frag( in v2f_img i ) {
					    highp vec4 color = xll_saturate_vf4(texture2D( _MainTex, i.uv));
					    highp vec4 x;
					    #line 53
					    x = lookup_linear( color);
					    #line 59
					    return (( (i.uv.x > 0.5) ) ? ( mix( color, x, vec4( _Params.z)) ) : ( color ));
					}
					varying mediump vec2 xlv_TEXCOORD0;
					void main() {
					unity_MatrixMVP = (unity_MatrixVP * unity_ObjectToWorld);
					unity_MatrixMV = (unity_MatrixV * unity_ObjectToWorld);
					unity_MatrixTMV = xll_transpose_mf4x4(unity_MatrixMV);
					unity_MatrixITMV = xll_transpose_mf4x4((unity_WorldToObject * unity_MatrixInvV));
					    highp vec4 xl_retval;
					    v2f_img xlt_i;
					    xlt_i.pos = vec4(0.0);
					    xlt_i.uv = vec2(xlv_TEXCOORD0);
					    xl_retval = frag( xlt_i);
					    gl_FragData[0] = vec4(xl_retval);
					}
					/* HLSL2GLSL - NOTE: GLSL optimization failed
					(9,1): error: invalid type `sampler3D' in declaration of `_LookupTex3D'
					(43,21): error: `_LookupTex3D' undeclared
					(43,10): error: no matching function for call to `texture3D(error, vec3)'; candidates are:
					(43,10): error: type mismatch
					*/
					
					#endif"
				}
				SubProgram "gles3 hw_tier00 " {
					"!!GLES3
					#ifdef VERTEX
					#version 300 es
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					in highp vec4 in_POSITION0;
					in mediump vec2 in_TEXCOORD0;
					out mediump vec2 vs_TEXCOORD0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					void main()
					{
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy;
					    return;
					}
					
					#endif
					#ifdef FRAGMENT
					#version 300 es
					
					precision highp int;
					uniform 	vec4 _Params;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler3D _LookupTex3D;
					in mediump vec2 vs_TEXCOORD0;
					layout(location = 0) out highp vec4 SV_Target0;
					vec4 u_xlat0;
					lowp vec4 u_xlat10_0;
					vec4 u_xlat1;
					vec3 u_xlat2;
					bvec3 u_xlatb2;
					vec3 u_xlat3;
					bvec3 u_xlatb3;
					void main()
					{
					    u_xlat10_0 = texture(_MainTex, vs_TEXCOORD0.xy);
					    u_xlat0 = u_xlat10_0;
					#ifdef UNITY_ADRENO_ES3
					    u_xlat0 = min(max(u_xlat0, 0.0), 1.0);
					#else
					    u_xlat0 = clamp(u_xlat0, 0.0, 1.0);
					#endif
					    u_xlat1.xyz = log2(u_xlat0.xyz);
					    u_xlat1.xyz = u_xlat1.xyz * vec3(0.416660011, 0.416660011, 0.416660011);
					    u_xlat1.xyz = exp2(u_xlat1.xyz);
					    u_xlat1.xyz = u_xlat1.xyz * vec3(1.05499995, 1.05499995, 1.05499995) + vec3(-0.0549999997, -0.0549999997, -0.0549999997);
					    u_xlatb2.xyz = greaterThanEqual(vec4(0.00313080009, 0.00313080009, 0.00313080009, 0.0), u_xlat0.xyzx).xyz;
					    u_xlat3.xyz = u_xlat0.xyz * vec3(12.9232101, 12.9232101, 12.9232101);
					    {
					        vec4 hlslcc_movcTemp = u_xlat1;
					        u_xlat1.x = (u_xlatb2.x) ? u_xlat3.x : hlslcc_movcTemp.x;
					        u_xlat1.y = (u_xlatb2.y) ? u_xlat3.y : hlslcc_movcTemp.y;
					        u_xlat1.z = (u_xlatb2.z) ? u_xlat3.z : hlslcc_movcTemp.z;
					    }
					    u_xlat1.xyz = u_xlat1.xyz * _Params.xxx + _Params.yyy;
					    u_xlat1.xyz = texture(_LookupTex3D, u_xlat1.xyz).xyz;
					    u_xlat2.xyz = u_xlat1.xyz + vec3(0.0549999997, 0.0549999997, 0.0549999997);
					    u_xlat2.xyz = u_xlat2.xyz * vec3(0.947867215, 0.947867215, 0.947867215);
					    u_xlat2.xyz = log2(u_xlat2.xyz);
					    u_xlat2.xyz = u_xlat2.xyz * vec3(2.4000001, 2.4000001, 2.4000001);
					    u_xlat2.xyz = exp2(u_xlat2.xyz);
					    u_xlatb3.xyz = greaterThanEqual(vec4(0.0404482, 0.0404482, 0.0404482, 0.0), u_xlat1.xyzx).xyz;
					    u_xlat1.xyz = u_xlat1.xyz * vec3(0.077380158, 0.077380158, 0.077380158);
					    {
					        vec4 hlslcc_movcTemp = u_xlat1;
					        u_xlat1.x = (u_xlatb3.x) ? hlslcc_movcTemp.x : u_xlat2.x;
					        u_xlat1.y = (u_xlatb3.y) ? hlslcc_movcTemp.y : u_xlat2.y;
					        u_xlat1.z = (u_xlatb3.z) ? hlslcc_movcTemp.z : u_xlat2.z;
					    }
					    u_xlat1.xyz = (-u_xlat0.xyz) + u_xlat1.xyz;
					    u_xlat1.w = 0.0;
					    u_xlat1 = _Params.zzzz * u_xlat1 + u_xlat0;
					#ifdef UNITY_ADRENO_ES3
					    u_xlatb2.x = !!(0.5<vs_TEXCOORD0.x);
					#else
					    u_xlatb2.x = 0.5<vs_TEXCOORD0.x;
					#endif
					    SV_Target0 = (u_xlatb2.x) ? u_xlat1 : u_xlat0;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles3 hw_tier01 " {
					"!!GLES3
					#ifdef VERTEX
					#version 300 es
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					in highp vec4 in_POSITION0;
					in mediump vec2 in_TEXCOORD0;
					out mediump vec2 vs_TEXCOORD0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					void main()
					{
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy;
					    return;
					}
					
					#endif
					#ifdef FRAGMENT
					#version 300 es
					
					precision highp int;
					uniform 	vec4 _Params;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler3D _LookupTex3D;
					in mediump vec2 vs_TEXCOORD0;
					layout(location = 0) out highp vec4 SV_Target0;
					vec4 u_xlat0;
					lowp vec4 u_xlat10_0;
					vec4 u_xlat1;
					vec3 u_xlat2;
					bvec3 u_xlatb2;
					vec3 u_xlat3;
					bvec3 u_xlatb3;
					void main()
					{
					    u_xlat10_0 = texture(_MainTex, vs_TEXCOORD0.xy);
					    u_xlat0 = u_xlat10_0;
					#ifdef UNITY_ADRENO_ES3
					    u_xlat0 = min(max(u_xlat0, 0.0), 1.0);
					#else
					    u_xlat0 = clamp(u_xlat0, 0.0, 1.0);
					#endif
					    u_xlat1.xyz = log2(u_xlat0.xyz);
					    u_xlat1.xyz = u_xlat1.xyz * vec3(0.416660011, 0.416660011, 0.416660011);
					    u_xlat1.xyz = exp2(u_xlat1.xyz);
					    u_xlat1.xyz = u_xlat1.xyz * vec3(1.05499995, 1.05499995, 1.05499995) + vec3(-0.0549999997, -0.0549999997, -0.0549999997);
					    u_xlatb2.xyz = greaterThanEqual(vec4(0.00313080009, 0.00313080009, 0.00313080009, 0.0), u_xlat0.xyzx).xyz;
					    u_xlat3.xyz = u_xlat0.xyz * vec3(12.9232101, 12.9232101, 12.9232101);
					    {
					        vec4 hlslcc_movcTemp = u_xlat1;
					        u_xlat1.x = (u_xlatb2.x) ? u_xlat3.x : hlslcc_movcTemp.x;
					        u_xlat1.y = (u_xlatb2.y) ? u_xlat3.y : hlslcc_movcTemp.y;
					        u_xlat1.z = (u_xlatb2.z) ? u_xlat3.z : hlslcc_movcTemp.z;
					    }
					    u_xlat1.xyz = u_xlat1.xyz * _Params.xxx + _Params.yyy;
					    u_xlat1.xyz = texture(_LookupTex3D, u_xlat1.xyz).xyz;
					    u_xlat2.xyz = u_xlat1.xyz + vec3(0.0549999997, 0.0549999997, 0.0549999997);
					    u_xlat2.xyz = u_xlat2.xyz * vec3(0.947867215, 0.947867215, 0.947867215);
					    u_xlat2.xyz = log2(u_xlat2.xyz);
					    u_xlat2.xyz = u_xlat2.xyz * vec3(2.4000001, 2.4000001, 2.4000001);
					    u_xlat2.xyz = exp2(u_xlat2.xyz);
					    u_xlatb3.xyz = greaterThanEqual(vec4(0.0404482, 0.0404482, 0.0404482, 0.0), u_xlat1.xyzx).xyz;
					    u_xlat1.xyz = u_xlat1.xyz * vec3(0.077380158, 0.077380158, 0.077380158);
					    {
					        vec4 hlslcc_movcTemp = u_xlat1;
					        u_xlat1.x = (u_xlatb3.x) ? hlslcc_movcTemp.x : u_xlat2.x;
					        u_xlat1.y = (u_xlatb3.y) ? hlslcc_movcTemp.y : u_xlat2.y;
					        u_xlat1.z = (u_xlatb3.z) ? hlslcc_movcTemp.z : u_xlat2.z;
					    }
					    u_xlat1.xyz = (-u_xlat0.xyz) + u_xlat1.xyz;
					    u_xlat1.w = 0.0;
					    u_xlat1 = _Params.zzzz * u_xlat1 + u_xlat0;
					#ifdef UNITY_ADRENO_ES3
					    u_xlatb2.x = !!(0.5<vs_TEXCOORD0.x);
					#else
					    u_xlatb2.x = 0.5<vs_TEXCOORD0.x;
					#endif
					    SV_Target0 = (u_xlatb2.x) ? u_xlat1 : u_xlat0;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles3 hw_tier02 " {
					"!!GLES3
					#ifdef VERTEX
					#version 300 es
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					in highp vec4 in_POSITION0;
					in mediump vec2 in_TEXCOORD0;
					out mediump vec2 vs_TEXCOORD0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					void main()
					{
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy;
					    return;
					}
					
					#endif
					#ifdef FRAGMENT
					#version 300 es
					
					precision highp int;
					uniform 	vec4 _Params;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler3D _LookupTex3D;
					in mediump vec2 vs_TEXCOORD0;
					layout(location = 0) out highp vec4 SV_Target0;
					vec4 u_xlat0;
					lowp vec4 u_xlat10_0;
					vec4 u_xlat1;
					vec3 u_xlat2;
					bvec3 u_xlatb2;
					vec3 u_xlat3;
					bvec3 u_xlatb3;
					void main()
					{
					    u_xlat10_0 = texture(_MainTex, vs_TEXCOORD0.xy);
					    u_xlat0 = u_xlat10_0;
					#ifdef UNITY_ADRENO_ES3
					    u_xlat0 = min(max(u_xlat0, 0.0), 1.0);
					#else
					    u_xlat0 = clamp(u_xlat0, 0.0, 1.0);
					#endif
					    u_xlat1.xyz = log2(u_xlat0.xyz);
					    u_xlat1.xyz = u_xlat1.xyz * vec3(0.416660011, 0.416660011, 0.416660011);
					    u_xlat1.xyz = exp2(u_xlat1.xyz);
					    u_xlat1.xyz = u_xlat1.xyz * vec3(1.05499995, 1.05499995, 1.05499995) + vec3(-0.0549999997, -0.0549999997, -0.0549999997);
					    u_xlatb2.xyz = greaterThanEqual(vec4(0.00313080009, 0.00313080009, 0.00313080009, 0.0), u_xlat0.xyzx).xyz;
					    u_xlat3.xyz = u_xlat0.xyz * vec3(12.9232101, 12.9232101, 12.9232101);
					    {
					        vec4 hlslcc_movcTemp = u_xlat1;
					        u_xlat1.x = (u_xlatb2.x) ? u_xlat3.x : hlslcc_movcTemp.x;
					        u_xlat1.y = (u_xlatb2.y) ? u_xlat3.y : hlslcc_movcTemp.y;
					        u_xlat1.z = (u_xlatb2.z) ? u_xlat3.z : hlslcc_movcTemp.z;
					    }
					    u_xlat1.xyz = u_xlat1.xyz * _Params.xxx + _Params.yyy;
					    u_xlat1.xyz = texture(_LookupTex3D, u_xlat1.xyz).xyz;
					    u_xlat2.xyz = u_xlat1.xyz + vec3(0.0549999997, 0.0549999997, 0.0549999997);
					    u_xlat2.xyz = u_xlat2.xyz * vec3(0.947867215, 0.947867215, 0.947867215);
					    u_xlat2.xyz = log2(u_xlat2.xyz);
					    u_xlat2.xyz = u_xlat2.xyz * vec3(2.4000001, 2.4000001, 2.4000001);
					    u_xlat2.xyz = exp2(u_xlat2.xyz);
					    u_xlatb3.xyz = greaterThanEqual(vec4(0.0404482, 0.0404482, 0.0404482, 0.0), u_xlat1.xyzx).xyz;
					    u_xlat1.xyz = u_xlat1.xyz * vec3(0.077380158, 0.077380158, 0.077380158);
					    {
					        vec4 hlslcc_movcTemp = u_xlat1;
					        u_xlat1.x = (u_xlatb3.x) ? hlslcc_movcTemp.x : u_xlat2.x;
					        u_xlat1.y = (u_xlatb3.y) ? hlslcc_movcTemp.y : u_xlat2.y;
					        u_xlat1.z = (u_xlatb3.z) ? hlslcc_movcTemp.z : u_xlat2.z;
					    }
					    u_xlat1.xyz = (-u_xlat0.xyz) + u_xlat1.xyz;
					    u_xlat1.w = 0.0;
					    u_xlat1 = _Params.zzzz * u_xlat1 + u_xlat0;
					#ifdef UNITY_ADRENO_ES3
					    u_xlatb2.x = !!(0.5<vs_TEXCOORD0.x);
					#else
					    u_xlatb2.x = 0.5<vs_TEXCOORD0.x;
					#endif
					    SV_Target0 = (u_xlatb2.x) ? u_xlat1 : u_xlat0;
					    return;
					}
					
					#endif"
				}
			}
			Program "fp" {
				SubProgram "gles hw_tier00 " {
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					"!!GLES"
				}
				SubProgram "gles3 hw_tier00 " {
					"!!GLES3"
				}
				SubProgram "gles3 hw_tier01 " {
					"!!GLES3"
				}
				SubProgram "gles3 hw_tier02 " {
					"!!GLES3"
				}
			}
		}
		Pass {
			ZTest Always
			ZWrite Off
			Cull Off
			Fog {
				Mode Off
			}
			GpuProgramID 317671
			Program "vp" {
				SubProgram "gles hw_tier00 " {
					"!!GLES
					#version 100
					
					#ifdef VERTEX
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 30
					#endif
					#ifndef SHADER_REQUIRE_INTERPOLATORS10
					    #define SHADER_REQUIRE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_REQUIRE_SAMPLELOD
					    #define SHADER_REQUIRE_SAMPLELOD 1
					#endif
					#ifndef SHADER_REQUIRE_FRAGCOORD
					    #define SHADER_REQUIRE_FRAGCOORD 1
					#endif
					#ifndef UNITY_NO_DXT5nm
					    #define UNITY_NO_DXT5nm 1
					#endif
					#ifndef UNITY_NO_RGBM
					    #define UNITY_NO_RGBM 1
					#endif
					#ifndef UNITY_ENABLE_REFLECTION_BUFFERS
					    #define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#endif
					#ifndef UNITY_FRAMEBUFFER_FETCH_AVAILABLE
					    #define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#endif
					#ifndef UNITY_NO_CUBEMAP_ARRAY
					    #define UNITY_NO_CUBEMAP_ARRAY 1
					#endif
					#ifndef UNITY_NO_SCREENSPACE_SHADOWS
					    #define UNITY_NO_SCREENSPACE_SHADOWS 1
					#endif
					#ifndef UNITY_PBS_USE_BRDF3
					    #define UNITY_PBS_USE_BRDF3 1
					#endif
					#ifndef UNITY_NO_FULL_STANDARD_SHADER
					    #define UNITY_NO_FULL_STANDARD_SHADER 1
					#endif
					#ifndef SHADER_API_MOBILE
					    #define SHADER_API_MOBILE 1
					#endif
					#ifndef UNITY_HARDWARE_TIER1
					    #define UNITY_HARDWARE_TIER1 1
					#endif
					#ifndef UNITY_COLORSPACE_GAMMA
					    #define UNITY_COLORSPACE_GAMMA 1
					#endif
					#ifndef UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS
					    #define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#endif
					#ifndef UNITY_LIGHTMAP_DLDR_ENCODING
					    #define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#endif
					#ifndef UNITY_VERSION
					    #define UNITY_VERSION 201834
					#endif
					#ifndef SHADER_STAGE_VERTEX
					    #define SHADER_STAGE_VERTEX 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 30
					#endif
					#ifndef SHADER_AVAILABLE_INTERPOLATORS10
					    #define SHADER_AVAILABLE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_SAMPLELOD
					    #define SHADER_AVAILABLE_SAMPLELOD 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#define gl_Vertex _glesVertex
					attribute vec4 _glesVertex;
					#define gl_MultiTexCoord0 _glesMultiTexCoord0
					attribute vec4 _glesMultiTexCoord0;
					mat2 xll_transpose_mf2x2(mat2 m) {
					  return mat2( m[0][0], m[1][0], m[0][1], m[1][1]);
					}
					mat3 xll_transpose_mf3x3(mat3 m) {
					  return mat3( m[0][0], m[1][0], m[2][0],
					               m[0][1], m[1][1], m[2][1],
					               m[0][2], m[1][2], m[2][2]);
					}
					mat4 xll_transpose_mf4x4(mat4 m) {
					  return mat4( m[0][0], m[1][0], m[2][0], m[3][0],
					               m[0][1], m[1][1], m[2][1], m[3][1],
					               m[0][2], m[1][2], m[2][2], m[3][2],
					               m[0][3], m[1][3], m[2][3], m[3][3]);
					}
					#line 447
					struct v2f_vertex_lit {
					    highp vec2 uv;
					    lowp vec4 diff;
					    lowp vec4 spec;
					};
					#line 756
					struct v2f_img {
					    highp vec4 pos;
					    mediump vec2 uv;
					};
					#line 749
					struct appdata_img {
					    highp vec4 vertex;
					    mediump vec2 texcoord;
					};
					#line 40
					uniform highp vec4 _Time;
					uniform highp vec4 _SinTime;
					uniform highp vec4 _CosTime;
					uniform highp vec4 unity_DeltaTime;
					#line 46
					uniform highp vec3 _WorldSpaceCameraPos;
					#line 53
					uniform highp vec4 _ProjectionParams;
					#line 59
					uniform highp vec4 _ScreenParams;
					#line 71
					uniform highp vec4 _ZBufferParams;
					#line 77
					uniform highp vec4 unity_OrthoParams;
					#line 86
					uniform highp vec4 unity_CameraWorldClipPlanes[6];
					#line 92
					uniform highp mat4 unity_CameraProjection;
					uniform highp mat4 unity_CameraInvProjection;
					uniform highp mat4 unity_WorldToCamera;
					uniform highp mat4 unity_CameraToWorld;
					#line 108
					uniform highp vec4 _WorldSpaceLightPos0;
					uniform highp vec4 _LightPositionRange;
					#line 112
					uniform highp vec4 _LightProjectionParams;
					uniform highp vec4 unity_4LightPosX0;
					uniform highp vec4 unity_4LightPosY0;
					#line 116
					uniform highp vec4 unity_4LightPosZ0;
					uniform mediump vec4 unity_4LightAtten0;
					uniform mediump vec4 unity_LightColor[8];
					#line 122
					uniform highp vec4 unity_LightPosition[8];
					#line 127
					uniform mediump vec4 unity_LightAtten[8];
					uniform highp vec4 unity_SpotDirection[8];
					#line 131
					uniform mediump vec4 unity_SHAr;
					uniform mediump vec4 unity_SHAg;
					uniform mediump vec4 unity_SHAb;
					uniform mediump vec4 unity_SHBr;
					#line 135
					uniform mediump vec4 unity_SHBg;
					uniform mediump vec4 unity_SHBb;
					uniform mediump vec4 unity_SHC;
					#line 140
					uniform lowp vec4 unity_OcclusionMaskSelector;
					uniform lowp vec4 unity_ProbesOcclusion;
					#line 145
					uniform mediump vec3 unity_LightColor0;
					uniform mediump vec3 unity_LightColor1;
					uniform mediump vec3 unity_LightColor2;
					uniform mediump vec3 unity_LightColor3;
					#line 152
					uniform highp vec4 unity_ShadowSplitSpheres[4];
					uniform highp vec4 unity_ShadowSplitSqRadii;
					uniform highp vec4 unity_LightShadowBias;
					uniform highp vec4 _LightSplitsNear;
					#line 156
					uniform highp vec4 _LightSplitsFar;
					uniform highp mat4 unity_WorldToShadow[4];
					uniform mediump vec4 _LightShadowData;
					uniform highp vec4 unity_ShadowFadeCenterAndType;
					#line 165
					uniform highp mat4 unity_ObjectToWorld;
					uniform highp mat4 unity_WorldToObject;
					uniform highp vec4 unity_LODFade;
					uniform highp vec4 unity_WorldTransformParams;
					#line 206
					uniform highp mat4 glstate_matrix_transpose_modelview0;
					#line 214
					uniform lowp vec4 glstate_lightmodel_ambient;
					uniform lowp vec4 unity_AmbientSky;
					uniform lowp vec4 unity_AmbientEquator;
					uniform lowp vec4 unity_AmbientGround;
					#line 218
					uniform lowp vec4 unity_IndirectSpecColor;
					uniform highp mat4 glstate_matrix_projection;
					#line 222
					uniform highp mat4 unity_MatrixV;
					uniform highp mat4 unity_MatrixInvV;
					uniform highp mat4 unity_MatrixVP;
					uniform highp int unity_StereoEyeIndex;
					#line 228
					uniform lowp vec4 unity_ShadowColor;
					#line 235
					uniform lowp vec4 unity_FogColor;
					#line 240
					uniform highp vec4 unity_FogParams;
					#line 248
					uniform mediump sampler2D unity_Lightmap;
					uniform mediump sampler2D unity_LightmapInd;
					#line 252
					uniform sampler2D unity_ShadowMask;
					uniform sampler2D unity_DynamicLightmap;
					#line 256
					uniform sampler2D unity_DynamicDirectionality;
					uniform sampler2D unity_DynamicNormal;
					#line 260
					uniform highp vec4 unity_LightmapST;
					uniform highp vec4 unity_DynamicLightmapST;
					#line 268
					uniform samplerCube unity_SpecCube0;
					uniform samplerCube unity_SpecCube1;
					#line 272
					uniform highp vec4 unity_SpecCube0_BoxMax;
					uniform highp vec4 unity_SpecCube0_BoxMin;
					uniform highp vec4 unity_SpecCube0_ProbePosition;
					uniform mediump vec4 unity_SpecCube0_HDR;
					#line 277
					uniform highp vec4 unity_SpecCube1_BoxMax;
					uniform highp vec4 unity_SpecCube1_BoxMin;
					uniform highp vec4 unity_SpecCube1_ProbePosition;
					uniform mediump vec4 unity_SpecCube1_HDR;
					#line 317
					highp mat4 unity_MatrixMVP;
					highp mat4 unity_MatrixMV;
					highp mat4 unity_MatrixTMV;
					highp mat4 unity_MatrixITMV;
					#line 8
					#line 30
					#line 44
					#line 84
					#line 93
					#line 103
					#line 112
					#line 124
					#line 135
					#line 141
					#line 147
					#line 151
					#line 157
					#line 163
					#line 169
					#line 175
					#line 186
					#line 201
					#line 208
					#line 223
					#line 230
					#line 237
					#line 255
					#line 291
					#line 320
					#line 326
					#line 339
					#line 357
					#line 373
					#line 427
					#line 453
					#line 464
					#line 473
					#line 480
					#line 485
					#line 502
					#line 522
					#line 537
					#line 543
					#line 554
					uniform mediump vec4 unity_Lightmap_HDR;
					uniform mediump vec4 unity_DynamicLightmap_HDR;
					#line 568
					#line 578
					#line 593
					#line 602
					#line 609
					#line 618
					#line 626
					#line 635
					#line 654
					#line 660
					#line 670
					#line 680
					#line 691
					#line 696
					#line 702
					#line 707
					#line 764
					#line 770
					#line 785
					#line 816
					#line 830
					#line 834
					#line 840
					#line 849
					#line 859
					#line 885
					#line 891
					#line 7
					uniform sampler2D _MainTex;
					uniform lowp sampler3D _LookupTex3D;
					uniform sampler2D _LookupTex2D;
					uniform highp vec4 _Params;
					#line 17
					#line 23
					#line 29
					#line 35
					#line 41
					#line 47
					#line 67
					#line 91
					#line 97
					#line 44
					highp vec4 UnityObjectToClipPos( in highp vec3 pos ) {
					    #line 50
					    return (unity_MatrixVP * (unity_ObjectToWorld * vec4( pos, 1.0)));
					}
					#line 53
					highp vec4 UnityObjectToClipPos( in highp vec4 pos ) {
					    #line 55
					    return UnityObjectToClipPos( pos.xyz);
					}
					#line 770
					v2f_img vert_img( in appdata_img v ) {
					    v2f_img o;
					    #line 777
					    o.pos = UnityObjectToClipPos( v.vertex);
					    o.uv = v.texcoord;
					    return o;
					}
					varying mediump vec2 xlv_TEXCOORD0;
					void main() {
					unity_MatrixMVP = (unity_MatrixVP * unity_ObjectToWorld);
					unity_MatrixMV = (unity_MatrixV * unity_ObjectToWorld);
					unity_MatrixTMV = xll_transpose_mf4x4(unity_MatrixMV);
					unity_MatrixITMV = xll_transpose_mf4x4((unity_WorldToObject * unity_MatrixInvV));
					    v2f_img xl_retval;
					    appdata_img xlt_v;
					    xlt_v.vertex = vec4(gl_Vertex);
					    xlt_v.texcoord = vec2(gl_MultiTexCoord0);
					    xl_retval = vert_img( xlt_v);
					    gl_Position = vec4(xl_retval.pos);
					    xlv_TEXCOORD0 = vec2(xl_retval.uv);
					}
					/* HLSL2GLSL - NOTE: GLSL optimization failed
					(9,1): error: invalid type `sampler3D' in declaration of `_LookupTex3D'
					*/
					
					#endif
					#ifdef FRAGMENT
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 30
					#endif
					#ifndef SHADER_REQUIRE_INTERPOLATORS10
					    #define SHADER_REQUIRE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_REQUIRE_SAMPLELOD
					    #define SHADER_REQUIRE_SAMPLELOD 1
					#endif
					#ifndef SHADER_REQUIRE_FRAGCOORD
					    #define SHADER_REQUIRE_FRAGCOORD 1
					#endif
					#ifndef UNITY_NO_DXT5nm
					    #define UNITY_NO_DXT5nm 1
					#endif
					#ifndef UNITY_NO_RGBM
					    #define UNITY_NO_RGBM 1
					#endif
					#ifndef UNITY_ENABLE_REFLECTION_BUFFERS
					    #define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#endif
					#ifndef UNITY_FRAMEBUFFER_FETCH_AVAILABLE
					    #define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#endif
					#ifndef UNITY_NO_CUBEMAP_ARRAY
					    #define UNITY_NO_CUBEMAP_ARRAY 1
					#endif
					#ifndef UNITY_NO_SCREENSPACE_SHADOWS
					    #define UNITY_NO_SCREENSPACE_SHADOWS 1
					#endif
					#ifndef UNITY_PBS_USE_BRDF3
					    #define UNITY_PBS_USE_BRDF3 1
					#endif
					#ifndef UNITY_NO_FULL_STANDARD_SHADER
					    #define UNITY_NO_FULL_STANDARD_SHADER 1
					#endif
					#ifndef SHADER_API_MOBILE
					    #define SHADER_API_MOBILE 1
					#endif
					#ifndef UNITY_HARDWARE_TIER1
					    #define UNITY_HARDWARE_TIER1 1
					#endif
					#ifndef UNITY_COLORSPACE_GAMMA
					    #define UNITY_COLORSPACE_GAMMA 1
					#endif
					#ifndef UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS
					    #define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#endif
					#ifndef UNITY_LIGHTMAP_DLDR_ENCODING
					    #define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#endif
					#ifndef UNITY_VERSION
					    #define UNITY_VERSION 201834
					#endif
					#ifndef SHADER_STAGE_VERTEX
					    #define SHADER_STAGE_VERTEX 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 30
					#endif
					#ifndef SHADER_AVAILABLE_INTERPOLATORS10
					    #define SHADER_AVAILABLE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_SAMPLELOD
					    #define SHADER_AVAILABLE_SAMPLELOD 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					mat2 xll_transpose_mf2x2(mat2 m) {
					  return mat2( m[0][0], m[1][0], m[0][1], m[1][1]);
					}
					mat3 xll_transpose_mf3x3(mat3 m) {
					  return mat3( m[0][0], m[1][0], m[2][0],
					               m[0][1], m[1][1], m[2][1],
					               m[0][2], m[1][2], m[2][2]);
					}
					mat4 xll_transpose_mf4x4(mat4 m) {
					  return mat4( m[0][0], m[1][0], m[2][0], m[3][0],
					               m[0][1], m[1][1], m[2][1], m[3][1],
					               m[0][2], m[1][2], m[2][2], m[3][2],
					               m[0][3], m[1][3], m[2][3], m[3][3]);
					}
					float xll_saturate_f( float x) {
					  return clamp( x, 0.0, 1.0);
					}
					vec2 xll_saturate_vf2( vec2 x) {
					  return clamp( x, 0.0, 1.0);
					}
					vec3 xll_saturate_vf3( vec3 x) {
					  return clamp( x, 0.0, 1.0);
					}
					vec4 xll_saturate_vf4( vec4 x) {
					  return clamp( x, 0.0, 1.0);
					}
					mat2 xll_saturate_mf2x2(mat2 m) {
					  return mat2( clamp(m[0], 0.0, 1.0), clamp(m[1], 0.0, 1.0));
					}
					mat3 xll_saturate_mf3x3(mat3 m) {
					  return mat3( clamp(m[0], 0.0, 1.0), clamp(m[1], 0.0, 1.0), clamp(m[2], 0.0, 1.0));
					}
					mat4 xll_saturate_mf4x4(mat4 m) {
					  return mat4( clamp(m[0], 0.0, 1.0), clamp(m[1], 0.0, 1.0), clamp(m[2], 0.0, 1.0), clamp(m[3], 0.0, 1.0));
					}
					#line 447
					struct v2f_vertex_lit {
					    highp vec2 uv;
					    lowp vec4 diff;
					    lowp vec4 spec;
					};
					#line 756
					struct v2f_img {
					    highp vec4 pos;
					    mediump vec2 uv;
					};
					#line 749
					struct appdata_img {
					    highp vec4 vertex;
					    mediump vec2 texcoord;
					};
					#line 40
					uniform highp vec4 _Time;
					uniform highp vec4 _SinTime;
					uniform highp vec4 _CosTime;
					uniform highp vec4 unity_DeltaTime;
					#line 46
					uniform highp vec3 _WorldSpaceCameraPos;
					#line 53
					uniform highp vec4 _ProjectionParams;
					#line 59
					uniform highp vec4 _ScreenParams;
					#line 71
					uniform highp vec4 _ZBufferParams;
					#line 77
					uniform highp vec4 unity_OrthoParams;
					#line 86
					uniform highp vec4 unity_CameraWorldClipPlanes[6];
					#line 92
					uniform highp mat4 unity_CameraProjection;
					uniform highp mat4 unity_CameraInvProjection;
					uniform highp mat4 unity_WorldToCamera;
					uniform highp mat4 unity_CameraToWorld;
					#line 108
					uniform highp vec4 _WorldSpaceLightPos0;
					uniform highp vec4 _LightPositionRange;
					#line 112
					uniform highp vec4 _LightProjectionParams;
					uniform highp vec4 unity_4LightPosX0;
					uniform highp vec4 unity_4LightPosY0;
					#line 116
					uniform highp vec4 unity_4LightPosZ0;
					uniform mediump vec4 unity_4LightAtten0;
					uniform mediump vec4 unity_LightColor[8];
					#line 122
					uniform highp vec4 unity_LightPosition[8];
					#line 127
					uniform mediump vec4 unity_LightAtten[8];
					uniform highp vec4 unity_SpotDirection[8];
					#line 131
					uniform mediump vec4 unity_SHAr;
					uniform mediump vec4 unity_SHAg;
					uniform mediump vec4 unity_SHAb;
					uniform mediump vec4 unity_SHBr;
					#line 135
					uniform mediump vec4 unity_SHBg;
					uniform mediump vec4 unity_SHBb;
					uniform mediump vec4 unity_SHC;
					#line 140
					uniform lowp vec4 unity_OcclusionMaskSelector;
					uniform lowp vec4 unity_ProbesOcclusion;
					#line 145
					uniform mediump vec3 unity_LightColor0;
					uniform mediump vec3 unity_LightColor1;
					uniform mediump vec3 unity_LightColor2;
					uniform mediump vec3 unity_LightColor3;
					#line 152
					uniform highp vec4 unity_ShadowSplitSpheres[4];
					uniform highp vec4 unity_ShadowSplitSqRadii;
					uniform highp vec4 unity_LightShadowBias;
					uniform highp vec4 _LightSplitsNear;
					#line 156
					uniform highp vec4 _LightSplitsFar;
					uniform highp mat4 unity_WorldToShadow[4];
					uniform mediump vec4 _LightShadowData;
					uniform highp vec4 unity_ShadowFadeCenterAndType;
					#line 165
					uniform highp mat4 unity_ObjectToWorld;
					uniform highp mat4 unity_WorldToObject;
					uniform highp vec4 unity_LODFade;
					uniform highp vec4 unity_WorldTransformParams;
					#line 206
					uniform highp mat4 glstate_matrix_transpose_modelview0;
					#line 214
					uniform lowp vec4 glstate_lightmodel_ambient;
					uniform lowp vec4 unity_AmbientSky;
					uniform lowp vec4 unity_AmbientEquator;
					uniform lowp vec4 unity_AmbientGround;
					#line 218
					uniform lowp vec4 unity_IndirectSpecColor;
					uniform highp mat4 glstate_matrix_projection;
					#line 222
					uniform highp mat4 unity_MatrixV;
					uniform highp mat4 unity_MatrixInvV;
					uniform highp mat4 unity_MatrixVP;
					uniform highp int unity_StereoEyeIndex;
					#line 228
					uniform lowp vec4 unity_ShadowColor;
					#line 235
					uniform lowp vec4 unity_FogColor;
					#line 240
					uniform highp vec4 unity_FogParams;
					#line 248
					uniform mediump sampler2D unity_Lightmap;
					uniform mediump sampler2D unity_LightmapInd;
					#line 252
					uniform sampler2D unity_ShadowMask;
					uniform sampler2D unity_DynamicLightmap;
					#line 256
					uniform sampler2D unity_DynamicDirectionality;
					uniform sampler2D unity_DynamicNormal;
					#line 260
					uniform highp vec4 unity_LightmapST;
					uniform highp vec4 unity_DynamicLightmapST;
					#line 268
					uniform samplerCube unity_SpecCube0;
					uniform samplerCube unity_SpecCube1;
					#line 272
					uniform highp vec4 unity_SpecCube0_BoxMax;
					uniform highp vec4 unity_SpecCube0_BoxMin;
					uniform highp vec4 unity_SpecCube0_ProbePosition;
					uniform mediump vec4 unity_SpecCube0_HDR;
					#line 277
					uniform highp vec4 unity_SpecCube1_BoxMax;
					uniform highp vec4 unity_SpecCube1_BoxMin;
					uniform highp vec4 unity_SpecCube1_ProbePosition;
					uniform mediump vec4 unity_SpecCube1_HDR;
					#line 317
					highp mat4 unity_MatrixMVP;
					highp mat4 unity_MatrixMV;
					highp mat4 unity_MatrixTMV;
					highp mat4 unity_MatrixITMV;
					#line 8
					#line 30
					#line 44
					#line 84
					#line 93
					#line 103
					#line 112
					#line 124
					#line 135
					#line 141
					#line 147
					#line 151
					#line 157
					#line 163
					#line 169
					#line 175
					#line 186
					#line 201
					#line 208
					#line 223
					#line 230
					#line 237
					#line 255
					#line 291
					#line 320
					#line 326
					#line 339
					#line 357
					#line 373
					#line 427
					#line 453
					#line 464
					#line 473
					#line 480
					#line 485
					#line 502
					#line 522
					#line 537
					#line 543
					#line 554
					uniform mediump vec4 unity_Lightmap_HDR;
					uniform mediump vec4 unity_DynamicLightmap_HDR;
					#line 568
					#line 578
					#line 593
					#line 602
					#line 609
					#line 618
					#line 626
					#line 635
					#line 654
					#line 660
					#line 670
					#line 680
					#line 691
					#line 696
					#line 702
					#line 707
					#line 764
					#line 770
					#line 785
					#line 816
					#line 830
					#line 834
					#line 840
					#line 849
					#line 859
					#line 885
					#line 891
					#line 7
					uniform sampler2D _MainTex;
					uniform lowp sampler3D _LookupTex3D;
					uniform sampler2D _LookupTex2D;
					uniform highp vec4 _Params;
					#line 17
					#line 23
					#line 29
					#line 35
					#line 41
					#line 47
					#line 67
					#line 91
					#line 97
					#line 35
					highp vec4 lookup_gamma( in highp vec4 o ) {
					    o.xyz = texture3D( _LookupTex3D, ((o.xyz * _Params.x) + _Params.y)).xyz;
					    return o;
					}
					#line 47
					highp vec4 frag( in v2f_img i ) {
					    highp vec4 color = xll_saturate_vf4(texture2D( _MainTex, i.uv));
					    highp vec4 x;
					    #line 55
					    x = lookup_gamma( color);
					    #line 61
					    return (( (i.uv.y > 0.5) ) ? ( mix( color, x, vec4( _Params.z)) ) : ( color ));
					}
					varying mediump vec2 xlv_TEXCOORD0;
					void main() {
					unity_MatrixMVP = (unity_MatrixVP * unity_ObjectToWorld);
					unity_MatrixMV = (unity_MatrixV * unity_ObjectToWorld);
					unity_MatrixTMV = xll_transpose_mf4x4(unity_MatrixMV);
					unity_MatrixITMV = xll_transpose_mf4x4((unity_WorldToObject * unity_MatrixInvV));
					    highp vec4 xl_retval;
					    v2f_img xlt_i;
					    xlt_i.pos = vec4(0.0);
					    xlt_i.uv = vec2(xlv_TEXCOORD0);
					    xl_retval = frag( xlt_i);
					    gl_FragData[0] = vec4(xl_retval);
					}
					/* HLSL2GLSL - NOTE: GLSL optimization failed
					(9,1): error: invalid type `sampler3D' in declaration of `_LookupTex3D'
					(37,21): error: `_LookupTex3D' undeclared
					(37,10): error: no matching function for call to `texture3D(error, vec3)'; candidates are:
					(37,10): error: type mismatch
					*/
					
					#endif"
				}
				SubProgram "gles hw_tier01 " {
					"!!GLES
					#version 100
					
					#ifdef VERTEX
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 30
					#endif
					#ifndef SHADER_REQUIRE_INTERPOLATORS10
					    #define SHADER_REQUIRE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_REQUIRE_SAMPLELOD
					    #define SHADER_REQUIRE_SAMPLELOD 1
					#endif
					#ifndef SHADER_REQUIRE_FRAGCOORD
					    #define SHADER_REQUIRE_FRAGCOORD 1
					#endif
					#ifndef UNITY_NO_DXT5nm
					    #define UNITY_NO_DXT5nm 1
					#endif
					#ifndef UNITY_NO_RGBM
					    #define UNITY_NO_RGBM 1
					#endif
					#ifndef UNITY_ENABLE_REFLECTION_BUFFERS
					    #define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#endif
					#ifndef UNITY_FRAMEBUFFER_FETCH_AVAILABLE
					    #define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#endif
					#ifndef UNITY_NO_CUBEMAP_ARRAY
					    #define UNITY_NO_CUBEMAP_ARRAY 1
					#endif
					#ifndef UNITY_NO_SCREENSPACE_SHADOWS
					    #define UNITY_NO_SCREENSPACE_SHADOWS 1
					#endif
					#ifndef UNITY_PBS_USE_BRDF2
					    #define UNITY_PBS_USE_BRDF2 1
					#endif
					#ifndef SHADER_API_MOBILE
					    #define SHADER_API_MOBILE 1
					#endif
					#ifndef UNITY_HARDWARE_TIER2
					    #define UNITY_HARDWARE_TIER2 1
					#endif
					#ifndef UNITY_COLORSPACE_GAMMA
					    #define UNITY_COLORSPACE_GAMMA 1
					#endif
					#ifndef UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS
					    #define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#endif
					#ifndef UNITY_LIGHTMAP_DLDR_ENCODING
					    #define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#endif
					#ifndef UNITY_VERSION
					    #define UNITY_VERSION 201834
					#endif
					#ifndef SHADER_STAGE_VERTEX
					    #define SHADER_STAGE_VERTEX 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 30
					#endif
					#ifndef SHADER_AVAILABLE_INTERPOLATORS10
					    #define SHADER_AVAILABLE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_SAMPLELOD
					    #define SHADER_AVAILABLE_SAMPLELOD 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#define gl_Vertex _glesVertex
					attribute vec4 _glesVertex;
					#define gl_MultiTexCoord0 _glesMultiTexCoord0
					attribute vec4 _glesMultiTexCoord0;
					mat2 xll_transpose_mf2x2(mat2 m) {
					  return mat2( m[0][0], m[1][0], m[0][1], m[1][1]);
					}
					mat3 xll_transpose_mf3x3(mat3 m) {
					  return mat3( m[0][0], m[1][0], m[2][0],
					               m[0][1], m[1][1], m[2][1],
					               m[0][2], m[1][2], m[2][2]);
					}
					mat4 xll_transpose_mf4x4(mat4 m) {
					  return mat4( m[0][0], m[1][0], m[2][0], m[3][0],
					               m[0][1], m[1][1], m[2][1], m[3][1],
					               m[0][2], m[1][2], m[2][2], m[3][2],
					               m[0][3], m[1][3], m[2][3], m[3][3]);
					}
					#line 447
					struct v2f_vertex_lit {
					    highp vec2 uv;
					    lowp vec4 diff;
					    lowp vec4 spec;
					};
					#line 756
					struct v2f_img {
					    highp vec4 pos;
					    mediump vec2 uv;
					};
					#line 749
					struct appdata_img {
					    highp vec4 vertex;
					    mediump vec2 texcoord;
					};
					#line 40
					uniform highp vec4 _Time;
					uniform highp vec4 _SinTime;
					uniform highp vec4 _CosTime;
					uniform highp vec4 unity_DeltaTime;
					#line 46
					uniform highp vec3 _WorldSpaceCameraPos;
					#line 53
					uniform highp vec4 _ProjectionParams;
					#line 59
					uniform highp vec4 _ScreenParams;
					#line 71
					uniform highp vec4 _ZBufferParams;
					#line 77
					uniform highp vec4 unity_OrthoParams;
					#line 86
					uniform highp vec4 unity_CameraWorldClipPlanes[6];
					#line 92
					uniform highp mat4 unity_CameraProjection;
					uniform highp mat4 unity_CameraInvProjection;
					uniform highp mat4 unity_WorldToCamera;
					uniform highp mat4 unity_CameraToWorld;
					#line 108
					uniform highp vec4 _WorldSpaceLightPos0;
					uniform highp vec4 _LightPositionRange;
					#line 112
					uniform highp vec4 _LightProjectionParams;
					uniform highp vec4 unity_4LightPosX0;
					uniform highp vec4 unity_4LightPosY0;
					#line 116
					uniform highp vec4 unity_4LightPosZ0;
					uniform mediump vec4 unity_4LightAtten0;
					uniform mediump vec4 unity_LightColor[8];
					#line 122
					uniform highp vec4 unity_LightPosition[8];
					#line 127
					uniform mediump vec4 unity_LightAtten[8];
					uniform highp vec4 unity_SpotDirection[8];
					#line 131
					uniform mediump vec4 unity_SHAr;
					uniform mediump vec4 unity_SHAg;
					uniform mediump vec4 unity_SHAb;
					uniform mediump vec4 unity_SHBr;
					#line 135
					uniform mediump vec4 unity_SHBg;
					uniform mediump vec4 unity_SHBb;
					uniform mediump vec4 unity_SHC;
					#line 140
					uniform lowp vec4 unity_OcclusionMaskSelector;
					uniform lowp vec4 unity_ProbesOcclusion;
					#line 145
					uniform mediump vec3 unity_LightColor0;
					uniform mediump vec3 unity_LightColor1;
					uniform mediump vec3 unity_LightColor2;
					uniform mediump vec3 unity_LightColor3;
					#line 152
					uniform highp vec4 unity_ShadowSplitSpheres[4];
					uniform highp vec4 unity_ShadowSplitSqRadii;
					uniform highp vec4 unity_LightShadowBias;
					uniform highp vec4 _LightSplitsNear;
					#line 156
					uniform highp vec4 _LightSplitsFar;
					uniform highp mat4 unity_WorldToShadow[4];
					uniform mediump vec4 _LightShadowData;
					uniform highp vec4 unity_ShadowFadeCenterAndType;
					#line 165
					uniform highp mat4 unity_ObjectToWorld;
					uniform highp mat4 unity_WorldToObject;
					uniform highp vec4 unity_LODFade;
					uniform highp vec4 unity_WorldTransformParams;
					#line 206
					uniform highp mat4 glstate_matrix_transpose_modelview0;
					#line 214
					uniform lowp vec4 glstate_lightmodel_ambient;
					uniform lowp vec4 unity_AmbientSky;
					uniform lowp vec4 unity_AmbientEquator;
					uniform lowp vec4 unity_AmbientGround;
					#line 218
					uniform lowp vec4 unity_IndirectSpecColor;
					uniform highp mat4 glstate_matrix_projection;
					#line 222
					uniform highp mat4 unity_MatrixV;
					uniform highp mat4 unity_MatrixInvV;
					uniform highp mat4 unity_MatrixVP;
					uniform highp int unity_StereoEyeIndex;
					#line 228
					uniform lowp vec4 unity_ShadowColor;
					#line 235
					uniform lowp vec4 unity_FogColor;
					#line 240
					uniform highp vec4 unity_FogParams;
					#line 248
					uniform mediump sampler2D unity_Lightmap;
					uniform mediump sampler2D unity_LightmapInd;
					#line 252
					uniform sampler2D unity_ShadowMask;
					uniform sampler2D unity_DynamicLightmap;
					#line 256
					uniform sampler2D unity_DynamicDirectionality;
					uniform sampler2D unity_DynamicNormal;
					#line 260
					uniform highp vec4 unity_LightmapST;
					uniform highp vec4 unity_DynamicLightmapST;
					#line 268
					uniform samplerCube unity_SpecCube0;
					uniform samplerCube unity_SpecCube1;
					#line 272
					uniform highp vec4 unity_SpecCube0_BoxMax;
					uniform highp vec4 unity_SpecCube0_BoxMin;
					uniform highp vec4 unity_SpecCube0_ProbePosition;
					uniform mediump vec4 unity_SpecCube0_HDR;
					#line 277
					uniform highp vec4 unity_SpecCube1_BoxMax;
					uniform highp vec4 unity_SpecCube1_BoxMin;
					uniform highp vec4 unity_SpecCube1_ProbePosition;
					uniform mediump vec4 unity_SpecCube1_HDR;
					#line 317
					highp mat4 unity_MatrixMVP;
					highp mat4 unity_MatrixMV;
					highp mat4 unity_MatrixTMV;
					highp mat4 unity_MatrixITMV;
					#line 8
					#line 30
					#line 44
					#line 84
					#line 93
					#line 103
					#line 112
					#line 124
					#line 135
					#line 141
					#line 147
					#line 151
					#line 157
					#line 163
					#line 169
					#line 175
					#line 186
					#line 201
					#line 208
					#line 223
					#line 230
					#line 237
					#line 255
					#line 291
					#line 320
					#line 326
					#line 339
					#line 357
					#line 373
					#line 427
					#line 453
					#line 464
					#line 473
					#line 480
					#line 485
					#line 502
					#line 522
					#line 537
					#line 543
					#line 554
					uniform mediump vec4 unity_Lightmap_HDR;
					uniform mediump vec4 unity_DynamicLightmap_HDR;
					#line 568
					#line 578
					#line 593
					#line 602
					#line 609
					#line 618
					#line 626
					#line 635
					#line 654
					#line 660
					#line 670
					#line 680
					#line 691
					#line 696
					#line 702
					#line 707
					#line 764
					#line 770
					#line 785
					#line 816
					#line 830
					#line 834
					#line 840
					#line 849
					#line 859
					#line 885
					#line 891
					#line 7
					uniform sampler2D _MainTex;
					uniform lowp sampler3D _LookupTex3D;
					uniform sampler2D _LookupTex2D;
					uniform highp vec4 _Params;
					#line 17
					#line 23
					#line 29
					#line 35
					#line 41
					#line 47
					#line 67
					#line 91
					#line 97
					#line 44
					highp vec4 UnityObjectToClipPos( in highp vec3 pos ) {
					    #line 50
					    return (unity_MatrixVP * (unity_ObjectToWorld * vec4( pos, 1.0)));
					}
					#line 53
					highp vec4 UnityObjectToClipPos( in highp vec4 pos ) {
					    #line 55
					    return UnityObjectToClipPos( pos.xyz);
					}
					#line 770
					v2f_img vert_img( in appdata_img v ) {
					    v2f_img o;
					    #line 777
					    o.pos = UnityObjectToClipPos( v.vertex);
					    o.uv = v.texcoord;
					    return o;
					}
					varying mediump vec2 xlv_TEXCOORD0;
					void main() {
					unity_MatrixMVP = (unity_MatrixVP * unity_ObjectToWorld);
					unity_MatrixMV = (unity_MatrixV * unity_ObjectToWorld);
					unity_MatrixTMV = xll_transpose_mf4x4(unity_MatrixMV);
					unity_MatrixITMV = xll_transpose_mf4x4((unity_WorldToObject * unity_MatrixInvV));
					    v2f_img xl_retval;
					    appdata_img xlt_v;
					    xlt_v.vertex = vec4(gl_Vertex);
					    xlt_v.texcoord = vec2(gl_MultiTexCoord0);
					    xl_retval = vert_img( xlt_v);
					    gl_Position = vec4(xl_retval.pos);
					    xlv_TEXCOORD0 = vec2(xl_retval.uv);
					}
					/* HLSL2GLSL - NOTE: GLSL optimization failed
					(9,1): error: invalid type `sampler3D' in declaration of `_LookupTex3D'
					*/
					
					#endif
					#ifdef FRAGMENT
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 30
					#endif
					#ifndef SHADER_REQUIRE_INTERPOLATORS10
					    #define SHADER_REQUIRE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_REQUIRE_SAMPLELOD
					    #define SHADER_REQUIRE_SAMPLELOD 1
					#endif
					#ifndef SHADER_REQUIRE_FRAGCOORD
					    #define SHADER_REQUIRE_FRAGCOORD 1
					#endif
					#ifndef UNITY_NO_DXT5nm
					    #define UNITY_NO_DXT5nm 1
					#endif
					#ifndef UNITY_NO_RGBM
					    #define UNITY_NO_RGBM 1
					#endif
					#ifndef UNITY_ENABLE_REFLECTION_BUFFERS
					    #define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#endif
					#ifndef UNITY_FRAMEBUFFER_FETCH_AVAILABLE
					    #define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#endif
					#ifndef UNITY_NO_CUBEMAP_ARRAY
					    #define UNITY_NO_CUBEMAP_ARRAY 1
					#endif
					#ifndef UNITY_NO_SCREENSPACE_SHADOWS
					    #define UNITY_NO_SCREENSPACE_SHADOWS 1
					#endif
					#ifndef UNITY_PBS_USE_BRDF2
					    #define UNITY_PBS_USE_BRDF2 1
					#endif
					#ifndef SHADER_API_MOBILE
					    #define SHADER_API_MOBILE 1
					#endif
					#ifndef UNITY_HARDWARE_TIER2
					    #define UNITY_HARDWARE_TIER2 1
					#endif
					#ifndef UNITY_COLORSPACE_GAMMA
					    #define UNITY_COLORSPACE_GAMMA 1
					#endif
					#ifndef UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS
					    #define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#endif
					#ifndef UNITY_LIGHTMAP_DLDR_ENCODING
					    #define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#endif
					#ifndef UNITY_VERSION
					    #define UNITY_VERSION 201834
					#endif
					#ifndef SHADER_STAGE_VERTEX
					    #define SHADER_STAGE_VERTEX 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 30
					#endif
					#ifndef SHADER_AVAILABLE_INTERPOLATORS10
					    #define SHADER_AVAILABLE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_SAMPLELOD
					    #define SHADER_AVAILABLE_SAMPLELOD 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					mat2 xll_transpose_mf2x2(mat2 m) {
					  return mat2( m[0][0], m[1][0], m[0][1], m[1][1]);
					}
					mat3 xll_transpose_mf3x3(mat3 m) {
					  return mat3( m[0][0], m[1][0], m[2][0],
					               m[0][1], m[1][1], m[2][1],
					               m[0][2], m[1][2], m[2][2]);
					}
					mat4 xll_transpose_mf4x4(mat4 m) {
					  return mat4( m[0][0], m[1][0], m[2][0], m[3][0],
					               m[0][1], m[1][1], m[2][1], m[3][1],
					               m[0][2], m[1][2], m[2][2], m[3][2],
					               m[0][3], m[1][3], m[2][3], m[3][3]);
					}
					float xll_saturate_f( float x) {
					  return clamp( x, 0.0, 1.0);
					}
					vec2 xll_saturate_vf2( vec2 x) {
					  return clamp( x, 0.0, 1.0);
					}
					vec3 xll_saturate_vf3( vec3 x) {
					  return clamp( x, 0.0, 1.0);
					}
					vec4 xll_saturate_vf4( vec4 x) {
					  return clamp( x, 0.0, 1.0);
					}
					mat2 xll_saturate_mf2x2(mat2 m) {
					  return mat2( clamp(m[0], 0.0, 1.0), clamp(m[1], 0.0, 1.0));
					}
					mat3 xll_saturate_mf3x3(mat3 m) {
					  return mat3( clamp(m[0], 0.0, 1.0), clamp(m[1], 0.0, 1.0), clamp(m[2], 0.0, 1.0));
					}
					mat4 xll_saturate_mf4x4(mat4 m) {
					  return mat4( clamp(m[0], 0.0, 1.0), clamp(m[1], 0.0, 1.0), clamp(m[2], 0.0, 1.0), clamp(m[3], 0.0, 1.0));
					}
					#line 447
					struct v2f_vertex_lit {
					    highp vec2 uv;
					    lowp vec4 diff;
					    lowp vec4 spec;
					};
					#line 756
					struct v2f_img {
					    highp vec4 pos;
					    mediump vec2 uv;
					};
					#line 749
					struct appdata_img {
					    highp vec4 vertex;
					    mediump vec2 texcoord;
					};
					#line 40
					uniform highp vec4 _Time;
					uniform highp vec4 _SinTime;
					uniform highp vec4 _CosTime;
					uniform highp vec4 unity_DeltaTime;
					#line 46
					uniform highp vec3 _WorldSpaceCameraPos;
					#line 53
					uniform highp vec4 _ProjectionParams;
					#line 59
					uniform highp vec4 _ScreenParams;
					#line 71
					uniform highp vec4 _ZBufferParams;
					#line 77
					uniform highp vec4 unity_OrthoParams;
					#line 86
					uniform highp vec4 unity_CameraWorldClipPlanes[6];
					#line 92
					uniform highp mat4 unity_CameraProjection;
					uniform highp mat4 unity_CameraInvProjection;
					uniform highp mat4 unity_WorldToCamera;
					uniform highp mat4 unity_CameraToWorld;
					#line 108
					uniform highp vec4 _WorldSpaceLightPos0;
					uniform highp vec4 _LightPositionRange;
					#line 112
					uniform highp vec4 _LightProjectionParams;
					uniform highp vec4 unity_4LightPosX0;
					uniform highp vec4 unity_4LightPosY0;
					#line 116
					uniform highp vec4 unity_4LightPosZ0;
					uniform mediump vec4 unity_4LightAtten0;
					uniform mediump vec4 unity_LightColor[8];
					#line 122
					uniform highp vec4 unity_LightPosition[8];
					#line 127
					uniform mediump vec4 unity_LightAtten[8];
					uniform highp vec4 unity_SpotDirection[8];
					#line 131
					uniform mediump vec4 unity_SHAr;
					uniform mediump vec4 unity_SHAg;
					uniform mediump vec4 unity_SHAb;
					uniform mediump vec4 unity_SHBr;
					#line 135
					uniform mediump vec4 unity_SHBg;
					uniform mediump vec4 unity_SHBb;
					uniform mediump vec4 unity_SHC;
					#line 140
					uniform lowp vec4 unity_OcclusionMaskSelector;
					uniform lowp vec4 unity_ProbesOcclusion;
					#line 145
					uniform mediump vec3 unity_LightColor0;
					uniform mediump vec3 unity_LightColor1;
					uniform mediump vec3 unity_LightColor2;
					uniform mediump vec3 unity_LightColor3;
					#line 152
					uniform highp vec4 unity_ShadowSplitSpheres[4];
					uniform highp vec4 unity_ShadowSplitSqRadii;
					uniform highp vec4 unity_LightShadowBias;
					uniform highp vec4 _LightSplitsNear;
					#line 156
					uniform highp vec4 _LightSplitsFar;
					uniform highp mat4 unity_WorldToShadow[4];
					uniform mediump vec4 _LightShadowData;
					uniform highp vec4 unity_ShadowFadeCenterAndType;
					#line 165
					uniform highp mat4 unity_ObjectToWorld;
					uniform highp mat4 unity_WorldToObject;
					uniform highp vec4 unity_LODFade;
					uniform highp vec4 unity_WorldTransformParams;
					#line 206
					uniform highp mat4 glstate_matrix_transpose_modelview0;
					#line 214
					uniform lowp vec4 glstate_lightmodel_ambient;
					uniform lowp vec4 unity_AmbientSky;
					uniform lowp vec4 unity_AmbientEquator;
					uniform lowp vec4 unity_AmbientGround;
					#line 218
					uniform lowp vec4 unity_IndirectSpecColor;
					uniform highp mat4 glstate_matrix_projection;
					#line 222
					uniform highp mat4 unity_MatrixV;
					uniform highp mat4 unity_MatrixInvV;
					uniform highp mat4 unity_MatrixVP;
					uniform highp int unity_StereoEyeIndex;
					#line 228
					uniform lowp vec4 unity_ShadowColor;
					#line 235
					uniform lowp vec4 unity_FogColor;
					#line 240
					uniform highp vec4 unity_FogParams;
					#line 248
					uniform mediump sampler2D unity_Lightmap;
					uniform mediump sampler2D unity_LightmapInd;
					#line 252
					uniform sampler2D unity_ShadowMask;
					uniform sampler2D unity_DynamicLightmap;
					#line 256
					uniform sampler2D unity_DynamicDirectionality;
					uniform sampler2D unity_DynamicNormal;
					#line 260
					uniform highp vec4 unity_LightmapST;
					uniform highp vec4 unity_DynamicLightmapST;
					#line 268
					uniform samplerCube unity_SpecCube0;
					uniform samplerCube unity_SpecCube1;
					#line 272
					uniform highp vec4 unity_SpecCube0_BoxMax;
					uniform highp vec4 unity_SpecCube0_BoxMin;
					uniform highp vec4 unity_SpecCube0_ProbePosition;
					uniform mediump vec4 unity_SpecCube0_HDR;
					#line 277
					uniform highp vec4 unity_SpecCube1_BoxMax;
					uniform highp vec4 unity_SpecCube1_BoxMin;
					uniform highp vec4 unity_SpecCube1_ProbePosition;
					uniform mediump vec4 unity_SpecCube1_HDR;
					#line 317
					highp mat4 unity_MatrixMVP;
					highp mat4 unity_MatrixMV;
					highp mat4 unity_MatrixTMV;
					highp mat4 unity_MatrixITMV;
					#line 8
					#line 30
					#line 44
					#line 84
					#line 93
					#line 103
					#line 112
					#line 124
					#line 135
					#line 141
					#line 147
					#line 151
					#line 157
					#line 163
					#line 169
					#line 175
					#line 186
					#line 201
					#line 208
					#line 223
					#line 230
					#line 237
					#line 255
					#line 291
					#line 320
					#line 326
					#line 339
					#line 357
					#line 373
					#line 427
					#line 453
					#line 464
					#line 473
					#line 480
					#line 485
					#line 502
					#line 522
					#line 537
					#line 543
					#line 554
					uniform mediump vec4 unity_Lightmap_HDR;
					uniform mediump vec4 unity_DynamicLightmap_HDR;
					#line 568
					#line 578
					#line 593
					#line 602
					#line 609
					#line 618
					#line 626
					#line 635
					#line 654
					#line 660
					#line 670
					#line 680
					#line 691
					#line 696
					#line 702
					#line 707
					#line 764
					#line 770
					#line 785
					#line 816
					#line 830
					#line 834
					#line 840
					#line 849
					#line 859
					#line 885
					#line 891
					#line 7
					uniform sampler2D _MainTex;
					uniform lowp sampler3D _LookupTex3D;
					uniform sampler2D _LookupTex2D;
					uniform highp vec4 _Params;
					#line 17
					#line 23
					#line 29
					#line 35
					#line 41
					#line 47
					#line 67
					#line 91
					#line 97
					#line 35
					highp vec4 lookup_gamma( in highp vec4 o ) {
					    o.xyz = texture3D( _LookupTex3D, ((o.xyz * _Params.x) + _Params.y)).xyz;
					    return o;
					}
					#line 47
					highp vec4 frag( in v2f_img i ) {
					    highp vec4 color = xll_saturate_vf4(texture2D( _MainTex, i.uv));
					    highp vec4 x;
					    #line 55
					    x = lookup_gamma( color);
					    #line 61
					    return (( (i.uv.y > 0.5) ) ? ( mix( color, x, vec4( _Params.z)) ) : ( color ));
					}
					varying mediump vec2 xlv_TEXCOORD0;
					void main() {
					unity_MatrixMVP = (unity_MatrixVP * unity_ObjectToWorld);
					unity_MatrixMV = (unity_MatrixV * unity_ObjectToWorld);
					unity_MatrixTMV = xll_transpose_mf4x4(unity_MatrixMV);
					unity_MatrixITMV = xll_transpose_mf4x4((unity_WorldToObject * unity_MatrixInvV));
					    highp vec4 xl_retval;
					    v2f_img xlt_i;
					    xlt_i.pos = vec4(0.0);
					    xlt_i.uv = vec2(xlv_TEXCOORD0);
					    xl_retval = frag( xlt_i);
					    gl_FragData[0] = vec4(xl_retval);
					}
					/* HLSL2GLSL - NOTE: GLSL optimization failed
					(9,1): error: invalid type `sampler3D' in declaration of `_LookupTex3D'
					(37,21): error: `_LookupTex3D' undeclared
					(37,10): error: no matching function for call to `texture3D(error, vec3)'; candidates are:
					(37,10): error: type mismatch
					*/
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {
					"!!GLES
					#version 100
					
					#ifdef VERTEX
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 30
					#endif
					#ifndef SHADER_REQUIRE_INTERPOLATORS10
					    #define SHADER_REQUIRE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_REQUIRE_SAMPLELOD
					    #define SHADER_REQUIRE_SAMPLELOD 1
					#endif
					#ifndef SHADER_REQUIRE_FRAGCOORD
					    #define SHADER_REQUIRE_FRAGCOORD 1
					#endif
					#ifndef UNITY_NO_DXT5nm
					    #define UNITY_NO_DXT5nm 1
					#endif
					#ifndef UNITY_NO_RGBM
					    #define UNITY_NO_RGBM 1
					#endif
					#ifndef UNITY_ENABLE_REFLECTION_BUFFERS
					    #define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#endif
					#ifndef UNITY_FRAMEBUFFER_FETCH_AVAILABLE
					    #define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#endif
					#ifndef UNITY_NO_CUBEMAP_ARRAY
					    #define UNITY_NO_CUBEMAP_ARRAY 1
					#endif
					#ifndef UNITY_NO_SCREENSPACE_SHADOWS
					    #define UNITY_NO_SCREENSPACE_SHADOWS 1
					#endif
					#ifndef UNITY_PBS_USE_BRDF2
					    #define UNITY_PBS_USE_BRDF2 1
					#endif
					#ifndef SHADER_API_MOBILE
					    #define SHADER_API_MOBILE 1
					#endif
					#ifndef UNITY_HARDWARE_TIER3
					    #define UNITY_HARDWARE_TIER3 1
					#endif
					#ifndef UNITY_COLORSPACE_GAMMA
					    #define UNITY_COLORSPACE_GAMMA 1
					#endif
					#ifndef UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS
					    #define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#endif
					#ifndef UNITY_LIGHTMAP_DLDR_ENCODING
					    #define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#endif
					#ifndef UNITY_VERSION
					    #define UNITY_VERSION 201834
					#endif
					#ifndef SHADER_STAGE_VERTEX
					    #define SHADER_STAGE_VERTEX 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 30
					#endif
					#ifndef SHADER_AVAILABLE_INTERPOLATORS10
					    #define SHADER_AVAILABLE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_SAMPLELOD
					    #define SHADER_AVAILABLE_SAMPLELOD 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#define gl_Vertex _glesVertex
					attribute vec4 _glesVertex;
					#define gl_MultiTexCoord0 _glesMultiTexCoord0
					attribute vec4 _glesMultiTexCoord0;
					mat2 xll_transpose_mf2x2(mat2 m) {
					  return mat2( m[0][0], m[1][0], m[0][1], m[1][1]);
					}
					mat3 xll_transpose_mf3x3(mat3 m) {
					  return mat3( m[0][0], m[1][0], m[2][0],
					               m[0][1], m[1][1], m[2][1],
					               m[0][2], m[1][2], m[2][2]);
					}
					mat4 xll_transpose_mf4x4(mat4 m) {
					  return mat4( m[0][0], m[1][0], m[2][0], m[3][0],
					               m[0][1], m[1][1], m[2][1], m[3][1],
					               m[0][2], m[1][2], m[2][2], m[3][2],
					               m[0][3], m[1][3], m[2][3], m[3][3]);
					}
					#line 447
					struct v2f_vertex_lit {
					    highp vec2 uv;
					    lowp vec4 diff;
					    lowp vec4 spec;
					};
					#line 756
					struct v2f_img {
					    highp vec4 pos;
					    mediump vec2 uv;
					};
					#line 749
					struct appdata_img {
					    highp vec4 vertex;
					    mediump vec2 texcoord;
					};
					#line 40
					uniform highp vec4 _Time;
					uniform highp vec4 _SinTime;
					uniform highp vec4 _CosTime;
					uniform highp vec4 unity_DeltaTime;
					#line 46
					uniform highp vec3 _WorldSpaceCameraPos;
					#line 53
					uniform highp vec4 _ProjectionParams;
					#line 59
					uniform highp vec4 _ScreenParams;
					#line 71
					uniform highp vec4 _ZBufferParams;
					#line 77
					uniform highp vec4 unity_OrthoParams;
					#line 86
					uniform highp vec4 unity_CameraWorldClipPlanes[6];
					#line 92
					uniform highp mat4 unity_CameraProjection;
					uniform highp mat4 unity_CameraInvProjection;
					uniform highp mat4 unity_WorldToCamera;
					uniform highp mat4 unity_CameraToWorld;
					#line 108
					uniform highp vec4 _WorldSpaceLightPos0;
					uniform highp vec4 _LightPositionRange;
					#line 112
					uniform highp vec4 _LightProjectionParams;
					uniform highp vec4 unity_4LightPosX0;
					uniform highp vec4 unity_4LightPosY0;
					#line 116
					uniform highp vec4 unity_4LightPosZ0;
					uniform mediump vec4 unity_4LightAtten0;
					uniform mediump vec4 unity_LightColor[8];
					#line 122
					uniform highp vec4 unity_LightPosition[8];
					#line 127
					uniform mediump vec4 unity_LightAtten[8];
					uniform highp vec4 unity_SpotDirection[8];
					#line 131
					uniform mediump vec4 unity_SHAr;
					uniform mediump vec4 unity_SHAg;
					uniform mediump vec4 unity_SHAb;
					uniform mediump vec4 unity_SHBr;
					#line 135
					uniform mediump vec4 unity_SHBg;
					uniform mediump vec4 unity_SHBb;
					uniform mediump vec4 unity_SHC;
					#line 140
					uniform lowp vec4 unity_OcclusionMaskSelector;
					uniform lowp vec4 unity_ProbesOcclusion;
					#line 145
					uniform mediump vec3 unity_LightColor0;
					uniform mediump vec3 unity_LightColor1;
					uniform mediump vec3 unity_LightColor2;
					uniform mediump vec3 unity_LightColor3;
					#line 152
					uniform highp vec4 unity_ShadowSplitSpheres[4];
					uniform highp vec4 unity_ShadowSplitSqRadii;
					uniform highp vec4 unity_LightShadowBias;
					uniform highp vec4 _LightSplitsNear;
					#line 156
					uniform highp vec4 _LightSplitsFar;
					uniform highp mat4 unity_WorldToShadow[4];
					uniform mediump vec4 _LightShadowData;
					uniform highp vec4 unity_ShadowFadeCenterAndType;
					#line 165
					uniform highp mat4 unity_ObjectToWorld;
					uniform highp mat4 unity_WorldToObject;
					uniform highp vec4 unity_LODFade;
					uniform highp vec4 unity_WorldTransformParams;
					#line 206
					uniform highp mat4 glstate_matrix_transpose_modelview0;
					#line 214
					uniform lowp vec4 glstate_lightmodel_ambient;
					uniform lowp vec4 unity_AmbientSky;
					uniform lowp vec4 unity_AmbientEquator;
					uniform lowp vec4 unity_AmbientGround;
					#line 218
					uniform lowp vec4 unity_IndirectSpecColor;
					uniform highp mat4 glstate_matrix_projection;
					#line 222
					uniform highp mat4 unity_MatrixV;
					uniform highp mat4 unity_MatrixInvV;
					uniform highp mat4 unity_MatrixVP;
					uniform highp int unity_StereoEyeIndex;
					#line 228
					uniform lowp vec4 unity_ShadowColor;
					#line 235
					uniform lowp vec4 unity_FogColor;
					#line 240
					uniform highp vec4 unity_FogParams;
					#line 248
					uniform mediump sampler2D unity_Lightmap;
					uniform mediump sampler2D unity_LightmapInd;
					#line 252
					uniform sampler2D unity_ShadowMask;
					uniform sampler2D unity_DynamicLightmap;
					#line 256
					uniform sampler2D unity_DynamicDirectionality;
					uniform sampler2D unity_DynamicNormal;
					#line 260
					uniform highp vec4 unity_LightmapST;
					uniform highp vec4 unity_DynamicLightmapST;
					#line 268
					uniform samplerCube unity_SpecCube0;
					uniform samplerCube unity_SpecCube1;
					#line 272
					uniform highp vec4 unity_SpecCube0_BoxMax;
					uniform highp vec4 unity_SpecCube0_BoxMin;
					uniform highp vec4 unity_SpecCube0_ProbePosition;
					uniform mediump vec4 unity_SpecCube0_HDR;
					#line 277
					uniform highp vec4 unity_SpecCube1_BoxMax;
					uniform highp vec4 unity_SpecCube1_BoxMin;
					uniform highp vec4 unity_SpecCube1_ProbePosition;
					uniform mediump vec4 unity_SpecCube1_HDR;
					#line 317
					highp mat4 unity_MatrixMVP;
					highp mat4 unity_MatrixMV;
					highp mat4 unity_MatrixTMV;
					highp mat4 unity_MatrixITMV;
					#line 8
					#line 30
					#line 44
					#line 84
					#line 93
					#line 103
					#line 112
					#line 124
					#line 135
					#line 141
					#line 147
					#line 151
					#line 157
					#line 163
					#line 169
					#line 175
					#line 186
					#line 201
					#line 208
					#line 223
					#line 230
					#line 237
					#line 255
					#line 291
					#line 320
					#line 326
					#line 339
					#line 357
					#line 373
					#line 427
					#line 453
					#line 464
					#line 473
					#line 480
					#line 485
					#line 502
					#line 522
					#line 537
					#line 543
					#line 554
					uniform mediump vec4 unity_Lightmap_HDR;
					uniform mediump vec4 unity_DynamicLightmap_HDR;
					#line 568
					#line 578
					#line 593
					#line 602
					#line 609
					#line 618
					#line 626
					#line 635
					#line 654
					#line 660
					#line 670
					#line 680
					#line 691
					#line 696
					#line 702
					#line 707
					#line 764
					#line 770
					#line 785
					#line 816
					#line 830
					#line 834
					#line 840
					#line 849
					#line 859
					#line 885
					#line 891
					#line 7
					uniform sampler2D _MainTex;
					uniform lowp sampler3D _LookupTex3D;
					uniform sampler2D _LookupTex2D;
					uniform highp vec4 _Params;
					#line 17
					#line 23
					#line 29
					#line 35
					#line 41
					#line 47
					#line 67
					#line 91
					#line 97
					#line 44
					highp vec4 UnityObjectToClipPos( in highp vec3 pos ) {
					    #line 50
					    return (unity_MatrixVP * (unity_ObjectToWorld * vec4( pos, 1.0)));
					}
					#line 53
					highp vec4 UnityObjectToClipPos( in highp vec4 pos ) {
					    #line 55
					    return UnityObjectToClipPos( pos.xyz);
					}
					#line 770
					v2f_img vert_img( in appdata_img v ) {
					    v2f_img o;
					    #line 777
					    o.pos = UnityObjectToClipPos( v.vertex);
					    o.uv = v.texcoord;
					    return o;
					}
					varying mediump vec2 xlv_TEXCOORD0;
					void main() {
					unity_MatrixMVP = (unity_MatrixVP * unity_ObjectToWorld);
					unity_MatrixMV = (unity_MatrixV * unity_ObjectToWorld);
					unity_MatrixTMV = xll_transpose_mf4x4(unity_MatrixMV);
					unity_MatrixITMV = xll_transpose_mf4x4((unity_WorldToObject * unity_MatrixInvV));
					    v2f_img xl_retval;
					    appdata_img xlt_v;
					    xlt_v.vertex = vec4(gl_Vertex);
					    xlt_v.texcoord = vec2(gl_MultiTexCoord0);
					    xl_retval = vert_img( xlt_v);
					    gl_Position = vec4(xl_retval.pos);
					    xlv_TEXCOORD0 = vec2(xl_retval.uv);
					}
					/* HLSL2GLSL - NOTE: GLSL optimization failed
					(9,1): error: invalid type `sampler3D' in declaration of `_LookupTex3D'
					*/
					
					#endif
					#ifdef FRAGMENT
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 30
					#endif
					#ifndef SHADER_REQUIRE_INTERPOLATORS10
					    #define SHADER_REQUIRE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_REQUIRE_SAMPLELOD
					    #define SHADER_REQUIRE_SAMPLELOD 1
					#endif
					#ifndef SHADER_REQUIRE_FRAGCOORD
					    #define SHADER_REQUIRE_FRAGCOORD 1
					#endif
					#ifndef UNITY_NO_DXT5nm
					    #define UNITY_NO_DXT5nm 1
					#endif
					#ifndef UNITY_NO_RGBM
					    #define UNITY_NO_RGBM 1
					#endif
					#ifndef UNITY_ENABLE_REFLECTION_BUFFERS
					    #define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#endif
					#ifndef UNITY_FRAMEBUFFER_FETCH_AVAILABLE
					    #define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#endif
					#ifndef UNITY_NO_CUBEMAP_ARRAY
					    #define UNITY_NO_CUBEMAP_ARRAY 1
					#endif
					#ifndef UNITY_NO_SCREENSPACE_SHADOWS
					    #define UNITY_NO_SCREENSPACE_SHADOWS 1
					#endif
					#ifndef UNITY_PBS_USE_BRDF2
					    #define UNITY_PBS_USE_BRDF2 1
					#endif
					#ifndef SHADER_API_MOBILE
					    #define SHADER_API_MOBILE 1
					#endif
					#ifndef UNITY_HARDWARE_TIER3
					    #define UNITY_HARDWARE_TIER3 1
					#endif
					#ifndef UNITY_COLORSPACE_GAMMA
					    #define UNITY_COLORSPACE_GAMMA 1
					#endif
					#ifndef UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS
					    #define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#endif
					#ifndef UNITY_LIGHTMAP_DLDR_ENCODING
					    #define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#endif
					#ifndef UNITY_VERSION
					    #define UNITY_VERSION 201834
					#endif
					#ifndef SHADER_STAGE_VERTEX
					    #define SHADER_STAGE_VERTEX 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 30
					#endif
					#ifndef SHADER_AVAILABLE_INTERPOLATORS10
					    #define SHADER_AVAILABLE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_SAMPLELOD
					    #define SHADER_AVAILABLE_SAMPLELOD 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					mat2 xll_transpose_mf2x2(mat2 m) {
					  return mat2( m[0][0], m[1][0], m[0][1], m[1][1]);
					}
					mat3 xll_transpose_mf3x3(mat3 m) {
					  return mat3( m[0][0], m[1][0], m[2][0],
					               m[0][1], m[1][1], m[2][1],
					               m[0][2], m[1][2], m[2][2]);
					}
					mat4 xll_transpose_mf4x4(mat4 m) {
					  return mat4( m[0][0], m[1][0], m[2][0], m[3][0],
					               m[0][1], m[1][1], m[2][1], m[3][1],
					               m[0][2], m[1][2], m[2][2], m[3][2],
					               m[0][3], m[1][3], m[2][3], m[3][3]);
					}
					float xll_saturate_f( float x) {
					  return clamp( x, 0.0, 1.0);
					}
					vec2 xll_saturate_vf2( vec2 x) {
					  return clamp( x, 0.0, 1.0);
					}
					vec3 xll_saturate_vf3( vec3 x) {
					  return clamp( x, 0.0, 1.0);
					}
					vec4 xll_saturate_vf4( vec4 x) {
					  return clamp( x, 0.0, 1.0);
					}
					mat2 xll_saturate_mf2x2(mat2 m) {
					  return mat2( clamp(m[0], 0.0, 1.0), clamp(m[1], 0.0, 1.0));
					}
					mat3 xll_saturate_mf3x3(mat3 m) {
					  return mat3( clamp(m[0], 0.0, 1.0), clamp(m[1], 0.0, 1.0), clamp(m[2], 0.0, 1.0));
					}
					mat4 xll_saturate_mf4x4(mat4 m) {
					  return mat4( clamp(m[0], 0.0, 1.0), clamp(m[1], 0.0, 1.0), clamp(m[2], 0.0, 1.0), clamp(m[3], 0.0, 1.0));
					}
					#line 447
					struct v2f_vertex_lit {
					    highp vec2 uv;
					    lowp vec4 diff;
					    lowp vec4 spec;
					};
					#line 756
					struct v2f_img {
					    highp vec4 pos;
					    mediump vec2 uv;
					};
					#line 749
					struct appdata_img {
					    highp vec4 vertex;
					    mediump vec2 texcoord;
					};
					#line 40
					uniform highp vec4 _Time;
					uniform highp vec4 _SinTime;
					uniform highp vec4 _CosTime;
					uniform highp vec4 unity_DeltaTime;
					#line 46
					uniform highp vec3 _WorldSpaceCameraPos;
					#line 53
					uniform highp vec4 _ProjectionParams;
					#line 59
					uniform highp vec4 _ScreenParams;
					#line 71
					uniform highp vec4 _ZBufferParams;
					#line 77
					uniform highp vec4 unity_OrthoParams;
					#line 86
					uniform highp vec4 unity_CameraWorldClipPlanes[6];
					#line 92
					uniform highp mat4 unity_CameraProjection;
					uniform highp mat4 unity_CameraInvProjection;
					uniform highp mat4 unity_WorldToCamera;
					uniform highp mat4 unity_CameraToWorld;
					#line 108
					uniform highp vec4 _WorldSpaceLightPos0;
					uniform highp vec4 _LightPositionRange;
					#line 112
					uniform highp vec4 _LightProjectionParams;
					uniform highp vec4 unity_4LightPosX0;
					uniform highp vec4 unity_4LightPosY0;
					#line 116
					uniform highp vec4 unity_4LightPosZ0;
					uniform mediump vec4 unity_4LightAtten0;
					uniform mediump vec4 unity_LightColor[8];
					#line 122
					uniform highp vec4 unity_LightPosition[8];
					#line 127
					uniform mediump vec4 unity_LightAtten[8];
					uniform highp vec4 unity_SpotDirection[8];
					#line 131
					uniform mediump vec4 unity_SHAr;
					uniform mediump vec4 unity_SHAg;
					uniform mediump vec4 unity_SHAb;
					uniform mediump vec4 unity_SHBr;
					#line 135
					uniform mediump vec4 unity_SHBg;
					uniform mediump vec4 unity_SHBb;
					uniform mediump vec4 unity_SHC;
					#line 140
					uniform lowp vec4 unity_OcclusionMaskSelector;
					uniform lowp vec4 unity_ProbesOcclusion;
					#line 145
					uniform mediump vec3 unity_LightColor0;
					uniform mediump vec3 unity_LightColor1;
					uniform mediump vec3 unity_LightColor2;
					uniform mediump vec3 unity_LightColor3;
					#line 152
					uniform highp vec4 unity_ShadowSplitSpheres[4];
					uniform highp vec4 unity_ShadowSplitSqRadii;
					uniform highp vec4 unity_LightShadowBias;
					uniform highp vec4 _LightSplitsNear;
					#line 156
					uniform highp vec4 _LightSplitsFar;
					uniform highp mat4 unity_WorldToShadow[4];
					uniform mediump vec4 _LightShadowData;
					uniform highp vec4 unity_ShadowFadeCenterAndType;
					#line 165
					uniform highp mat4 unity_ObjectToWorld;
					uniform highp mat4 unity_WorldToObject;
					uniform highp vec4 unity_LODFade;
					uniform highp vec4 unity_WorldTransformParams;
					#line 206
					uniform highp mat4 glstate_matrix_transpose_modelview0;
					#line 214
					uniform lowp vec4 glstate_lightmodel_ambient;
					uniform lowp vec4 unity_AmbientSky;
					uniform lowp vec4 unity_AmbientEquator;
					uniform lowp vec4 unity_AmbientGround;
					#line 218
					uniform lowp vec4 unity_IndirectSpecColor;
					uniform highp mat4 glstate_matrix_projection;
					#line 222
					uniform highp mat4 unity_MatrixV;
					uniform highp mat4 unity_MatrixInvV;
					uniform highp mat4 unity_MatrixVP;
					uniform highp int unity_StereoEyeIndex;
					#line 228
					uniform lowp vec4 unity_ShadowColor;
					#line 235
					uniform lowp vec4 unity_FogColor;
					#line 240
					uniform highp vec4 unity_FogParams;
					#line 248
					uniform mediump sampler2D unity_Lightmap;
					uniform mediump sampler2D unity_LightmapInd;
					#line 252
					uniform sampler2D unity_ShadowMask;
					uniform sampler2D unity_DynamicLightmap;
					#line 256
					uniform sampler2D unity_DynamicDirectionality;
					uniform sampler2D unity_DynamicNormal;
					#line 260
					uniform highp vec4 unity_LightmapST;
					uniform highp vec4 unity_DynamicLightmapST;
					#line 268
					uniform samplerCube unity_SpecCube0;
					uniform samplerCube unity_SpecCube1;
					#line 272
					uniform highp vec4 unity_SpecCube0_BoxMax;
					uniform highp vec4 unity_SpecCube0_BoxMin;
					uniform highp vec4 unity_SpecCube0_ProbePosition;
					uniform mediump vec4 unity_SpecCube0_HDR;
					#line 277
					uniform highp vec4 unity_SpecCube1_BoxMax;
					uniform highp vec4 unity_SpecCube1_BoxMin;
					uniform highp vec4 unity_SpecCube1_ProbePosition;
					uniform mediump vec4 unity_SpecCube1_HDR;
					#line 317
					highp mat4 unity_MatrixMVP;
					highp mat4 unity_MatrixMV;
					highp mat4 unity_MatrixTMV;
					highp mat4 unity_MatrixITMV;
					#line 8
					#line 30
					#line 44
					#line 84
					#line 93
					#line 103
					#line 112
					#line 124
					#line 135
					#line 141
					#line 147
					#line 151
					#line 157
					#line 163
					#line 169
					#line 175
					#line 186
					#line 201
					#line 208
					#line 223
					#line 230
					#line 237
					#line 255
					#line 291
					#line 320
					#line 326
					#line 339
					#line 357
					#line 373
					#line 427
					#line 453
					#line 464
					#line 473
					#line 480
					#line 485
					#line 502
					#line 522
					#line 537
					#line 543
					#line 554
					uniform mediump vec4 unity_Lightmap_HDR;
					uniform mediump vec4 unity_DynamicLightmap_HDR;
					#line 568
					#line 578
					#line 593
					#line 602
					#line 609
					#line 618
					#line 626
					#line 635
					#line 654
					#line 660
					#line 670
					#line 680
					#line 691
					#line 696
					#line 702
					#line 707
					#line 764
					#line 770
					#line 785
					#line 816
					#line 830
					#line 834
					#line 840
					#line 849
					#line 859
					#line 885
					#line 891
					#line 7
					uniform sampler2D _MainTex;
					uniform lowp sampler3D _LookupTex3D;
					uniform sampler2D _LookupTex2D;
					uniform highp vec4 _Params;
					#line 17
					#line 23
					#line 29
					#line 35
					#line 41
					#line 47
					#line 67
					#line 91
					#line 97
					#line 35
					highp vec4 lookup_gamma( in highp vec4 o ) {
					    o.xyz = texture3D( _LookupTex3D, ((o.xyz * _Params.x) + _Params.y)).xyz;
					    return o;
					}
					#line 47
					highp vec4 frag( in v2f_img i ) {
					    highp vec4 color = xll_saturate_vf4(texture2D( _MainTex, i.uv));
					    highp vec4 x;
					    #line 55
					    x = lookup_gamma( color);
					    #line 61
					    return (( (i.uv.y > 0.5) ) ? ( mix( color, x, vec4( _Params.z)) ) : ( color ));
					}
					varying mediump vec2 xlv_TEXCOORD0;
					void main() {
					unity_MatrixMVP = (unity_MatrixVP * unity_ObjectToWorld);
					unity_MatrixMV = (unity_MatrixV * unity_ObjectToWorld);
					unity_MatrixTMV = xll_transpose_mf4x4(unity_MatrixMV);
					unity_MatrixITMV = xll_transpose_mf4x4((unity_WorldToObject * unity_MatrixInvV));
					    highp vec4 xl_retval;
					    v2f_img xlt_i;
					    xlt_i.pos = vec4(0.0);
					    xlt_i.uv = vec2(xlv_TEXCOORD0);
					    xl_retval = frag( xlt_i);
					    gl_FragData[0] = vec4(xl_retval);
					}
					/* HLSL2GLSL - NOTE: GLSL optimization failed
					(9,1): error: invalid type `sampler3D' in declaration of `_LookupTex3D'
					(37,21): error: `_LookupTex3D' undeclared
					(37,10): error: no matching function for call to `texture3D(error, vec3)'; candidates are:
					(37,10): error: type mismatch
					*/
					
					#endif"
				}
				SubProgram "gles3 hw_tier00 " {
					"!!GLES3
					#ifdef VERTEX
					#version 300 es
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					in highp vec4 in_POSITION0;
					in mediump vec2 in_TEXCOORD0;
					out mediump vec2 vs_TEXCOORD0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					void main()
					{
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy;
					    return;
					}
					
					#endif
					#ifdef FRAGMENT
					#version 300 es
					
					precision highp int;
					uniform 	vec4 _Params;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler3D _LookupTex3D;
					in mediump vec2 vs_TEXCOORD0;
					layout(location = 0) out highp vec4 SV_Target0;
					vec4 u_xlat0;
					lowp vec4 u_xlat10_0;
					vec4 u_xlat1;
					lowp vec3 u_xlat10_1;
					bool u_xlatb2;
					void main()
					{
					    u_xlat10_0 = texture(_MainTex, vs_TEXCOORD0.xy);
					    u_xlat0 = u_xlat10_0;
					#ifdef UNITY_ADRENO_ES3
					    u_xlat0 = min(max(u_xlat0, 0.0), 1.0);
					#else
					    u_xlat0 = clamp(u_xlat0, 0.0, 1.0);
					#endif
					    u_xlat1.xyz = u_xlat0.xyz * _Params.xxx + _Params.yyy;
					    u_xlat10_1.xyz = texture(_LookupTex3D, u_xlat1.xyz).xyz;
					    u_xlat1.xyz = (-u_xlat0.xyz) + u_xlat10_1.xyz;
					    u_xlat1.w = 0.0;
					    u_xlat1 = _Params.zzzz * u_xlat1 + u_xlat0;
					#ifdef UNITY_ADRENO_ES3
					    u_xlatb2 = !!(0.5<vs_TEXCOORD0.y);
					#else
					    u_xlatb2 = 0.5<vs_TEXCOORD0.y;
					#endif
					    SV_Target0 = (bool(u_xlatb2)) ? u_xlat1 : u_xlat0;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles3 hw_tier01 " {
					"!!GLES3
					#ifdef VERTEX
					#version 300 es
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					in highp vec4 in_POSITION0;
					in mediump vec2 in_TEXCOORD0;
					out mediump vec2 vs_TEXCOORD0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					void main()
					{
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy;
					    return;
					}
					
					#endif
					#ifdef FRAGMENT
					#version 300 es
					
					precision highp int;
					uniform 	vec4 _Params;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler3D _LookupTex3D;
					in mediump vec2 vs_TEXCOORD0;
					layout(location = 0) out highp vec4 SV_Target0;
					vec4 u_xlat0;
					lowp vec4 u_xlat10_0;
					vec4 u_xlat1;
					lowp vec3 u_xlat10_1;
					bool u_xlatb2;
					void main()
					{
					    u_xlat10_0 = texture(_MainTex, vs_TEXCOORD0.xy);
					    u_xlat0 = u_xlat10_0;
					#ifdef UNITY_ADRENO_ES3
					    u_xlat0 = min(max(u_xlat0, 0.0), 1.0);
					#else
					    u_xlat0 = clamp(u_xlat0, 0.0, 1.0);
					#endif
					    u_xlat1.xyz = u_xlat0.xyz * _Params.xxx + _Params.yyy;
					    u_xlat10_1.xyz = texture(_LookupTex3D, u_xlat1.xyz).xyz;
					    u_xlat1.xyz = (-u_xlat0.xyz) + u_xlat10_1.xyz;
					    u_xlat1.w = 0.0;
					    u_xlat1 = _Params.zzzz * u_xlat1 + u_xlat0;
					#ifdef UNITY_ADRENO_ES3
					    u_xlatb2 = !!(0.5<vs_TEXCOORD0.y);
					#else
					    u_xlatb2 = 0.5<vs_TEXCOORD0.y;
					#endif
					    SV_Target0 = (bool(u_xlatb2)) ? u_xlat1 : u_xlat0;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles3 hw_tier02 " {
					"!!GLES3
					#ifdef VERTEX
					#version 300 es
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					in highp vec4 in_POSITION0;
					in mediump vec2 in_TEXCOORD0;
					out mediump vec2 vs_TEXCOORD0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					void main()
					{
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy;
					    return;
					}
					
					#endif
					#ifdef FRAGMENT
					#version 300 es
					
					precision highp int;
					uniform 	vec4 _Params;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler3D _LookupTex3D;
					in mediump vec2 vs_TEXCOORD0;
					layout(location = 0) out highp vec4 SV_Target0;
					vec4 u_xlat0;
					lowp vec4 u_xlat10_0;
					vec4 u_xlat1;
					lowp vec3 u_xlat10_1;
					bool u_xlatb2;
					void main()
					{
					    u_xlat10_0 = texture(_MainTex, vs_TEXCOORD0.xy);
					    u_xlat0 = u_xlat10_0;
					#ifdef UNITY_ADRENO_ES3
					    u_xlat0 = min(max(u_xlat0, 0.0), 1.0);
					#else
					    u_xlat0 = clamp(u_xlat0, 0.0, 1.0);
					#endif
					    u_xlat1.xyz = u_xlat0.xyz * _Params.xxx + _Params.yyy;
					    u_xlat10_1.xyz = texture(_LookupTex3D, u_xlat1.xyz).xyz;
					    u_xlat1.xyz = (-u_xlat0.xyz) + u_xlat10_1.xyz;
					    u_xlat1.w = 0.0;
					    u_xlat1 = _Params.zzzz * u_xlat1 + u_xlat0;
					#ifdef UNITY_ADRENO_ES3
					    u_xlatb2 = !!(0.5<vs_TEXCOORD0.y);
					#else
					    u_xlatb2 = 0.5<vs_TEXCOORD0.y;
					#endif
					    SV_Target0 = (bool(u_xlatb2)) ? u_xlat1 : u_xlat0;
					    return;
					}
					
					#endif"
				}
			}
			Program "fp" {
				SubProgram "gles hw_tier00 " {
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					"!!GLES"
				}
				SubProgram "gles3 hw_tier00 " {
					"!!GLES3"
				}
				SubProgram "gles3 hw_tier01 " {
					"!!GLES3"
				}
				SubProgram "gles3 hw_tier02 " {
					"!!GLES3"
				}
			}
		}
		Pass {
			ZTest Always
			ZWrite Off
			Cull Off
			Fog {
				Mode Off
			}
			GpuProgramID 335609
			Program "vp" {
				SubProgram "gles hw_tier00 " {
					"!!GLES
					#version 100
					
					#ifdef VERTEX
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 30
					#endif
					#ifndef SHADER_REQUIRE_INTERPOLATORS10
					    #define SHADER_REQUIRE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_REQUIRE_SAMPLELOD
					    #define SHADER_REQUIRE_SAMPLELOD 1
					#endif
					#ifndef SHADER_REQUIRE_FRAGCOORD
					    #define SHADER_REQUIRE_FRAGCOORD 1
					#endif
					#ifndef UNITY_NO_DXT5nm
					    #define UNITY_NO_DXT5nm 1
					#endif
					#ifndef UNITY_NO_RGBM
					    #define UNITY_NO_RGBM 1
					#endif
					#ifndef UNITY_ENABLE_REFLECTION_BUFFERS
					    #define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#endif
					#ifndef UNITY_FRAMEBUFFER_FETCH_AVAILABLE
					    #define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#endif
					#ifndef UNITY_NO_CUBEMAP_ARRAY
					    #define UNITY_NO_CUBEMAP_ARRAY 1
					#endif
					#ifndef UNITY_NO_SCREENSPACE_SHADOWS
					    #define UNITY_NO_SCREENSPACE_SHADOWS 1
					#endif
					#ifndef UNITY_PBS_USE_BRDF3
					    #define UNITY_PBS_USE_BRDF3 1
					#endif
					#ifndef UNITY_NO_FULL_STANDARD_SHADER
					    #define UNITY_NO_FULL_STANDARD_SHADER 1
					#endif
					#ifndef SHADER_API_MOBILE
					    #define SHADER_API_MOBILE 1
					#endif
					#ifndef UNITY_HARDWARE_TIER1
					    #define UNITY_HARDWARE_TIER1 1
					#endif
					#ifndef UNITY_COLORSPACE_GAMMA
					    #define UNITY_COLORSPACE_GAMMA 1
					#endif
					#ifndef UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS
					    #define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#endif
					#ifndef UNITY_LIGHTMAP_DLDR_ENCODING
					    #define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#endif
					#ifndef UNITY_VERSION
					    #define UNITY_VERSION 201834
					#endif
					#ifndef SHADER_STAGE_VERTEX
					    #define SHADER_STAGE_VERTEX 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 30
					#endif
					#ifndef SHADER_AVAILABLE_INTERPOLATORS10
					    #define SHADER_AVAILABLE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_SAMPLELOD
					    #define SHADER_AVAILABLE_SAMPLELOD 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#define gl_Vertex _glesVertex
					attribute vec4 _glesVertex;
					#define gl_MultiTexCoord0 _glesMultiTexCoord0
					attribute vec4 _glesMultiTexCoord0;
					mat2 xll_transpose_mf2x2(mat2 m) {
					  return mat2( m[0][0], m[1][0], m[0][1], m[1][1]);
					}
					mat3 xll_transpose_mf3x3(mat3 m) {
					  return mat3( m[0][0], m[1][0], m[2][0],
					               m[0][1], m[1][1], m[2][1],
					               m[0][2], m[1][2], m[2][2]);
					}
					mat4 xll_transpose_mf4x4(mat4 m) {
					  return mat4( m[0][0], m[1][0], m[2][0], m[3][0],
					               m[0][1], m[1][1], m[2][1], m[3][1],
					               m[0][2], m[1][2], m[2][2], m[3][2],
					               m[0][3], m[1][3], m[2][3], m[3][3]);
					}
					#line 447
					struct v2f_vertex_lit {
					    highp vec2 uv;
					    lowp vec4 diff;
					    lowp vec4 spec;
					};
					#line 756
					struct v2f_img {
					    highp vec4 pos;
					    mediump vec2 uv;
					};
					#line 749
					struct appdata_img {
					    highp vec4 vertex;
					    mediump vec2 texcoord;
					};
					#line 40
					uniform highp vec4 _Time;
					uniform highp vec4 _SinTime;
					uniform highp vec4 _CosTime;
					uniform highp vec4 unity_DeltaTime;
					#line 46
					uniform highp vec3 _WorldSpaceCameraPos;
					#line 53
					uniform highp vec4 _ProjectionParams;
					#line 59
					uniform highp vec4 _ScreenParams;
					#line 71
					uniform highp vec4 _ZBufferParams;
					#line 77
					uniform highp vec4 unity_OrthoParams;
					#line 86
					uniform highp vec4 unity_CameraWorldClipPlanes[6];
					#line 92
					uniform highp mat4 unity_CameraProjection;
					uniform highp mat4 unity_CameraInvProjection;
					uniform highp mat4 unity_WorldToCamera;
					uniform highp mat4 unity_CameraToWorld;
					#line 108
					uniform highp vec4 _WorldSpaceLightPos0;
					uniform highp vec4 _LightPositionRange;
					#line 112
					uniform highp vec4 _LightProjectionParams;
					uniform highp vec4 unity_4LightPosX0;
					uniform highp vec4 unity_4LightPosY0;
					#line 116
					uniform highp vec4 unity_4LightPosZ0;
					uniform mediump vec4 unity_4LightAtten0;
					uniform mediump vec4 unity_LightColor[8];
					#line 122
					uniform highp vec4 unity_LightPosition[8];
					#line 127
					uniform mediump vec4 unity_LightAtten[8];
					uniform highp vec4 unity_SpotDirection[8];
					#line 131
					uniform mediump vec4 unity_SHAr;
					uniform mediump vec4 unity_SHAg;
					uniform mediump vec4 unity_SHAb;
					uniform mediump vec4 unity_SHBr;
					#line 135
					uniform mediump vec4 unity_SHBg;
					uniform mediump vec4 unity_SHBb;
					uniform mediump vec4 unity_SHC;
					#line 140
					uniform lowp vec4 unity_OcclusionMaskSelector;
					uniform lowp vec4 unity_ProbesOcclusion;
					#line 145
					uniform mediump vec3 unity_LightColor0;
					uniform mediump vec3 unity_LightColor1;
					uniform mediump vec3 unity_LightColor2;
					uniform mediump vec3 unity_LightColor3;
					#line 152
					uniform highp vec4 unity_ShadowSplitSpheres[4];
					uniform highp vec4 unity_ShadowSplitSqRadii;
					uniform highp vec4 unity_LightShadowBias;
					uniform highp vec4 _LightSplitsNear;
					#line 156
					uniform highp vec4 _LightSplitsFar;
					uniform highp mat4 unity_WorldToShadow[4];
					uniform mediump vec4 _LightShadowData;
					uniform highp vec4 unity_ShadowFadeCenterAndType;
					#line 165
					uniform highp mat4 unity_ObjectToWorld;
					uniform highp mat4 unity_WorldToObject;
					uniform highp vec4 unity_LODFade;
					uniform highp vec4 unity_WorldTransformParams;
					#line 206
					uniform highp mat4 glstate_matrix_transpose_modelview0;
					#line 214
					uniform lowp vec4 glstate_lightmodel_ambient;
					uniform lowp vec4 unity_AmbientSky;
					uniform lowp vec4 unity_AmbientEquator;
					uniform lowp vec4 unity_AmbientGround;
					#line 218
					uniform lowp vec4 unity_IndirectSpecColor;
					uniform highp mat4 glstate_matrix_projection;
					#line 222
					uniform highp mat4 unity_MatrixV;
					uniform highp mat4 unity_MatrixInvV;
					uniform highp mat4 unity_MatrixVP;
					uniform highp int unity_StereoEyeIndex;
					#line 228
					uniform lowp vec4 unity_ShadowColor;
					#line 235
					uniform lowp vec4 unity_FogColor;
					#line 240
					uniform highp vec4 unity_FogParams;
					#line 248
					uniform mediump sampler2D unity_Lightmap;
					uniform mediump sampler2D unity_LightmapInd;
					#line 252
					uniform sampler2D unity_ShadowMask;
					uniform sampler2D unity_DynamicLightmap;
					#line 256
					uniform sampler2D unity_DynamicDirectionality;
					uniform sampler2D unity_DynamicNormal;
					#line 260
					uniform highp vec4 unity_LightmapST;
					uniform highp vec4 unity_DynamicLightmapST;
					#line 268
					uniform samplerCube unity_SpecCube0;
					uniform samplerCube unity_SpecCube1;
					#line 272
					uniform highp vec4 unity_SpecCube0_BoxMax;
					uniform highp vec4 unity_SpecCube0_BoxMin;
					uniform highp vec4 unity_SpecCube0_ProbePosition;
					uniform mediump vec4 unity_SpecCube0_HDR;
					#line 277
					uniform highp vec4 unity_SpecCube1_BoxMax;
					uniform highp vec4 unity_SpecCube1_BoxMin;
					uniform highp vec4 unity_SpecCube1_ProbePosition;
					uniform mediump vec4 unity_SpecCube1_HDR;
					#line 317
					highp mat4 unity_MatrixMVP;
					highp mat4 unity_MatrixMV;
					highp mat4 unity_MatrixTMV;
					highp mat4 unity_MatrixITMV;
					#line 8
					#line 30
					#line 44
					#line 84
					#line 93
					#line 103
					#line 112
					#line 124
					#line 135
					#line 141
					#line 147
					#line 151
					#line 157
					#line 163
					#line 169
					#line 175
					#line 186
					#line 201
					#line 208
					#line 223
					#line 230
					#line 237
					#line 255
					#line 291
					#line 320
					#line 326
					#line 339
					#line 357
					#line 373
					#line 427
					#line 453
					#line 464
					#line 473
					#line 480
					#line 485
					#line 502
					#line 522
					#line 537
					#line 543
					#line 554
					uniform mediump vec4 unity_Lightmap_HDR;
					uniform mediump vec4 unity_DynamicLightmap_HDR;
					#line 568
					#line 578
					#line 593
					#line 602
					#line 609
					#line 618
					#line 626
					#line 635
					#line 654
					#line 660
					#line 670
					#line 680
					#line 691
					#line 696
					#line 702
					#line 707
					#line 764
					#line 770
					#line 785
					#line 816
					#line 830
					#line 834
					#line 840
					#line 849
					#line 859
					#line 885
					#line 891
					#line 7
					uniform sampler2D _MainTex;
					uniform lowp sampler3D _LookupTex3D;
					uniform sampler2D _LookupTex2D;
					uniform highp vec4 _Params;
					#line 17
					#line 23
					#line 29
					#line 35
					#line 41
					#line 47
					#line 67
					#line 91
					#line 97
					#line 44
					highp vec4 UnityObjectToClipPos( in highp vec3 pos ) {
					    #line 50
					    return (unity_MatrixVP * (unity_ObjectToWorld * vec4( pos, 1.0)));
					}
					#line 53
					highp vec4 UnityObjectToClipPos( in highp vec4 pos ) {
					    #line 55
					    return UnityObjectToClipPos( pos.xyz);
					}
					#line 770
					v2f_img vert_img( in appdata_img v ) {
					    v2f_img o;
					    #line 777
					    o.pos = UnityObjectToClipPos( v.vertex);
					    o.uv = v.texcoord;
					    return o;
					}
					varying mediump vec2 xlv_TEXCOORD0;
					void main() {
					unity_MatrixMVP = (unity_MatrixVP * unity_ObjectToWorld);
					unity_MatrixMV = (unity_MatrixV * unity_ObjectToWorld);
					unity_MatrixTMV = xll_transpose_mf4x4(unity_MatrixMV);
					unity_MatrixITMV = xll_transpose_mf4x4((unity_WorldToObject * unity_MatrixInvV));
					    v2f_img xl_retval;
					    appdata_img xlt_v;
					    xlt_v.vertex = vec4(gl_Vertex);
					    xlt_v.texcoord = vec2(gl_MultiTexCoord0);
					    xl_retval = vert_img( xlt_v);
					    gl_Position = vec4(xl_retval.pos);
					    xlv_TEXCOORD0 = vec2(xl_retval.uv);
					}
					/* HLSL2GLSL - NOTE: GLSL optimization failed
					(9,1): error: invalid type `sampler3D' in declaration of `_LookupTex3D'
					*/
					
					#endif
					#ifdef FRAGMENT
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 30
					#endif
					#ifndef SHADER_REQUIRE_INTERPOLATORS10
					    #define SHADER_REQUIRE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_REQUIRE_SAMPLELOD
					    #define SHADER_REQUIRE_SAMPLELOD 1
					#endif
					#ifndef SHADER_REQUIRE_FRAGCOORD
					    #define SHADER_REQUIRE_FRAGCOORD 1
					#endif
					#ifndef UNITY_NO_DXT5nm
					    #define UNITY_NO_DXT5nm 1
					#endif
					#ifndef UNITY_NO_RGBM
					    #define UNITY_NO_RGBM 1
					#endif
					#ifndef UNITY_ENABLE_REFLECTION_BUFFERS
					    #define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#endif
					#ifndef UNITY_FRAMEBUFFER_FETCH_AVAILABLE
					    #define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#endif
					#ifndef UNITY_NO_CUBEMAP_ARRAY
					    #define UNITY_NO_CUBEMAP_ARRAY 1
					#endif
					#ifndef UNITY_NO_SCREENSPACE_SHADOWS
					    #define UNITY_NO_SCREENSPACE_SHADOWS 1
					#endif
					#ifndef UNITY_PBS_USE_BRDF3
					    #define UNITY_PBS_USE_BRDF3 1
					#endif
					#ifndef UNITY_NO_FULL_STANDARD_SHADER
					    #define UNITY_NO_FULL_STANDARD_SHADER 1
					#endif
					#ifndef SHADER_API_MOBILE
					    #define SHADER_API_MOBILE 1
					#endif
					#ifndef UNITY_HARDWARE_TIER1
					    #define UNITY_HARDWARE_TIER1 1
					#endif
					#ifndef UNITY_COLORSPACE_GAMMA
					    #define UNITY_COLORSPACE_GAMMA 1
					#endif
					#ifndef UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS
					    #define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#endif
					#ifndef UNITY_LIGHTMAP_DLDR_ENCODING
					    #define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#endif
					#ifndef UNITY_VERSION
					    #define UNITY_VERSION 201834
					#endif
					#ifndef SHADER_STAGE_VERTEX
					    #define SHADER_STAGE_VERTEX 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 30
					#endif
					#ifndef SHADER_AVAILABLE_INTERPOLATORS10
					    #define SHADER_AVAILABLE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_SAMPLELOD
					    #define SHADER_AVAILABLE_SAMPLELOD 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					mat2 xll_transpose_mf2x2(mat2 m) {
					  return mat2( m[0][0], m[1][0], m[0][1], m[1][1]);
					}
					mat3 xll_transpose_mf3x3(mat3 m) {
					  return mat3( m[0][0], m[1][0], m[2][0],
					               m[0][1], m[1][1], m[2][1],
					               m[0][2], m[1][2], m[2][2]);
					}
					mat4 xll_transpose_mf4x4(mat4 m) {
					  return mat4( m[0][0], m[1][0], m[2][0], m[3][0],
					               m[0][1], m[1][1], m[2][1], m[3][1],
					               m[0][2], m[1][2], m[2][2], m[3][2],
					               m[0][3], m[1][3], m[2][3], m[3][3]);
					}
					float xll_saturate_f( float x) {
					  return clamp( x, 0.0, 1.0);
					}
					vec2 xll_saturate_vf2( vec2 x) {
					  return clamp( x, 0.0, 1.0);
					}
					vec3 xll_saturate_vf3( vec3 x) {
					  return clamp( x, 0.0, 1.0);
					}
					vec4 xll_saturate_vf4( vec4 x) {
					  return clamp( x, 0.0, 1.0);
					}
					mat2 xll_saturate_mf2x2(mat2 m) {
					  return mat2( clamp(m[0], 0.0, 1.0), clamp(m[1], 0.0, 1.0));
					}
					mat3 xll_saturate_mf3x3(mat3 m) {
					  return mat3( clamp(m[0], 0.0, 1.0), clamp(m[1], 0.0, 1.0), clamp(m[2], 0.0, 1.0));
					}
					mat4 xll_saturate_mf4x4(mat4 m) {
					  return mat4( clamp(m[0], 0.0, 1.0), clamp(m[1], 0.0, 1.0), clamp(m[2], 0.0, 1.0), clamp(m[3], 0.0, 1.0));
					}
					vec2 xll_vecTSel_vb2_vf2_vf2 (bvec2 a, vec2 b, vec2 c) {
					  return vec2 (a.x ? b.x : c.x, a.y ? b.y : c.y);
					}
					vec3 xll_vecTSel_vb3_vf3_vf3 (bvec3 a, vec3 b, vec3 c) {
					  return vec3 (a.x ? b.x : c.x, a.y ? b.y : c.y, a.z ? b.z : c.z);
					}
					vec4 xll_vecTSel_vb4_vf4_vf4 (bvec4 a, vec4 b, vec4 c) {
					  return vec4 (a.x ? b.x : c.x, a.y ? b.y : c.y, a.z ? b.z : c.z, a.w ? b.w : c.w);
					}
					#line 447
					struct v2f_vertex_lit {
					    highp vec2 uv;
					    lowp vec4 diff;
					    lowp vec4 spec;
					};
					#line 756
					struct v2f_img {
					    highp vec4 pos;
					    mediump vec2 uv;
					};
					#line 749
					struct appdata_img {
					    highp vec4 vertex;
					    mediump vec2 texcoord;
					};
					#line 40
					uniform highp vec4 _Time;
					uniform highp vec4 _SinTime;
					uniform highp vec4 _CosTime;
					uniform highp vec4 unity_DeltaTime;
					#line 46
					uniform highp vec3 _WorldSpaceCameraPos;
					#line 53
					uniform highp vec4 _ProjectionParams;
					#line 59
					uniform highp vec4 _ScreenParams;
					#line 71
					uniform highp vec4 _ZBufferParams;
					#line 77
					uniform highp vec4 unity_OrthoParams;
					#line 86
					uniform highp vec4 unity_CameraWorldClipPlanes[6];
					#line 92
					uniform highp mat4 unity_CameraProjection;
					uniform highp mat4 unity_CameraInvProjection;
					uniform highp mat4 unity_WorldToCamera;
					uniform highp mat4 unity_CameraToWorld;
					#line 108
					uniform highp vec4 _WorldSpaceLightPos0;
					uniform highp vec4 _LightPositionRange;
					#line 112
					uniform highp vec4 _LightProjectionParams;
					uniform highp vec4 unity_4LightPosX0;
					uniform highp vec4 unity_4LightPosY0;
					#line 116
					uniform highp vec4 unity_4LightPosZ0;
					uniform mediump vec4 unity_4LightAtten0;
					uniform mediump vec4 unity_LightColor[8];
					#line 122
					uniform highp vec4 unity_LightPosition[8];
					#line 127
					uniform mediump vec4 unity_LightAtten[8];
					uniform highp vec4 unity_SpotDirection[8];
					#line 131
					uniform mediump vec4 unity_SHAr;
					uniform mediump vec4 unity_SHAg;
					uniform mediump vec4 unity_SHAb;
					uniform mediump vec4 unity_SHBr;
					#line 135
					uniform mediump vec4 unity_SHBg;
					uniform mediump vec4 unity_SHBb;
					uniform mediump vec4 unity_SHC;
					#line 140
					uniform lowp vec4 unity_OcclusionMaskSelector;
					uniform lowp vec4 unity_ProbesOcclusion;
					#line 145
					uniform mediump vec3 unity_LightColor0;
					uniform mediump vec3 unity_LightColor1;
					uniform mediump vec3 unity_LightColor2;
					uniform mediump vec3 unity_LightColor3;
					#line 152
					uniform highp vec4 unity_ShadowSplitSpheres[4];
					uniform highp vec4 unity_ShadowSplitSqRadii;
					uniform highp vec4 unity_LightShadowBias;
					uniform highp vec4 _LightSplitsNear;
					#line 156
					uniform highp vec4 _LightSplitsFar;
					uniform highp mat4 unity_WorldToShadow[4];
					uniform mediump vec4 _LightShadowData;
					uniform highp vec4 unity_ShadowFadeCenterAndType;
					#line 165
					uniform highp mat4 unity_ObjectToWorld;
					uniform highp mat4 unity_WorldToObject;
					uniform highp vec4 unity_LODFade;
					uniform highp vec4 unity_WorldTransformParams;
					#line 206
					uniform highp mat4 glstate_matrix_transpose_modelview0;
					#line 214
					uniform lowp vec4 glstate_lightmodel_ambient;
					uniform lowp vec4 unity_AmbientSky;
					uniform lowp vec4 unity_AmbientEquator;
					uniform lowp vec4 unity_AmbientGround;
					#line 218
					uniform lowp vec4 unity_IndirectSpecColor;
					uniform highp mat4 glstate_matrix_projection;
					#line 222
					uniform highp mat4 unity_MatrixV;
					uniform highp mat4 unity_MatrixInvV;
					uniform highp mat4 unity_MatrixVP;
					uniform highp int unity_StereoEyeIndex;
					#line 228
					uniform lowp vec4 unity_ShadowColor;
					#line 235
					uniform lowp vec4 unity_FogColor;
					#line 240
					uniform highp vec4 unity_FogParams;
					#line 248
					uniform mediump sampler2D unity_Lightmap;
					uniform mediump sampler2D unity_LightmapInd;
					#line 252
					uniform sampler2D unity_ShadowMask;
					uniform sampler2D unity_DynamicLightmap;
					#line 256
					uniform sampler2D unity_DynamicDirectionality;
					uniform sampler2D unity_DynamicNormal;
					#line 260
					uniform highp vec4 unity_LightmapST;
					uniform highp vec4 unity_DynamicLightmapST;
					#line 268
					uniform samplerCube unity_SpecCube0;
					uniform samplerCube unity_SpecCube1;
					#line 272
					uniform highp vec4 unity_SpecCube0_BoxMax;
					uniform highp vec4 unity_SpecCube0_BoxMin;
					uniform highp vec4 unity_SpecCube0_ProbePosition;
					uniform mediump vec4 unity_SpecCube0_HDR;
					#line 277
					uniform highp vec4 unity_SpecCube1_BoxMax;
					uniform highp vec4 unity_SpecCube1_BoxMin;
					uniform highp vec4 unity_SpecCube1_ProbePosition;
					uniform mediump vec4 unity_SpecCube1_HDR;
					#line 317
					highp mat4 unity_MatrixMVP;
					highp mat4 unity_MatrixMV;
					highp mat4 unity_MatrixTMV;
					highp mat4 unity_MatrixITMV;
					#line 8
					#line 30
					#line 44
					#line 84
					#line 93
					#line 103
					#line 112
					#line 124
					#line 135
					#line 141
					#line 147
					#line 151
					#line 157
					#line 163
					#line 169
					#line 175
					#line 186
					#line 201
					#line 208
					#line 223
					#line 230
					#line 237
					#line 255
					#line 291
					#line 320
					#line 326
					#line 339
					#line 357
					#line 373
					#line 427
					#line 453
					#line 464
					#line 473
					#line 480
					#line 485
					#line 502
					#line 522
					#line 537
					#line 543
					#line 554
					uniform mediump vec4 unity_Lightmap_HDR;
					uniform mediump vec4 unity_DynamicLightmap_HDR;
					#line 568
					#line 578
					#line 593
					#line 602
					#line 609
					#line 618
					#line 626
					#line 635
					#line 654
					#line 660
					#line 670
					#line 680
					#line 691
					#line 696
					#line 702
					#line 707
					#line 764
					#line 770
					#line 785
					#line 816
					#line 830
					#line 834
					#line 840
					#line 849
					#line 859
					#line 885
					#line 891
					#line 7
					uniform sampler2D _MainTex;
					uniform lowp sampler3D _LookupTex3D;
					uniform sampler2D _LookupTex2D;
					uniform highp vec4 _Params;
					#line 17
					#line 23
					#line 29
					#line 35
					#line 41
					#line 47
					#line 67
					#line 91
					#line 97
					#line 29
					highp vec4 Linear( in highp vec4 color ) {
					    color.xyz = xll_vecTSel_vb3_vf3_vf3 (lessThanEqual( color.xyz, vec3( 0.0404482, 0.0404482, 0.0404482)), (color.xyz / 12.92321), pow( ((color.xyz + 0.055) * 0.9478672), vec3( 2.4)));
					    return color;
					}
					#line 17
					highp vec3 sRGB( in highp vec3 color ) {
					    color = xll_vecTSel_vb3_vf3_vf3 (lessThanEqual( color, vec3( 0.0031308, 0.0031308, 0.0031308)), (color * 12.92321), ((1.055 * pow( color, vec3( 0.41666))) - 0.055));
					    return color;
					}
					#line 41
					highp vec4 lookup_linear( in highp vec4 o ) {
					    o.xyz = texture3D( _LookupTex3D, ((sRGB( o.xyz) * _Params.x) + _Params.y)).xyz;
					    return Linear( o);
					}
					#line 47
					highp vec4 frag( in v2f_img i ) {
					    highp vec4 color = xll_saturate_vf4(texture2D( _MainTex, i.uv));
					    highp vec4 x;
					    #line 53
					    x = lookup_linear( color);
					    #line 61
					    return (( (i.uv.y > 0.5) ) ? ( mix( color, x, vec4( _Params.z)) ) : ( color ));
					}
					varying mediump vec2 xlv_TEXCOORD0;
					void main() {
					unity_MatrixMVP = (unity_MatrixVP * unity_ObjectToWorld);
					unity_MatrixMV = (unity_MatrixV * unity_ObjectToWorld);
					unity_MatrixTMV = xll_transpose_mf4x4(unity_MatrixMV);
					unity_MatrixITMV = xll_transpose_mf4x4((unity_WorldToObject * unity_MatrixInvV));
					    highp vec4 xl_retval;
					    v2f_img xlt_i;
					    xlt_i.pos = vec4(0.0);
					    xlt_i.uv = vec2(xlv_TEXCOORD0);
					    xl_retval = frag( xlt_i);
					    gl_FragData[0] = vec4(xl_retval);
					}
					/* HLSL2GLSL - NOTE: GLSL optimization failed
					(9,1): error: invalid type `sampler3D' in declaration of `_LookupTex3D'
					(43,21): error: `_LookupTex3D' undeclared
					(43,10): error: no matching function for call to `texture3D(error, vec3)'; candidates are:
					(43,10): error: type mismatch
					*/
					
					#endif"
				}
				SubProgram "gles hw_tier01 " {
					"!!GLES
					#version 100
					
					#ifdef VERTEX
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 30
					#endif
					#ifndef SHADER_REQUIRE_INTERPOLATORS10
					    #define SHADER_REQUIRE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_REQUIRE_SAMPLELOD
					    #define SHADER_REQUIRE_SAMPLELOD 1
					#endif
					#ifndef SHADER_REQUIRE_FRAGCOORD
					    #define SHADER_REQUIRE_FRAGCOORD 1
					#endif
					#ifndef UNITY_NO_DXT5nm
					    #define UNITY_NO_DXT5nm 1
					#endif
					#ifndef UNITY_NO_RGBM
					    #define UNITY_NO_RGBM 1
					#endif
					#ifndef UNITY_ENABLE_REFLECTION_BUFFERS
					    #define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#endif
					#ifndef UNITY_FRAMEBUFFER_FETCH_AVAILABLE
					    #define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#endif
					#ifndef UNITY_NO_CUBEMAP_ARRAY
					    #define UNITY_NO_CUBEMAP_ARRAY 1
					#endif
					#ifndef UNITY_NO_SCREENSPACE_SHADOWS
					    #define UNITY_NO_SCREENSPACE_SHADOWS 1
					#endif
					#ifndef UNITY_PBS_USE_BRDF2
					    #define UNITY_PBS_USE_BRDF2 1
					#endif
					#ifndef SHADER_API_MOBILE
					    #define SHADER_API_MOBILE 1
					#endif
					#ifndef UNITY_HARDWARE_TIER2
					    #define UNITY_HARDWARE_TIER2 1
					#endif
					#ifndef UNITY_COLORSPACE_GAMMA
					    #define UNITY_COLORSPACE_GAMMA 1
					#endif
					#ifndef UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS
					    #define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#endif
					#ifndef UNITY_LIGHTMAP_DLDR_ENCODING
					    #define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#endif
					#ifndef UNITY_VERSION
					    #define UNITY_VERSION 201834
					#endif
					#ifndef SHADER_STAGE_VERTEX
					    #define SHADER_STAGE_VERTEX 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 30
					#endif
					#ifndef SHADER_AVAILABLE_INTERPOLATORS10
					    #define SHADER_AVAILABLE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_SAMPLELOD
					    #define SHADER_AVAILABLE_SAMPLELOD 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#define gl_Vertex _glesVertex
					attribute vec4 _glesVertex;
					#define gl_MultiTexCoord0 _glesMultiTexCoord0
					attribute vec4 _glesMultiTexCoord0;
					mat2 xll_transpose_mf2x2(mat2 m) {
					  return mat2( m[0][0], m[1][0], m[0][1], m[1][1]);
					}
					mat3 xll_transpose_mf3x3(mat3 m) {
					  return mat3( m[0][0], m[1][0], m[2][0],
					               m[0][1], m[1][1], m[2][1],
					               m[0][2], m[1][2], m[2][2]);
					}
					mat4 xll_transpose_mf4x4(mat4 m) {
					  return mat4( m[0][0], m[1][0], m[2][0], m[3][0],
					               m[0][1], m[1][1], m[2][1], m[3][1],
					               m[0][2], m[1][2], m[2][2], m[3][2],
					               m[0][3], m[1][3], m[2][3], m[3][3]);
					}
					#line 447
					struct v2f_vertex_lit {
					    highp vec2 uv;
					    lowp vec4 diff;
					    lowp vec4 spec;
					};
					#line 756
					struct v2f_img {
					    highp vec4 pos;
					    mediump vec2 uv;
					};
					#line 749
					struct appdata_img {
					    highp vec4 vertex;
					    mediump vec2 texcoord;
					};
					#line 40
					uniform highp vec4 _Time;
					uniform highp vec4 _SinTime;
					uniform highp vec4 _CosTime;
					uniform highp vec4 unity_DeltaTime;
					#line 46
					uniform highp vec3 _WorldSpaceCameraPos;
					#line 53
					uniform highp vec4 _ProjectionParams;
					#line 59
					uniform highp vec4 _ScreenParams;
					#line 71
					uniform highp vec4 _ZBufferParams;
					#line 77
					uniform highp vec4 unity_OrthoParams;
					#line 86
					uniform highp vec4 unity_CameraWorldClipPlanes[6];
					#line 92
					uniform highp mat4 unity_CameraProjection;
					uniform highp mat4 unity_CameraInvProjection;
					uniform highp mat4 unity_WorldToCamera;
					uniform highp mat4 unity_CameraToWorld;
					#line 108
					uniform highp vec4 _WorldSpaceLightPos0;
					uniform highp vec4 _LightPositionRange;
					#line 112
					uniform highp vec4 _LightProjectionParams;
					uniform highp vec4 unity_4LightPosX0;
					uniform highp vec4 unity_4LightPosY0;
					#line 116
					uniform highp vec4 unity_4LightPosZ0;
					uniform mediump vec4 unity_4LightAtten0;
					uniform mediump vec4 unity_LightColor[8];
					#line 122
					uniform highp vec4 unity_LightPosition[8];
					#line 127
					uniform mediump vec4 unity_LightAtten[8];
					uniform highp vec4 unity_SpotDirection[8];
					#line 131
					uniform mediump vec4 unity_SHAr;
					uniform mediump vec4 unity_SHAg;
					uniform mediump vec4 unity_SHAb;
					uniform mediump vec4 unity_SHBr;
					#line 135
					uniform mediump vec4 unity_SHBg;
					uniform mediump vec4 unity_SHBb;
					uniform mediump vec4 unity_SHC;
					#line 140
					uniform lowp vec4 unity_OcclusionMaskSelector;
					uniform lowp vec4 unity_ProbesOcclusion;
					#line 145
					uniform mediump vec3 unity_LightColor0;
					uniform mediump vec3 unity_LightColor1;
					uniform mediump vec3 unity_LightColor2;
					uniform mediump vec3 unity_LightColor3;
					#line 152
					uniform highp vec4 unity_ShadowSplitSpheres[4];
					uniform highp vec4 unity_ShadowSplitSqRadii;
					uniform highp vec4 unity_LightShadowBias;
					uniform highp vec4 _LightSplitsNear;
					#line 156
					uniform highp vec4 _LightSplitsFar;
					uniform highp mat4 unity_WorldToShadow[4];
					uniform mediump vec4 _LightShadowData;
					uniform highp vec4 unity_ShadowFadeCenterAndType;
					#line 165
					uniform highp mat4 unity_ObjectToWorld;
					uniform highp mat4 unity_WorldToObject;
					uniform highp vec4 unity_LODFade;
					uniform highp vec4 unity_WorldTransformParams;
					#line 206
					uniform highp mat4 glstate_matrix_transpose_modelview0;
					#line 214
					uniform lowp vec4 glstate_lightmodel_ambient;
					uniform lowp vec4 unity_AmbientSky;
					uniform lowp vec4 unity_AmbientEquator;
					uniform lowp vec4 unity_AmbientGround;
					#line 218
					uniform lowp vec4 unity_IndirectSpecColor;
					uniform highp mat4 glstate_matrix_projection;
					#line 222
					uniform highp mat4 unity_MatrixV;
					uniform highp mat4 unity_MatrixInvV;
					uniform highp mat4 unity_MatrixVP;
					uniform highp int unity_StereoEyeIndex;
					#line 228
					uniform lowp vec4 unity_ShadowColor;
					#line 235
					uniform lowp vec4 unity_FogColor;
					#line 240
					uniform highp vec4 unity_FogParams;
					#line 248
					uniform mediump sampler2D unity_Lightmap;
					uniform mediump sampler2D unity_LightmapInd;
					#line 252
					uniform sampler2D unity_ShadowMask;
					uniform sampler2D unity_DynamicLightmap;
					#line 256
					uniform sampler2D unity_DynamicDirectionality;
					uniform sampler2D unity_DynamicNormal;
					#line 260
					uniform highp vec4 unity_LightmapST;
					uniform highp vec4 unity_DynamicLightmapST;
					#line 268
					uniform samplerCube unity_SpecCube0;
					uniform samplerCube unity_SpecCube1;
					#line 272
					uniform highp vec4 unity_SpecCube0_BoxMax;
					uniform highp vec4 unity_SpecCube0_BoxMin;
					uniform highp vec4 unity_SpecCube0_ProbePosition;
					uniform mediump vec4 unity_SpecCube0_HDR;
					#line 277
					uniform highp vec4 unity_SpecCube1_BoxMax;
					uniform highp vec4 unity_SpecCube1_BoxMin;
					uniform highp vec4 unity_SpecCube1_ProbePosition;
					uniform mediump vec4 unity_SpecCube1_HDR;
					#line 317
					highp mat4 unity_MatrixMVP;
					highp mat4 unity_MatrixMV;
					highp mat4 unity_MatrixTMV;
					highp mat4 unity_MatrixITMV;
					#line 8
					#line 30
					#line 44
					#line 84
					#line 93
					#line 103
					#line 112
					#line 124
					#line 135
					#line 141
					#line 147
					#line 151
					#line 157
					#line 163
					#line 169
					#line 175
					#line 186
					#line 201
					#line 208
					#line 223
					#line 230
					#line 237
					#line 255
					#line 291
					#line 320
					#line 326
					#line 339
					#line 357
					#line 373
					#line 427
					#line 453
					#line 464
					#line 473
					#line 480
					#line 485
					#line 502
					#line 522
					#line 537
					#line 543
					#line 554
					uniform mediump vec4 unity_Lightmap_HDR;
					uniform mediump vec4 unity_DynamicLightmap_HDR;
					#line 568
					#line 578
					#line 593
					#line 602
					#line 609
					#line 618
					#line 626
					#line 635
					#line 654
					#line 660
					#line 670
					#line 680
					#line 691
					#line 696
					#line 702
					#line 707
					#line 764
					#line 770
					#line 785
					#line 816
					#line 830
					#line 834
					#line 840
					#line 849
					#line 859
					#line 885
					#line 891
					#line 7
					uniform sampler2D _MainTex;
					uniform lowp sampler3D _LookupTex3D;
					uniform sampler2D _LookupTex2D;
					uniform highp vec4 _Params;
					#line 17
					#line 23
					#line 29
					#line 35
					#line 41
					#line 47
					#line 67
					#line 91
					#line 97
					#line 44
					highp vec4 UnityObjectToClipPos( in highp vec3 pos ) {
					    #line 50
					    return (unity_MatrixVP * (unity_ObjectToWorld * vec4( pos, 1.0)));
					}
					#line 53
					highp vec4 UnityObjectToClipPos( in highp vec4 pos ) {
					    #line 55
					    return UnityObjectToClipPos( pos.xyz);
					}
					#line 770
					v2f_img vert_img( in appdata_img v ) {
					    v2f_img o;
					    #line 777
					    o.pos = UnityObjectToClipPos( v.vertex);
					    o.uv = v.texcoord;
					    return o;
					}
					varying mediump vec2 xlv_TEXCOORD0;
					void main() {
					unity_MatrixMVP = (unity_MatrixVP * unity_ObjectToWorld);
					unity_MatrixMV = (unity_MatrixV * unity_ObjectToWorld);
					unity_MatrixTMV = xll_transpose_mf4x4(unity_MatrixMV);
					unity_MatrixITMV = xll_transpose_mf4x4((unity_WorldToObject * unity_MatrixInvV));
					    v2f_img xl_retval;
					    appdata_img xlt_v;
					    xlt_v.vertex = vec4(gl_Vertex);
					    xlt_v.texcoord = vec2(gl_MultiTexCoord0);
					    xl_retval = vert_img( xlt_v);
					    gl_Position = vec4(xl_retval.pos);
					    xlv_TEXCOORD0 = vec2(xl_retval.uv);
					}
					/* HLSL2GLSL - NOTE: GLSL optimization failed
					(9,1): error: invalid type `sampler3D' in declaration of `_LookupTex3D'
					*/
					
					#endif
					#ifdef FRAGMENT
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 30
					#endif
					#ifndef SHADER_REQUIRE_INTERPOLATORS10
					    #define SHADER_REQUIRE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_REQUIRE_SAMPLELOD
					    #define SHADER_REQUIRE_SAMPLELOD 1
					#endif
					#ifndef SHADER_REQUIRE_FRAGCOORD
					    #define SHADER_REQUIRE_FRAGCOORD 1
					#endif
					#ifndef UNITY_NO_DXT5nm
					    #define UNITY_NO_DXT5nm 1
					#endif
					#ifndef UNITY_NO_RGBM
					    #define UNITY_NO_RGBM 1
					#endif
					#ifndef UNITY_ENABLE_REFLECTION_BUFFERS
					    #define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#endif
					#ifndef UNITY_FRAMEBUFFER_FETCH_AVAILABLE
					    #define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#endif
					#ifndef UNITY_NO_CUBEMAP_ARRAY
					    #define UNITY_NO_CUBEMAP_ARRAY 1
					#endif
					#ifndef UNITY_NO_SCREENSPACE_SHADOWS
					    #define UNITY_NO_SCREENSPACE_SHADOWS 1
					#endif
					#ifndef UNITY_PBS_USE_BRDF2
					    #define UNITY_PBS_USE_BRDF2 1
					#endif
					#ifndef SHADER_API_MOBILE
					    #define SHADER_API_MOBILE 1
					#endif
					#ifndef UNITY_HARDWARE_TIER2
					    #define UNITY_HARDWARE_TIER2 1
					#endif
					#ifndef UNITY_COLORSPACE_GAMMA
					    #define UNITY_COLORSPACE_GAMMA 1
					#endif
					#ifndef UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS
					    #define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#endif
					#ifndef UNITY_LIGHTMAP_DLDR_ENCODING
					    #define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#endif
					#ifndef UNITY_VERSION
					    #define UNITY_VERSION 201834
					#endif
					#ifndef SHADER_STAGE_VERTEX
					    #define SHADER_STAGE_VERTEX 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 30
					#endif
					#ifndef SHADER_AVAILABLE_INTERPOLATORS10
					    #define SHADER_AVAILABLE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_SAMPLELOD
					    #define SHADER_AVAILABLE_SAMPLELOD 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					mat2 xll_transpose_mf2x2(mat2 m) {
					  return mat2( m[0][0], m[1][0], m[0][1], m[1][1]);
					}
					mat3 xll_transpose_mf3x3(mat3 m) {
					  return mat3( m[0][0], m[1][0], m[2][0],
					               m[0][1], m[1][1], m[2][1],
					               m[0][2], m[1][2], m[2][2]);
					}
					mat4 xll_transpose_mf4x4(mat4 m) {
					  return mat4( m[0][0], m[1][0], m[2][0], m[3][0],
					               m[0][1], m[1][1], m[2][1], m[3][1],
					               m[0][2], m[1][2], m[2][2], m[3][2],
					               m[0][3], m[1][3], m[2][3], m[3][3]);
					}
					float xll_saturate_f( float x) {
					  return clamp( x, 0.0, 1.0);
					}
					vec2 xll_saturate_vf2( vec2 x) {
					  return clamp( x, 0.0, 1.0);
					}
					vec3 xll_saturate_vf3( vec3 x) {
					  return clamp( x, 0.0, 1.0);
					}
					vec4 xll_saturate_vf4( vec4 x) {
					  return clamp( x, 0.0, 1.0);
					}
					mat2 xll_saturate_mf2x2(mat2 m) {
					  return mat2( clamp(m[0], 0.0, 1.0), clamp(m[1], 0.0, 1.0));
					}
					mat3 xll_saturate_mf3x3(mat3 m) {
					  return mat3( clamp(m[0], 0.0, 1.0), clamp(m[1], 0.0, 1.0), clamp(m[2], 0.0, 1.0));
					}
					mat4 xll_saturate_mf4x4(mat4 m) {
					  return mat4( clamp(m[0], 0.0, 1.0), clamp(m[1], 0.0, 1.0), clamp(m[2], 0.0, 1.0), clamp(m[3], 0.0, 1.0));
					}
					vec2 xll_vecTSel_vb2_vf2_vf2 (bvec2 a, vec2 b, vec2 c) {
					  return vec2 (a.x ? b.x : c.x, a.y ? b.y : c.y);
					}
					vec3 xll_vecTSel_vb3_vf3_vf3 (bvec3 a, vec3 b, vec3 c) {
					  return vec3 (a.x ? b.x : c.x, a.y ? b.y : c.y, a.z ? b.z : c.z);
					}
					vec4 xll_vecTSel_vb4_vf4_vf4 (bvec4 a, vec4 b, vec4 c) {
					  return vec4 (a.x ? b.x : c.x, a.y ? b.y : c.y, a.z ? b.z : c.z, a.w ? b.w : c.w);
					}
					#line 447
					struct v2f_vertex_lit {
					    highp vec2 uv;
					    lowp vec4 diff;
					    lowp vec4 spec;
					};
					#line 756
					struct v2f_img {
					    highp vec4 pos;
					    mediump vec2 uv;
					};
					#line 749
					struct appdata_img {
					    highp vec4 vertex;
					    mediump vec2 texcoord;
					};
					#line 40
					uniform highp vec4 _Time;
					uniform highp vec4 _SinTime;
					uniform highp vec4 _CosTime;
					uniform highp vec4 unity_DeltaTime;
					#line 46
					uniform highp vec3 _WorldSpaceCameraPos;
					#line 53
					uniform highp vec4 _ProjectionParams;
					#line 59
					uniform highp vec4 _ScreenParams;
					#line 71
					uniform highp vec4 _ZBufferParams;
					#line 77
					uniform highp vec4 unity_OrthoParams;
					#line 86
					uniform highp vec4 unity_CameraWorldClipPlanes[6];
					#line 92
					uniform highp mat4 unity_CameraProjection;
					uniform highp mat4 unity_CameraInvProjection;
					uniform highp mat4 unity_WorldToCamera;
					uniform highp mat4 unity_CameraToWorld;
					#line 108
					uniform highp vec4 _WorldSpaceLightPos0;
					uniform highp vec4 _LightPositionRange;
					#line 112
					uniform highp vec4 _LightProjectionParams;
					uniform highp vec4 unity_4LightPosX0;
					uniform highp vec4 unity_4LightPosY0;
					#line 116
					uniform highp vec4 unity_4LightPosZ0;
					uniform mediump vec4 unity_4LightAtten0;
					uniform mediump vec4 unity_LightColor[8];
					#line 122
					uniform highp vec4 unity_LightPosition[8];
					#line 127
					uniform mediump vec4 unity_LightAtten[8];
					uniform highp vec4 unity_SpotDirection[8];
					#line 131
					uniform mediump vec4 unity_SHAr;
					uniform mediump vec4 unity_SHAg;
					uniform mediump vec4 unity_SHAb;
					uniform mediump vec4 unity_SHBr;
					#line 135
					uniform mediump vec4 unity_SHBg;
					uniform mediump vec4 unity_SHBb;
					uniform mediump vec4 unity_SHC;
					#line 140
					uniform lowp vec4 unity_OcclusionMaskSelector;
					uniform lowp vec4 unity_ProbesOcclusion;
					#line 145
					uniform mediump vec3 unity_LightColor0;
					uniform mediump vec3 unity_LightColor1;
					uniform mediump vec3 unity_LightColor2;
					uniform mediump vec3 unity_LightColor3;
					#line 152
					uniform highp vec4 unity_ShadowSplitSpheres[4];
					uniform highp vec4 unity_ShadowSplitSqRadii;
					uniform highp vec4 unity_LightShadowBias;
					uniform highp vec4 _LightSplitsNear;
					#line 156
					uniform highp vec4 _LightSplitsFar;
					uniform highp mat4 unity_WorldToShadow[4];
					uniform mediump vec4 _LightShadowData;
					uniform highp vec4 unity_ShadowFadeCenterAndType;
					#line 165
					uniform highp mat4 unity_ObjectToWorld;
					uniform highp mat4 unity_WorldToObject;
					uniform highp vec4 unity_LODFade;
					uniform highp vec4 unity_WorldTransformParams;
					#line 206
					uniform highp mat4 glstate_matrix_transpose_modelview0;
					#line 214
					uniform lowp vec4 glstate_lightmodel_ambient;
					uniform lowp vec4 unity_AmbientSky;
					uniform lowp vec4 unity_AmbientEquator;
					uniform lowp vec4 unity_AmbientGround;
					#line 218
					uniform lowp vec4 unity_IndirectSpecColor;
					uniform highp mat4 glstate_matrix_projection;
					#line 222
					uniform highp mat4 unity_MatrixV;
					uniform highp mat4 unity_MatrixInvV;
					uniform highp mat4 unity_MatrixVP;
					uniform highp int unity_StereoEyeIndex;
					#line 228
					uniform lowp vec4 unity_ShadowColor;
					#line 235
					uniform lowp vec4 unity_FogColor;
					#line 240
					uniform highp vec4 unity_FogParams;
					#line 248
					uniform mediump sampler2D unity_Lightmap;
					uniform mediump sampler2D unity_LightmapInd;
					#line 252
					uniform sampler2D unity_ShadowMask;
					uniform sampler2D unity_DynamicLightmap;
					#line 256
					uniform sampler2D unity_DynamicDirectionality;
					uniform sampler2D unity_DynamicNormal;
					#line 260
					uniform highp vec4 unity_LightmapST;
					uniform highp vec4 unity_DynamicLightmapST;
					#line 268
					uniform samplerCube unity_SpecCube0;
					uniform samplerCube unity_SpecCube1;
					#line 272
					uniform highp vec4 unity_SpecCube0_BoxMax;
					uniform highp vec4 unity_SpecCube0_BoxMin;
					uniform highp vec4 unity_SpecCube0_ProbePosition;
					uniform mediump vec4 unity_SpecCube0_HDR;
					#line 277
					uniform highp vec4 unity_SpecCube1_BoxMax;
					uniform highp vec4 unity_SpecCube1_BoxMin;
					uniform highp vec4 unity_SpecCube1_ProbePosition;
					uniform mediump vec4 unity_SpecCube1_HDR;
					#line 317
					highp mat4 unity_MatrixMVP;
					highp mat4 unity_MatrixMV;
					highp mat4 unity_MatrixTMV;
					highp mat4 unity_MatrixITMV;
					#line 8
					#line 30
					#line 44
					#line 84
					#line 93
					#line 103
					#line 112
					#line 124
					#line 135
					#line 141
					#line 147
					#line 151
					#line 157
					#line 163
					#line 169
					#line 175
					#line 186
					#line 201
					#line 208
					#line 223
					#line 230
					#line 237
					#line 255
					#line 291
					#line 320
					#line 326
					#line 339
					#line 357
					#line 373
					#line 427
					#line 453
					#line 464
					#line 473
					#line 480
					#line 485
					#line 502
					#line 522
					#line 537
					#line 543
					#line 554
					uniform mediump vec4 unity_Lightmap_HDR;
					uniform mediump vec4 unity_DynamicLightmap_HDR;
					#line 568
					#line 578
					#line 593
					#line 602
					#line 609
					#line 618
					#line 626
					#line 635
					#line 654
					#line 660
					#line 670
					#line 680
					#line 691
					#line 696
					#line 702
					#line 707
					#line 764
					#line 770
					#line 785
					#line 816
					#line 830
					#line 834
					#line 840
					#line 849
					#line 859
					#line 885
					#line 891
					#line 7
					uniform sampler2D _MainTex;
					uniform lowp sampler3D _LookupTex3D;
					uniform sampler2D _LookupTex2D;
					uniform highp vec4 _Params;
					#line 17
					#line 23
					#line 29
					#line 35
					#line 41
					#line 47
					#line 67
					#line 91
					#line 97
					#line 29
					highp vec4 Linear( in highp vec4 color ) {
					    color.xyz = xll_vecTSel_vb3_vf3_vf3 (lessThanEqual( color.xyz, vec3( 0.0404482, 0.0404482, 0.0404482)), (color.xyz / 12.92321), pow( ((color.xyz + 0.055) * 0.9478672), vec3( 2.4)));
					    return color;
					}
					#line 17
					highp vec3 sRGB( in highp vec3 color ) {
					    color = xll_vecTSel_vb3_vf3_vf3 (lessThanEqual( color, vec3( 0.0031308, 0.0031308, 0.0031308)), (color * 12.92321), ((1.055 * pow( color, vec3( 0.41666))) - 0.055));
					    return color;
					}
					#line 41
					highp vec4 lookup_linear( in highp vec4 o ) {
					    o.xyz = texture3D( _LookupTex3D, ((sRGB( o.xyz) * _Params.x) + _Params.y)).xyz;
					    return Linear( o);
					}
					#line 47
					highp vec4 frag( in v2f_img i ) {
					    highp vec4 color = xll_saturate_vf4(texture2D( _MainTex, i.uv));
					    highp vec4 x;
					    #line 53
					    x = lookup_linear( color);
					    #line 61
					    return (( (i.uv.y > 0.5) ) ? ( mix( color, x, vec4( _Params.z)) ) : ( color ));
					}
					varying mediump vec2 xlv_TEXCOORD0;
					void main() {
					unity_MatrixMVP = (unity_MatrixVP * unity_ObjectToWorld);
					unity_MatrixMV = (unity_MatrixV * unity_ObjectToWorld);
					unity_MatrixTMV = xll_transpose_mf4x4(unity_MatrixMV);
					unity_MatrixITMV = xll_transpose_mf4x4((unity_WorldToObject * unity_MatrixInvV));
					    highp vec4 xl_retval;
					    v2f_img xlt_i;
					    xlt_i.pos = vec4(0.0);
					    xlt_i.uv = vec2(xlv_TEXCOORD0);
					    xl_retval = frag( xlt_i);
					    gl_FragData[0] = vec4(xl_retval);
					}
					/* HLSL2GLSL - NOTE: GLSL optimization failed
					(9,1): error: invalid type `sampler3D' in declaration of `_LookupTex3D'
					(43,21): error: `_LookupTex3D' undeclared
					(43,10): error: no matching function for call to `texture3D(error, vec3)'; candidates are:
					(43,10): error: type mismatch
					*/
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {
					"!!GLES
					#version 100
					
					#ifdef VERTEX
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 30
					#endif
					#ifndef SHADER_REQUIRE_INTERPOLATORS10
					    #define SHADER_REQUIRE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_REQUIRE_SAMPLELOD
					    #define SHADER_REQUIRE_SAMPLELOD 1
					#endif
					#ifndef SHADER_REQUIRE_FRAGCOORD
					    #define SHADER_REQUIRE_FRAGCOORD 1
					#endif
					#ifndef UNITY_NO_DXT5nm
					    #define UNITY_NO_DXT5nm 1
					#endif
					#ifndef UNITY_NO_RGBM
					    #define UNITY_NO_RGBM 1
					#endif
					#ifndef UNITY_ENABLE_REFLECTION_BUFFERS
					    #define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#endif
					#ifndef UNITY_FRAMEBUFFER_FETCH_AVAILABLE
					    #define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#endif
					#ifndef UNITY_NO_CUBEMAP_ARRAY
					    #define UNITY_NO_CUBEMAP_ARRAY 1
					#endif
					#ifndef UNITY_NO_SCREENSPACE_SHADOWS
					    #define UNITY_NO_SCREENSPACE_SHADOWS 1
					#endif
					#ifndef UNITY_PBS_USE_BRDF2
					    #define UNITY_PBS_USE_BRDF2 1
					#endif
					#ifndef SHADER_API_MOBILE
					    #define SHADER_API_MOBILE 1
					#endif
					#ifndef UNITY_HARDWARE_TIER3
					    #define UNITY_HARDWARE_TIER3 1
					#endif
					#ifndef UNITY_COLORSPACE_GAMMA
					    #define UNITY_COLORSPACE_GAMMA 1
					#endif
					#ifndef UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS
					    #define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#endif
					#ifndef UNITY_LIGHTMAP_DLDR_ENCODING
					    #define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#endif
					#ifndef UNITY_VERSION
					    #define UNITY_VERSION 201834
					#endif
					#ifndef SHADER_STAGE_VERTEX
					    #define SHADER_STAGE_VERTEX 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 30
					#endif
					#ifndef SHADER_AVAILABLE_INTERPOLATORS10
					    #define SHADER_AVAILABLE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_SAMPLELOD
					    #define SHADER_AVAILABLE_SAMPLELOD 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#define gl_Vertex _glesVertex
					attribute vec4 _glesVertex;
					#define gl_MultiTexCoord0 _glesMultiTexCoord0
					attribute vec4 _glesMultiTexCoord0;
					mat2 xll_transpose_mf2x2(mat2 m) {
					  return mat2( m[0][0], m[1][0], m[0][1], m[1][1]);
					}
					mat3 xll_transpose_mf3x3(mat3 m) {
					  return mat3( m[0][0], m[1][0], m[2][0],
					               m[0][1], m[1][1], m[2][1],
					               m[0][2], m[1][2], m[2][2]);
					}
					mat4 xll_transpose_mf4x4(mat4 m) {
					  return mat4( m[0][0], m[1][0], m[2][0], m[3][0],
					               m[0][1], m[1][1], m[2][1], m[3][1],
					               m[0][2], m[1][2], m[2][2], m[3][2],
					               m[0][3], m[1][3], m[2][3], m[3][3]);
					}
					#line 447
					struct v2f_vertex_lit {
					    highp vec2 uv;
					    lowp vec4 diff;
					    lowp vec4 spec;
					};
					#line 756
					struct v2f_img {
					    highp vec4 pos;
					    mediump vec2 uv;
					};
					#line 749
					struct appdata_img {
					    highp vec4 vertex;
					    mediump vec2 texcoord;
					};
					#line 40
					uniform highp vec4 _Time;
					uniform highp vec4 _SinTime;
					uniform highp vec4 _CosTime;
					uniform highp vec4 unity_DeltaTime;
					#line 46
					uniform highp vec3 _WorldSpaceCameraPos;
					#line 53
					uniform highp vec4 _ProjectionParams;
					#line 59
					uniform highp vec4 _ScreenParams;
					#line 71
					uniform highp vec4 _ZBufferParams;
					#line 77
					uniform highp vec4 unity_OrthoParams;
					#line 86
					uniform highp vec4 unity_CameraWorldClipPlanes[6];
					#line 92
					uniform highp mat4 unity_CameraProjection;
					uniform highp mat4 unity_CameraInvProjection;
					uniform highp mat4 unity_WorldToCamera;
					uniform highp mat4 unity_CameraToWorld;
					#line 108
					uniform highp vec4 _WorldSpaceLightPos0;
					uniform highp vec4 _LightPositionRange;
					#line 112
					uniform highp vec4 _LightProjectionParams;
					uniform highp vec4 unity_4LightPosX0;
					uniform highp vec4 unity_4LightPosY0;
					#line 116
					uniform highp vec4 unity_4LightPosZ0;
					uniform mediump vec4 unity_4LightAtten0;
					uniform mediump vec4 unity_LightColor[8];
					#line 122
					uniform highp vec4 unity_LightPosition[8];
					#line 127
					uniform mediump vec4 unity_LightAtten[8];
					uniform highp vec4 unity_SpotDirection[8];
					#line 131
					uniform mediump vec4 unity_SHAr;
					uniform mediump vec4 unity_SHAg;
					uniform mediump vec4 unity_SHAb;
					uniform mediump vec4 unity_SHBr;
					#line 135
					uniform mediump vec4 unity_SHBg;
					uniform mediump vec4 unity_SHBb;
					uniform mediump vec4 unity_SHC;
					#line 140
					uniform lowp vec4 unity_OcclusionMaskSelector;
					uniform lowp vec4 unity_ProbesOcclusion;
					#line 145
					uniform mediump vec3 unity_LightColor0;
					uniform mediump vec3 unity_LightColor1;
					uniform mediump vec3 unity_LightColor2;
					uniform mediump vec3 unity_LightColor3;
					#line 152
					uniform highp vec4 unity_ShadowSplitSpheres[4];
					uniform highp vec4 unity_ShadowSplitSqRadii;
					uniform highp vec4 unity_LightShadowBias;
					uniform highp vec4 _LightSplitsNear;
					#line 156
					uniform highp vec4 _LightSplitsFar;
					uniform highp mat4 unity_WorldToShadow[4];
					uniform mediump vec4 _LightShadowData;
					uniform highp vec4 unity_ShadowFadeCenterAndType;
					#line 165
					uniform highp mat4 unity_ObjectToWorld;
					uniform highp mat4 unity_WorldToObject;
					uniform highp vec4 unity_LODFade;
					uniform highp vec4 unity_WorldTransformParams;
					#line 206
					uniform highp mat4 glstate_matrix_transpose_modelview0;
					#line 214
					uniform lowp vec4 glstate_lightmodel_ambient;
					uniform lowp vec4 unity_AmbientSky;
					uniform lowp vec4 unity_AmbientEquator;
					uniform lowp vec4 unity_AmbientGround;
					#line 218
					uniform lowp vec4 unity_IndirectSpecColor;
					uniform highp mat4 glstate_matrix_projection;
					#line 222
					uniform highp mat4 unity_MatrixV;
					uniform highp mat4 unity_MatrixInvV;
					uniform highp mat4 unity_MatrixVP;
					uniform highp int unity_StereoEyeIndex;
					#line 228
					uniform lowp vec4 unity_ShadowColor;
					#line 235
					uniform lowp vec4 unity_FogColor;
					#line 240
					uniform highp vec4 unity_FogParams;
					#line 248
					uniform mediump sampler2D unity_Lightmap;
					uniform mediump sampler2D unity_LightmapInd;
					#line 252
					uniform sampler2D unity_ShadowMask;
					uniform sampler2D unity_DynamicLightmap;
					#line 256
					uniform sampler2D unity_DynamicDirectionality;
					uniform sampler2D unity_DynamicNormal;
					#line 260
					uniform highp vec4 unity_LightmapST;
					uniform highp vec4 unity_DynamicLightmapST;
					#line 268
					uniform samplerCube unity_SpecCube0;
					uniform samplerCube unity_SpecCube1;
					#line 272
					uniform highp vec4 unity_SpecCube0_BoxMax;
					uniform highp vec4 unity_SpecCube0_BoxMin;
					uniform highp vec4 unity_SpecCube0_ProbePosition;
					uniform mediump vec4 unity_SpecCube0_HDR;
					#line 277
					uniform highp vec4 unity_SpecCube1_BoxMax;
					uniform highp vec4 unity_SpecCube1_BoxMin;
					uniform highp vec4 unity_SpecCube1_ProbePosition;
					uniform mediump vec4 unity_SpecCube1_HDR;
					#line 317
					highp mat4 unity_MatrixMVP;
					highp mat4 unity_MatrixMV;
					highp mat4 unity_MatrixTMV;
					highp mat4 unity_MatrixITMV;
					#line 8
					#line 30
					#line 44
					#line 84
					#line 93
					#line 103
					#line 112
					#line 124
					#line 135
					#line 141
					#line 147
					#line 151
					#line 157
					#line 163
					#line 169
					#line 175
					#line 186
					#line 201
					#line 208
					#line 223
					#line 230
					#line 237
					#line 255
					#line 291
					#line 320
					#line 326
					#line 339
					#line 357
					#line 373
					#line 427
					#line 453
					#line 464
					#line 473
					#line 480
					#line 485
					#line 502
					#line 522
					#line 537
					#line 543
					#line 554
					uniform mediump vec4 unity_Lightmap_HDR;
					uniform mediump vec4 unity_DynamicLightmap_HDR;
					#line 568
					#line 578
					#line 593
					#line 602
					#line 609
					#line 618
					#line 626
					#line 635
					#line 654
					#line 660
					#line 670
					#line 680
					#line 691
					#line 696
					#line 702
					#line 707
					#line 764
					#line 770
					#line 785
					#line 816
					#line 830
					#line 834
					#line 840
					#line 849
					#line 859
					#line 885
					#line 891
					#line 7
					uniform sampler2D _MainTex;
					uniform lowp sampler3D _LookupTex3D;
					uniform sampler2D _LookupTex2D;
					uniform highp vec4 _Params;
					#line 17
					#line 23
					#line 29
					#line 35
					#line 41
					#line 47
					#line 67
					#line 91
					#line 97
					#line 44
					highp vec4 UnityObjectToClipPos( in highp vec3 pos ) {
					    #line 50
					    return (unity_MatrixVP * (unity_ObjectToWorld * vec4( pos, 1.0)));
					}
					#line 53
					highp vec4 UnityObjectToClipPos( in highp vec4 pos ) {
					    #line 55
					    return UnityObjectToClipPos( pos.xyz);
					}
					#line 770
					v2f_img vert_img( in appdata_img v ) {
					    v2f_img o;
					    #line 777
					    o.pos = UnityObjectToClipPos( v.vertex);
					    o.uv = v.texcoord;
					    return o;
					}
					varying mediump vec2 xlv_TEXCOORD0;
					void main() {
					unity_MatrixMVP = (unity_MatrixVP * unity_ObjectToWorld);
					unity_MatrixMV = (unity_MatrixV * unity_ObjectToWorld);
					unity_MatrixTMV = xll_transpose_mf4x4(unity_MatrixMV);
					unity_MatrixITMV = xll_transpose_mf4x4((unity_WorldToObject * unity_MatrixInvV));
					    v2f_img xl_retval;
					    appdata_img xlt_v;
					    xlt_v.vertex = vec4(gl_Vertex);
					    xlt_v.texcoord = vec2(gl_MultiTexCoord0);
					    xl_retval = vert_img( xlt_v);
					    gl_Position = vec4(xl_retval.pos);
					    xlv_TEXCOORD0 = vec2(xl_retval.uv);
					}
					/* HLSL2GLSL - NOTE: GLSL optimization failed
					(9,1): error: invalid type `sampler3D' in declaration of `_LookupTex3D'
					*/
					
					#endif
					#ifdef FRAGMENT
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 30
					#endif
					#ifndef SHADER_REQUIRE_INTERPOLATORS10
					    #define SHADER_REQUIRE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_REQUIRE_SAMPLELOD
					    #define SHADER_REQUIRE_SAMPLELOD 1
					#endif
					#ifndef SHADER_REQUIRE_FRAGCOORD
					    #define SHADER_REQUIRE_FRAGCOORD 1
					#endif
					#ifndef UNITY_NO_DXT5nm
					    #define UNITY_NO_DXT5nm 1
					#endif
					#ifndef UNITY_NO_RGBM
					    #define UNITY_NO_RGBM 1
					#endif
					#ifndef UNITY_ENABLE_REFLECTION_BUFFERS
					    #define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#endif
					#ifndef UNITY_FRAMEBUFFER_FETCH_AVAILABLE
					    #define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#endif
					#ifndef UNITY_NO_CUBEMAP_ARRAY
					    #define UNITY_NO_CUBEMAP_ARRAY 1
					#endif
					#ifndef UNITY_NO_SCREENSPACE_SHADOWS
					    #define UNITY_NO_SCREENSPACE_SHADOWS 1
					#endif
					#ifndef UNITY_PBS_USE_BRDF2
					    #define UNITY_PBS_USE_BRDF2 1
					#endif
					#ifndef SHADER_API_MOBILE
					    #define SHADER_API_MOBILE 1
					#endif
					#ifndef UNITY_HARDWARE_TIER3
					    #define UNITY_HARDWARE_TIER3 1
					#endif
					#ifndef UNITY_COLORSPACE_GAMMA
					    #define UNITY_COLORSPACE_GAMMA 1
					#endif
					#ifndef UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS
					    #define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#endif
					#ifndef UNITY_LIGHTMAP_DLDR_ENCODING
					    #define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#endif
					#ifndef UNITY_VERSION
					    #define UNITY_VERSION 201834
					#endif
					#ifndef SHADER_STAGE_VERTEX
					    #define SHADER_STAGE_VERTEX 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 30
					#endif
					#ifndef SHADER_AVAILABLE_INTERPOLATORS10
					    #define SHADER_AVAILABLE_INTERPOLATORS10 1
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_SAMPLELOD
					    #define SHADER_AVAILABLE_SAMPLELOD 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					mat2 xll_transpose_mf2x2(mat2 m) {
					  return mat2( m[0][0], m[1][0], m[0][1], m[1][1]);
					}
					mat3 xll_transpose_mf3x3(mat3 m) {
					  return mat3( m[0][0], m[1][0], m[2][0],
					               m[0][1], m[1][1], m[2][1],
					               m[0][2], m[1][2], m[2][2]);
					}
					mat4 xll_transpose_mf4x4(mat4 m) {
					  return mat4( m[0][0], m[1][0], m[2][0], m[3][0],
					               m[0][1], m[1][1], m[2][1], m[3][1],
					               m[0][2], m[1][2], m[2][2], m[3][2],
					               m[0][3], m[1][3], m[2][3], m[3][3]);
					}
					float xll_saturate_f( float x) {
					  return clamp( x, 0.0, 1.0);
					}
					vec2 xll_saturate_vf2( vec2 x) {
					  return clamp( x, 0.0, 1.0);
					}
					vec3 xll_saturate_vf3( vec3 x) {
					  return clamp( x, 0.0, 1.0);
					}
					vec4 xll_saturate_vf4( vec4 x) {
					  return clamp( x, 0.0, 1.0);
					}
					mat2 xll_saturate_mf2x2(mat2 m) {
					  return mat2( clamp(m[0], 0.0, 1.0), clamp(m[1], 0.0, 1.0));
					}
					mat3 xll_saturate_mf3x3(mat3 m) {
					  return mat3( clamp(m[0], 0.0, 1.0), clamp(m[1], 0.0, 1.0), clamp(m[2], 0.0, 1.0));
					}
					mat4 xll_saturate_mf4x4(mat4 m) {
					  return mat4( clamp(m[0], 0.0, 1.0), clamp(m[1], 0.0, 1.0), clamp(m[2], 0.0, 1.0), clamp(m[3], 0.0, 1.0));
					}
					vec2 xll_vecTSel_vb2_vf2_vf2 (bvec2 a, vec2 b, vec2 c) {
					  return vec2 (a.x ? b.x : c.x, a.y ? b.y : c.y);
					}
					vec3 xll_vecTSel_vb3_vf3_vf3 (bvec3 a, vec3 b, vec3 c) {
					  return vec3 (a.x ? b.x : c.x, a.y ? b.y : c.y, a.z ? b.z : c.z);
					}
					vec4 xll_vecTSel_vb4_vf4_vf4 (bvec4 a, vec4 b, vec4 c) {
					  return vec4 (a.x ? b.x : c.x, a.y ? b.y : c.y, a.z ? b.z : c.z, a.w ? b.w : c.w);
					}
					#line 447
					struct v2f_vertex_lit {
					    highp vec2 uv;
					    lowp vec4 diff;
					    lowp vec4 spec;
					};
					#line 756
					struct v2f_img {
					    highp vec4 pos;
					    mediump vec2 uv;
					};
					#line 749
					struct appdata_img {
					    highp vec4 vertex;
					    mediump vec2 texcoord;
					};
					#line 40
					uniform highp vec4 _Time;
					uniform highp vec4 _SinTime;
					uniform highp vec4 _CosTime;
					uniform highp vec4 unity_DeltaTime;
					#line 46
					uniform highp vec3 _WorldSpaceCameraPos;
					#line 53
					uniform highp vec4 _ProjectionParams;
					#line 59
					uniform highp vec4 _ScreenParams;
					#line 71
					uniform highp vec4 _ZBufferParams;
					#line 77
					uniform highp vec4 unity_OrthoParams;
					#line 86
					uniform highp vec4 unity_CameraWorldClipPlanes[6];
					#line 92
					uniform highp mat4 unity_CameraProjection;
					uniform highp mat4 unity_CameraInvProjection;
					uniform highp mat4 unity_WorldToCamera;
					uniform highp mat4 unity_CameraToWorld;
					#line 108
					uniform highp vec4 _WorldSpaceLightPos0;
					uniform highp vec4 _LightPositionRange;
					#line 112
					uniform highp vec4 _LightProjectionParams;
					uniform highp vec4 unity_4LightPosX0;
					uniform highp vec4 unity_4LightPosY0;
					#line 116
					uniform highp vec4 unity_4LightPosZ0;
					uniform mediump vec4 unity_4LightAtten0;
					uniform mediump vec4 unity_LightColor[8];
					#line 122
					uniform highp vec4 unity_LightPosition[8];
					#line 127
					uniform mediump vec4 unity_LightAtten[8];
					uniform highp vec4 unity_SpotDirection[8];
					#line 131
					uniform mediump vec4 unity_SHAr;
					uniform mediump vec4 unity_SHAg;
					uniform mediump vec4 unity_SHAb;
					uniform mediump vec4 unity_SHBr;
					#line 135
					uniform mediump vec4 unity_SHBg;
					uniform mediump vec4 unity_SHBb;
					uniform mediump vec4 unity_SHC;
					#line 140
					uniform lowp vec4 unity_OcclusionMaskSelector;
					uniform lowp vec4 unity_ProbesOcclusion;
					#line 145
					uniform mediump vec3 unity_LightColor0;
					uniform mediump vec3 unity_LightColor1;
					uniform mediump vec3 unity_LightColor2;
					uniform mediump vec3 unity_LightColor3;
					#line 152
					uniform highp vec4 unity_ShadowSplitSpheres[4];
					uniform highp vec4 unity_ShadowSplitSqRadii;
					uniform highp vec4 unity_LightShadowBias;
					uniform highp vec4 _LightSplitsNear;
					#line 156
					uniform highp vec4 _LightSplitsFar;
					uniform highp mat4 unity_WorldToShadow[4];
					uniform mediump vec4 _LightShadowData;
					uniform highp vec4 unity_ShadowFadeCenterAndType;
					#line 165
					uniform highp mat4 unity_ObjectToWorld;
					uniform highp mat4 unity_WorldToObject;
					uniform highp vec4 unity_LODFade;
					uniform highp vec4 unity_WorldTransformParams;
					#line 206
					uniform highp mat4 glstate_matrix_transpose_modelview0;
					#line 214
					uniform lowp vec4 glstate_lightmodel_ambient;
					uniform lowp vec4 unity_AmbientSky;
					uniform lowp vec4 unity_AmbientEquator;
					uniform lowp vec4 unity_AmbientGround;
					#line 218
					uniform lowp vec4 unity_IndirectSpecColor;
					uniform highp mat4 glstate_matrix_projection;
					#line 222
					uniform highp mat4 unity_MatrixV;
					uniform highp mat4 unity_MatrixInvV;
					uniform highp mat4 unity_MatrixVP;
					uniform highp int unity_StereoEyeIndex;
					#line 228
					uniform lowp vec4 unity_ShadowColor;
					#line 235
					uniform lowp vec4 unity_FogColor;
					#line 240
					uniform highp vec4 unity_FogParams;
					#line 248
					uniform mediump sampler2D unity_Lightmap;
					uniform mediump sampler2D unity_LightmapInd;
					#line 252
					uniform sampler2D unity_ShadowMask;
					uniform sampler2D unity_DynamicLightmap;
					#line 256
					uniform sampler2D unity_DynamicDirectionality;
					uniform sampler2D unity_DynamicNormal;
					#line 260
					uniform highp vec4 unity_LightmapST;
					uniform highp vec4 unity_DynamicLightmapST;
					#line 268
					uniform samplerCube unity_SpecCube0;
					uniform samplerCube unity_SpecCube1;
					#line 272
					uniform highp vec4 unity_SpecCube0_BoxMax;
					uniform highp vec4 unity_SpecCube0_BoxMin;
					uniform highp vec4 unity_SpecCube0_ProbePosition;
					uniform mediump vec4 unity_SpecCube0_HDR;
					#line 277
					uniform highp vec4 unity_SpecCube1_BoxMax;
					uniform highp vec4 unity_SpecCube1_BoxMin;
					uniform highp vec4 unity_SpecCube1_ProbePosition;
					uniform mediump vec4 unity_SpecCube1_HDR;
					#line 317
					highp mat4 unity_MatrixMVP;
					highp mat4 unity_MatrixMV;
					highp mat4 unity_MatrixTMV;
					highp mat4 unity_MatrixITMV;
					#line 8
					#line 30
					#line 44
					#line 84
					#line 93
					#line 103
					#line 112
					#line 124
					#line 135
					#line 141
					#line 147
					#line 151
					#line 157
					#line 163
					#line 169
					#line 175
					#line 186
					#line 201
					#line 208
					#line 223
					#line 230
					#line 237
					#line 255
					#line 291
					#line 320
					#line 326
					#line 339
					#line 357
					#line 373
					#line 427
					#line 453
					#line 464
					#line 473
					#line 480
					#line 485
					#line 502
					#line 522
					#line 537
					#line 543
					#line 554
					uniform mediump vec4 unity_Lightmap_HDR;
					uniform mediump vec4 unity_DynamicLightmap_HDR;
					#line 568
					#line 578
					#line 593
					#line 602
					#line 609
					#line 618
					#line 626
					#line 635
					#line 654
					#line 660
					#line 670
					#line 680
					#line 691
					#line 696
					#line 702
					#line 707
					#line 764
					#line 770
					#line 785
					#line 816
					#line 830
					#line 834
					#line 840
					#line 849
					#line 859
					#line 885
					#line 891
					#line 7
					uniform sampler2D _MainTex;
					uniform lowp sampler3D _LookupTex3D;
					uniform sampler2D _LookupTex2D;
					uniform highp vec4 _Params;
					#line 17
					#line 23
					#line 29
					#line 35
					#line 41
					#line 47
					#line 67
					#line 91
					#line 97
					#line 29
					highp vec4 Linear( in highp vec4 color ) {
					    color.xyz = xll_vecTSel_vb3_vf3_vf3 (lessThanEqual( color.xyz, vec3( 0.0404482, 0.0404482, 0.0404482)), (color.xyz / 12.92321), pow( ((color.xyz + 0.055) * 0.9478672), vec3( 2.4)));
					    return color;
					}
					#line 17
					highp vec3 sRGB( in highp vec3 color ) {
					    color = xll_vecTSel_vb3_vf3_vf3 (lessThanEqual( color, vec3( 0.0031308, 0.0031308, 0.0031308)), (color * 12.92321), ((1.055 * pow( color, vec3( 0.41666))) - 0.055));
					    return color;
					}
					#line 41
					highp vec4 lookup_linear( in highp vec4 o ) {
					    o.xyz = texture3D( _LookupTex3D, ((sRGB( o.xyz) * _Params.x) + _Params.y)).xyz;
					    return Linear( o);
					}
					#line 47
					highp vec4 frag( in v2f_img i ) {
					    highp vec4 color = xll_saturate_vf4(texture2D( _MainTex, i.uv));
					    highp vec4 x;
					    #line 53
					    x = lookup_linear( color);
					    #line 61
					    return (( (i.uv.y > 0.5) ) ? ( mix( color, x, vec4( _Params.z)) ) : ( color ));
					}
					varying mediump vec2 xlv_TEXCOORD0;
					void main() {
					unity_MatrixMVP = (unity_MatrixVP * unity_ObjectToWorld);
					unity_MatrixMV = (unity_MatrixV * unity_ObjectToWorld);
					unity_MatrixTMV = xll_transpose_mf4x4(unity_MatrixMV);
					unity_MatrixITMV = xll_transpose_mf4x4((unity_WorldToObject * unity_MatrixInvV));
					    highp vec4 xl_retval;
					    v2f_img xlt_i;
					    xlt_i.pos = vec4(0.0);
					    xlt_i.uv = vec2(xlv_TEXCOORD0);
					    xl_retval = frag( xlt_i);
					    gl_FragData[0] = vec4(xl_retval);
					}
					/* HLSL2GLSL - NOTE: GLSL optimization failed
					(9,1): error: invalid type `sampler3D' in declaration of `_LookupTex3D'
					(43,21): error: `_LookupTex3D' undeclared
					(43,10): error: no matching function for call to `texture3D(error, vec3)'; candidates are:
					(43,10): error: type mismatch
					*/
					
					#endif"
				}
				SubProgram "gles3 hw_tier00 " {
					"!!GLES3
					#ifdef VERTEX
					#version 300 es
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					in highp vec4 in_POSITION0;
					in mediump vec2 in_TEXCOORD0;
					out mediump vec2 vs_TEXCOORD0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					void main()
					{
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy;
					    return;
					}
					
					#endif
					#ifdef FRAGMENT
					#version 300 es
					
					precision highp int;
					uniform 	vec4 _Params;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler3D _LookupTex3D;
					in mediump vec2 vs_TEXCOORD0;
					layout(location = 0) out highp vec4 SV_Target0;
					vec4 u_xlat0;
					lowp vec4 u_xlat10_0;
					vec4 u_xlat1;
					vec3 u_xlat2;
					bvec3 u_xlatb2;
					vec3 u_xlat3;
					bvec3 u_xlatb3;
					void main()
					{
					    u_xlat10_0 = texture(_MainTex, vs_TEXCOORD0.xy);
					    u_xlat0 = u_xlat10_0;
					#ifdef UNITY_ADRENO_ES3
					    u_xlat0 = min(max(u_xlat0, 0.0), 1.0);
					#else
					    u_xlat0 = clamp(u_xlat0, 0.0, 1.0);
					#endif
					    u_xlat1.xyz = log2(u_xlat0.xyz);
					    u_xlat1.xyz = u_xlat1.xyz * vec3(0.416660011, 0.416660011, 0.416660011);
					    u_xlat1.xyz = exp2(u_xlat1.xyz);
					    u_xlat1.xyz = u_xlat1.xyz * vec3(1.05499995, 1.05499995, 1.05499995) + vec3(-0.0549999997, -0.0549999997, -0.0549999997);
					    u_xlatb2.xyz = greaterThanEqual(vec4(0.00313080009, 0.00313080009, 0.00313080009, 0.0), u_xlat0.xyzx).xyz;
					    u_xlat3.xyz = u_xlat0.xyz * vec3(12.9232101, 12.9232101, 12.9232101);
					    {
					        vec4 hlslcc_movcTemp = u_xlat1;
					        u_xlat1.x = (u_xlatb2.x) ? u_xlat3.x : hlslcc_movcTemp.x;
					        u_xlat1.y = (u_xlatb2.y) ? u_xlat3.y : hlslcc_movcTemp.y;
					        u_xlat1.z = (u_xlatb2.z) ? u_xlat3.z : hlslcc_movcTemp.z;
					    }
					    u_xlat1.xyz = u_xlat1.xyz * _Params.xxx + _Params.yyy;
					    u_xlat1.xyz = texture(_LookupTex3D, u_xlat1.xyz).xyz;
					    u_xlat2.xyz = u_xlat1.xyz + vec3(0.0549999997, 0.0549999997, 0.0549999997);
					    u_xlat2.xyz = u_xlat2.xyz * vec3(0.947867215, 0.947867215, 0.947867215);
					    u_xlat2.xyz = log2(u_xlat2.xyz);
					    u_xlat2.xyz = u_xlat2.xyz * vec3(2.4000001, 2.4000001, 2.4000001);
					    u_xlat2.xyz = exp2(u_xlat2.xyz);
					    u_xlatb3.xyz = greaterThanEqual(vec4(0.0404482, 0.0404482, 0.0404482, 0.0), u_xlat1.xyzx).xyz;
					    u_xlat1.xyz = u_xlat1.xyz * vec3(0.077380158, 0.077380158, 0.077380158);
					    {
					        vec4 hlslcc_movcTemp = u_xlat1;
					        u_xlat1.x = (u_xlatb3.x) ? hlslcc_movcTemp.x : u_xlat2.x;
					        u_xlat1.y = (u_xlatb3.y) ? hlslcc_movcTemp.y : u_xlat2.y;
					        u_xlat1.z = (u_xlatb3.z) ? hlslcc_movcTemp.z : u_xlat2.z;
					    }
					    u_xlat1.xyz = (-u_xlat0.xyz) + u_xlat1.xyz;
					    u_xlat1.w = 0.0;
					    u_xlat1 = _Params.zzzz * u_xlat1 + u_xlat0;
					#ifdef UNITY_ADRENO_ES3
					    u_xlatb2.x = !!(0.5<vs_TEXCOORD0.y);
					#else
					    u_xlatb2.x = 0.5<vs_TEXCOORD0.y;
					#endif
					    SV_Target0 = (u_xlatb2.x) ? u_xlat1 : u_xlat0;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles3 hw_tier01 " {
					"!!GLES3
					#ifdef VERTEX
					#version 300 es
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					in highp vec4 in_POSITION0;
					in mediump vec2 in_TEXCOORD0;
					out mediump vec2 vs_TEXCOORD0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					void main()
					{
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy;
					    return;
					}
					
					#endif
					#ifdef FRAGMENT
					#version 300 es
					
					precision highp int;
					uniform 	vec4 _Params;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler3D _LookupTex3D;
					in mediump vec2 vs_TEXCOORD0;
					layout(location = 0) out highp vec4 SV_Target0;
					vec4 u_xlat0;
					lowp vec4 u_xlat10_0;
					vec4 u_xlat1;
					vec3 u_xlat2;
					bvec3 u_xlatb2;
					vec3 u_xlat3;
					bvec3 u_xlatb3;
					void main()
					{
					    u_xlat10_0 = texture(_MainTex, vs_TEXCOORD0.xy);
					    u_xlat0 = u_xlat10_0;
					#ifdef UNITY_ADRENO_ES3
					    u_xlat0 = min(max(u_xlat0, 0.0), 1.0);
					#else
					    u_xlat0 = clamp(u_xlat0, 0.0, 1.0);
					#endif
					    u_xlat1.xyz = log2(u_xlat0.xyz);
					    u_xlat1.xyz = u_xlat1.xyz * vec3(0.416660011, 0.416660011, 0.416660011);
					    u_xlat1.xyz = exp2(u_xlat1.xyz);
					    u_xlat1.xyz = u_xlat1.xyz * vec3(1.05499995, 1.05499995, 1.05499995) + vec3(-0.0549999997, -0.0549999997, -0.0549999997);
					    u_xlatb2.xyz = greaterThanEqual(vec4(0.00313080009, 0.00313080009, 0.00313080009, 0.0), u_xlat0.xyzx).xyz;
					    u_xlat3.xyz = u_xlat0.xyz * vec3(12.9232101, 12.9232101, 12.9232101);
					    {
					        vec4 hlslcc_movcTemp = u_xlat1;
					        u_xlat1.x = (u_xlatb2.x) ? u_xlat3.x : hlslcc_movcTemp.x;
					        u_xlat1.y = (u_xlatb2.y) ? u_xlat3.y : hlslcc_movcTemp.y;
					        u_xlat1.z = (u_xlatb2.z) ? u_xlat3.z : hlslcc_movcTemp.z;
					    }
					    u_xlat1.xyz = u_xlat1.xyz * _Params.xxx + _Params.yyy;
					    u_xlat1.xyz = texture(_LookupTex3D, u_xlat1.xyz).xyz;
					    u_xlat2.xyz = u_xlat1.xyz + vec3(0.0549999997, 0.0549999997, 0.0549999997);
					    u_xlat2.xyz = u_xlat2.xyz * vec3(0.947867215, 0.947867215, 0.947867215);
					    u_xlat2.xyz = log2(u_xlat2.xyz);
					    u_xlat2.xyz = u_xlat2.xyz * vec3(2.4000001, 2.4000001, 2.4000001);
					    u_xlat2.xyz = exp2(u_xlat2.xyz);
					    u_xlatb3.xyz = greaterThanEqual(vec4(0.0404482, 0.0404482, 0.0404482, 0.0), u_xlat1.xyzx).xyz;
					    u_xlat1.xyz = u_xlat1.xyz * vec3(0.077380158, 0.077380158, 0.077380158);
					    {
					        vec4 hlslcc_movcTemp = u_xlat1;
					        u_xlat1.x = (u_xlatb3.x) ? hlslcc_movcTemp.x : u_xlat2.x;
					        u_xlat1.y = (u_xlatb3.y) ? hlslcc_movcTemp.y : u_xlat2.y;
					        u_xlat1.z = (u_xlatb3.z) ? hlslcc_movcTemp.z : u_xlat2.z;
					    }
					    u_xlat1.xyz = (-u_xlat0.xyz) + u_xlat1.xyz;
					    u_xlat1.w = 0.0;
					    u_xlat1 = _Params.zzzz * u_xlat1 + u_xlat0;
					#ifdef UNITY_ADRENO_ES3
					    u_xlatb2.x = !!(0.5<vs_TEXCOORD0.y);
					#else
					    u_xlatb2.x = 0.5<vs_TEXCOORD0.y;
					#endif
					    SV_Target0 = (u_xlatb2.x) ? u_xlat1 : u_xlat0;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles3 hw_tier02 " {
					"!!GLES3
					#ifdef VERTEX
					#version 300 es
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					in highp vec4 in_POSITION0;
					in mediump vec2 in_TEXCOORD0;
					out mediump vec2 vs_TEXCOORD0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					void main()
					{
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy;
					    return;
					}
					
					#endif
					#ifdef FRAGMENT
					#version 300 es
					
					precision highp int;
					uniform 	vec4 _Params;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler3D _LookupTex3D;
					in mediump vec2 vs_TEXCOORD0;
					layout(location = 0) out highp vec4 SV_Target0;
					vec4 u_xlat0;
					lowp vec4 u_xlat10_0;
					vec4 u_xlat1;
					vec3 u_xlat2;
					bvec3 u_xlatb2;
					vec3 u_xlat3;
					bvec3 u_xlatb3;
					void main()
					{
					    u_xlat10_0 = texture(_MainTex, vs_TEXCOORD0.xy);
					    u_xlat0 = u_xlat10_0;
					#ifdef UNITY_ADRENO_ES3
					    u_xlat0 = min(max(u_xlat0, 0.0), 1.0);
					#else
					    u_xlat0 = clamp(u_xlat0, 0.0, 1.0);
					#endif
					    u_xlat1.xyz = log2(u_xlat0.xyz);
					    u_xlat1.xyz = u_xlat1.xyz * vec3(0.416660011, 0.416660011, 0.416660011);
					    u_xlat1.xyz = exp2(u_xlat1.xyz);
					    u_xlat1.xyz = u_xlat1.xyz * vec3(1.05499995, 1.05499995, 1.05499995) + vec3(-0.0549999997, -0.0549999997, -0.0549999997);
					    u_xlatb2.xyz = greaterThanEqual(vec4(0.00313080009, 0.00313080009, 0.00313080009, 0.0), u_xlat0.xyzx).xyz;
					    u_xlat3.xyz = u_xlat0.xyz * vec3(12.9232101, 12.9232101, 12.9232101);
					    {
					        vec4 hlslcc_movcTemp = u_xlat1;
					        u_xlat1.x = (u_xlatb2.x) ? u_xlat3.x : hlslcc_movcTemp.x;
					        u_xlat1.y = (u_xlatb2.y) ? u_xlat3.y : hlslcc_movcTemp.y;
					        u_xlat1.z = (u_xlatb2.z) ? u_xlat3.z : hlslcc_movcTemp.z;
					    }
					    u_xlat1.xyz = u_xlat1.xyz * _Params.xxx + _Params.yyy;
					    u_xlat1.xyz = texture(_LookupTex3D, u_xlat1.xyz).xyz;
					    u_xlat2.xyz = u_xlat1.xyz + vec3(0.0549999997, 0.0549999997, 0.0549999997);
					    u_xlat2.xyz = u_xlat2.xyz * vec3(0.947867215, 0.947867215, 0.947867215);
					    u_xlat2.xyz = log2(u_xlat2.xyz);
					    u_xlat2.xyz = u_xlat2.xyz * vec3(2.4000001, 2.4000001, 2.4000001);
					    u_xlat2.xyz = exp2(u_xlat2.xyz);
					    u_xlatb3.xyz = greaterThanEqual(vec4(0.0404482, 0.0404482, 0.0404482, 0.0), u_xlat1.xyzx).xyz;
					    u_xlat1.xyz = u_xlat1.xyz * vec3(0.077380158, 0.077380158, 0.077380158);
					    {
					        vec4 hlslcc_movcTemp = u_xlat1;
					        u_xlat1.x = (u_xlatb3.x) ? hlslcc_movcTemp.x : u_xlat2.x;
					        u_xlat1.y = (u_xlatb3.y) ? hlslcc_movcTemp.y : u_xlat2.y;
					        u_xlat1.z = (u_xlatb3.z) ? hlslcc_movcTemp.z : u_xlat2.z;
					    }
					    u_xlat1.xyz = (-u_xlat0.xyz) + u_xlat1.xyz;
					    u_xlat1.w = 0.0;
					    u_xlat1 = _Params.zzzz * u_xlat1 + u_xlat0;
					#ifdef UNITY_ADRENO_ES3
					    u_xlatb2.x = !!(0.5<vs_TEXCOORD0.y);
					#else
					    u_xlatb2.x = 0.5<vs_TEXCOORD0.y;
					#endif
					    SV_Target0 = (u_xlatb2.x) ? u_xlat1 : u_xlat0;
					    return;
					}
					
					#endif"
				}
			}
			Program "fp" {
				SubProgram "gles hw_tier00 " {
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					"!!GLES"
				}
				SubProgram "gles3 hw_tier00 " {
					"!!GLES3"
				}
				SubProgram "gles3 hw_tier01 " {
					"!!GLES3"
				}
				SubProgram "gles3 hw_tier02 " {
					"!!GLES3"
				}
			}
		}
	}
}