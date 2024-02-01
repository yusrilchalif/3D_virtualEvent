using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRaycast : MonoBehaviour
{
    public float speed = 10.0f;
    public float distanceToGround = 0.5f; // Jarak maksimum dari pemain ke permukaan tangga
    public LayerMask stairsLayer; // Layer untuk tangga

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

        // Mengecek apakah pemain di atas permukaan tangga
        if (IsOnStairs())
        {
            // Menerapkan gerakan yang sesuai untuk tangga
            Vector3 movementOnStairs = CalculateStairsMovement(horizontalInput, verticalInput);

            // Mengatur kecepatan dan menerapkan gerakan ke rigidbody
            rb.velocity = movementOnStairs * speed;
        }
        else
        {
            // Menghitung vektor gerakan menggunakan input dan vektor maju kamera
            Vector3 movement = (cameraForward * verticalInput + mainCamera.transform.right * horizontalInput).normalized;

            // Menetapkan nilai nol pada sumbu Y untuk mencegah melayang
            movement.y = 0f;

            // Mengatur kecepatan dan menerapkan gerakan ke rigidbody
            rb.velocity = movement * speed;
        }
    }

    // Fungsi untuk mengecek apakah pemain di atas permukaan tangga
    bool IsOnStairs()
    {
        RaycastHit hit;
        // Raycast ke bawah hanya untuk layer tangga
        return Physics.Raycast(transform.position, Vector3.down, out hit, distanceToGround + 0.1f, stairsLayer);
    }

    // Fungsi untuk menghitung gerakan pemain ketika di atas tangga
    Vector3 CalculateStairsMovement(float horizontalInput, float verticalInput)
    {
        RaycastHit hit;
        Vector3 movementOnStairs = Vector3.zero;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, distanceToGround + 0.1f, stairsLayer))
        {
            // Mendapatkan arah normal dari permukaan tangga
            Vector3 stairsNormal = hit.normal;

            // Menghitung vektor gerakan relatif terhadap tangga
            Vector3 relativeMovement = (stairsNormal * verticalInput + Vector3.up * horizontalInput).normalized;

            // Menghitung vektor gerakan di ruang dunia
            movementOnStairs = Quaternion.FromToRotation(Vector3.up, stairsNormal) * relativeMovement;

            // Memastikan pemain tetap di atas tangga
            movementOnStairs.y = 0f;

            // Mengatur rotasi pemain agar sejajar dengan permukaan tangga
            transform.rotation = Quaternion.FromToRotation(transform.up, stairsNormal) * transform.rotation;
        }

        return movementOnStairs;
    }
}
