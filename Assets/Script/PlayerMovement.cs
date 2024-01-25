using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10.0f;

    private Rigidbody rb;
    private Camera mainCamera;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Mengambil input dari sumbu horizontal dan vertical
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Mengambil vektor maju dari transformasi kamera
        Vector3 cameraForward = mainCamera.transform.forward;
        cameraForward.y = 0f; // Menetapkan nilai y menjadi 0 agar pergerakan hanya pada bidang horizontal

        // Normalisasi vektor maju agar panjangnya tetap 1
        cameraForward.Normalize();

        // Menghitung vektor gerakan menggunakan input dan vektor maju kamera
        Vector3 movement = (cameraForward * verticalInput + mainCamera.transform.right * horizontalInput).normalized;

        // Mengatur kecepatan dan menerapkan gerakan ke rigidbody
        rb.velocity = movement * speed;
    }
}
