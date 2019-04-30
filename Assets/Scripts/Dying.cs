using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dying : MonoBehaviour
{
	float slowRate = .05f;
    private UnityStandardAssets.ImageEffects.Grayscale grayscale;

    public bool startDying = false;
    // Start is called before the first frame update
    void Start()
    {
        grayscale = GetComponentInChildren<UnityStandardAssets.ImageEffects.Grayscale>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startDying)
        {
            DyingEffectActivate();
        }
        if (Input.GetMouseButton(0))
        {
            if (startDying) startDying = false;
        }
    }

    void OnParticleCollision(GameObject gameObject)
	{
        if (gameObject.CompareTag("Fire"))
        {
            startDying = true;
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Damage"))
        {
            startDying = true;
        }
    }

    void DyingEffectActivate()
    {
        if (Time.timeScale != 0f)
        {
            //slow down time fast first 
            if (Time.timeScale > .6f)
            {
                Time.timeScale -= (slowRate + .015f);
                grayscale._Strength += (slowRate);
            }
            //then slow down the speed
            else if (Time.timeScale > .3f)
            {
                Time.timeScale -= (slowRate - .01f);
                grayscale._Strength += (slowRate - .01f);
            }
            //slow down the speed even more
            else if (Time.timeScale - (slowRate - .02f) >= 0f)
            {
                Time.timeScale -= (slowRate - .02f);
                grayscale._Strength += (slowRate - .02f);
            }
            //stop time
            else
            {
                Time.timeScale = 0f;
                grayscale._Strength = 1f;
            }
        }
    }
}
