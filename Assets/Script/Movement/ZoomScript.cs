using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomScript : MonoBehaviour
{
    public float zoomSpeed = 5.0f;
    public float minimDistance = 2.0f;
    public float maxDistance = 5.0f;

    private bool isZooming;
    private Camera camera;
    private Transform playerTransform;

    private void Start()
    {
        camera = GetComponentInChildren<Camera>();
        playerTransform = transform.parent.gameObject.transform;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            isZooming = true;
        }
        else
        {
            isZooming = false;
        }

        if(isZooming)
        {
            float changeDistance = zoomSpeed * Time.deltaTime;
            camera.transform.localPosition += new Vector3(0, 0, changeDistance);

            camera.transform.localPosition = Vector3.ClampMagnitude(camera.transform.localPosition, minimDistance);
        }
    }
}
