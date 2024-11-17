using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSelect : MonoBehaviour
{

    public int newValue; // Valor a ser atribuído

    public void OnButtonPress()
    {
        if (PlayerScript.Instance != null)
        {
            // Tenta modificar p1 primeiro
            if (PlayerScript.Instance.p1 == 0)
            {
                PlayerScript.Instance.SetPValue(1, newValue);
                Debug.Log("p1 foi alterado.");
                
            }
            // Se p1 já foi escolhido, modifica p2
            else if (PlayerScript.Instance.p2 == 0 && PlayerScript.Instance.p1 != newValue)
            {
                PlayerScript.Instance.SetPValue(2, newValue);
                Debug.Log("p2 foi alterado.");
            }
            else
            {
                Debug.LogWarning("Ambas as variáveis (p1 e p2) já foram definidas!" + PlayerScript.Instance.p1 + PlayerScript.Instance.p2);
            }
        }
        else
        {
            Debug.LogError("PlayerScript não foi encontrado!");
        }
    }
}
