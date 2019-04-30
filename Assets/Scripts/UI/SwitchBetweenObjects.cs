using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBetweenObjects : MonoBehaviour {

    public GameObject objectToDeactivate;
    public GameObject objectToActivate;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        objectToActivate.SetActive(true);
        objectToDeactivate.SetActive(false);
    }
}
