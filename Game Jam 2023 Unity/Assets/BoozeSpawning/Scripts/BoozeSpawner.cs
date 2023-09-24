using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoozeSpawner : MonoBehaviour
{

    [SerializeField] private GameObject droplet;  // reference to pumpkin
    [SerializeField] private int numToSpawn;
    [SerializeField] private int veloMax;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numToSpawn; i++)
        {
            Instantiate(droplet, new Vector3(Random.Range(-5.0f, 5.0f), Random.Range(0, 5.0f), 0),
                Quaternion.identity);
            

        }
    }

    // Update is called once per frame  
    /*void Update()
    {
        
    }*/
}
