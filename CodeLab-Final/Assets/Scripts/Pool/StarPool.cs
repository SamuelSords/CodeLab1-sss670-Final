using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is connected to ObjectPool
public class StarPool : ObjectPool
{
    public GameObject star; //This is the game object i am attaching from the prefab

    public static StarPool instance; //this makes the script accessible

    void Start()
    {
        //singleton setup
        if (instance == null)
        { //if it does not exist
            instance = this; //now it does
            DontDestroyOnLoad(gameObject); //Please do not destroy
        }
        else
        { //if it does exist
            Destroy(gameObject); //Destroy on sight sir
        }
    }

    //override parent objectpool and get a new star
    protected override GameObject GetNewObject()
    {
        return Instantiate<GameObject>(star);
    }

    //acquire the star and return it to the scene for use
    public GameObject GetStar()
    {
        GameObject recycledStar = Get(); //find recycled star

        recycledStar.GetComponent<StarScript>().Reset(); //reset it

        return recycledStar; //send it to objectpool
    }
}

