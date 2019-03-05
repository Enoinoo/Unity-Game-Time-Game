using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindParticleSystemActivation : MonoBehaviour
{
	RewindParticleSystem rewindParticleSystem;
    // Start is called before the first frame update
    void Start()
    {
        rewindParticleSystem = GetComponent<RewindParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
        	rewindParticleSystem.enabled = true;
        }
        else if (!Input.GetMouseButton(0)){
        	rewindParticleSystem.enabled = false;
        }
    }
}
