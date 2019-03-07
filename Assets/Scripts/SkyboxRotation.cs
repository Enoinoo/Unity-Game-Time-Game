using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxRotation : MonoBehaviour
{
    public float speed = 0.02f;
    public float maxBlurSize = 3f;
    private UnityStandardAssets.ImageEffects.BlurOptimized blurOptimized;
    private bool decreaseBlurSize = false;
    private UnityStandardAssets.Characters.FirstPerson.FirstPersonController FirstPersonController;
    // Start is called before the first frame update
    void Start()
    {
        blurOptimized = FindObjectOfType<UnityStandardAssets.ImageEffects.BlurOptimized>();
        FirstPersonController = FindObjectOfType<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            if (FirstPersonController.canMove) FirstPersonController.canMove = false;
            if (!blurOptimized.enabled)
            {
                blurOptimized.blurSize = 0f;
                blurOptimized.enabled = true;
            }
            RenderSettings.skybox.SetFloat("_Rotation", RenderSettings.skybox.GetFloat("_Rotation") - speed + 0.005f);
            if (blurOptimized.blurSize < maxBlurSize && !decreaseBlurSize)
            {
                blurOptimized.blurSize += 0.05f;
            }
            else
            {
                decreaseBlurSize = true;
            }
            if (decreaseBlurSize)
            {
                if (blurOptimized.blurSize > maxBlurSize - .8f) blurOptimized.blurSize -= .03f;
                else decreaseBlurSize = false;
            }
        }
        else
        {
            if (!FirstPersonController.canMove) FirstPersonController.canMove = true;
            if (blurOptimized.enabled) blurOptimized.enabled = false;
            RenderSettings.skybox.SetFloat("_Rotation", RenderSettings.skybox.GetFloat("_Rotation") + speed);
        }
    }
}
