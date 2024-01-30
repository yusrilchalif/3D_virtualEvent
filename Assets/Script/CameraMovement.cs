using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float sensitivity = 2.0f; // Kurangi sensitivitas
    public float maxYRotation = 80.0f; // Batasi rotasi pada sumbu Y

    void Update()
    {
        // Check apakah tombol mouse kiri ditekan
        if (Input.GetMouseButton(0))
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            // Ubah rotasi kamera berdasarkan input mouse
            transform.Rotate(Vector3.up * mouseX * sensitivity);
            transform.Rotate(Vector3.left * mouseY * sensitivity);

            // Batasi rotasi pada sumbu Y agar kamera tidak terbalik
            float currentXRotation = transform.rotation.eulerAngles.x;
            float clampedXRotation = ClampAngle(currentXRotation, -maxYRotation, maxYRotation);

            // Terapkan rotasi yang sudah dibatasi
            transform.rotation = Quaternion.Euler(clampedXRotation, transform.rotation.eulerAngles.y, 0f);
        }
    }

    // Fungsi untuk membatasi sudut rotasi pada sumbu tertentu
    float ClampAngle(float angle, float min, float max)
    {
        if (angle < 0f) angle += 360f;
        if (angle > 180f) return Mathf.Max(angle, 360f + min);
        return Mathf.Min(angle, max);
    }
}
