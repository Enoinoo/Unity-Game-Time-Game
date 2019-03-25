using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportAblity : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            Debug.Log("flash key pressed" + Time.time);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 mousePos = hit.point;
                Debug.Log("x.pos" + mousePos.x);
                Debug.Log("y.pos" + mousePos.y);
                transform.position = mousePos;
            }
            else
            {
            }
        }
    }
}
