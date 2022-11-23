using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public float patrolDistance;
    public float speed;

    private float patrolDirection = 1;
    private Vector3 ogPos;
    private float waitDuration = 3;
    private float currentWait;
    private SpriteRenderer sRender;
    private Rigidbody2D rb;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        sRender = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
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
