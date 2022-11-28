using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public float patrolDistance;
    public float speed;

    private float patrolDirection = 1;
    private Vector3 ogPos;
    private SpriteRenderer sRender;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject snakeObj in GameObject.FindGameObjectsWithTag("Snake"))
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), snakeObj.GetComponent<Collider2D>());
        }
        sRender = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        ogPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(speed * patrolDirection, 0);
        if (Mathf.Abs(transform.position.x - ogPos.x) > patrolDistance)
        {
            // stops constant flipping at patrol boundary
            if (transform.position.x > ogPos.x)
            {
                patrolDirection = -1;
                sRender.flipX = true;
                
            } else
            {
                patrolDirection = 1;
                sRender.flipX = false;
            }
        }
    }
}
