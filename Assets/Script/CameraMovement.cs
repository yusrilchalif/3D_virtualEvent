using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float sensitivity = 2.0f;
    public PopUpController popUpController;

    void Start()
    {
        //popUpController = GetComponent<PopUpController>();
        //if (popUpController == null)
        //{
        //    Debug.LogError("PopupController script not found on the camera.");
        //}
    }


    void Update()
    {
        //if(popUpController.isActive)
        //{
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            // Rotasi kamera berdasarkan input mouse
            transform.Rotate(Vector3.up * mouseX * sensitivity);
            transform.Rotate(Vector3.left * mouseY * sensitivity);

            // Batasi rotasi pada sumbu Y agar kamera tidak terbalik
            float xRotation = Mathf.Clamp(transform.rotation.eulerAngles.x, 0f, 90f);
            transform.rotation = Quaternion.Euler(xRotation, transform.rotation.eulerAngles.y, 0f);
        //}
    }
}
