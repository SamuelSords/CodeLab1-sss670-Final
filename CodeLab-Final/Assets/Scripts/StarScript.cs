using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScript : MonoBehaviour
{
    public float yRange; //random range for star pos on the x axis

    const float MIN_SPEED = 0.05f; //min speed
    const float MAX_SPEED = 0.3f; //max speed
    const float MAX_X = 12; //where to start star
    const float MIN_X = -10; //wher to recycle star

    float speed; //this will be the random speed of the star

    private Vector3 scaleChange; //this is the name of what will be how fast the star shrink

    // Start is called before the first frame update
    void Start()
    {
        Reset(); //setup star
    }

    public void Reset()
    {
        speed = -Random.Range(MIN_SPEED, MAX_SPEED); //give it a random speed in range

        scaleChange = new Vector3(.0025f, .0025f, .0025f); //this is value at which the star will shrink

        transform.localScale = new Vector3(.25f, .25f, 1f); //this is setting the size of the star

        //set random star position
        transform.position = new Vector2(
            MAX_X, Random.Range(2, yRange));
    }

    void Update()
    {
        //move star by speed
        transform.position = new Vector3(
            transform.position.x + speed,
            transform.position.y);

        transform.localScale -= scaleChange; //change the size of the star over time

        //if the star has gone too far
        if (transform.position.x < MIN_X)
        {
            StarPool.instance.Push(gameObject); //recycle it into the pool
        }

        //if the star gets too small
        if (transform.localScale.x < 0f)
        {
            StarPool.instance.Push(gameObject); //recycle it to the pool
        }
    }
}