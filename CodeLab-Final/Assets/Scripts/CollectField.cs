using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectField : MonoBehaviour
{
    public float intervalMin = 0.1f; //min time to span new star
    public float intervalMax = 0.5f; //max time to span new star
    public float numStars = 10; //how many stars to span at once

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnCollectable", intervalMin); //call SpawnStar after intervalMin time
    }

    void SpawnCollectable()
    {
        //generate numStars stars
        for (int i = 0; i < numStars; i++)
        {
            GameObject Collectable = CollectPool.instance.GetCollectable();
        }

        //call SpawnStar again after a random amount of time between min and max
        Invoke("SpawnCollectable", Random.Range(intervalMin, intervalMax));
    }
}
