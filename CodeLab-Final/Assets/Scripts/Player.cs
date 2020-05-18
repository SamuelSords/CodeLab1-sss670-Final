using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player instance; //this script is now accessible

    Rigidbody2D rb;  //name the rigid body

    public Text startText; //get the startText object

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //get the rigid body
    }

    void Update()
    {
        // move the character
        transform.Translate(Input.GetAxis("Horizontal") * 15f * Time.deltaTime, 0f, 0f);
        transform.Translate(0f, Input.GetAxis("Vertical") * 15f * Time.deltaTime, 0f);

        // flip the character
        Vector3 characterScale = transform.localScale; //set character scale to equal the scale of the character
        if (Input.GetAxis("Horizontal") < 0) //if the player is moving left
        {
            characterScale.x = -5; //flip it left
        }
        if (Input.GetAxis("Horizontal") > 0) //if the player is moving right
        {
            characterScale.x = 5; //flip it right
        }
        transform.localScale = characterScale; //reset the character scale to the actual scale of the character

        //if the player is within close vicinity to the empty bottle, enable the start text
        if (transform.position.x > 1 && transform.position.x < 4 && transform.position.y > 2 && transform.position.y < 4)
        {
            if (startText != null) //if the start text exists
            {
                startText.GetComponent<Text>().enabled = true; //enable it
            }
        }
    }
}

