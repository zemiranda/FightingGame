using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public static PlayerScript Instance; // Singleton

    public int p1 = 0; // Valor inicial como 0 (não definido)
    public int p2 = 0; // Valor inicial como 0 (não definido)

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
}

