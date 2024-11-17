Shader "Unlit/AlwaysOnTop"
{

    Properties
    {
        _MainTex ("Particle Texture", 2D) = "white" {} 
    }
    SubShader
    {
        Tags { "Queue" = "Overlay" } 
        Pass
        {
            ZWrite Off      
            ZTest Always     
            Blend SrcAlpha One  
            SetTexture [_MainTex] { combine primary } 
        }
    }

    Fallback "Particles/Alpha Blended"
}
