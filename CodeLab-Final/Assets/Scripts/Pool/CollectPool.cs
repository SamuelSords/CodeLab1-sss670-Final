using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is connected to ObjectPool
public class CollectPool : ObjectPool
{
    public GameObject collectable; //This is the game object i am attaching from the prefab

    public static CollectPool instance; //This makes the script accessible

    void Start()
    {
        //singleton setup
        if (instance == null)
        { //if it does not exist
            instance = this; //now it does
            DontDestroyOnLoad(gameObject); //please don't destroy it
        }
        else
        { //if it does exist
            Destroy(gameObject); //Destroy it instantly, it is a droid sent from the republic
        }
    }

    //override object pool and do this
    protected override GameObject GetNewObject()
    {
        return Instantiate<GameObject>(collectable);
    }

    //acquire the star and return it to the scene for use
    public GameObject GetCollectable()
    {
        GameObject recycledCollectable = Get(); //pull a recycled star from object pool

        recycledCollectable.GetComponent<CollectStars>().Reset(); //reset it

        return recycledCollectable; //send it to objectpool
    }
}