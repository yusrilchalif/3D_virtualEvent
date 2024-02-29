using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToPicture : MonoBehaviour
{
    public float zoomSpeed = 5f;
    public float maxRaycastDistance = 10f; // Jarak maksimum raycast
    public float maxZoomDistance = 3f; // Batas maksimum jarak zoom

    private Camera mainCamera;
    private Vector3 originalPosition;
    private bool isZoomed = false;
    private Transform targetImage;

    void Start()
    {
        mainCamera = Camera.main;
        originalPosition = mainCamera.transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Ganti dengan input yang sesuai (misalnya touch input untuk perangkat mobile)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, maxRaycastDistance))
            {
                if (hit.collider.CompareTag("Picture"))
                {
                    targetImage = hit.collider.transform;
                    ToggleZoom();
                }
            }
        }

        if (isZoomed)
        {
            // Setel kamera ke posisi target gambar
            mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, targetImage.position, Time.deltaTime * zoomSpeed);

            // Batasi jarak zoom
            float distance = Vector3.Distance(mainCamera.transform.position, targetImage.position);
            if (distance > maxZoomDistance)
            {
                mainCamera.transform.position = (mainCamera.transform.position - targetImage.position).normalized * maxZoomDistance + targetImage.position;
            }
        }
    }

    void ToggleZoom()
    {
        isZoomed = !isZoomed;

        if (!isZoomed)
        {
            // Kembalikan kamera ke posisi awal
            mainCamera.transform.position = originalPosition;
        }
    }
}
