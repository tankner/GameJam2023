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
    [SerializeField] private float dashSpeed = 3f;
    [SerializeField] private float dashLength= 0.5f;
    [SerializeField] private float dashlenMuti = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coordinate.x = Input.GetAxisRaw("Horizontal");
        coordinate.y = Input.GetAxisRaw("Vertical");
        
    }
	private void FixedUpdate()
	{   //myRB.position will get add by the coordinate x,y coordinate 50 times for every second.
        myRB.MovePosition(myRB.position + coordinate.normalized * moveSpeed * Time.fixedDeltaTime);
	}
}
