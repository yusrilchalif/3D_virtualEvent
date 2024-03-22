using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TouchToMove : MonoBehaviour
{
    public Camera camera;
    public NavMeshAgent player;
    public GameObject targetDestination;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                targetDestination.transform.position = hit.point;
                player.SetDestination(hit.point);
            }
        }
    }
}
