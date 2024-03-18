using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveCloserToPainting : MonoBehaviour
{
    public float moveSpeed = 5f; // Kecepatan pergerakan player
    public float minDistance = 1f; // Jarak minimum antara player dan lukisan
    public LayerMask pictureLayerMask; // LayerMask untuk lukisan

    private Camera mainCamera;
    private CharacterController characterController; // Character Controller player

    private void Start()
    {
        mainCamera = transform.Find("Main Camera").GetComponent<Camera>(); // Mendapatkan referensi ke komponen kamera
        characterController = GetComponent<CharacterController>(); // Mendapatkan referensi ke Character Controller player
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, pictureLayerMask))
            {
                // Mengecek apakah objek yang terkena raycast memiliki tag "Picture"
                if (hit.collider.CompareTag("Picture"))
                {
                    MoveToPicture(hit.collider.transform.position);
                }
            }
        }
    }

    private void MoveToPicture(Vector3 targetPosition)
    {
        // Mengatur posisi player langsung ke posisi lukisan yang diklik
        transform.position = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);
    }
}
