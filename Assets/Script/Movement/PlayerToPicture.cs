using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToPicture : MonoBehaviour
{
    Transform targetLukisan;
    float speed = 2.0f;
    float maxDistance = 5.0f;
    string wallTag = "Wall";

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Picture"))
                {
                    MendekatiLukisan(hit.transform);
                }
            }
        }

        MoveTowardsLukisan();
    }

    void MoveTowardsLukisan()
    {
        if (targetLukisan != null)
        {
            float distance = Vector3.Distance(transform.position, targetLukisan.position);

            if (distance > maxDistance && !IsWallBetweenPlayerAndPainting())
            {
                transform.position = Vector3.Lerp(transform.position, targetLukisan.position, Time.deltaTime * speed);
            }
        }
    }

    bool IsWallBetweenPlayerAndPainting()
    {
        if (targetLukisan == null)
        {
            return false;
        }

        Ray ray = new Ray(transform.position, targetLukisan.position - transform.position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null && hit.collider.CompareTag(wallTag))
            {
                return true;
            }
        }

        return false;
    }

    void MendekatiLukisan(Transform lukisanTransform)
    {
        targetLukisan = lukisanTransform;
    }
}
