using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int p1 = 0;
    public int p2 = 0;

    // Jogadores
    public GameObject player1; // Player 1 GameObject
    public GameObject player2; // Player 2 GameObject

    // Sprites e Animators para cada personagem
    [Header("Deadpool")]
    public Sprite deadpoolSprite;
    public RuntimeAnimatorController deadpoolAnimator;

    [Header("Sailor Moon")]
    public Sprite sailorMoonSprite;
    public RuntimeAnimatorController sailorMoonAnimator;

    [Header("Lara Croft")]
    public Sprite laraCroftSprite;
    public RuntimeAnimatorController laraCroftAnimator;

    [Header("Black Widow")]
    public Sprite blackWidowSprite;
    public RuntimeAnimatorController blackWidowAnimator;

    [Header("Superman")]
    public Sprite supermanSprite;
    public RuntimeAnimatorController supermanAnimator;

    [Header("Darth Vader")]
    public Sprite darthVaderSprite;
    public RuntimeAnimatorController darthVaderAnimator;

    public SpriteRenderer spriteRenderer;

    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
    
        int randomIndex = Random.Range(0, 6);

        switch (randomIndex)
        {
            case 0:
                spriteRenderer.sprite = sprite1;
                break;
            case 1:
                spriteRenderer.sprite = sprite2;
                break;
            case 2:
                spriteRenderer.sprite = sprite3;
                break;
            case 3:
                spriteRenderer.sprite = sprite4;
                break;
        
        }
        Debug.Log($"skibi players {p1}{p2}");
        p1 = PlayerPrefs.GetInt("Player1", 0);
        p2 = PlayerPrefs.GetInt("Player2", 0);
        Debug.Log($"skibidi players {p1}{p2}");

        Debug.Log($"Player 1 escolhido: {p1}");
        Debug.Log($"Player 2 escolhido: {p2}");

        // Configura os jogadores
        SetPlayerAttributes(player1, p1, true);
        SetPlayerAttributes(player2, p2, false);


        StartFight(p1 , p2);
        StartCoroutine(ChangeSceneAfterDelay(10f));
    }

    IEnumerator ChangeSceneAfterDelay(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Change the scene to "Select Fighters"
        PlayerPrefs.SetInt("Player1", 0);
        PlayerPrefs.SetInt("Player2", 0);
        PlayerPrefs.Save();

        SceneManager.LoadScene("Select Fighters");
    }

    private void SetPlayerAttributes(GameObject player, int characterId, bool isPlayer1)
    {
        SpriteRenderer spriteRenderer = player.GetComponent<SpriteRenderer>();
        Animator animator = player.GetComponent<Animator>();

        switch (characterId)
        {
            case 1: // Deadpool
                spriteRenderer.sprite = deadpoolSprite;
                animator.runtimeAnimatorController = deadpoolAnimator;
                break;
            case 2: // Sailor Moon
                spriteRenderer.sprite = sailorMoonSprite;
                animator.runtimeAnimatorController = sailorMoonAnimator;
                break;
            case 3: // Lara Croft
                spriteRenderer.sprite = laraCroftSprite;
                animator.runtimeAnimatorController = laraCroftAnimator;
                Debug.Log($"Sprite atualizado para: {spriteRenderer.sprite}");
                break;
            case 4: // Black Widow
                spriteRenderer.sprite = blackWidowSprite;
                animator.runtimeAnimatorController = blackWidowAnimator;
                break;
            case 5: // Superman
                spriteRenderer.sprite = supermanSprite;
                animator.runtimeAnimatorController = supermanAnimator;
                break;
            case 6: // Darth Vader
                spriteRenderer.sprite = darthVaderSprite;
                animator.runtimeAnimatorController = darthVaderAnimator;
                break;
            default:
                Debug.LogWarning($"Character ID {characterId} inválido.");
                break;
        }
        if (isPlayer1)
        {
            player.transform.position = new Vector2(-14, -6);

        }
        else
        {
            player.transform.position = new Vector2(-7, -6);
        }

        
    }


    public void StartFight(int p1, int p2)
    {
        // Access the Animator components of both players
        Animator animator1 = player1.GetComponent<Animator>();
        Animator animator2 = player2.GetComponent<Animator>();

        Debug.Log($"Player 1 Animator: {animator1.runtimeAnimatorController.name}");
        Debug.Log($"Player 2 Animator: {animator2.runtimeAnimatorController.name}");

        // Start the fight and set the winner value based on each case
        switch (p1)
        {
            case 1://DeadPool
                switch (p2)
                {
                    case 1:// Deadpool
                        animator1.SetBool("winner", true); //vitoria = true player 1
                        animator2.SetBool("winner", false); // derrota = false player 2 
                        Debug.Log("Fight 1 vs 1 started!");
                        break;
                    case 2:// Sailor Moon
                        animator1.SetBool("winner", false);
                        animator2.SetBool("winner", true);
                        Debug.Log("Fight 1 vs 2 started!");
                        break;
                    case 3:// Lara Croft
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 3 started!");
                        break;
                    case 4:// Black Widow
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 4 started!");
                        break;
                    case 5:// Superman
                        animator1.SetBool("winner", false);
                        animator2.SetBool("winner", true);
                        Debug.Log("Fight 1 vs 5 started!");
                        break;
                    case 6:// Darth Vader
                        animator1.SetBool("winner", false);
                        animator2.SetBool("winner", true);
                        Debug.Log("Fight 1 vs 6 started!");
                        break;
                    default:
                        Debug.Log("Invalid match!");
                        break;
                }
                break;

            case 2:// Sailor Moon
                switch (p2)
                {
                    case 1:
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 2 vs 1 started!");
                        break;
                    case 2:
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 2 vs 2 started!");
                        break;
                    case 3:
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 2 vs 3 started!");
                        break;
                    case 4:
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 2 vs 4 started!");
                        break;
                    case 5:
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", true);
                        Debug.Log("Fight 2 vs 5 started!");
                        break;
                    case 6:
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 2 vs 6 started!");
                        break;
                    default:
                        Debug.Log("Invalid match!");
                        break;
                }
                break;

            case 3://Lara croft
                switch (p2)
                {
                    case 1://DeadPool
                        animator1.SetBool("winner", false);
                        animator2.SetBool("winner", true);
                        Debug.Log("Fight 3 vs 1 started!");
                        break;
                    case 2:
                        animator1.SetBool("winner", false);
                        animator2.SetBool("winner", true);
                        Debug.Log("Fight 3 vs 2 started!");
                        break;
                    case 3:
                        animator1.SetBool("winner", false);
                        animator2.SetBool("winner", true);
                        Debug.Log("Fight 3 vs 3 started!");
                        break;
                    case 4:
                        animator1.SetBool("winner", false);
                        animator2.SetBool("winner", true);
                        Debug.Log("Fight 3 vs 4 started!");
                        break;
                    case 5://superMan
                        animator1.SetBool("winner", false);
                        animator2.SetBool("winner", true);
                        Debug.Log("Fight 3 vs 5 started!");
                        break;
                    case 6:
                        animator1.SetBool("winner", false);
                        animator2.SetBool("winner", true);
                        Debug.Log("Fight 3 vs 6 started!");
                        break;
                    default:
                        Debug.Log("Invalid match!");
                        break;
                }
                break;

            case 4:// Black Widow
                switch (p2)
                {
                    case 1:
                        animator1.SetBool("winner", false);
                        animator2.SetBool("winner", true);
                        Debug.Log("Fight 4 vs 1 started!");
                        break;
                    case 2:
                        animator1.SetBool("winner", false);
                        animator2.SetBool("winner", true);
                        Debug.Log("Fight 4 vs 2 started!");
                        break;
                    case 3:
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 4 vs 3 started!");
                        break;
                    case 4:
                        animator1.SetBool("winner", false);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 4 vs 4 started!");
                        break;
                    case 5:
                        animator1.SetBool("winner", false);
                        animator2.SetBool("winner", true);
                        Debug.Log("Fight 4 vs 5 started!");
                        break;
                    case 6:
                        animator1.SetBool("winner", false);
                        animator2.SetBool("winner", true);
                        Debug.Log("Fight 4 vs 6 started!");
                        break;
                    default:
                        Debug.Log("Invalid match!");
                        break;
                }
                break;

            case 5:// Superman
                switch (p2)
                {
                    case 1:
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 5 vs 1 started!");
                        break;
                    case 2:
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", true);
                        Debug.Log("Fight 5 vs 2 started!");
                        break;
                    case 3:
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 5 vs 3 started!");
                        break;
                    case 4:
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 5 vs 4 started!");
                        break;
                    case 5:
                        animator1.SetBool("winner", false);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 5 vs 5 started!");
                        break;
                    case 6:
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 5 vs 6 started!");
                        break;
                    default:
                        Debug.Log("Invalid match!");
                        break;
                }
                break;

            case 6:// Darth Vader
                switch (p2)
                {
                    case 1:
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 6 vs 1 started!");
                        break;
                    case 2:
                        animator1.SetBool("winner", false);
                        animator2.SetBool("winner", true);
                        Debug.Log("Fight 6 vs 2 started!");
                        break;
                    case 3:
                        animator1.SetBool("winner", false);
                        animator2.SetBool("winner", true);
                        Debug.Log("Fight 6 vs 3 started!");
                        break;
                    case 4:
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 6 vs 4 started!");
                        break;
                    case 5:
                        animator1.SetBool("winner", false);
                        animator2.SetBool("winner", true);
                        Debug.Log("Fight 6 vs 5 started!");
                        break;
                    case 6:
                        animator1.SetBool("winner", false);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 6 vs 6 started!");
                        break;
                    default:
                        Debug.Log("Invalid match!");
                        break;
                }
                break;

            default:
                Debug.Log("Invalid player selection!");
                break;
        }
    }

}
