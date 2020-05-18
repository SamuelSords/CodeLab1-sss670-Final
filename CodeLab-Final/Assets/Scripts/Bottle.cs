using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    public float force = 5; //variable of force that effects object movement

    public int light = 0; //variable that stores how many stars have been collected

    Rigidbody2D rb; //var for the Rigidbody2D

    public static Bottle instance; //this script is now accessible

    void Start() //setup
    {
        

        rb = GetComponent<Rigidbody2D>(); //acquire the rigid body

    }

    void Update() //function that is called every frame
    {
        
        if (Input.GetKey("up"))//if up is pressed
        {
            rb.AddForce(Vector2.up * force); //apply to the up mult by the "force" var
        }

        if (Input.GetKey("down"))//if down is pressed
        {
            rb.AddForce(Vector2.down * force); //apply to the down mult by the "force" var
        }

        if (Input.GetKey("left"))//if left is pressed
        {
            rb.AddForce(Vector2.left * force); //apply to the left mult by the "force" var
        }

        if (Input.GetKey("right")) //if right is pressed
        {
            rb.AddForce(Vector2.right * force); //apply to the right mult by the "force" var
        }
    }
}