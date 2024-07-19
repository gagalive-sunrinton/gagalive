using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player main {get; private set;}
    Rigidbody2D rb;
    SpriteRenderer render;
    public float gravity, moveSpeed;
    public float stemina = 100;
    [SerializeField] Slider stemina_display;
    [SerializeField] Image Fill, background;
    float stem_disTime;
    float stairMax, stairMin;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();

        main = this;
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 10 * moveSpeed;
        stemina_display.value = stemina / 100f;
        
        float h = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.LeftShift)) {
            speed *= 1.5f;

            stemina -= 160 * Time.deltaTime;

            stem_disTime = 3;
        }

        if (InStair()) {
            rb.gravityScale = 0;
            rb.velocity = new Vector2(rb.velocity.x, 0);

            speed /= 1.5f;

            bool up = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space);
            bool down = Input.GetKey(KeyCode.S);

            if (up && transform.position.y < stairMax) 
                transform.Translate(Vector2.up * 6 * Time.deltaTime);
            else if (down && transform.position.y > stairMin + 1f) 
                transform.Translate(-Vector2.up * 6 * Time.deltaTime);
        } else {
            rb.gravityScale = gravity;
        }

        if (h == 0) {
            rb.velocity = new Vector2(rb.velocity.x / 3, rb.velocity.y);
        } else {
            if (h < 0) {
                transform.localScale = new Vector3(-1, 1);
                stemina_display.transform.localScale = new Vector3(1, 1);
            } else {
                transform.localScale = new Vector3(1, 1);
                stemina_display.transform.localScale = new Vector3(-1, 1);
            }

            rb.velocity = new Vector2(h * speed * Time.deltaTime, rb.velocity.y);
        }
    }

    public bool InStair() {
        RaycastHit2D cast = Physics2D.BoxCast(transform.position, new Vector2(0.5f, 0.5f), 0, Vector2.down, 0.7f, LayerMask.GetMask("stair"));

        if (cast) {
            stairMin = cast.transform.position.y - cast.transform.localScale.y;
            stairMax = cast.transform.position.y + cast.transform.localScale.y;
        }

        return cast;
    }
}
