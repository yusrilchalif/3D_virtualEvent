using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerCollider : MonoBehaviour
{
    [SerializeField] VideoPlayer videoPlayer;

    public Renderer thumbnailMaterial;


    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        thumbnailMaterial = GetComponent<Renderer>();
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
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            print(" Video stop");
            StopVideo();
        }
    }

    private void PlayVideo()
    {
        if (videoPlayer != null)
        {
            // Putar video
            videoPlayer.Play();
            SetThumbnailActive(false);
        }
    }

    private void StopVideo()
    {
        if (videoPlayer != null)
        {
            // Hentikan video
            videoPlayer.Stop();
            SetThumbnailActive(true);
        }
    }

    void SetThumbnailActive(bool isActive)
    {
        thumbnailMaterial.enabled = isActive;
    }
}
