using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpController : MonoBehaviour
{
    public static PopUpController Instance { get; private set; }

    public bool isActive = false;
    public GameObject canvasPopUp;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        canvasPopUp.SetActive(false);
    }

    public void ShowPopUp()
    {
        isActive = true;
        canvasPopUp.SetActive(true);
    }

    public void HidePopUp()
    {
        isActive = false;
        canvasPopUp.SetActive(false);
    }
}
