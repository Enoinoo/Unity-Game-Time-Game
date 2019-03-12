using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetect : MonoBehaviour
{
    public int flameThrowerIndex = 0;
    public GameObject[] originalParticles;
    public GameObject[] reverseParticlesAccordingly;
    public float fieldOfViewAngle = 110f;

    private GameObject flameThrower;
    private GameObject flameThrowerReverse;
    private FlameRobot flameRobot;
    private bool playerInSight;

    // Start is called before the first frame update
    void Start()
    {
        flameRobot = GetComponentInParent<FlameRobot>();
        flameThrower = originalParticles[flameThrowerIndex];
        flameThrowerReverse = reverseParticlesAccordingly[flameThrowerIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            SwitchParticleSystems(originalParticles, reverseParticlesAccordingly);
        }
        if (Input.GetMouseButtonUp(0)){
            SwitchParticleSystems(reverseParticlesAccordingly, originalParticles);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (!flameRobot.rotateTowards)
        {
            if (col.tag == "Player") flameRobot.rotateTowards = true;
        }

    }

    void OnTriggerExit(Collider col)
    {
        if (flameRobot.rotateTowards)
        {
            if (col.tag == "Player") flameRobot.rotateTowards = false;
        }
        if (flameThrower.activeInHierarchy)
        {
            StopFire();
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player")
        {
            Vector3 direction = col.transform.position - transform.position;
            float angle = Vector3.Angle(direction, transform.forward);

            if (angle < fieldOfViewAngle * 0.5f)
            {
                //RaycastHit hit;
                //if (Physics.Raycast(transform.position + transform.up, direction.normalized, out hit, GetComponent<SphereCollider>().radius))
                //{
                //if (hit.collider.tag == "Player" && !flameThrower.activeInHierarchy)
                    if(!flameThrower.activeInHierarchy)
                    {
                        Fire();
                    }

                //}
            }
            else if (flameThrower.activeInHierarchy)
            {
                StopFire();
            }
        }

    }

    void Fire()
    {
        flameThrower.SetActive(true);
    }

    void StopFire()
    {
        if(flameThrower.activeInHierarchy){
            flameThrower.SetActive(false);
        }
        if (flameThrowerReverse.activeInHierarchy){
            flameThrowerReverse.SetActive(false);
        }
    }

    void SwitchParticleSystems(GameObject[] listA, GameObject[] listB){
        for (int i = 0; i < listB.Length; i++){
            if (listA[i].activeInHierarchy){
                listB[i].SetActive(true);
                listA[i].SetActive(false);
            }
        }
    }

}
