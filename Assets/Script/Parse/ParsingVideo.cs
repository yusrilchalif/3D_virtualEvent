using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ParsingVideo : MonoBehaviour
{
    [SerializeField] string videoName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayVideo()
    {
        VideoPlayer videoPlayer = GetComponent<VideoPlayer>();

        if (videoPlayer)
        {
            string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, videoName);

            videoPlayer.url = videoPath;
            videoPlayer.Play();
        }
    }

    public void StopVideo()
    {
        VideoPlayer videoPlayer = GetComponent<VideoPlayer>();

        if(videoPlayer && videoPlayer.isPlaying)
        {
            videoPlayer.Stop();
        }    
    }
}
