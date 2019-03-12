using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<Asteroid>())
        {
            Debug.Log("initial velocity is" + collider.GetComponent<Asteroid>().rb.velocity);
            collider.GetComponent<Asteroid>().ChangeVelocity();
            Debug.Log("new velocity is" + collider.GetComponent<Asteroid>().rb.velocity);
        }
    }
}
