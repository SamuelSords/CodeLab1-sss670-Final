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

    float speed;
    private Vector3 scaleChange;

    // Start is called before the first frame update
    void Start()
    {
        Reset(); //setup star
    }

    public void Reset()
    {
        speed = -Random.Range(MIN_SPEED, MAX_SPEED); //give it a random speed in range

        scaleChange = new Vector3(.003f, .003f, .003f);

        transform.localScale = new Vector3(.25f, .25f, 1f);

        //set random star pos
        transform.position = new Vector2(
            MAX_X, Random.Range(2, yRange));
    }

    // Update is called once per frame
    void Update()
    {
        //move star by speed
        transform.position = new Vector3(
            transform.position.x + speed,
            transform.position.y);

        transform.localScale -= scaleChange;
        //transform.localScale = new Vector3(transform.localScale.x - scaleChange.x, transform.localScale.y - scaleChange.y);

        //if the star has gone to far
        if (transform.position.x < MIN_X)
        {
            StarPool.instance.Push(gameObject); //recycle it into the pool
        }

        if (transform.localScale.x < 0f)
        {
            StarPool.instance.Push(gameObject);
        }
    }
}