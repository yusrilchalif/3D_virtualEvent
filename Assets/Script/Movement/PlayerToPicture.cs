using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToPicture : MonoBehaviour
{
    public float zoomSpeed = 5f;
    public float approachDistance; // Jarak pendekatan ke picture

    void Update()
    {
        if (Camera.main == null)
        {
            Debug.LogError("Tidak ada kamera utama di scene.");
            return;
        }

        if (Input.GetMouseButtonDown(0))
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
        Vector3 targetPosition = lukisanTransform.position + lukisanTransform.forward / approachDistance;
        StartCoroutine(MovePlayer(targetPosition));
    }

    IEnumerator MovePlayer(Vector3 targetPosition)
    {
        float elapsedTime = 0f;
        float duration = 0.2f;

        Rigidbody playerRigidbody = GetComponent<Rigidbody>();

        if (playerRigidbody != null)
            playerRigidbody.useGravity = false;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;

        if (playerRigidbody != null)
            playerRigidbody.useGravity = true;
    }
}
