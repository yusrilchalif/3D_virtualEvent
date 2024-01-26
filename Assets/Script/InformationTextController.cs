using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InformationTextController : MonoBehaviour
{
    // public static InformationTextController instance { get; private set; }

    [Header("Isi Informasi Disini")]
    [SerializeField] string titleString;
    [SerializeField] string informationString;

    public TextMeshProUGUI titleText;
    public TextMeshProUGUI informationText;

    //private void Awake()
    //{
    //    if(instance != this)
    //    {
    //        instance = this;
    //    }
    //}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseDown()
    {
        Debug.Log("Mouse Down detected");
        //StartCoroutine(ShowPopUp());

        PopUpController.Instance.ShowPopUp();
        titleText.text = titleString.ToString();
        informationText.text = informationString.ToString();
    }

    //IEnumerator ShowPopUp()
    //{
    //    Debug.Log("Showing Popup");
    //    canvasPopUp.SetActive(true);
    //    titleText.text = titleString.ToString();
    //    informationText.text = informationString.ToString();

    //    yield return new WaitForSeconds(0.5f);
    //}
}
