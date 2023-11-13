using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droplet : MonoBehaviour
{
    private Vector2 moveDirection;
    private float moveSpeed;


    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 2f;    
    }

    public void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Boundary":
                SetMoveDirection(new Vector2(-moveDirection[0], moveDirection[1]));
                break;
            case "Floor":
                Destroy();
                break;
            case "Cup":
                Destroy();
                break;
        }
    }
}
