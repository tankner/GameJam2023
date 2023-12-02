using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] GameObject EnemySpawner;
    [SerializeField] GameObject Parasite;
    [Header("Movement")]
    public float moveSpeed = 5f;
    public Rigidbody2D myRB;
    public SpriteRenderer myRenderer;
    Vector2 coordinate;
    
    int count;
    [SerializeField] int max =15;    // max booze level
    public Sprite state1;  // empty state
    public Sprite state2;  // 1/3 full state
    public Sprite state3;  // 2/3 full state
    public Sprite state4;  // full state

    public Sprite drinkSprite;  // drinking animation


    [Header("Dash")]
    [SerializeField] float dashSpeed = 100f;
    [SerializeField] float dashSpeedMultiply = 0.3f;
    [SerializeField] float dashTime = 0.5f;
    [SerializeField] float dashCooldown = 1f;
    
    Vector2 dashDir;
    bool isDashing;
	bool canDash = true;

    void Start()
    {
        count = 0;
        myRenderer.sprite = state1;
    }

    // Update is called once per frame
    void Update()
    {
		if (isDashing)
		{
            return;
		}
        //Get coordinate(x, y)
        coordinate.x = Input.GetAxisRaw("Horizontal");
        Debug.Log("Parasite Position: " + Parasite.transform.position.x);
        Debug.Log("Mouse Position: " + Input.mousePosition.x);

        Vector2 screenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Flip sprite when mouse is on the left side of the screen and flip capsule collider 2d to match the sprite

        if (screenPosition.x < Parasite.transform.position.x)
        {
            myRenderer.flipX = false;
            Parasite.GetComponent<CapsuleCollider2D>().offset = new Vector2(-0.5f, 0);
        }
        else
        {
            myRenderer.flipX = true;
            Parasite.GetComponent<CapsuleCollider2D>().offset = new Vector2(0.5f, 0);
        }

        coordinate.y = Input.GetAxisRaw("Vertical");

        // Check if player press dash
		if (Input.GetKeyDown(KeyCode.Space) & canDash)
		{
            StartCoroutine(Dash());
		} else if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(EmptyCup());
        }
        // Get vector2D for dash direction
        dashDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;


    }
	private void FixedUpdate()
	{   //myRB.position will get add by the coordinate x,y coordinate 50 times for every second.
        if (isDashing)
        {
            return;
        }
        myRB.MovePosition(myRB.position + coordinate.normalized * moveSpeed * Time.fixedDeltaTime);
	}

    // Dash mechanic
    private IEnumerator Dash()
    {
        // while dash, canDash become false because Dash too many time is OP
        canDash = false;
        isDashing = true;
        myRB.velocity = new Vector2(dashDir.x * dashSpeed * dashSpeedMultiply, dashDir.y * dashSpeed * dashSpeedMultiply);
        yield return new WaitForSeconds(dashTime);
        isDashing = false;
        //Cooldown for dash
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }


    // collisions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(myRenderer.sprite == drinkSprite)
            {
                return;
            }
        switch(collision.gameObject.tag)
        {
            
            case "Booze":
                if (count < max / 3)
                {
                    count++;
                    UnityEngine.Debug.Log(count);
                    // set state 1
                    myRenderer.sprite = state1;
                }
                else if (count < max * 2 / 3)
                {
                    count++;
                    UnityEngine.Debug.Log(count);
                    // set state 2
                    myRenderer.sprite = state2;
                }
                else if (count < max)
                {
                    count++;
                    UnityEngine.Debug.Log(count);
                    // set state 3
                    myRenderer.sprite = state3;
                }
                else if (count == max)
                {
                    UnityEngine.Debug.Log("Cup full");
                    // set state 4
                    myRenderer.sprite = state4;
                }
                collision.gameObject.SetActive(false);
                // increment cup counter
                break;
            case "Bullet":
                if(count < max / 3)
                {
                    count = 0;
                } else if (count < max *2/3){
                    count -= max / 3;
                    myRenderer.sprite = state1;
                } else if (count < max)
                {
                    count -= max / 3;
                    myRenderer.sprite = state2;
                } else 
                {
                    count -= max / 3;
                    myRenderer.sprite = state3;
                }
                UnityEngine.Debug.Log("hit");
                UnityEngine.Debug.Log(count);
                break;
        }
    }

    // placeholder for drinking and getting power up
    public IEnumerator EmptyCup()  // not sure if powerup like this is good
    {
        if (count < max) yield return null;
        myRenderer.sprite = drinkSprite;
        yield return new WaitForSeconds(1.0f);

        // empty cup
        count = 0;
        myRenderer.sprite = state1;
        EnemySpawner.GetComponent<EnemySpawner>().Kill();

    }
}
