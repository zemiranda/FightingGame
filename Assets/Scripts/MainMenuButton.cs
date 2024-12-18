using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{

    public int newValue; // Valor a ser atribuído

    public void OnButtonPress()
    {
        
        if (newValue == 1)
        {
            
            SceneManager.LoadScene("Select Fighters");
            

        }
        if (newValue == 2)
        {
            Debug.Log("Saindo do jogo...");

            // Quit the game if it's a build, or stop play mode if in the Unity Editor
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // Stop play mode in the editor
#else
            Application.Quit(); // Quit the built application
#endif
        }
        else return;
    }


}
