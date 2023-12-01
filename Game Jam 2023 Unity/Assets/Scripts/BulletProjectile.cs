using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    [Header("Bullet Stat")]
    public float bulletSpeed;
    public float bulletDistance;

    public Transform player;
    public Collider2D cupCollider;
    private Vector2 target;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        //Call the parasite position
        player = GameObject.FindGameObjectWithTag("Player").transform;
        // Make a direction vector that targeting the parasite position
        direction = (new Vector3(player.position.x, player.position.y, 0) - transform.position).normalized;
        
    }

    // Update is called once per frame
    void Update()
    {
        // The bullet will move toward the player intial position of the parasite( can modify this to make the bullet more unpredictable)
        // transform.position = Vector2.MoveTowards(transform.position, target, bulletSpeed * Time.deltaTime);
        transform.position = transform.position + direction * Time.deltaTime * bulletSpeed;
        //will make the bullet dissapear if it reach the final location
        // if( transform.position.x  == target.x && transform.position.y == target.y)
		// {
        //     DestroyBullet();
        // }
        
    }


    // check if two collider collide
	private void OnTriggerEnter2D(Collider2D collision)
	{
        // If two collider between bullet and parasite contact, destroy the bullet
        if (collision.CompareTag("Player") || collision.CompareTag("Floor") || collision.CompareTag("Boundary"))
		{
            DestroyBullet();
		}
	}
    
	void DestroyBullet()
	{
        //Destroy the bullet
        Destroy(gameObject);
	}
}
