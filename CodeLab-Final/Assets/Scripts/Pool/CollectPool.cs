using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPool : ObjectPool
{
    public GameObject collectable; //Type of gameObject for this pool

    public static CollectPool instance; //holds singleton reference

    void Start()
    {
        //set up the singleton
        if (instance == null)
        { //if instance isn't set
            instance = this; //set it to this instance
            DontDestroyOnLoad(gameObject); //Don't destory this gameObject
        }
        else
        { //otherwise, if we have a singleton already
            Destroy(gameObject); //Destroy this instance
        }
    }

    //ovveride abstract method, make it return a new star
    protected override GameObject GetNewObject()
    {
        return Instantiate<GameObject>(collectable);
    }

    //wrapper around "Get" from base, sets up star to be used again
    public GameObject GetCollectable()
    {
        GameObject recycledCollectable = Get(); //Star out of the stack

        recycledCollectable.GetComponent<CollectStars>().Reset(); //reset it

        return recycledCollectable; //return it
    }
}