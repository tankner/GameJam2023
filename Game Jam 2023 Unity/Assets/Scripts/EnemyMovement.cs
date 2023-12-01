using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{   [Header("Enemy Movement Stat")]
    public float speed;
    public float stopDistance;
    public float retreatDistance;
    public float retreatSpeed;

    [Header("Enemy Bullet Stat")]
    //Two variable for time between shot to avoid aliasing, which can cause shooting 60 bullet in one frame
    public float startTimeBtwShots;
    private float timeBtwShots;

    public Transform player;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        // Calling player transform component
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
        stopDistance += Random.Range(-2.0f, 3.0f);
        retreatDistance += Random.Range(-2.0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        // if the distance between the enemy and parasite is furthur than the stopDistance, the ememy move closer to the parasite
        if(Vector2.Distance(transform.position, player.position) > stopDistance)
		{
            // enemy move toward the parasite with amount of speed
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
		}
        
        // if the distance between the enemy is close enough, the enemy will stop
        else if(Vector2.Distance(transform.position, player.position) < stopDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
		{
            transform.position = this.transform.position;
        }
        // ifthe parasite too close to the enemy will move away from it.
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
		{
            transform.position = Vector2.MoveTowards(transform.position, player.position, -retreatSpeed *Time.deltaTime);
        }
        // --------------------------------------------Spawning Bullet Code-----------------------------------------------------------

        if(timeBtwShots <= 0)
		{   //Release bullet from current enemy body with no rotation(Quaternion.identity)
            Instantiate(bullet, transform.position, Quaternion.identity);
            
            // Update re initialize timeBtwShots with startTimeBtwShots;
            timeBtwShots = startTimeBtwShots;
		}
		else
		{
            //Cooldown between shot.
            timeBtwShots -= Time.deltaTime;
		}
      
    }
}
