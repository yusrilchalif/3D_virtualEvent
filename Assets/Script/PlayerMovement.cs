using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10.0f;
    public float distanceToGround = 0.5f; // Jarak maksimum dari pemain ke permukaan tangga
    public LayerMask Stair; // Layer untuk tangga

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

        // Mengambil vektor maju langsung dari transformasi kamera
        Vector3 cameraForward = mainCamera.transform.forward;

        // Normalisasi vektor maju agar panjangnya tetap 1
        cameraForward.Normalize();

        // Menghitung vektor gerakan menggunakan input dan vektor maju kamera
        Vector3 movement = (cameraForward * verticalInput + mainCamera.transform.right * horizontalInput).normalized;

        // Menetapkan nilai nol pada sumbu Y untuk mencegah melayang
        movement.y = 0f;

        // Mengatur kecepatan dan menerapkan gerakan ke rigidbody
        rb.velocity = movement * speed;

        // Mengecek apakah pemain di atas permukaan tangga
        if (IsOnStairs())
        {
            // Mendapatkan posisi pemain
            Vector3 currentPosition = transform.position;

            // Menetapkan posisi pemain ke tinggi tangga yang sesuai
            transform.position = new Vector3(currentPosition.x, GetStairsHeight() + distanceToGround, currentPosition.z);
        }
    }

    // Fungsi untuk mengecek apakah pemain di atas permukaan tangga
    bool IsOnStairs()
    {
        RaycastHit hit;
        // Raycast ke bawah hanya untuk layer tangga
        return Physics.Raycast(transform.position, Vector3.down, out hit, distanceToGround + 0.1f, Stair);
    }

    // Fungsi untuk mendapatkan tinggi permukaan tangga di bawah pemain
    float GetStairsHeight()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, distanceToGround + 0.1f, Stair))
        {
            return hit.point.y;
        }
        return transform.position.y; // Kembalikan tinggi pemain jika tidak ada tangga yang terdeteksi
    }

}
