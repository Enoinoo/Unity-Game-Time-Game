using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxRotation : MonoBehaviour
{
    public float speed = 0.02f;
    public float maxBlurSize = 3f;
    public bool isRewinding = false;
    public AudioSource BackgroundMusic;
    public GameObject[] originalParticles;
    public GameObject[] reverseParticlesAccordingly;

    private AudioSource rewindSoundEffect;

    private UnityStandardAssets.ImageEffects.BlurOptimized blurOptimized;
    private bool decreaseBlurSize = false;
    private UnityStandardAssets.Characters.FirstPerson.FirstPersonController FirstPersonController;
    // Start is called before the first frame update
    void Start()
    {
        blurOptimized = FindObjectOfType<UnityStandardAssets.ImageEffects.BlurOptimized>();
        FirstPersonController = FindObjectOfType<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
        rewindSoundEffect = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (originalParticles.Length != 0 && reverseParticlesAccordingly.Length != 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SwitchParticleSystems(originalParticles, reverseParticlesAccordingly);
            }
            if (Input.GetMouseButtonUp(0))
            {
                SwitchParticleSystems(reverseParticlesAccordingly, originalParticles);
            }
        }
        if (Input.GetMouseButton(0))
        {
            if (!isRewinding) isRewinding = true;
            if (FirstPersonController.canMove) FirstPersonController.canMove = false;
            if (!blurOptimized.enabled)
            {
                blurOptimized.blurSize = 0f;
                blurOptimized.enabled = true;
            }
            RenderSettings.skybox.SetFloat("_Rotation", RenderSettings.skybox.GetFloat("_Rotation") - speed + 0.005f);
            if(BackgroundMusic.pitch == 1f){ BackgroundMusic.pitch = -1.1f;}
            if(!rewindSoundEffect.isPlaying){ rewindSoundEffect.Play();}
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
            if(rewindSoundEffect.isPlaying){rewindSoundEffect.Stop();}
            if(BackgroundMusic.pitch == -1.1f){ BackgroundMusic.pitch = 1f;}
            if (isRewinding) isRewinding = false;
            if (!FirstPersonController.canMove) FirstPersonController.canMove = true;
            if (blurOptimized.enabled) blurOptimized.enabled = false;
            RenderSettings.skybox.SetFloat("_Rotation", RenderSettings.skybox.GetFloat("_Rotation") + speed);
        }
    }

    public void SwitchParticleSystems(GameObject[] listA, GameObject[] listB)
    {
        for (int i = 0; i < listB.Length; i++)
        {
            if (listA[i].activeInHierarchy)
            {
                listB[i].SetActive(true);
                listA[i].SetActive(false);
            }
        }
    }
}
