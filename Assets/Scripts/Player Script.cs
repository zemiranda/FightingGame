using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public static PlayerScript Instance; // Singleton

    public int p1 = 0; // Valor inicial como 0 (não definido)
    public int p2 = 0; // Valor inicial como 0 (não definido)
    public Image targetImage;        // The Image component that will be changed
    public Image targetImageD;        // The Image component that will be changed

    public Image nameImage;        // The Image component that will be changed
    public Image nameImageD;        // The Image component that will be changed

    public GameObject pressF;        

    public Sprite initialNameSprite;        // The Image component that will be changed
    public Sprite initialSprite;     // The initial sprite (set this in the inspector or find it at runtime)
    private bool isP2Selected = false;  // Track if p2 is selected


   
    private void Update()
    {
        isP2Selected = p2 != 0;  // Check if p2 is selected
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PlayerScript.Instance != null)
            {
                PlayerScript.Instance.DeselectValues();
            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            
            TryChangeScene();
            
                
        }


    }

    public void DeselectValues()
    {

        if (p2 != 0) // Deselect p2 first if it is selected
        {
            Debug.Log($"p2 ({p2}) foi deselecionado.");
            p2 = 0;
            targetImageD.sprite = initialSprite;
            SetImageAlpha(0f, targetImageD);
            nameImageD.sprite = initialNameSprite;
            SetImageAlpha(0f, nameImageD);
            pressF.SetActive(false);

        }
        else if (p1 != 0) // Then deselect p1
        {
            Debug.Log($"p1 ({p1}) foi deselecionado.");
            p1 = 0;
            targetImage.sprite = initialSprite;
            SetImageAlpha(0f, targetImage);
            nameImage.sprite = initialNameSprite;
            SetImageAlpha(0f, nameImage);
        }
        else
        {
            Debug.Log("Nenhuma variável está selecionada.");
        }
    }

    private void Awake()
    {
        // Configurar Singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Método para definir os valores
    public void SetPValue(int pNumber, int value)
    {
        if (pNumber == 1)
        {
            p1 = value;
            Debug.Log($"p1 foi definido para {value}");
        }
        else if (pNumber == 2)
        {
            p2 = value;
            pressF.SetActive(true);
            Debug.Log($"p2 foi definido para {value}");
        }
    }

    // Método para trocar de cena se ambos os jogadores estiverem selecionados
    private void TryChangeScene()
    {
        // Only proceed if both players are selected (both p1 and p2 should be non-zero)
        if (p1 != 0 && p2 != 0 && p2 != p1)
        {
            PlayerPrefs.SetInt("Player1", p1);
            PlayerPrefs.SetInt("Player2", p2);
            PlayerPrefs.Save();
            // Proceed to change the scene only when both players are chosen
            Debug.Log($"players {p1}{p2}");
            SceneManager.LoadScene("CutScene"); // Replace with your actual scene name
        }
        else
        {
            // Notify that both players need to be selected
            Debug.LogWarning("Both players must be selected to change the scene.");
        }
    }



    private void SetImageAlpha(float alpha, Image i)
    {
        if (targetImage != null)
        {
            Color currentColor = i.color;
            currentColor.a = alpha;  // Set the alpha value
            i.color = currentColor;
        }
    }
}

