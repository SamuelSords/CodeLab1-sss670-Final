using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Empty : MonoBehaviour
{
    public Sprite sprite1; //this will be where i hold the empty bottle sprite
    public Sprite sprite2; //this will be where i hold the full bottle sprite

    private SpriteRenderer spriteRenderer; //make a sprite renderer accessible

    public int light2; //this is so this object can hold the value of light and inherit it from the game manager

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // access the sprite renderer
        if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer does not exist
            spriteRenderer.sprite = sprite1; // set the sprite to the empty bottle
    }

    void Update()
    {
        //find the value of light from the game manager and inherit that value in light2
        light2 = GameObject.Find("GameManager").GetComponent<GameManager>().light1;


        if (light2 >= 100 && spriteRenderer.sprite == sprite1) // If the sprite is the empty bottle and the light is full, change it to the full bottle
        {
            ChangeTheSprite(); // call function to change sprite
        }
    }
    //function to change sprite
    void ChangeTheSprite()
    {
        if (spriteRenderer.sprite == sprite1) // if the bottle is empty when this function is called
        {
            spriteRenderer.sprite = sprite2; //now it is full
        }
    }
}
