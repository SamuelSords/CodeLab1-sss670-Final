using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectStars : MonoBehaviour
{
    public float yRange; //random range for placig star on y axis

    public int lightValue = 1; //this is the value for every star that hits the bottle

    private bool caught; //boolean to determine if the star has been caught or not


    const float MIN_SPEED = 0.05f; //minimum speed
    const float MAX_SPEED = 0.15f; //maximum speed
    const float MAX_X = 12; //where to start star on the x axis
    const float MIN_X = -10; //where the star should be recycled on the x axis

    float speed; //float variable to hold random speed range

    private Vector3 scaleChange; //Vector3 that determines how fast the stars shrink

    //if a collision is triggered
    public void OnTriggerEnter2D(Collider2D Collision)
    {
        //from the bottle script, find the value of light and increase that value
        Bottle bottle = Collision.GetComponent<Bottle>();

        if (bottle != null) //if it exists
        {
            bottle.light += lightValue; //increase light based on this stars light value
        }

        transform.position = Collision.GetComponent<Bottle>().transform.position; //move the star to be positioned inside the bottle
        transform.localScale = transform.localScale; //make the local scale equal itself

        caught = true; //this star is now caught
    }

    void Start()
    {
        Reset(); //set the star
    }

    public void Reset()
    {
        speed = -Random.Range(MIN_SPEED, MAX_SPEED); //give random value to speed based on max speed and minimum speed

        scaleChange = new Vector3(.002f, .002f, .002f); //set the star shrink value

        transform.localScale = new Vector3(.6f, .6f, .6f); //this is the starting size of the star

        transform.position = new Vector2(
            MAX_X, Random.Range(-2, yRange)); //this is setting the random position of the star
    }

    void Update()
    {

        if (caught == false) //if the star has not been caught
        {
            transform.position = new Vector3(
                transform.position.x + speed,
                transform.position.y); //move the star at the speed it was given

            transform.localScale -= scaleChange; //make the star shrink
        }

        //if the star has gone to far
        if (transform.position.x < MIN_X)
        {
            CollectPool.instance.Push(gameObject); //recycle it into the pool
        }
        //if the star has gotten too small
        if (transform.localScale.x < 0f)
        {
            CollectPool.instance.Push(gameObject); //recycle it into the pool
        }
    }
}