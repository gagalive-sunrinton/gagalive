using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player main {get; private set;}
    Rigidbody2D rb;
    public Light2D sp_light;
    SpriteRenderer render;
    Animator animator;
    public float gravity, moveSpeed;
    public float stemina = 100;
    [SerializeField] Slider stemina_display;
    [SerializeField] Image Fill, background;
    float stem_disTime;
    public float stairMax, stairMin;
    public int health, salt;
    public GameObject saltsalt;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        main = this;

        health = 6;
    }

    void Update() {
        if (salt > 0 && Input.GetKeyDown(KeyCode.J)) {
            salt--;

            var obj = Instantiate(saltsalt, transform.localScale.x / 1.5f * new Vector3(2, 1) + transform.position, Quaternion.identity);
            Destroy(obj, 10);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        sp_light.lightCookieSprite = render.sprite;

        float speed = 10 * moveSpeed;
        stemina_display.value = stemina / 100f;
        
        float h = Input.GetAxis("Horizontal");

        if (MapManager.Instance.state == MapState.Class) {
            stemina += Time.deltaTime * 20;

            stem_disTime = 3;

            if (stemina > 100) stemina = 100;
        }

        if (Input.GetKey(KeyCode.LeftShift) && stemina > 0) {
            speed *= 1.5f;

            stemina -= 60 * Time.fixedDeltaTime;

            stem_disTime = 3;

            animator.SetBool("isSprinting", true);
        } else {
            animator.SetBool("isSprinting", false);
        }

        stem_disTime -= Time.deltaTime;

        Color fcol = Fill.color;
        Color bcol = background.color;
        bcol.a = fcol.a = stem_disTime/3f;

        Fill.color = fcol;
        background.color = bcol;

        if (InStair()) {
            rb.gravityScale = 0;
            rb.velocity = new Vector2(rb.velocity.x, 0);

            h /= 2;

            bool up = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space);
            bool down = Input.GetKey(KeyCode.S);

            if (up) {
                transform.Translate(Vector2.up * 3 * Time.fixedDeltaTime);
                animator.SetInteger("stair", 1);
            }else if (down) {
                transform.Translate(-Vector2.up * 3 * Time.fixedDeltaTime);
                animator.SetInteger("stair", 2);
            }
        } else {
            rb.gravityScale = gravity;
            animator.SetInteger("stair", 0);
        }

        if (h == 0) {
            rb.velocity = new Vector2(rb.velocity.x / 3, rb.velocity.y);
            animator.SetBool("isMoving", false);
        } else {
            animator.SetBool("isMoving", true);
            if (h < 0) {
                transform.localScale = new Vector3(-1.5f, 1.5f);
                stemina_display.transform.localScale = new Vector3(0.7f, 0.7f);
            } else {
                transform.localScale = new Vector3(1.5f, 1.5f);
                stemina_display.transform.localScale = new Vector3(-0.7f, 0.7f);
            }

            rb.velocity = new Vector2(h * speed * Time.fixedDeltaTime, rb.velocity.y);
        }
    }

    public bool InStair() {
        RaycastHit2D cast = Physics2D.BoxCast(transform.position, new Vector2(0.5f, 0.5f), 0, Vector2.down, 0.7f, LayerMask.GetMask("stair"));

        return cast;
    }

    private void OnCollisionEnter2D(Collision2D collision)

    {

        if (collision.gameObject.tag == "enemy")

        {
            MapManager.Instance.lastClass.Go();
            health--;
            MapManager.Instance.timer = -5f;
            MapManager.Instance.classMob.gameObject.SetActive(false);

            if (health <= 0) {
                SceneManager.LoadScene("Die_ending");
            }
        }

    }
}
