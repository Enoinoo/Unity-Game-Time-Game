using System;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
    [ExecuteInEditMode]
    [AddComponentMenu("Image Effects/Color Adjustments/Grayscale")]
    public class Grayscale : ImageEffectBase {
        public Texture  textureRamp;
        
        [Range(-1.0f,1.0f)]       
        public float _Strength = 1.0f;

        //[Range(-1.0f,1.0f)]
        //public float    rampOffset;

        // Called by camera to apply image effect
        void OnRenderImage (RenderTexture source, RenderTexture destination) {
            material.SetTexture("_RampTex", textureRamp);
            //material.SetFloat("_RampOffset", rampOffset);
            Shader.SetGlobalFloat ("_Strength", _Strength);
            Graphics.Blit (source, destination, material);
        }
    }
}
