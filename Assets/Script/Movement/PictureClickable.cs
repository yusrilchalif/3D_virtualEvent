using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureClickable : MonoBehaviour
{
    public CharacterController controller; // Reference to your CharacterController component
    public float moveSpeed = 5f; // Kecepatan pergerakan player
    public float rotateSpeed = 5f; // Kecepatan rotasi player
    public float distanceToStop = 2f; // Jarak berhenti player dari lukisan

    private Transform paintingTransform; // Transform lukisan yang dipilih

    void Update()
    {
        // Menjalankan fungsi RaycastToPainting hanya ketika player mengklik kiri mouse
        if (Input.GetMouseButtonDown(0))
        {
            // Melakukan raycast dari kamera utama
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                // Jika raycast mengenai objek dengan tag "Picture"
                if (hit.collider.gameObject.tag == "Picture")
                {
                    // Menyimpan transform lukisan yang dipilih
                    paintingTransform = hit.collider.gameObject.transform;

                    // Menghitung arah dan jarak ke lukisan
                    Vector3 direction = (paintingTransform.position - transform.position).normalized;
                    float distanceToPainting = Vector3.Distance(transform.position, paintingTransform.position);

                    // Menghitung waktu yang dibutuhkan untuk mencapai lukisan
                    float timeToReachPainting = distanceToPainting / moveSpeed;

                    // Memindahkan player langsung ke lukisan
                    controller.Move(direction * distanceToPainting);

                    // Merotasi player agar menghadap lukisan
                    Quaternion targetRotation = Quaternion.LookRotation(paintingTransform.position - transform.position);
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);

                    // Menghentikan pergerakan player ketika mencapai jarak tertentu
                    if (distanceToPainting <= distanceToStop)
                    {
                        // Menghentikan pergerakan player
                        moveSpeed = 0f;

                        // Menghentikan rotasi player
                        rotateSpeed = 0f;
                    }
                }
            }
        }
    }
}
