using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToImage : MonoBehaviour
{
    public Camera mainCamera;
    public float approachSpeed = 2;

    // Start is called before the first frame update
    void Start()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider.CompareTag("Picture"))
                {
                    ApproachCamera(hit.collider.gameObject);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ApproachCamera(GameObject imageObject)
    {
        // Ambil posisi kamera lokal dalam koordinat objek gambar
        Vector3 localCameraPosition = imageObject.transform.InverseTransformPoint(mainCamera.transform.position);

        // Tentukan posisi target dalam koordinat lokal objek gambar
        Vector3 targetLocalPosition = new Vector3(0f, 0f, 0f);  // Atur ke posisi yang diinginkan
        Vector3 newLocalPosition = Vector3.MoveTowards(localCameraPosition, targetLocalPosition, approachSpeed * Time.deltaTime);

        // Ubah posisi lokal kamera ke dalam koordinat dunia
        Vector3 newWorldPosition = imageObject.transform.TransformPoint(newLocalPosition);

        // Terapkan posisi baru ke objek gambar
        imageObject.transform.position = newWorldPosition;
    }
}
