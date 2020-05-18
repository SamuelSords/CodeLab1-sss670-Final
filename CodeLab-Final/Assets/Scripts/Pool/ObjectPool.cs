using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//abstract parent to starpool and collect pool
public abstract class ObjectPool : MonoBehaviour
{
    //make a stack of game objects
    protected Stack<GameObject> pool = new Stack<GameObject>();

    //acquire one of these objects from starpool or collect pool
    public GameObject Get()
    {
        GameObject result; // name the object

        if (pool.Count == 0) //when there is nothing
        {
            result = GetNewObject(); //make something
        }
        else
        { //if there is something
            result = pool.Pop(); //get it
        }

        result.transform.parent = this.transform; //move the object to the parent, star pool or collect pool

        result.SetActive(true); //activate the object
        return result; //send it
    }

    //abstract function that changes depending on how star pool or collect pool writes it
    protected abstract GameObject GetNewObject();

    //capture the object and return it to pool
    public void Push(GameObject used)
    {
        used.SetActive(false); //deactivate it
        pool.Push(used); //place the object into the stack again
    }

}