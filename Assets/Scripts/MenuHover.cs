using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class MenuHover : MonoBehaviour
{
    public Image targetImage;        // The Image component that will be changed
    public Image targetImageD;        // The Image component that will be changed
    public Sprite hoverSprite;       // The sprite to display on hover
    public Sprite initialSprite;     // The initial sprite (set this in the inspector or find it at runtime)

    private bool isP1Selected = false;  // Track if p1 is selected
    private bool isP2Selected = false;  // Track if p2 is selected

    void Start()
    {


        SetImageAlpha(0f, targetImage);
        SetImageAlpha(0f, targetImageD);
        // Store the initial sprite when the script starts
        if (targetImage != null)
        {
            initialSprite = targetImage.sprite;  // Store the initial sprite
        }
        else
        {
            Debug.LogError("Target Image is not assigned!");
        }
    }

    void Update()
    {
        // Continuously check the p1 and p2 values from the PlayerScript instance
        if (PlayerScript.Instance != null)
        {
            isP1Selected = PlayerScript.Instance.p1 != 0;  // Check if p1 is selected
            isP2Selected = PlayerScript.Instance.p2 != 0;  // Check if p2 is selected
            if (isP1Selected)
            {
                // Change the sprite to hoverSprite
                targetImage.sprite = hoverSprite;
                SetImageAlpha(1f, targetImage);
                return;
            }
            if (isP2Selected)
            {
                // Change the sprite to hoverSprite
                targetImageD.sprite = hoverSprite;
                SetImageAlpha(1f, targetImageD);
                return;
            }
        }
    }



    public void OnHoverStart()
    {
        // Check if the targetImage and hoverSprite are assigned
        if (targetImage == null)
        {
            Debug.LogError("Target Image is not assigned!");
            return;
        }

        if (hoverSprite == null)
        {
            Debug.LogError("Hover Sprite is not assigned!");
            return;
        }

        if (isP1Selected && isP2Selected)
        {
            return;  // Prevent hover effect on p1 if it’s already selected
        }

        if (isP1Selected && !isP2Selected)
        {
            // Change the sprite to hoverSprite
            targetImageD.sprite = hoverSprite;
            Debug.Log("Sprite changed to: " + targetImage.sprite.name);
            SetImageAlpha(1f, targetImageD);
            return;
        }
        // Change the sprite to hoverSprite
        targetImage.sprite = hoverSprite;
        Debug.Log("Sprite changed to: " + targetImage.sprite.name);
        SetImageAlpha(1f, targetImage);
    }

    public void OnHoverEnd()
    {
        // Check if the targetImage is assigned
        if (targetImage == null)
        {
            Debug.LogError("Target Image is not assigned!");
            return;
        }
        if (isP1Selected && isP2Selected)
        {
            return;  // Prevent hover effect on p1 if it’s already selected
        }

        if (isP1Selected && !isP2Selected)
        {
            if (initialSprite != null)
            {
                targetImageD.sprite = initialSprite;
                Debug.Log("Sprite reverted to: " + targetImage.sprite.name);
                SetImageAlpha(0f, targetImageD);
            }
            return;
        }

            // Revert to the initial sprite (restore the sprite before hover started)
        if (initialSprite != null)
        {
            targetImage.sprite = initialSprite;
            Debug.Log("Sprite reverted to: " + targetImage.sprite.name);
            SetImageAlpha(0f, targetImage);
        }
        else
        {
            Debug.LogError("Initial sprite is not assigned!");
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
