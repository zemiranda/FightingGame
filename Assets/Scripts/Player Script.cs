using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public static PlayerScript Instance; // Singleton

    public int p1 = 0; // Valor inicial como 0 (não definido)
    public int p2 = 0; // Valor inicial como 0 (não definido)

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PlayerScript.Instance != null)
            {
                PlayerScript.Instance.DeselectValues();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
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
        }
        else if (p1 != 0) // Then deselect p1
        {
            Debug.Log($"p1 ({p1}) foi deselecionado.");
            p1 = 0;
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
            Debug.Log($"p2 foi definido para {value}");
        }
    }

    // Método para trocar de cena se ambos os jogadores estiverem selecionados
    private void TryChangeScene()
    {
        if (p1 != 0 && p2 != 0)
        {
            Debug.Log("Ambos os jogadores estão selecionados. Trocando de cena...");
            SceneManager.LoadScene("Fight Scene"); // Substitua pelo nome ou índice da cena
        }
        else
        {
            Debug.LogWarning("Não é possível trocar de cena. Ambos os jogadores precisam estar selecionados.");
        }
    }
}

