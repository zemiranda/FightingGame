using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    [SerializeField] VideoPlayer video1; // Video Player 1
    [SerializeField] VideoPlayer video2; // Video Player 2
    [SerializeField] VideoPlayer video3; // Video Player 3
    [SerializeField] VideoPlayer video4; // Video Player 4
    [SerializeField] VideoPlayer video5; // Video Player 5
    [SerializeField] VideoPlayer video6; // Video Player 6

    private int p1; // Player 1 selection
    private int p2; // Player 2 selection

    void Start()
    {
        // Get PlayerPrefs values for p1 and p2
        p1 = PlayerPrefs.GetInt("Player1", 0);
        p2 = PlayerPrefs.GetInt("Player2", 0);

        Debug.Log($"Player 1 selected: {p1}");
        Debug.Log($"Player 2 selected: {p2}");

        // Play videos based on player selections
        PlayVideosForPlayers(p1, p2);
    }

    void PlayVideosForPlayers(int player1, int player2)
    {
        if (player1 == 1 && player2 == 2)
        {
            Debug.Log("Player 1: Deadpool vs Player 2: Sailor Moon");
            video1.Play();
            video1.loopPointReached += (vp) => PlayNextVideo(video2);
        }
        else if (player1 == 1 && player2 == 3)
        {
            Debug.Log("Player 1: Deadpool vs Player 2: Lara Croft");
            video1.Play();
            video1.loopPointReached += (vp) => PlayNextVideo(video3);
        }
        else if (player1 == 1 && player2 == 4)
        {
            Debug.Log("Player 1: Deadpool vs Player 2: Black Widow");
            video1.Play();
            video1.loopPointReached += (vp) => PlayNextVideo(video4);
        }
        else if (player1 == 1 && player2 == 5)
        {
            Debug.Log("Player 1: Deadpool vs Player 2: Superman");
            video1.Play();
            video1.loopPointReached += (vp) => PlayNextVideo(video5);
        }
        else if (player1 == 1 && player2 == 6)
        {
            Debug.Log("Player 1: Deadpool vs Player 2: Darth Vader");
            video1.Play();
            video1.loopPointReached += (vp) => PlayNextVideo(video6);
        }

        // Sailor Moon combinations
        else if (player1 == 2 && player2 == 1)
        {
            Debug.Log("Player 1: Sailor Moon vs Player 2: Deadpool");
            video2.Play();
            video2.loopPointReached += (vp) => PlayNextVideo(video1);
        }
        else if (player1 == 2 && player2 == 3)
        {
            Debug.Log("Player 1: Sailor Moon vs Player 2: Lara Croft");
            video2.Play();
            video2.loopPointReached += (vp) => PlayNextVideo(video3);
        }
        else if (player1 == 2 && player2 == 4)
        {
            Debug.Log("Player 1: Sailor Moon vs Player 2: Black Widow");
            video2.Play();
            video2.loopPointReached += (vp) => PlayNextVideo(video4);
        }
        else if (player1 == 2 && player2 == 5)
        {
            Debug.Log("Player 1: Sailor Moon vs Player 2: Superman");
            video2.Play();
            video2.loopPointReached += (vp) => PlayNextVideo(video5);
        }
        else if (player1 == 2 && player2 == 6)
        {
            Debug.Log("Player 1: Sailor Moon vs Player 2: Darth Vader");
            video2.Play();
            video2.loopPointReached += (vp) => PlayNextVideo(video6);
        }

        // Lara Croft combinations
        else if (player1 == 3 && player2 == 1)
        {
            Debug.Log("Player 1: Lara Croft vs Player 2: Deadpool");
            video3.Play();
            video3.loopPointReached += (vp) => PlayNextVideo(video1);
        }
        else if (player1 == 3 && player2 == 2)
        {
            Debug.Log("Player 1: Lara Croft vs Player 2: Sailor Moon");
            video3.Play();
            video3.loopPointReached += (vp) => PlayNextVideo(video2);
        }
        else if (player1 == 3 && player2 == 4)
        {
            Debug.Log("Player 1: Lara Croft vs Player 2: Black Widow");
            video3.Play();
            video3.loopPointReached += (vp) => PlayNextVideo(video4);
        }
        else if (player1 == 3 && player2 == 5)
        {
            Debug.Log("Player 1: Lara Croft vs Player 2: Superman");
            video3.Play();
            video3.loopPointReached += (vp) => PlayNextVideo(video5);
        }
        else if (player1 == 3 && player2 == 6)
        {
            Debug.Log("Player 1: Lara Croft vs Player 2: Darth Vader");
            video3.Play();
            video3.loopPointReached += (vp) => PlayNextVideo(video6);
        }

        // Black Widow combinations
        else if (player1 == 4 && player2 == 1)
        {
            Debug.Log("Player 1: Black Widow vs Player 2: Deadpool");
            video4.Play();
            video4.loopPointReached += (vp) => PlayNextVideo(video1);
        }
        else if (player1 == 4 && player2 == 2)
        {
            Debug.Log("Player 1: Black Widow vs Player 2: Sailor Moon");
            video4.Play();
            video4.loopPointReached += (vp) => PlayNextVideo(video2);
        }
        else if (player1 == 4 && player2 == 3)
        {
            Debug.Log("Player 1: Black Widow vs Player 2: Lara Croft");
            video4.Play();
            video4.loopPointReached += (vp) => PlayNextVideo(video3);
        }
        else if (player1 == 4 && player2 == 5)
        {
            Debug.Log("Player 1: Black Widow vs Player 2: Superman");
            video4.Play();
            video4.loopPointReached += (vp) => PlayNextVideo(video5);
        }
        else if (player1 == 4 && player2 == 6)
        {
            Debug.Log("Player 1: Black Widow vs Player 2: Darth Vader");
            video4.Play();
            video4.loopPointReached += (vp) => PlayNextVideo(video6);
        }

        // Superman combinations
        else if (player1 == 5 && player2 == 1)
        {
            Debug.Log("Player 1: Superman vs Player 2: Deadpool");
            video5.Play();
            video5.loopPointReached += (vp) => PlayNextVideo(video1);
        }
        else if (player1 == 5 && player2 == 2)
        {
            Debug.Log("Player 1: Superman vs Player 2: Sailor Moon");
            video5.Play();
            video5.loopPointReached += (vp) => PlayNextVideo(video2);
        }
        else if (player1 == 5 && player2 == 3)
        {
            Debug.Log("Player 1: Superman vs Player 2: Lara Croft");
            video5.Play();
            video5.loopPointReached += (vp) => PlayNextVideo(video3);
        }
        else if (player1 == 5 && player2 == 4)
        {
            Debug.Log("Player 1: Superman vs Player 2: Black Widow");
            video5.Play();
            video5.loopPointReached += (vp) => PlayNextVideo(video4);
        }
        else if (player1 == 5 && player2 == 6)
        {
            Debug.Log("Player 1: Superman vs Player 2: Darth Vader");
            video5.Play();
            video5.loopPointReached += (vp) => PlayNextVideo(video6);
        }

        // Darth Vader combinations
        else if (player1 == 6 && player2 == 1)
        {
            Debug.Log("Player 1: Darth Vader vs Player 2: Deadpool");
            video6.Play();
            video6.loopPointReached += (vp) => PlayNextVideo(video1);
        }
        else if (player1 == 6 && player2 == 2)
        {
            Debug.Log("Player 1: Darth Vader vs Player 2: Sailor Moon");
            video6.Play();
            video6.loopPointReached += (vp) => PlayNextVideo(video2);
        }
        else if (player1 == 6 && player2 == 3)
        {
            Debug.Log("Player 1: Darth Vader vs Player 2: Deadpool");
            video6.Play();
            video6.loopPointReached += (vp) => PlayNextVideo(video3);
        }
        else if (player1 == 6 && player2 == 4)
        {
            Debug.Log("Player 1: Darth Vader vs Player 2: Sailor Moon");
            video6.Play();
            video6.loopPointReached += (vp) => PlayNextVideo(video4);
        }
        else if (player1 == 6 && player2 == 5)
        {
            Debug.Log("Player 1: Darth Vader vs Player 2: Deadpool");
            video6.Play();
            video6.loopPointReached += (vp) => PlayNextVideo(video5);
        }
    }

    void PlayNextVideo(VideoPlayer nextVideo)
    {
        Debug.Log($"Playing next video: {nextVideo.name}");
        nextVideo.Play();
        nextVideo.loopPointReached += (vp) => LoadNextScene(); // Load next scene after the last video
    }

    void LoadNextScene()
    {
        Debug.Log("Cutscene finished. Loading next scene...");
        SceneManager.LoadScene("Fight Scene"); // Replace with your desired scene name
    }
}
