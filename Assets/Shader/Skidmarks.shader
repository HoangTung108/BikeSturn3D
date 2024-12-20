Shader "Skidmarks" {
	Properties {
		_Color ("Main Color", Vector) = (1,1,1,1)
		_MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
	}
	SubShader {
		Tags { "QUEUE" = "Transparent" "RenderType" = "Transparent" }
		Pass {
			Tags { "QUEUE" = "Transparent" "RenderType" = "Transparent" }
			Blend SrcAlpha OneMinusSrcAlpha, SrcAlpha OneMinusSrcAlpha
			ZWrite Off
			Offset -4, -4
			Fog {
				Mode Off
			}
			GpuProgramID 53112
			Program "vp" {
				SubProgram "gles hw_tier00 " {
					"!!GLES
					#version 100
					
					#ifdef VERTEX
					attribute vec4 _glesVertex;
					attribute vec4 _glesColor;
					attribute vec4 _glesMultiTexCoord0;
					uniform highp mat4 unity_ObjectToWorld;
					uniform highp mat4 unity_MatrixVP;
					uniform highp vec4 _MainTex_ST;
					varying lowp vec4 xlv_COLOR0;
					varying highp vec2 xlv_TEXCOORD0;
					varying highp vec2 xlv_TEXCOORD1;
					void main ()
					{
					  lowp vec4 tmpvar_1;
					  mediump vec4 tmpvar_2;
					  tmpvar_2 = clamp (_glesColor, 0.0, 1.0);
					  tmpvar_1 = tmpvar_2;
					  highp vec4 tmpvar_3;
					  tmpvar_3.w = 1.0;
					  tmpvar_3.xyz = _glesVertex.xyz;
					  xlv_COLOR0 = tmpvar_1;
					  highp vec2 tmpvar_4;
					  tmpvar_4 = (_glesMultiTexCoord0.xy * _MainTex_ST.xy);
					  xlv_TEXCOORD0 = (tmpvar_4 + _MainTex_ST.zw);
					  xlv_TEXCOORD1 = (tmpvar_4 + _MainTex_ST.zw);
					  gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar_3));
					}
					
					
					#endif
					#ifdef FRAGMENT
					uniform sampler2D _MainTex;
					uniform lowp vec4 _Color;
					varying lowp vec4 xlv_COLOR0;
					varying highp vec2 xlv_TEXCOORD0;
					void main ()
					{
					  lowp vec4 col_1;
					  lowp vec4 tmpvar_2;
					  tmpvar_2 = texture2D (_MainTex, xlv_TEXCOORD0);
					  col_1.xyz = tmpvar_2.xyz;
					  col_1.w = (tmpvar_2.w * xlv_COLOR0.w);
					  col_1 = (_Color * col_1);
					  if ((col_1.w <= 0.0)) {
					    discard;
					  };
					  gl_FragData[0] = col_1;
					}
					
					
					#endif"
				}
				SubProgram "gles hw_tier01 " {
					"!!GLES
					#version 100
					
					#ifdef VERTEX
					attribute vec4 _glesVertex;
					attribute vec4 _glesColor;
					attribute vec4 _glesMultiTexCoord0;
					uniform highp mat4 unity_ObjectToWorld;
					uniform highp mat4 unity_MatrixVP;
					uniform highp vec4 _MainTex_ST;
					varying lowp vec4 xlv_COLOR0;
					varying highp vec2 xlv_TEXCOORD0;
					varying highp vec2 xlv_TEXCOORD1;
					void main ()
					{
					  lowp vec4 tmpvar_1;
					  mediump vec4 tmpvar_2;
					  tmpvar_2 = clamp (_glesColor, 0.0, 1.0);
					  tmpvar_1 = tmpvar_2;
					  highp vec4 tmpvar_3;
					  tmpvar_3.w = 1.0;
					  tmpvar_3.xyz = _glesVertex.xyz;
					  xlv_COLOR0 = tmpvar_1;
					  highp vec2 tmpvar_4;
					  tmpvar_4 = (_glesMultiTexCoord0.xy * _MainTex_ST.xy);
					  xlv_TEXCOORD0 = (tmpvar_4 + _MainTex_ST.zw);
					  xlv_TEXCOORD1 = (tmpvar_4 + _MainTex_ST.zw);
					  gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar_3));
					}
					
					
					#endif
					#ifdef FRAGMENT
					uniform sampler2D _MainTex;
					uniform lowp vec4 _Color;
					varying lowp vec4 xlv_COLOR0;
					varying highp vec2 xlv_TEXCOORD0;
					void main ()
					{
					  lowp vec4 col_1;
					  lowp vec4 tmpvar_2;
					  tmpvar_2 = texture2D (_MainTex, xlv_TEXCOORD0);
					  col_1.xyz = tmpvar_2.xyz;
					  col_1.w = (tmpvar_2.w * xlv_COLOR0.w);
					  col_1 = (_Color * col_1);
					  if ((col_1.w <= 0.0)) {
					    discard;
					  };
					  gl_FragData[0] = col_1;
					}
					
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {
					"!!GLES
					#version 100
					
					#ifdef VERTEX
					attribute vec4 _glesVertex;
					attribute vec4 _glesColor;
					attribute vec4 _glesMultiTexCoord0;
					uniform highp mat4 unity_ObjectToWorld;
					uniform highp mat4 unity_MatrixVP;
					uniform highp vec4 _MainTex_ST;
					varying lowp vec4 xlv_COLOR0;
					varying highp vec2 xlv_TEXCOORD0;
					varying highp vec2 xlv_TEXCOORD1;
					void main ()
					{
					  lowp vec4 tmpvar_1;
					  mediump vec4 tmpvar_2;
					  tmpvar_2 = clamp (_glesColor, 0.0, 1.0);
					  tmpvar_1 = tmpvar_2;
					  highp vec4 tmpvar_3;
					  tmpvar_3.w = 1.0;
					  tmpvar_3.xyz = _glesVertex.xyz;
					  xlv_COLOR0 = tmpvar_1;
					  highp vec2 tmpvar_4;
					  tmpvar_4 = (_glesMultiTexCoord0.xy * _MainTex_ST.xy);
					  xlv_TEXCOORD0 = (tmpvar_4 + _MainTex_ST.zw);
					  xlv_TEXCOORD1 = (tmpvar_4 + _MainTex_ST.zw);
					  gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar_3));
					}
					
					
					#endif
					#ifdef FRAGMENT
					uniform sampler2D _MainTex;
					uniform lowp vec4 _Color;
					varying lowp vec4 xlv_COLOR0;
					varying highp vec2 xlv_TEXCOORD0;
					void main ()
					{
					  lowp vec4 col_1;
					  lowp vec4 tmpvar_2;
					  tmpvar_2 = texture2D (_MainTex, xlv_TEXCOORD0);
					  col_1.xyz = tmpvar_2.xyz;
					  col_1.w = (tmpvar_2.w * xlv_COLOR0.w);
					  col_1 = (_Color * col_1);
					  if ((col_1.w <= 0.0)) {
					    discard;
					  };
					  gl_FragData[0] = col_1;
					}
					
					
					#endif"
				}
				SubProgram "gles3 hw_tier00 " {
					"!!GLES3
					#ifdef VERTEX
					#version 300 es
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					in highp vec3 in_POSITION0;
					in mediump vec4 in_COLOR0;
					in highp vec3 in_TEXCOORD0;
					out mediump vec4 vs_COLOR0;
					out highp vec2 vs_TEXCOORD0;
					highp  vec4 phase0_Output0_1;
					out highp vec2 vs_TEXCOORD1;
					vec4 u_xlat0;
					vec4 u_xlat1;
					void main()
					{
					    vs_COLOR0 = in_COLOR0;
					#ifdef UNITY_ADRENO_ES3
					    vs_COLOR0 = min(max(vs_COLOR0, 0.0), 1.0);
					#else
					    vs_COLOR0 = clamp(vs_COLOR0, 0.0, 1.0);
					#endif
					    phase0_Output0_1 = in_TEXCOORD0.xyxy * _MainTex_ST.xyxy + _MainTex_ST.zwzw;
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_1.xy;
					vs_TEXCOORD1 = phase0_Output0_1.zw;
					    return;
					}
					
					#endif
					#ifdef FRAGMENT
					#version 300 es
					
					precision highp int;
					uniform 	mediump vec4 _Color;
					uniform lowp sampler2D _MainTex;
					in mediump vec4 vs_COLOR0;
					in highp vec2 vs_TEXCOORD0;
					layout(location = 0) out mediump vec4 SV_Target0;
					lowp vec4 u_xlat10_0;
					bool u_xlatb0;
					mediump float u_xlat16_1;
					void main()
					{
					    u_xlat10_0 = texture(_MainTex, vs_TEXCOORD0.xy);
					    u_xlat16_1 = u_xlat10_0.w * vs_COLOR0.w;
					    SV_Target0.xyz = u_xlat10_0.xyz * _Color.xyz;
					    u_xlat16_1 = u_xlat16_1 * _Color.w;
					#ifdef UNITY_ADRENO_ES3
					    u_xlatb0 = !!(0.0>=u_xlat16_1);
					#else
					    u_xlatb0 = 0.0>=u_xlat16_1;
					#endif
					    SV_Target0.w = u_xlat16_1;
					    if((int(u_xlatb0) * int(0xffffffffu))!=0){discard;}
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
					uniform 	vec4 _MainTex_ST;
					in highp vec3 in_POSITION0;
					in mediump vec4 in_COLOR0;
					in highp vec3 in_TEXCOORD0;
					out mediump vec4 vs_COLOR0;
					out highp vec2 vs_TEXCOORD0;
					highp  vec4 phase0_Output0_1;
					out highp vec2 vs_TEXCOORD1;
					vec4 u_xlat0;
					vec4 u_xlat1;
					void main()
					{
					    vs_COLOR0 = in_COLOR0;
					#ifdef UNITY_ADRENO_ES3
					    vs_COLOR0 = min(max(vs_COLOR0, 0.0), 1.0);
					#else
					    vs_COLOR0 = clamp(vs_COLOR0, 0.0, 1.0);
					#endif
					    phase0_Output0_1 = in_TEXCOORD0.xyxy * _MainTex_ST.xyxy + _MainTex_ST.zwzw;
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_1.xy;
					vs_TEXCOORD1 = phase0_Output0_1.zw;
					    return;
					}
					
					#endif
					#ifdef FRAGMENT
					#version 300 es
					
					precision highp int;
					uniform 	mediump vec4 _Color;
					uniform lowp sampler2D _MainTex;
					in mediump vec4 vs_COLOR0;
					in highp vec2 vs_TEXCOORD0;
					layout(location = 0) out mediump vec4 SV_Target0;
					lowp vec4 u_xlat10_0;
					bool u_xlatb0;
					mediump float u_xlat16_1;
					void main()
					{
					    u_xlat10_0 = texture(_MainTex, vs_TEXCOORD0.xy);
					    u_xlat16_1 = u_xlat10_0.w * vs_COLOR0.w;
					    SV_Target0.xyz = u_xlat10_0.xyz * _Color.xyz;
					    u_xlat16_1 = u_xlat16_1 * _Color.w;
					#ifdef UNITY_ADRENO_ES3
					    u_xlatb0 = !!(0.0>=u_xlat16_1);
					#else
					    u_xlatb0 = 0.0>=u_xlat16_1;
					#endif
					    SV_Target0.w = u_xlat16_1;
					    if((int(u_xlatb0) * int(0xffffffffu))!=0){discard;}
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
					uniform 	vec4 _MainTex_ST;
					in highp vec3 in_POSITION0;
					in mediump vec4 in_COLOR0;
					in highp vec3 in_TEXCOORD0;
					out mediump vec4 vs_COLOR0;
					out highp vec2 vs_TEXCOORD0;
					highp  vec4 phase0_Output0_1;
					out highp vec2 vs_TEXCOORD1;
					vec4 u_xlat0;
					vec4 u_xlat1;
					void main()
					{
					    vs_COLOR0 = in_COLOR0;
					#ifdef UNITY_ADRENO_ES3
					    vs_COLOR0 = min(max(vs_COLOR0, 0.0), 1.0);
					#else
					    vs_COLOR0 = clamp(vs_COLOR0, 0.0, 1.0);
					#endif
					    phase0_Output0_1 = in_TEXCOORD0.xyxy * _MainTex_ST.xyxy + _MainTex_ST.zwzw;
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_1.xy;
					vs_TEXCOORD1 = phase0_Output0_1.zw;
					    return;
					}
					
					#endif
					#ifdef FRAGMENT
					#version 300 es
					
					precision highp int;
					uniform 	mediump vec4 _Color;
					uniform lowp sampler2D _MainTex;
					in mediump vec4 vs_COLOR0;
					in highp vec2 vs_TEXCOORD0;
					layout(location = 0) out mediump vec4 SV_Target0;
					lowp vec4 u_xlat10_0;
					bool u_xlatb0;
					mediump float u_xlat16_1;
					void main()
					{
					    u_xlat10_0 = texture(_MainTex, vs_TEXCOORD0.xy);
					    u_xlat16_1 = u_xlat10_0.w * vs_COLOR0.w;
					    SV_Target0.xyz = u_xlat10_0.xyz * _Color.xyz;
					    u_xlat16_1 = u_xlat16_1 * _Color.w;
					#ifdef UNITY_ADRENO_ES3
					    u_xlatb0 = !!(0.0>=u_xlat16_1);
					#else
					    u_xlatb0 = 0.0>=u_xlat16_1;
					#endif
					    SV_Target0.w = u_xlat16_1;
					    if((int(u_xlatb0) * int(0xffffffffu))!=0){discard;}
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "FOG_EXP2" }
					"!!GLES
					#version 100
					
					#ifdef VERTEX
					attribute vec4 _glesVertex;
					attribute vec4 _glesColor;
					attribute vec4 _glesMultiTexCoord0;
					uniform highp mat4 unity_ObjectToWorld;
					uniform highp mat4 unity_MatrixV;
					uniform highp mat4 unity_MatrixVP;
					uniform highp vec4 unity_FogParams;
					uniform highp vec4 _MainTex_ST;
					varying lowp vec4 xlv_COLOR0;
					varying highp vec2 xlv_TEXCOORD0;
					varying highp vec2 xlv_TEXCOORD1;
					varying lowp float xlv_TEXCOORD2;
					void main ()
					{
					  highp vec3 tmpvar_1;
					  tmpvar_1 = _glesVertex.xyz;
					  highp vec4 tmpvar_2;
					  tmpvar_2.w = 1.0;
					  tmpvar_2.xyz = tmpvar_1;
					  highp vec3 tmpvar_3;
					  tmpvar_3 = ((unity_MatrixV * unity_ObjectToWorld) * tmpvar_2).xyz;
					  lowp vec4 tmpvar_4;
					  mediump vec4 tmpvar_5;
					  tmpvar_5 = clamp (_glesColor, 0.0, 1.0);
					  tmpvar_4 = tmpvar_5;
					  highp float tmpvar_6;
					  tmpvar_6 = (unity_FogParams.x * sqrt(dot (tmpvar_3, tmpvar_3)));
					  lowp float tmpvar_7;
					  highp float tmpvar_8;
					  tmpvar_8 = clamp (exp2((
					    -(tmpvar_6)
					   * tmpvar_6)), 0.0, 1.0);
					  tmpvar_7 = tmpvar_8;
					  highp vec4 tmpvar_9;
					  tmpvar_9.w = 1.0;
					  tmpvar_9.xyz = tmpvar_1;
					  xlv_COLOR0 = tmpvar_4;
					  highp vec2 tmpvar_10;
					  tmpvar_10 = (_glesMultiTexCoord0.xy * _MainTex_ST.xy);
					  xlv_TEXCOORD0 = (tmpvar_10 + _MainTex_ST.zw);
					  xlv_TEXCOORD1 = (tmpvar_10 + _MainTex_ST.zw);
					  xlv_TEXCOORD2 = tmpvar_7;
					  gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar_9));
					}
					
					
					#endif
					#ifdef FRAGMENT
					uniform lowp vec4 unity_FogColor;
					uniform sampler2D _MainTex;
					uniform lowp vec4 _Color;
					varying lowp vec4 xlv_COLOR0;
					varying highp vec2 xlv_TEXCOORD0;
					varying lowp float xlv_TEXCOORD2;
					void main ()
					{
					  lowp vec4 col_1;
					  lowp vec4 tmpvar_2;
					  tmpvar_2 = texture2D (_MainTex, xlv_TEXCOORD0);
					  col_1.xyz = tmpvar_2.xyz;
					  col_1.w = (tmpvar_2.w * xlv_COLOR0.w);
					  col_1 = (_Color * col_1);
					  if ((col_1.w <= 0.0)) {
					    discard;
					  };
					  col_1.xyz = mix (unity_FogColor.xyz, col_1.xyz, vec3(xlv_TEXCOORD2));
					  gl_FragData[0] = col_1;
					}
					
					
					#endif"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "FOG_EXP2" }
					"!!GLES
					#version 100
					
					#ifdef VERTEX
					attribute vec4 _glesVertex;
					attribute vec4 _glesColor;
					attribute vec4 _glesMultiTexCoord0;
					uniform highp mat4 unity_ObjectToWorld;
					uniform highp mat4 unity_MatrixV;
					uniform highp mat4 unity_MatrixVP;
					uniform highp vec4 unity_FogParams;
					uniform highp vec4 _MainTex_ST;
					varying lowp vec4 xlv_COLOR0;
					varying highp vec2 xlv_TEXCOORD0;
					varying highp vec2 xlv_TEXCOORD1;
					varying lowp float xlv_TEXCOORD2;
					void main ()
					{
					  highp vec3 tmpvar_1;
					  tmpvar_1 = _glesVertex.xyz;
					  highp vec4 tmpvar_2;
					  tmpvar_2.w = 1.0;
					  tmpvar_2.xyz = tmpvar_1;
					  highp vec3 tmpvar_3;
					  tmpvar_3 = ((unity_MatrixV * unity_ObjectToWorld) * tmpvar_2).xyz;
					  lowp vec4 tmpvar_4;
					  mediump vec4 tmpvar_5;
					  tmpvar_5 = clamp (_glesColor, 0.0, 1.0);
					  tmpvar_4 = tmpvar_5;
					  highp float tmpvar_6;
					  tmpvar_6 = (unity_FogParams.x * sqrt(dot (tmpvar_3, tmpvar_3)));
					  lowp float tmpvar_7;
					  highp float tmpvar_8;
					  tmpvar_8 = clamp (exp2((
					    -(tmpvar_6)
					   * tmpvar_6)), 0.0, 1.0);
					  tmpvar_7 = tmpvar_8;
					  highp vec4 tmpvar_9;
					  tmpvar_9.w = 1.0;
					  tmpvar_9.xyz = tmpvar_1;
					  xlv_COLOR0 = tmpvar_4;
					  highp vec2 tmpvar_10;
					  tmpvar_10 = (_glesMultiTexCoord0.xy * _MainTex_ST.xy);
					  xlv_TEXCOORD0 = (tmpvar_10 + _MainTex_ST.zw);
					  xlv_TEXCOORD1 = (tmpvar_10 + _MainTex_ST.zw);
					  xlv_TEXCOORD2 = tmpvar_7;
					  gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar_9));
					}
					
					
					#endif
					#ifdef FRAGMENT
					uniform lowp vec4 unity_FogColor;
					uniform sampler2D _MainTex;
					uniform lowp vec4 _Color;
					varying lowp vec4 xlv_COLOR0;
					varying highp vec2 xlv_TEXCOORD0;
					varying lowp float xlv_TEXCOORD2;
					void main ()
					{
					  lowp vec4 col_1;
					  lowp vec4 tmpvar_2;
					  tmpvar_2 = texture2D (_MainTex, xlv_TEXCOORD0);
					  col_1.xyz = tmpvar_2.xyz;
					  col_1.w = (tmpvar_2.w * xlv_COLOR0.w);
					  col_1 = (_Color * col_1);
					  if ((col_1.w <= 0.0)) {
					    discard;
					  };
					  col_1.xyz = mix (unity_FogColor.xyz, col_1.xyz, vec3(xlv_TEXCOORD2));
					  gl_FragData[0] = col_1;
					}
					
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "FOG_EXP2" }
					"!!GLES
					#version 100
					
					#ifdef VERTEX
					attribute vec4 _glesVertex;
					attribute vec4 _glesColor;
					attribute vec4 _glesMultiTexCoord0;
					uniform highp mat4 unity_ObjectToWorld;
					uniform highp mat4 unity_MatrixV;
					uniform highp mat4 unity_MatrixVP;
					uniform highp vec4 unity_FogParams;
					uniform highp vec4 _MainTex_ST;
					varying lowp vec4 xlv_COLOR0;
					varying highp vec2 xlv_TEXCOORD0;
					varying highp vec2 xlv_TEXCOORD1;
					varying lowp float xlv_TEXCOORD2;
					void main ()
					{
					  highp vec3 tmpvar_1;
					  tmpvar_1 = _glesVertex.xyz;
					  highp vec4 tmpvar_2;
					  tmpvar_2.w = 1.0;
					  tmpvar_2.xyz = tmpvar_1;
					  highp vec3 tmpvar_3;
					  tmpvar_3 = ((unity_MatrixV * unity_ObjectToWorld) * tmpvar_2).xyz;
					  lowp vec4 tmpvar_4;
					  mediump vec4 tmpvar_5;
					  tmpvar_5 = clamp (_glesColor, 0.0, 1.0);
					  tmpvar_4 = tmpvar_5;
					  highp float tmpvar_6;
					  tmpvar_6 = (unity_FogParams.x * sqrt(dot (tmpvar_3, tmpvar_3)));
					  lowp float tmpvar_7;
					  highp float tmpvar_8;
					  tmpvar_8 = clamp (exp2((
					    -(tmpvar_6)
					   * tmpvar_6)), 0.0, 1.0);
					  tmpvar_7 = tmpvar_8;
					  highp vec4 tmpvar_9;
					  tmpvar_9.w = 1.0;
					  tmpvar_9.xyz = tmpvar_1;
					  xlv_COLOR0 = tmpvar_4;
					  highp vec2 tmpvar_10;
					  tmpvar_10 = (_glesMultiTexCoord0.xy * _MainTex_ST.xy);
					  xlv_TEXCOORD0 = (tmpvar_10 + _MainTex_ST.zw);
					  xlv_TEXCOORD1 = (tmpvar_10 + _MainTex_ST.zw);
					  xlv_TEXCOORD2 = tmpvar_7;
					  gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar_9));
					}
					
					
					#endif
					#ifdef FRAGMENT
					uniform lowp vec4 unity_FogColor;
					uniform sampler2D _MainTex;
					uniform lowp vec4 _Color;
					varying lowp vec4 xlv_COLOR0;
					varying highp vec2 xlv_TEXCOORD0;
					varying lowp float xlv_TEXCOORD2;
					void main ()
					{
					  lowp vec4 col_1;
					  lowp vec4 tmpvar_2;
					  tmpvar_2 = texture2D (_MainTex, xlv_TEXCOORD0);
					  col_1.xyz = tmpvar_2.xyz;
					  col_1.w = (tmpvar_2.w * xlv_COLOR0.w);
					  col_1 = (_Color * col_1);
					  if ((col_1.w <= 0.0)) {
					    discard;
					  };
					  col_1.xyz = mix (unity_FogColor.xyz, col_1.xyz, vec3(xlv_TEXCOORD2));
					  gl_FragData[0] = col_1;
					}
					
					
					#endif"
				}
				SubProgram "gles3 hw_tier00 " {
					Keywords { "FOG_EXP2" }
					"!!GLES3
					#ifdef VERTEX
					#version 300 es
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixV[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 unity_FogParams;
					uniform 	vec4 _MainTex_ST;
					in highp vec3 in_POSITION0;
					in mediump vec4 in_COLOR0;
					in highp vec3 in_TEXCOORD0;
					out mediump vec4 vs_COLOR0;
					out highp vec2 vs_TEXCOORD0;
					highp  vec4 phase0_Output0_1;
					out highp vec2 vs_TEXCOORD1;
					out mediump float vs_TEXCOORD2;
					vec4 u_xlat0;
					vec4 u_xlat1;
					void main()
					{
					    vs_COLOR0 = in_COLOR0;
					#ifdef UNITY_ADRENO_ES3
					    vs_COLOR0 = min(max(vs_COLOR0, 0.0), 1.0);
					#else
					    vs_COLOR0 = clamp(vs_COLOR0, 0.0, 1.0);
					#endif
					    phase0_Output0_1 = in_TEXCOORD0.xyxy * _MainTex_ST.xyxy + _MainTex_ST.zwzw;
					    u_xlat0.xyz = hlslcc_mtx4x4unity_ObjectToWorld[1].yyy * hlslcc_mtx4x4unity_MatrixV[1].xyz;
					    u_xlat0.xyz = hlslcc_mtx4x4unity_MatrixV[0].xyz * hlslcc_mtx4x4unity_ObjectToWorld[1].xxx + u_xlat0.xyz;
					    u_xlat0.xyz = hlslcc_mtx4x4unity_MatrixV[2].xyz * hlslcc_mtx4x4unity_ObjectToWorld[1].zzz + u_xlat0.xyz;
					    u_xlat0.xyz = hlslcc_mtx4x4unity_MatrixV[3].xyz * hlslcc_mtx4x4unity_ObjectToWorld[1].www + u_xlat0.xyz;
					    u_xlat0.xyz = u_xlat0.xyz * in_POSITION0.yyy;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_ObjectToWorld[0].yyy * hlslcc_mtx4x4unity_MatrixV[1].xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_MatrixV[0].xyz * hlslcc_mtx4x4unity_ObjectToWorld[0].xxx + u_xlat1.xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_MatrixV[2].xyz * hlslcc_mtx4x4unity_ObjectToWorld[0].zzz + u_xlat1.xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_MatrixV[3].xyz * hlslcc_mtx4x4unity_ObjectToWorld[0].www + u_xlat1.xyz;
					    u_xlat0.xyz = u_xlat1.xyz * in_POSITION0.xxx + u_xlat0.xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_ObjectToWorld[2].yyy * hlslcc_mtx4x4unity_MatrixV[1].xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_MatrixV[0].xyz * hlslcc_mtx4x4unity_ObjectToWorld[2].xxx + u_xlat1.xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_MatrixV[2].xyz * hlslcc_mtx4x4unity_ObjectToWorld[2].zzz + u_xlat1.xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_MatrixV[3].xyz * hlslcc_mtx4x4unity_ObjectToWorld[2].www + u_xlat1.xyz;
					    u_xlat0.xyz = u_xlat1.xyz * in_POSITION0.zzz + u_xlat0.xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_ObjectToWorld[3].yyy * hlslcc_mtx4x4unity_MatrixV[1].xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_MatrixV[0].xyz * hlslcc_mtx4x4unity_ObjectToWorld[3].xxx + u_xlat1.xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_MatrixV[2].xyz * hlslcc_mtx4x4unity_ObjectToWorld[3].zzz + u_xlat1.xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_MatrixV[3].xyz * hlslcc_mtx4x4unity_ObjectToWorld[3].www + u_xlat1.xyz;
					    u_xlat0.xyz = u_xlat0.xyz + u_xlat1.xyz;
					    u_xlat0.x = dot(u_xlat0.xyz, u_xlat0.xyz);
					    u_xlat0.x = sqrt(u_xlat0.x);
					    u_xlat0.x = u_xlat0.x * unity_FogParams.x;
					    u_xlat0.x = u_xlat0.x * (-u_xlat0.x);
					    vs_TEXCOORD2 = exp2(u_xlat0.x);
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_1.xy;
					vs_TEXCOORD1 = phase0_Output0_1.zw;
					    return;
					}
					
					#endif
					#ifdef FRAGMENT
					#version 300 es
					
					precision highp int;
					uniform 	mediump vec4 unity_FogColor;
					uniform 	mediump vec4 _Color;
					uniform lowp sampler2D _MainTex;
					in mediump vec4 vs_COLOR0;
					in highp vec2 vs_TEXCOORD0;
					in mediump float vs_TEXCOORD2;
					layout(location = 0) out mediump vec4 SV_Target0;
					lowp vec4 u_xlat10_0;
					bool u_xlatb0;
					mediump float u_xlat16_1;
					mediump vec3 u_xlat16_3;
					void main()
					{
					    u_xlat10_0 = texture(_MainTex, vs_TEXCOORD0.xy);
					    u_xlat16_1 = u_xlat10_0.w * vs_COLOR0.w;
					    u_xlat16_3.xyz = _Color.xyz * u_xlat10_0.xyz + (-unity_FogColor.xyz);
					    SV_Target0.xyz = vec3(vs_TEXCOORD2) * u_xlat16_3.xyz + unity_FogColor.xyz;
					    u_xlat16_1 = u_xlat16_1 * _Color.w;
					#ifdef UNITY_ADRENO_ES3
					    u_xlatb0 = !!(0.0>=u_xlat16_1);
					#else
					    u_xlatb0 = 0.0>=u_xlat16_1;
					#endif
					    SV_Target0.w = u_xlat16_1;
					    if((int(u_xlatb0) * int(0xffffffffu))!=0){discard;}
					    return;
					}
					
					#endif"
				}
				SubProgram "gles3 hw_tier01 " {
					Keywords { "FOG_EXP2" }
					"!!GLES3
					#ifdef VERTEX
					#version 300 es
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixV[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 unity_FogParams;
					uniform 	vec4 _MainTex_ST;
					in highp vec3 in_POSITION0;
					in mediump vec4 in_COLOR0;
					in highp vec3 in_TEXCOORD0;
					out mediump vec4 vs_COLOR0;
					out highp vec2 vs_TEXCOORD0;
					highp  vec4 phase0_Output0_1;
					out highp vec2 vs_TEXCOORD1;
					out mediump float vs_TEXCOORD2;
					vec4 u_xlat0;
					vec4 u_xlat1;
					void main()
					{
					    vs_COLOR0 = in_COLOR0;
					#ifdef UNITY_ADRENO_ES3
					    vs_COLOR0 = min(max(vs_COLOR0, 0.0), 1.0);
					#else
					    vs_COLOR0 = clamp(vs_COLOR0, 0.0, 1.0);
					#endif
					    phase0_Output0_1 = in_TEXCOORD0.xyxy * _MainTex_ST.xyxy + _MainTex_ST.zwzw;
					    u_xlat0.xyz = hlslcc_mtx4x4unity_ObjectToWorld[1].yyy * hlslcc_mtx4x4unity_MatrixV[1].xyz;
					    u_xlat0.xyz = hlslcc_mtx4x4unity_MatrixV[0].xyz * hlslcc_mtx4x4unity_ObjectToWorld[1].xxx + u_xlat0.xyz;
					    u_xlat0.xyz = hlslcc_mtx4x4unity_MatrixV[2].xyz * hlslcc_mtx4x4unity_ObjectToWorld[1].zzz + u_xlat0.xyz;
					    u_xlat0.xyz = hlslcc_mtx4x4unity_MatrixV[3].xyz * hlslcc_mtx4x4unity_ObjectToWorld[1].www + u_xlat0.xyz;
					    u_xlat0.xyz = u_xlat0.xyz * in_POSITION0.yyy;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_ObjectToWorld[0].yyy * hlslcc_mtx4x4unity_MatrixV[1].xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_MatrixV[0].xyz * hlslcc_mtx4x4unity_ObjectToWorld[0].xxx + u_xlat1.xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_MatrixV[2].xyz * hlslcc_mtx4x4unity_ObjectToWorld[0].zzz + u_xlat1.xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_MatrixV[3].xyz * hlslcc_mtx4x4unity_ObjectToWorld[0].www + u_xlat1.xyz;
					    u_xlat0.xyz = u_xlat1.xyz * in_POSITION0.xxx + u_xlat0.xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_ObjectToWorld[2].yyy * hlslcc_mtx4x4unity_MatrixV[1].xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_MatrixV[0].xyz * hlslcc_mtx4x4unity_ObjectToWorld[2].xxx + u_xlat1.xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_MatrixV[2].xyz * hlslcc_mtx4x4unity_ObjectToWorld[2].zzz + u_xlat1.xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_MatrixV[3].xyz * hlslcc_mtx4x4unity_ObjectToWorld[2].www + u_xlat1.xyz;
					    u_xlat0.xyz = u_xlat1.xyz * in_POSITION0.zzz + u_xlat0.xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_ObjectToWorld[3].yyy * hlslcc_mtx4x4unity_MatrixV[1].xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_MatrixV[0].xyz * hlslcc_mtx4x4unity_ObjectToWorld[3].xxx + u_xlat1.xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_MatrixV[2].xyz * hlslcc_mtx4x4unity_ObjectToWorld[3].zzz + u_xlat1.xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_MatrixV[3].xyz * hlslcc_mtx4x4unity_ObjectToWorld[3].www + u_xlat1.xyz;
					    u_xlat0.xyz = u_xlat0.xyz + u_xlat1.xyz;
					    u_xlat0.x = dot(u_xlat0.xyz, u_xlat0.xyz);
					    u_xlat0.x = sqrt(u_xlat0.x);
					    u_xlat0.x = u_xlat0.x * unity_FogParams.x;
					    u_xlat0.x = u_xlat0.x * (-u_xlat0.x);
					    vs_TEXCOORD2 = exp2(u_xlat0.x);
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_1.xy;
					vs_TEXCOORD1 = phase0_Output0_1.zw;
					    return;
					}
					
					#endif
					#ifdef FRAGMENT
					#version 300 es
					
					precision highp int;
					uniform 	mediump vec4 unity_FogColor;
					uniform 	mediump vec4 _Color;
					uniform lowp sampler2D _MainTex;
					in mediump vec4 vs_COLOR0;
					in highp vec2 vs_TEXCOORD0;
					in mediump float vs_TEXCOORD2;
					layout(location = 0) out mediump vec4 SV_Target0;
					lowp vec4 u_xlat10_0;
					bool u_xlatb0;
					mediump float u_xlat16_1;
					mediump vec3 u_xlat16_3;
					void main()
					{
					    u_xlat10_0 = texture(_MainTex, vs_TEXCOORD0.xy);
					    u_xlat16_1 = u_xlat10_0.w * vs_COLOR0.w;
					    u_xlat16_3.xyz = _Color.xyz * u_xlat10_0.xyz + (-unity_FogColor.xyz);
					    SV_Target0.xyz = vec3(vs_TEXCOORD2) * u_xlat16_3.xyz + unity_FogColor.xyz;
					    u_xlat16_1 = u_xlat16_1 * _Color.w;
					#ifdef UNITY_ADRENO_ES3
					    u_xlatb0 = !!(0.0>=u_xlat16_1);
					#else
					    u_xlatb0 = 0.0>=u_xlat16_1;
					#endif
					    SV_Target0.w = u_xlat16_1;
					    if((int(u_xlatb0) * int(0xffffffffu))!=0){discard;}
					    return;
					}
					
					#endif"
				}
				SubProgram "gles3 hw_tier02 " {
					Keywords { "FOG_EXP2" }
					"!!GLES3
					#ifdef VERTEX
					#version 300 es
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixV[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 unity_FogParams;
					uniform 	vec4 _MainTex_ST;
					in highp vec3 in_POSITION0;
					in mediump vec4 in_COLOR0;
					in highp vec3 in_TEXCOORD0;
					out mediump vec4 vs_COLOR0;
					out highp vec2 vs_TEXCOORD0;
					highp  vec4 phase0_Output0_1;
					out highp vec2 vs_TEXCOORD1;
					out mediump float vs_TEXCOORD2;
					vec4 u_xlat0;
					vec4 u_xlat1;
					void main()
					{
					    vs_COLOR0 = in_COLOR0;
					#ifdef UNITY_ADRENO_ES3
					    vs_COLOR0 = min(max(vs_COLOR0, 0.0), 1.0);
					#else
					    vs_COLOR0 = clamp(vs_COLOR0, 0.0, 1.0);
					#endif
					    phase0_Output0_1 = in_TEXCOORD0.xyxy * _MainTex_ST.xyxy + _MainTex_ST.zwzw;
					    u_xlat0.xyz = hlslcc_mtx4x4unity_ObjectToWorld[1].yyy * hlslcc_mtx4x4unity_MatrixV[1].xyz;
					    u_xlat0.xyz = hlslcc_mtx4x4unity_MatrixV[0].xyz * hlslcc_mtx4x4unity_ObjectToWorld[1].xxx + u_xlat0.xyz;
					    u_xlat0.xyz = hlslcc_mtx4x4unity_MatrixV[2].xyz * hlslcc_mtx4x4unity_ObjectToWorld[1].zzz + u_xlat0.xyz;
					    u_xlat0.xyz = hlslcc_mtx4x4unity_MatrixV[3].xyz * hlslcc_mtx4x4unity_ObjectToWorld[1].www + u_xlat0.xyz;
					    u_xlat0.xyz = u_xlat0.xyz * in_POSITION0.yyy;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_ObjectToWorld[0].yyy * hlslcc_mtx4x4unity_MatrixV[1].xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_MatrixV[0].xyz * hlslcc_mtx4x4unity_ObjectToWorld[0].xxx + u_xlat1.xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_MatrixV[2].xyz * hlslcc_mtx4x4unity_ObjectToWorld[0].zzz + u_xlat1.xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_MatrixV[3].xyz * hlslcc_mtx4x4unity_ObjectToWorld[0].www + u_xlat1.xyz;
					    u_xlat0.xyz = u_xlat1.xyz * in_POSITION0.xxx + u_xlat0.xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_ObjectToWorld[2].yyy * hlslcc_mtx4x4unity_MatrixV[1].xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_MatrixV[0].xyz * hlslcc_mtx4x4unity_ObjectToWorld[2].xxx + u_xlat1.xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_MatrixV[2].xyz * hlslcc_mtx4x4unity_ObjectToWorld[2].zzz + u_xlat1.xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_MatrixV[3].xyz * hlslcc_mtx4x4unity_ObjectToWorld[2].www + u_xlat1.xyz;
					    u_xlat0.xyz = u_xlat1.xyz * in_POSITION0.zzz + u_xlat0.xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_ObjectToWorld[3].yyy * hlslcc_mtx4x4unity_MatrixV[1].xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_MatrixV[0].xyz * hlslcc_mtx4x4unity_ObjectToWorld[3].xxx + u_xlat1.xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_MatrixV[2].xyz * hlslcc_mtx4x4unity_ObjectToWorld[3].zzz + u_xlat1.xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_MatrixV[3].xyz * hlslcc_mtx4x4unity_ObjectToWorld[3].www + u_xlat1.xyz;
					    u_xlat0.xyz = u_xlat0.xyz + u_xlat1.xyz;
					    u_xlat0.x = dot(u_xlat0.xyz, u_xlat0.xyz);
					    u_xlat0.x = sqrt(u_xlat0.x);
					    u_xlat0.x = u_xlat0.x * unity_FogParams.x;
					    u_xlat0.x = u_xlat0.x * (-u_xlat0.x);
					    vs_TEXCOORD2 = exp2(u_xlat0.x);
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_1.xy;
					vs_TEXCOORD1 = phase0_Output0_1.zw;
					    return;
					}
					
					#endif
					#ifdef FRAGMENT
					#version 300 es
					
					precision highp int;
					uniform 	mediump vec4 unity_FogColor;
					uniform 	mediump vec4 _Color;
					uniform lowp sampler2D _MainTex;
					in mediump vec4 vs_COLOR0;
					in highp vec2 vs_TEXCOORD0;
					in mediump float vs_TEXCOORD2;
					layout(location = 0) out mediump vec4 SV_Target0;
					lowp vec4 u_xlat10_0;
					bool u_xlatb0;
					mediump float u_xlat16_1;
					mediump vec3 u_xlat16_3;
					void main()
					{
					    u_xlat10_0 = texture(_MainTex, vs_TEXCOORD0.xy);
					    u_xlat16_1 = u_xlat10_0.w * vs_COLOR0.w;
					    u_xlat16_3.xyz = _Color.xyz * u_xlat10_0.xyz + (-unity_FogColor.xyz);
					    SV_Target0.xyz = vec3(vs_TEXCOORD2) * u_xlat16_3.xyz + unity_FogColor.xyz;
					    u_xlat16_1 = u_xlat16_1 * _Color.w;
					#ifdef UNITY_ADRENO_ES3
					    u_xlatb0 = !!(0.0>=u_xlat16_1);
					#else
					    u_xlatb0 = 0.0>=u_xlat16_1;
					#endif
					    SV_Target0.w = u_xlat16_1;
					    if((int(u_xlatb0) * int(0xffffffffu))!=0){discard;}
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
				SubProgram "gles hw_tier00 " {
					Keywords { "FOG_EXP2" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "FOG_EXP2" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "FOG_EXP2" }
					"!!GLES"
				}
				SubProgram "gles3 hw_tier00 " {
					Keywords { "FOG_EXP2" }
					"!!GLES3"
				}
				SubProgram "gles3 hw_tier01 " {
					Keywords { "FOG_EXP2" }
					"!!GLES3"
				}
				SubProgram "gles3 hw_tier02 " {
					Keywords { "FOG_EXP2" }
					"!!GLES3"
				}
			}
		}
	}
	Fallback "Transparent/VertexLit"
}