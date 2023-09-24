using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropletPool : MonoBehaviour
{
    public static DropletPool instance;

    [SerializeField] private GameObject pooledDroplet;
    private bool notEnoughDropletsInPool = true;

    private List<GameObject> droplets;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        droplets = new List<GameObject>();
    }

    public GameObject GetDroplet()
    {
        if (droplets.Count > 0)
        {
            for (int i = 0; i < droplets.Count; i++)
            {
                if (!droplets[i].activeInHierarchy)
                {
                    return droplets[i];
                }
            }
        }

        if (notEnoughDropletsInPool)
        {
            GameObject drop = Instantiate(pooledDroplet);
            drop.SetActive(false);
            droplets.Add(drop);
            return drop;
        }

        return null;
    }
}


