using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{

    [SerializeField] VideoPlayer video1;
    [SerializeField] VideoPlayer video2;
    // Start is called before the first frame update
    void Start()
    {
        video2.Pause();
        video1.Play();
        video1.loopPointReached += NextVideo;
    }

    void NextVideo(VideoPlayer vp)
    {
        video1.Pause();
        video2.Play();
        video2.loopPointReached += NextScene ;
    }

    void NextScene(VideoPlayer vp2)
    {
        vp2.Pause();
        SceneManager.LoadScene("Select Fighters");
    }
}
