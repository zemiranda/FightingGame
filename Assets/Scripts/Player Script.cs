using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public static PlayerScript Instance; // Singleton

    public int p1 = 0; // Valor inicial como 0 (n�o definido)
    public int p2 = 0; // Valor inicial como 0 (n�o definido)

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

    // M�todo para definir os valores
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

