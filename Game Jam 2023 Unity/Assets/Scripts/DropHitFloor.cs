using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoozeCounter : MonoBehaviour
{
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    public void HitFloor()
    {
        count++;
    }

    public int getFloorCount()
    {
        return count;
    }
}
