using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : MonoBehaviour
{
    [SerializeField] int max = 10;
    private int count;
    
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    public void AddToCup()
    {
        if (!IsFull())
        {
            count++;
        }
    }

    public bool IsFull()
    {
        return count == max;
    }
    public void EmptyCup(string powerup)  // not sure if powerup like this is good
    {
        count = 0;
        // TODO: call respective powerup function
    }

}
