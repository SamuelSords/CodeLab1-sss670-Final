using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Empty : MonoBehaviour
{
    public Sprite sprite1;
    public Sprite sprite2;

    private SpriteRenderer spriteRenderer;

    public int light2;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
        if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
            spriteRenderer.sprite = sprite1; // set the sprite to sprite1
    }

    // Update is called once per frame
    void Update()
    {
        light2 = GameObject.Find("GameManager").GetComponent<GameManager>().light1;
        if (light2 >= 100 && spriteRenderer.sprite == sprite1) // If the sprite is the empty bottle and the light is full, change it to the full bottle
        {
            ChangeTheSprite(); // call method to change sprite
        }
    }

    void ChangeTheSprite()
    {
        if (spriteRenderer.sprite == sprite1) // if the spriteRenderer sprite = sprite1 then change to sprite2
        {
            spriteRenderer.sprite = sprite2;
        }
    }
}
