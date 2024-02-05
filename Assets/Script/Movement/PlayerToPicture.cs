using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToPicture : MonoBehaviour
{
    public float zoomSpeed = 2f;
    public float approachDistance = 50f; // Jarak pendekatan ke picture

    private bool isMoving = false; // Tandai apakah pemain sedang bergerak

    void Update()
    {
        if (Camera.main == null)
        {
            Debug.LogError("Tidak ada kamera utama di scene.");
            return;
        }

        if (Input.GetMouseButtonDown(0) && !isMoving)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Picture"))
                {
                    ZoomToLukisan(hit.collider.transform);
                }
            }
        }
    }

    void ZoomToLukisan(Transform lukisanTransform)
    {
        Vector3 targetPosition = lukisanTransform.position + lukisanTransform.forward * approachDistance;
        StartCoroutine(MovePlayer(targetPosition));
    }

    IEnumerator MovePlayer(Vector3 targetPosition)
    {
        float elapsedTime = 0f;
        float duration = 0.5f;

        Rigidbody playerRigidbody = GetComponent<Rigidbody>();

        if (playerRigidbody != null)
            playerRigidbody.useGravity = false;

        isMoving = true;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;

            // Periksa jarak antara pemain dan target position
            float distance = Vector3.Distance(transform.position, targetPosition);
            if (distance <= 2f)
                break;

            yield return null;
        }

        transform.position = targetPosition;

        if (playerRigidbody != null)
            playerRigidbody.useGravity = true;

        isMoving = false;
    }
}
