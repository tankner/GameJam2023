using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private int spawnTime = 10;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Spawn()
    {
        Instantiate(enemy, new Vector3(Random.Range(-5.0f, 5.0f), Random.Range(0, 5.0f), 0),
                Quaternion.identity);
    }
}
