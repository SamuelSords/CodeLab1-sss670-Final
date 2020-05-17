using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectStars : MonoBehaviour
{
    public float yRange; //random range for star pos on the x axis

    public int lightValue = 1;

    private bool caught;


    const float MIN_SPEED = 0.05f; //min speed
    const float MAX_SPEED = 0.15f; //max speed
    const float MAX_X = 12; //where to start star
    const float MIN_X = -10; //wher to recycle star

    float speed;
    private Vector3 scaleChange;

    public void OnTriggerEnter2D(Collider2D Collision)
    {
        Bottle bottle = Collision.GetComponent<Bottle>();

        if (bottle != null)
        {
            bottle.light += lightValue;
        }

        transform.position = Collision.GetComponent<Bottle>().transform.position;
        transform.localScale = transform.localScale;

        caught = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        Reset(); //setup star
    }

    public void Reset()
    {
        speed = -Random.Range(MIN_SPEED, MAX_SPEED); //give it a random speed in range

        scaleChange = new Vector3(.002f, .002f, .002f);

        transform.localScale = new Vector3(.6f, .6f, .6f);
        //set random star pos
        transform.position = new Vector2(
            MAX_X, Random.Range(-2, yRange));
    }

    // Update is called once per frame
    void Update()
    {

        if (caught == false)
        {
            //move star by speed
            transform.position = new Vector3(
                transform.position.x + speed,
                transform.position.y);

            transform.localScale -= scaleChange;
        }

        //if the star has gone to far
        if (transform.position.x < MIN_X)
        {
            CollectPool.instance.Push(gameObject); //recycle it into the pool
        }

        if (transform.localScale.x < 0f)
        {
            CollectPool.instance.Push(gameObject);
        }
    }
}