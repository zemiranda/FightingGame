using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuHover : MonoBehaviour
{
    public Image targetImage;        // The Image component that will be changed
    public Sprite hoverSprite;       // The sprite to display on hover
    public Sprite initialSprite;     // The initial sprite (set this in the inspector or find it at runtime)

    void Start()
    {
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

        // Change the sprite to hoverSprite
        targetImage.sprite = hoverSprite;
        Debug.Log("Sprite changed to: " + targetImage.sprite.name);
    }

    public void OnHoverEnd()
    {
        // Check if the targetImage is assigned
        if (targetImage == null)
        {
            Debug.LogError("Target Image is not assigned!");
            return;
        }

        // Revert to the initial sprite (restore the sprite before hover started)
        if (initialSprite != null)
        {
            targetImage.sprite = initialSprite;
            Debug.Log("Sprite reverted to: " + targetImage.sprite.name);
        }
        else
        {
            Debug.LogError("Initial sprite is not assigned!");
        }
    }
}
