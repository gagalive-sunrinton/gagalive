using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer render;
    public float gravity, moveSpeed;
    public sight2D sight2D1 = new sight2D();
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sight2D1.isSeePlayer == true)
        {
            Debug.Log("으아ㅏ아아!");
        }
        
        float h = Input.GetAxis("Horizontal");

        if (InStair()) {
            rb.gravityScale = 0;
            rb.velocity = new Vector2(rb.velocity.x, 0);

            h /= 2;

            bool up = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space);
            bool down = Input.GetKey(KeyCode.S);

            if (up) 
                transform.Translate(Vector2.up * 6 * Time.deltaTime);
            else if (down) 
                transform.Translate(-Vector2.up * 6 * Time.deltaTime);
        } else {
            rb.gravityScale = gravity;
        }

        if (h == 0) {
            rb.velocity = new Vector2(rb.velocity.x / 3, rb.velocity.y);
        } else {
            if (h < 0) {
                transform.localScale = new Vector3(-1, 1);
            } else {
                transform.localScale = new Vector3(1, 1);
            }
            rb.velocity = new Vector2(h * 10 * moveSpeed * Time.deltaTime, rb.velocity.y);
        }
    }

    public bool InStair() {
        RaycastHit2D cast = Physics2D.BoxCast(transform.position, new Vector2(0.5f, 0.5f), 0, Vector2.down, 0.7f, LayerMask.GetMask("stair"));

        return cast;
    }
}
