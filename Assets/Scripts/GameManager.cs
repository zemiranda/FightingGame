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

    [Header("Yoda")]
    public Sprite yodaSprite;
    public RuntimeAnimatorController yodaAnimator;

    [Header("Poppins")]
    public Sprite poppinsSprite;
    public RuntimeAnimatorController poppinsAnimator;

    [Header("Harry")]
    public Sprite harrySprite;
    public RuntimeAnimatorController harryAnimator;

    [Header("Noiva")]
    public Sprite noivaSprite;
    public RuntimeAnimatorController noivaAnimator;

    [Header("King")]
    public Sprite kingSprite;
    public RuntimeAnimatorController kingAnimator;

    [Header("Frank")]
    public Sprite frankSprite;
    public RuntimeAnimatorController frankAnimator;

    public SpriteRenderer spriteRenderer;

    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;

    public GameObject objectToChangeSprite;

    public Sprite laraV;
    public Sprite vaderV;
    public Sprite deadPoolV;
    public Sprite widowV;
    public Sprite yodaV;
    public Sprite superManV;
    public Sprite poppinsV;
    public Sprite frankenV;
    public Sprite noivaV;
    public Sprite saylorV;
    public Sprite harryV;//9
    public Sprite iceV;//11
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
        SpriteRenderer objSpriteRenderer = objectToChangeSprite.GetComponent<SpriteRenderer>();
        objSpriteRenderer.sprite = iceV;

        Color color = objSpriteRenderer.color;
        color.a = 0; // Define o alfa para 0
        objSpriteRenderer.color = color;

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
        int victoryN = 0;
        SpriteRenderer objSpriteRenderer = objectToChangeSprite.GetComponent<SpriteRenderer>();

        Animator animator1 = player1.GetComponent<Animator>();
        Animator animator2 = player2.GetComponent<Animator>();
        if (animator1.GetBool("winner") == true)
        {
            victoryN = p1;
        }
        else victoryN = p2;

        switch (victoryN)
        {
            case 1://deadPool
                objSpriteRenderer.sprite = deadPoolV;
                break;
            case 2://sailor
                objSpriteRenderer.sprite = saylorV;
                break;
            case 3://laraCroft
                objSpriteRenderer.sprite = laraV;
                break;
            case 4://blackWidow
                objSpriteRenderer.sprite = widowV;
                break;
            case 5://superMan
                objSpriteRenderer.sprite = superManV;
                break;
            case 6://darthVader
                objSpriteRenderer.sprite = vaderV;
                break;
            case 7://yoda
                objSpriteRenderer.sprite = yodaV;
                break;
            case 8://poppins
                objSpriteRenderer.sprite = poppinsV;
                break;
            case 9://harry
                objSpriteRenderer.sprite = harryV;
                break;
            case 10://noiva
                objSpriteRenderer.sprite = noivaV;
                break;
            case 11://ice King
                objSpriteRenderer.sprite = iceV;
                break;
            case 12://Frankenstein
                objSpriteRenderer.sprite = frankenV;
                break;

        }

        Color color = objSpriteRenderer.color;
        color.a = 1; 
        objSpriteRenderer.color = color;

        yield return new WaitForSeconds(delay/2);

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
                if (isPlayer1)
                {
                    player.transform.position = new Vector2(-14, -6);//feito

                }
                else
                {
                    player.transform.position = new Vector2(-7, -6);//feito
                }
                break;
            case 2: // Sailor Moon
                spriteRenderer.sprite = sailorMoonSprite;
                animator.runtimeAnimatorController = sailorMoonAnimator;
                if (isPlayer1)
                {
                    player.transform.position = new Vector2(-14, -6);//feito

                }
                else
                {
                    player.transform.position = new Vector2(-7, -6);//feito
                }
                break;
            case 3: // Lara Croft
                spriteRenderer.sprite = laraCroftSprite;
                animator.runtimeAnimatorController = laraCroftAnimator;
                Debug.Log($"Sprite atualizado para: {spriteRenderer.sprite}");
                if (isPlayer1)
                {
                    player.transform.position = new Vector2(-14, -6);//feito

                }
                else
                {
                    player.transform.position = new Vector2(-7, -6);//feito
                }
                break;
            case 4: // Black Widow
                spriteRenderer.sprite = blackWidowSprite;
                animator.runtimeAnimatorController = blackWidowAnimator;
                if (isPlayer1)
                {
                    player.transform.position = new Vector2(-14, -6);//feito

                }
                else
                {
                    player.transform.position = new Vector2(-7, -6);//feito
                }
                break;
            case 5: // Superman
                spriteRenderer.sprite = supermanSprite;
                animator.runtimeAnimatorController = supermanAnimator;
                if (isPlayer1)
                {
                    player.transform.position = new Vector2(-12, -6);//feito

                }
                else
                {
                    player.transform.position = new Vector2(-9, -6);//feito
                }
                break;
            case 6: // Darth Vader
                spriteRenderer.sprite = darthVaderSprite;
                animator.runtimeAnimatorController = darthVaderAnimator;
                if (isPlayer1)
                {
                    player.transform.position = new Vector2(-14, -7);//feito

                }
                else
                {
                    player.transform.position = new Vector2(-8, -7);//feito
                }
                break;
            case 7: // Yoda
                spriteRenderer.sprite = yodaSprite;
                animator.runtimeAnimatorController = yodaAnimator;
                if (isPlayer1)
                {
                    player.transform.position = new Vector2(-14, -6);//feito

                }
                else
                {
                    player.transform.position = new Vector2(-8, -6);//feito
                }
                break;
            case 8: // Poppins
                spriteRenderer.sprite = poppinsSprite;
                animator.runtimeAnimatorController = poppinsAnimator;
                if (isPlayer1)
                {
                    player.transform.position = new Vector2(-14, -6);//feito

                }
                else
                {
                    player.transform.position = new Vector2(-8, -6);//feito
                }
                break;
            case 9: // Harry
                spriteRenderer.sprite = harrySprite;
                animator.runtimeAnimatorController = harryAnimator;
                if (isPlayer1)
                {
                    player.transform.position = new Vector2(-14, -6);//feito

                }
                else
                {
                    player.transform.position = new Vector2(-8, -6);//feito
                }
                break;
            case 10: // Noiva
                spriteRenderer.sprite = noivaSprite;
                animator.runtimeAnimatorController = noivaAnimator;
                if (isPlayer1)
                {
                    player.transform.position = new Vector2(-15, -6);//feito

                }
                else
                {
                    player.transform.position = new Vector2(-9, -6);//feito
                }
                break;
            case 11: // King
                spriteRenderer.sprite = kingSprite;
                animator.runtimeAnimatorController = kingAnimator;
                if (isPlayer1)
                {
                    player.transform.position = new Vector2(-15, -6);//feito

                }
                else
                {
                    player.transform.position = new Vector2(-9, -6);//feito
                }
                break;
            case 12: // Frank
                spriteRenderer.sprite = frankSprite;
                animator.runtimeAnimatorController = frankAnimator;
                if (isPlayer1)
                {
                    player.transform.position = new Vector2(-14, -6);//feito

                }
                else
                {
                    player.transform.position = new Vector2(-8, -6);//feito
                }
                break;
            default:
                Debug.LogWarning($"Character ID {characterId} inv�lido.");
                break;
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
                    case 7:// Yoda
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    case 8:// Poppins
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    case 9:// Harry
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    case 10://Noiva
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    case 11://King
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    case 12://Frank
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 7 started!");
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
                    case 7:// Yoda
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    case 8:// Poppins
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    case 9:// Harry
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    case 10://Noiva
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    case 11://King
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    case 12://Frank
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 7 started!");
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
                    case 7:// Yoda
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    case 8:// Poppins
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    case 9:// Harry
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    case 10://Noiva
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    case 11://King
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    case 12://Frank
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 7 started!");
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
                    case 7:// Yoda
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    case 8:// Poppins
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    case 9:// Harry
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    case 10://Noiva
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    case 11://King
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    case 12://Frank
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 7 started!");
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
                    case 7:// Yoda
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    case 8:// Poppins
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    case 9:// Harry
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    case 10://Noiva
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    case 11://King
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    case 12://Frank
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 7 started!");
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
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
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
                    case 7:// Yoda
                        animator1.SetBool("winner", false);
                        animator2.SetBool("winner", true);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    case 8:// Poppins
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    case 9:// Harry
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    case 10://Noiva
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    case 11://King
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    case 12://Frank
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    default:
                        Debug.Log("Invalid match!");
                        break;
                }
                break;
            case 7:// Yoda
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
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
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
                    case 7:// Yoda
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    case 8:// Poppins
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    case 9:// Harry
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    case 10://Noiva
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    case 11://King
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    case 12://Frank
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    default:
                        Debug.Log("Invalid match!");
                        break;
                }
                break;
            case 8:// Poppins
                switch (p2)
                {
                    case 1:
                        animator1.SetBool("winner", false);
                        animator2.SetBool("winner", true);
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
                        animator1.SetBool("winner", false);
                        animator2.SetBool("winner", true);
                        Debug.Log("Fight 6 vs 4 started!");
                        break;
                    case 5:
                        animator1.SetBool("winner", false);
                        animator2.SetBool("winner", true);
                        Debug.Log("Fight 6 vs 5 started!");
                        break;
                    case 6:
                        animator1.SetBool("winner", false);
                        animator2.SetBool("winner", true);
                        Debug.Log("Fight 6 vs 6 started!");
                        break;
                    case 7:// Yoda
                        animator1.SetBool("winner", false);
                        animator2.SetBool("winner", true);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    case 8:// Poppins
                        animator1.SetBool("winner", false);
                        animator2.SetBool("winner", true);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    case 9:// Harry
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    case 10://Noiva
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    case 11://King
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    case 12://Frank
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    default:
                        Debug.Log("Invalid match!");
                        break;
                }
                break;
            case 9:// Harry
                switch (p2)
                {
                    case 1:
                        animator1.SetBool("winner", false);
                        animator2.SetBool("winner", true);
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
                        animator1.SetBool("winner", false);
                        animator2.SetBool("winner", true);
                        Debug.Log("Fight 6 vs 4 started!");
                        break;
                    case 5:
                        animator1.SetBool("winner", false);
                        animator2.SetBool("winner", true);
                        Debug.Log("Fight 6 vs 5 started!");
                        break;
                    case 6:
                        animator1.SetBool("winner", false);
                        animator2.SetBool("winner", true);
                        Debug.Log("Fight 6 vs 6 started!");
                        break;
                    case 7:// Yoda
                        animator1.SetBool("winner", false);
                        animator2.SetBool("winner", true);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    case 8:// Poppins
                        animator1.SetBool("winner", false);
                        animator2.SetBool("winner", true);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    case 9:// Harry
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    case 10://Noiva
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    case 11://King
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    case 12://Frank
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    default:
                        Debug.Log("Invalid match!");
                        break;
                }
                break;
            case 10: // Noiva
                switch (p2)
                {
                    case 1:
                        animator1.SetBool("winner", false);
                        animator2.SetBool("winner", true);
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
                        animator1.SetBool("winner", false);
                        animator2.SetBool("winner", true);
                        Debug.Log("Fight 6 vs 4 started!");
                        break;
                    case 5:
                        animator1.SetBool("winner", false);
                        animator2.SetBool("winner", true);
                        Debug.Log("Fight 6 vs 5 started!");
                        break;
                    case 6:
                        animator1.SetBool("winner", false);
                        animator2.SetBool("winner", true);
                        Debug.Log("Fight 6 vs 6 started!");
                        break;
                    case 7:// Yoda
                        animator1.SetBool("winner", false);
                        animator2.SetBool("winner", true);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    case 8:// Poppins
                        animator1.SetBool("winner", false);
                        animator2.SetBool("winner", true);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    case 9:// Harry
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    case 10://Noiva
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    case 11://King
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    case 12://Frank
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    default:
                        Debug.Log("Invalid match!");
                        break;
                }
                break;
            case 11:// Noiva
                switch (p2)
                {
                    case 1:
                        animator1.SetBool("winner", false);
                        animator2.SetBool("winner", true);
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
                        animator1.SetBool("winner", false);
                        animator2.SetBool("winner", true);
                        Debug.Log("Fight 6 vs 4 started!");
                        break;
                    case 5:
                        animator1.SetBool("winner", false);
                        animator2.SetBool("winner", true);
                        Debug.Log("Fight 6 vs 5 started!");
                        break;
                    case 6:
                        animator1.SetBool("winner", false);
                        animator2.SetBool("winner", true);
                        Debug.Log("Fight 6 vs 6 started!");
                        break;
                    case 7:// Yoda
                        animator1.SetBool("winner", false);
                        animator2.SetBool("winner", true);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    case 8:// Poppins
                        animator1.SetBool("winner", false);
                        animator2.SetBool("winner", true);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    case 9:// Harry
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    case 10://Noiva
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    case 11://King
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    case 12://Frank
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    default:
                        Debug.Log("Invalid match!");
                        break;
                }

                break;
            case 12:// Frank
                switch (p2)
                {
                    case 1:
                        animator1.SetBool("winner", false);
                        animator2.SetBool("winner", true);
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
                        animator1.SetBool("winner", false);
                        animator2.SetBool("winner", true);
                        Debug.Log("Fight 6 vs 4 started!");
                        break;
                    case 5:
                        animator1.SetBool("winner", false);
                        animator2.SetBool("winner", true);
                        Debug.Log("Fight 6 vs 5 started!");
                        break;
                    case 6:
                        animator1.SetBool("winner", false);
                        animator2.SetBool("winner", true);
                        Debug.Log("Fight 6 vs 6 started!");
                        break;
                    case 7:// Yoda
                        animator1.SetBool("winner", false);
                        animator2.SetBool("winner", true);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    case 8:// Poppins
                        animator1.SetBool("winner", false);
                        animator2.SetBool("winner", true);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    case 9:// Harry
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    case 10://Noiva
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    case 11://King
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 7 started!");
                        break;
                    case 12://Frank
                        animator1.SetBool("winner", true);
                        animator2.SetBool("winner", false);
                        Debug.Log("Fight 1 vs 7 started!");
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
