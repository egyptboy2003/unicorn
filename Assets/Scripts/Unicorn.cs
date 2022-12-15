using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Unicorn : MonoBehaviour
{
    private SpriteRenderer sRender;
    private Rigidbody2D rb;
    private Animator anim;
    public float maxSpeed;
    public float acceleration;
    public float jumpForce;
    public int carrots;
    public int ogCarrots;
    private bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        sRender = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        ogCarrots = GameObject.FindGameObjectsWithTag("Carrot").Length;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() && !isDead)
        {
            anim.SetTrigger("jumpTrigger");
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    
        // Update is called once per frame
    void FixedUpdate()
    {
        if (!isDead)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            if (Mathf.Abs(rb.velocity.x) < maxSpeed || rb.velocity.x * horizontalInput < 0)
            {
                rb.AddForce(new Vector2(horizontalInput * acceleration, 0), ForceMode2D.Impulse);
            }
            if (sRender.flipX)
            {
                sRender.flipX = horizontalInput <= 0;
            }
            else
            {
                sRender.flipX = horizontalInput < 0;
            }
            anim.SetBool("isRunning", horizontalInput != 0);
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D ray = Physics2D.Raycast(gameObject.transform.position, Vector2.down, 1f, layerMask: LayerMask.GetMask("floor tm"));
        return ray;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Snake")) {
            // TODO: Sound
            StartCoroutine(Respawn());
            Physics2D.IgnoreCollision(collision.collider, collision.otherCollider);
        } 
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("KillBox"))
        {
            // TODO: Sound
            StartCoroutine(Respawn());
        }
    }

    IEnumerator Respawn()
    {
        anim.SetTrigger("dieTrigger");
        isDead = true;
        yield return new WaitForSeconds(2);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }

    public void Win()
    {
        Time.timeScale = 0;
        MenuManagement menuManagement = GameObject.Find("GUI").GetComponent<MenuManagement>();
        menuManagement.toggleWinMenu();
    }
}