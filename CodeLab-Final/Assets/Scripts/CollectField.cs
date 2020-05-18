using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectField : MonoBehaviour
{
    public float intervalMin = 0.1f; //min time to span new star
    public float intervalMax = 0.5f; //max time to span new star
    public float numStars = 10; //how many stars to spawn at once

    void Start()
    {
        Invoke("SpawnCollectable", intervalMin); //call SpawnStar after intervalMin time
    }

    void SpawnCollectable()
    {
        //depending on numStars instantiate these stars
        for (int i = 0; i < numStars; i++)
        {
            GameObject Collectable = CollectPool.instance.GetCollectable();
        }

        //do this again between the set time interval
        Invoke("SpawnCollectable", Random.Range(intervalMin, intervalMax));
    }
}
