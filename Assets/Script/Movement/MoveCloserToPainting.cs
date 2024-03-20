using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveCloserToPainting : MonoBehaviour
{
    public float moveSpeed = 5f; // Kecepatan pergerakan player
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
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, pictureLayerMask))
            {
                MoveToPicture(hit.point);
            }
        }
    }

    private void MoveToPicture(Vector3 targetPosition)
    {
        // Hitung arah ke titik yang diinginkan
        Vector3 moveDirection = (targetPosition - transform.position).normalized;

        // Hitung posisi target berdasarkan jarak minimum dari lukisan
        Vector3 targetPositionAdjusted = targetPosition - moveDirection * 0.1f; // Mengurangi sedikit jarak untuk menghindari tabrakan

        // Pindahkan karakter ke posisi target
        characterController.Move((targetPositionAdjusted - transform.position) * moveSpeed * Time.deltaTime);
    }
}
