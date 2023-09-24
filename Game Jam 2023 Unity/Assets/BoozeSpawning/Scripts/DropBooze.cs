using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBooze : MonoBehaviour
{
    [SerializeField] private int dropletAmount = 10;

    public Vector3 dropletPosition;

    private float min_x = -5.0f;
    private float max_x = 5.0f;

    private float min_y = 10.0f;
    private float max_y = 15.0f;

    // private float SCREENEDGE = 10.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Drop", 0f, 8f);
    }

    private void Drop()
    {
        for (int i = 0; i < dropletAmount; i++)
        {
            GameObject drop = DropletPool.instance.GetDroplet();
            dropletPosition = new Vector3(Random.Range(min_x, max_x), Random.Range(min_y, max_y), 0);
            drop.transform.position = dropletPosition;
            drop.SetActive(true);

            if (dropletPosition[0] < min_x + 1.0f)
            {
                drop.GetComponent<Droplet>().SetMoveDirection(new Vector2(1, 0));
            } else if (dropletPosition[0] > max_x - 1.0f)
            {
                drop.GetComponent<Droplet>().SetMoveDirection(new Vector2(-1, 0));
            }
            else 
            {
                drop.GetComponent<Droplet>().SetMoveDirection(new Vector2(Random.Range(-1, 1), 0)); 
            }
            
        }
    }
}
