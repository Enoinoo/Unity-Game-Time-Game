using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportAblity : MonoBehaviour
{
    public GameObject teleportEffect;
    private bool isMoving = false;
    private Vector3 targetPos;
    private GameObject instantiatedEffect;
    private int layerMask;
    private bool isPlayerMoving = false;
    private UnityStandardAssets.Characters.FirstPerson.FirstPersonController FirstPersonController;

    private float time;
    private Vector3 startPos = Vector3.zero;
    private float timeToReachTarget = .1f;

    private Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        layerMask = 1 << 12;
        FirstPersonController = FindObjectOfType<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            //var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Ray ray = new Ray(camera.transform.position, camera.transform.forward);

            if (Physics.Raycast(ray, out hit, 1000f, layerMask))
            {

                instantiatedEffect = Instantiate(teleportEffect, hit.point, Quaternion.identity);
                
            }
        }
        if (Input.GetMouseButton(1))
        {
            SetTarggetPosition();
        }
        if (Input.GetMouseButtonUp(1) && !targetPos.Equals(Vector3.zero))
        {
            /*
            transform.position = targetPos;
            Debug.Log(targetPos);
            Debug.Log(transform.position);
            */
            if (Time.timeScale > 0)
            {
                Time.timeScale = 0;
            }
            isPlayerMoving = true;
            startPos = transform.position;
            targetPos.y += 1.5f;
            Destroy(instantiatedEffect);
        }

        /*
        if (isMoving)
        {
            MoveObject();
        }
        */
    }

    void LateUpdate()
    {
        if (isPlayerMoving)
        {
            MovePlayer();
        }
    }

    void MovePlayer()
    {
        if(FirstPersonController.canMove)
            FirstPersonController.canMove = false;

        if (transform.position != targetPos)
        {
            time += Time.unscaledDeltaTime / timeToReachTarget;
            //transform.position = targetPos;
            transform.position = Vector3.Lerp(startPos, targetPos, time);
            //Debug.Log(Vector3.Lerp(startPos, targetPos, time));
            //Debug.Log("start pos is"+startPos);
            //Debug.Log("target pos is"+targetPos);
            //Debug.Log("time is"+time);
        }

        else {
            isPlayerMoving = false;
            if (Time.timeScale != 1)
            {
                Time.timeScale = 1;
            }
            time = 0f;
            targetPos = Vector3.zero;
        }

    }

    void SetTarggetPosition()
    {
        if (instantiatedEffect)
        {
            /*
            Plane plane = new Plane(Vector3.up, instantiatedEffect.transform.position);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float point = 0f;

            if (plane.Raycast(ray, out point))
            {
                    targetPos = ray.GetPoint(point);
            }*/

            RaycastHit hit;
            //var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Ray ray = new Ray(camera.transform.position, camera.transform.forward);

            if (Physics.Raycast(ray, out hit, 1000f, layerMask))
            {

                targetPos = hit.point;
                
            }
            Debug.DrawLine(Camera.main.transform.position, hit.point, Color.red);

            MoveObject();
        }
    }
    void MoveObject()
    {
        if (instantiatedEffect)
        {
            //transform.LookAt(targetPos);
            instantiatedEffect.transform.position = targetPos;
            /*
            if (instantiatedEffect.transform.position == targetPos)
                isMoving = false;
            Debug.DrawLine(transform.position, targetPos, Color.red);
            */
        }
    }
}
