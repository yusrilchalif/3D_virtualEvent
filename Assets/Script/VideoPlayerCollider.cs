using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlayerCollider : MonoBehaviour
{
    public ParsingVideo parsingVideo;
    public Canvas spriteCanvas;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            parsingVideo.PlayVideo();
            spriteCanvas.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            parsingVideo.StopVideo();
            spriteCanvas.enabled = true;
        }
    }
}
