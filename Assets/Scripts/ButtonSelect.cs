using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSelect : MonoBehaviour
{

    public int newValue; // Valor a ser atribu�do

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
            // Se p1 j� foi escolhido, modifica p2
            else if (PlayerScript.Instance.p2 == 0 && PlayerScript.Instance.p1 != newValue)
            {
                PlayerScript.Instance.SetPValue(2, newValue);
                Debug.Log("p2 foi alterado.");
            }
            else
            {
                Debug.LogWarning("Ambas as vari�veis (p1 e p2) j� foram definidas!" + PlayerScript.Instance.p1 + PlayerScript.Instance.p2);
            }
        }
        else
        {
            Debug.LogError("PlayerScript n�o foi encontrado!");
        }
    }
}
