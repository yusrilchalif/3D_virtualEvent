using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerCollider : MonoBehaviour
{
    [SerializeField] VideoPlayer videoPlayer;

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
