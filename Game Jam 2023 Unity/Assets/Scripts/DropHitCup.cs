using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropHitCup : MonoBehaviour
{
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    public void HitCup()
    {
        count++;
    }

    public int getCupCount()
    {
        return count;
    }
}
