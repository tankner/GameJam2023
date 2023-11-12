using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    int count;
    [SerializeField] int max = 10;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    public int getMax() { return max; }
    public int getCount() { return count; }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Booze")
        {
            ++count;
            UnityEngine.Debug.Log("it works dammit");
            UnityEngine.Debug.Log(count);
            // if count > max : lose game
        }
    }
}
