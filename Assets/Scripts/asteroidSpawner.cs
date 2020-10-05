using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidSpawner : MonoBehaviour
{

    public asteroidControl left, right;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnRandom", 1f, 4f);
    }

    public void spawnRandom()
    {
        if (Random.Range(0, 9) < 5)
        {
            left.spawn();
        }
        else
        {
            right.spawn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
