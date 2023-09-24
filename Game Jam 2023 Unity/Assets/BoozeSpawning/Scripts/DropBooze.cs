using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBooze : MonoBehaviour
{
    [SerializeField] private int dropletAmount = 10;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Drop", 0f, 2f);
    }

    private void Drop()
    {
        for (int i = 0; i <= dropletAmount; i++)
        {
            GameObject drop = DropletPool.instance.GetDroplet();
            drop.transform.position = new Vector3(Random.Range(-5.0f, 5.0f), Random.Range(0, 5.0f), 0);
            drop.SetActive(true);
            

        }
    }
}
