using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    public Rigidbody2D myRB;
    Vector2 coordinate;


    [Header("Dash")]
    [SerializeField] float dashSpeed = 100f;
    [SerializeField] float dashSpeedMultiply = 0.3f;
    [SerializeField] float dashTime = 0.5f;
    [SerializeField] float dashCooldown = 1f;
    Vector2 dashDir;
    bool isDashing;
	bool canDash = true;

  
    // Update is called once per frame
    void Update()
    {
		if (isDashing)
		{
            return;
		}
        //Get coordinate(x, y)
        coordinate.x = Input.GetAxisRaw("Horizontal");
        coordinate.y = Input.GetAxisRaw("Vertical");

        // Check if player press dash
		if (Input.GetKeyDown(KeyCode.Space) & canDash)
		{
            StartCoroutine(Dash());
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

    //Dash mechanic
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
        switch(collision.gameObject.tag)
        {
            case "Booze":
                collision.gameObject.SetActive(false);
                break;
        }
    }
}
