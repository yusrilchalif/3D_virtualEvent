using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlayerCollider : MonoBehaviour
{
    [SerializeField] VideoPlayer videoPlayer;
    [SerializeField] Canvas thumbnailSprite;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            print("Video play");
            PlayVideo();
            thumbnailSprite.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            print(" Video stop");
            StopVideo();
            thumbnailSprite.enabled = true;

        }
    }

    private void PlayVideo()
    {
        if (videoPlayer != null)
        {
            // Putar video
            videoPlayer.Play();
        }
    }

    private void StopVideo()
    {
        if (videoPlayer != null)
        {
            // Hentikan video
            videoPlayer.Stop();
        }
    }

}
