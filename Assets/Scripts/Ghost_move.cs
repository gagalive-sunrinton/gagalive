using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ghost_move : MonoBehaviour
{
    public sight2D sight = new sight2D();
    public GameObject onepoint;
    public GameObject twopoint;
    public GameObject onepoint_stair_right;
    public GameObject twopoint_stair_right;
    public GameObject threepoint_stair_right;
    public GameObject onepoint_stair_left;
    public GameObject twopoint_stair_left;
    public GameObject threepoint_stair_left;
    int wherego;
    private bool up = false;
    public float speed = 5f;
    private int a = 0;
    private Rigidbody2D rb;
    private int star = 0;

    private bool upToone = false;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        wherego = Mathf.RoundToInt(Random.Range(0f, 1f));

        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(wherego);
       
        if (sight.isSeePlayer == true || MapManager.Instance.state == MapState.Class)
        {
            Vector3 xd = new Vector3(Player.main.transform.position.x, transform.position.y, 0);
            Vector3 dir = xd - transform.position;
            dir.Normalize();
            transform.position += dir * speed * Time.deltaTime;
        }
        else
        {
            
           
            if (wherego == 0)
            {
              
                Vector3 d1 = new Vector3(onepoint.transform.position.x, transform.position.y, 0);
                if (Mathf.RoundToInt(onepoint.transform.position.x) == Mathf.RoundToInt(transform.position.x))
                {
                    if (upToone)
                    {
                        upToone = false;
                    }
                    else
                    {
                        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y);
                        
                    }
                       
                   
                    
                        
                int d = Mathf.RoundToInt(Random.Range(0f, 1f));
                    if (d == 0)
                    {
                        wherego = 1;
                    }
                    else
                    {
                        wherego = 3;
                    }
                    Debug.Log("앙");
                    
                    
                    a++;
                }

                Vector3 dir_one = d1 - transform.position;
                dir_one.Normalize();
                transform.position += dir_one * (speed - 2) * Time.deltaTime;

            }
            else if(wherego == 1)
            {
          
                if (a == 0)
                {
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y);
                    a++;
                }
                Vector3 d2 = new Vector3(twopoint.transform.position.x, transform.position.y, 0);
                if (Mathf.RoundToInt(twopoint.transform.position.x) == Mathf.RoundToInt(transform.position.x))
                {
                    int d = Mathf.RoundToInt(Random.Range(0f, 1f));
                    if (d == 0)
                    {
                        wherego = 0;
                    }
                    else
                    {
                        wherego = 2;
                    }
                    Debug.Log("앙");
                    if (upToone)
                    {
                        upToone = false;
                    }
                    else
                    {
                        
                        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y);
                  
                    }
                    a++;
                }
                Vector3 dir_two = d2 - transform.position;
                dir_two.Normalize();
                transform.position += dir_two * (speed - 2) * Time.deltaTime;

            }
            else if (wherego == 2)
            {
                if (up == false)
                {
                    Debug.Log("올라가야됨");
                    up1();
                }
                else
                {
                    Debug.Log("내려가야됨");
                   down1();
              
                }
                
            }
            else if(wherego == 3)
            {
                if (up == false)
                {
                    Debug.Log("올라가야됨");
                    up2();
                }
                else
                {
                    Debug.Log("내려가야됨");
                    down2();
              
                }
            }
            else
            {
                Debug.Log("afdoahufdankjafdilafsdm");
            }
        }
    }




    public void up1()
    {
           if (star == 0)
                {
                    Vector3 d1 = new Vector3(onepoint.transform.position.x, transform.position.y, 0);
                    if (Mathf.RoundToInt(onepoint.transform.position.x) == Mathf.RoundToInt(transform.position.x))
                    {
                        star = 1;
                        Debug.Log("앙");
                        a++;
                    }

                    Vector3 dir_one = d1 - transform.position;
                    dir_one.Normalize();
                    transform.position += dir_one * (speed - 2) * Time.deltaTime;
                }
                else if(star ==1 )
                {
                    rb.gravityScale = 0;
                    Vector3 d1 = new Vector3(transform.position.x, onepoint_stair_right.transform.position.y, 0);
                    if (Mathf.RoundToInt(onepoint_stair_right.transform.position.y) == Mathf.RoundToInt(transform.position.y))
                    {
                        star = 2;
                        Debug.Log("앙");
                    }
    
                    Vector3 dir_one = d1 - transform.position;
                    dir_one.Normalize();
                    transform.position += dir_one * (speed - 2) * Time.deltaTime;
                }
                else if (star == 2)
                {
                    Vector3 d1 = new Vector3(twopoint_stair_right.transform.position.x, transform.position.y, 0);
                    if (Mathf.RoundToInt(twopoint_stair_right.transform.position.x) == Mathf.RoundToInt(transform.position.x))
                    {
                        star = 3;
                        Debug.Log("앙");
                    }
    
                    Vector3 dir_one = d1 - transform.position;
                    dir_one.Normalize();
                    transform.position += dir_one * (speed - 2) * Time.deltaTime;
                }
                else
                {
                    Vector3 d1 = new Vector3(transform.position.x, threepoint_stair_right.transform.position.y, 0);
                    if (Mathf.RoundToInt(threepoint_stair_right.transform.position.y) == Mathf.RoundToInt(transform.position.y))
                    {
                        wherego = 0;
                        up = true;
                        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y);
                        Debug.Log("앙");
                        upToone = true;
                    }
    
                    Vector3 dir_one = d1 - transform.position;
                    dir_one.Normalize();
                    transform.position += dir_one * (speed - 2) * Time.deltaTime;
                }
    }

    public void down1()
    {
        if (star == 3)
        {
            Vector3 d1 = new Vector3(threepoint_stair_right.transform.position.x, transform.position.y, 0);
            if (Mathf.RoundToInt(threepoint_stair_right.transform.position.x) == Mathf.RoundToInt(transform.position.x))
            {
                star = 2;
                
            }
            Vector3 dir_one = d1 - transform.position;
            dir_one.Normalize();
            transform.position += dir_one * (speed - 2) * Time.deltaTime;
        }
        else if (star == 2)
        {
            Vector3 d1 = new Vector3(transform.position.x, twopoint_stair_right.transform.position.y, 0);
            if (Mathf.RoundToInt(twopoint_stair_right.transform.position.y) == Mathf.RoundToInt(transform.position.y))
            {
                star = 1;
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y);
            }
            Vector3 dir_one = d1 - transform.position;
            dir_one.Normalize();
            transform.position += dir_one * (speed - 2) * Time.deltaTime;
        }
        else if(star == 1)
        {
            Vector3 d1 = new Vector3(onepoint_stair_right.transform.position.x, transform.position.y, 0);
            if (Mathf.RoundToInt(onepoint_stair_right.transform.position.x) == Mathf.RoundToInt(transform.position.x))
            {
                star = 0;
                
            }
            Vector3 dir_one = d1 - transform.position;
            dir_one.Normalize();
            transform.position += dir_one * (speed - 2) * Time.deltaTime;
        }
        else
        {
            Vector3 d1 = new Vector3(transform.position.x, onepoint.transform.position.y, 0);
            if (Mathf.RoundToInt(onepoint.transform.position.y) == Mathf.RoundToInt(transform.position.y))
            {
                wherego = 0;
                up = false;
                rb.gravityScale = 0;
                upToone = true;
            }
            Vector3 dir_one = d1 - transform.position;
            dir_one.Normalize();
            transform.position += dir_one * (speed - 2) * Time.deltaTime;
        }
    }
    
     public void up2()
    {
           if (star == 0)
                {
                    Vector3 d1 = new Vector3(twopoint.transform.position.x, transform.position.y, 0);
                    if (Mathf.RoundToInt(twopoint.transform.position.x) == Mathf.RoundToInt(transform.position.x))
                    {
                        star = 1;
                        Debug.Log("앙");
                        a++;
                    }

                    Vector3 dir_one = d1 - transform.position;
                    dir_one.Normalize();
                    transform.position += dir_one * (speed - 2) * Time.deltaTime;
                }
                else if(star ==1 )
                {
                    rb.gravityScale = 0;
                    Vector3 d1 = new Vector3(transform.position.x, onepoint_stair_left.transform.position.y, 0);
                    if (Mathf.RoundToInt(onepoint_stair_left.transform.position.y) == Mathf.RoundToInt(transform.position.y))
                    {
                        star = 2;
                        Debug.Log("앙");
                    }
    
                    Vector3 dir_one = d1 - transform.position;
                    dir_one.Normalize();
                    transform.position += dir_one * (speed - 2) * Time.deltaTime;
                }
                else if (star == 2)
                {
                    Vector3 d1 = new Vector3(twopoint_stair_left.transform.position.x, transform.position.y, 0);
                    if (Mathf.RoundToInt(twopoint_stair_left.transform.position.x) == Mathf.RoundToInt(transform.position.x))
                    {
                        star = 3;
                        Debug.Log("앙");
                    }
    
                    Vector3 dir_one = d1 - transform.position;
                    dir_one.Normalize();
                    transform.position += dir_one * (speed - 2) * Time.deltaTime;
                }
                else
                {
                    Vector3 d1 = new Vector3(transform.position.x, threepoint_stair_left.transform.position.y, 0);
                    if (Mathf.RoundToInt(threepoint_stair_left.transform.position.y) == Mathf.RoundToInt(transform.position.y))
                    {
                        wherego = 1;
                        up = true;
                        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y);
                        Debug.Log("앙");
                        upToone = true;
                    }
    
                    Vector3 dir_one = d1 - transform.position;
                    dir_one.Normalize();
                    transform.position += dir_one * (speed - 2) * Time.deltaTime;
                }
    }
    public void down2()
    {
        if (star == 3)
        {
            Vector3 d1 = new Vector3(threepoint_stair_left.transform.position.x, transform.position.y, 0);
            if (Mathf.RoundToInt(threepoint_stair_left.transform.position.x) == Mathf.RoundToInt(transform.position.x))
            {
                star = 2;
                
            }
            Vector3 dir_one = d1 - transform.position;
            dir_one.Normalize();
            transform.position += dir_one * (speed - 2) * Time.deltaTime;
        }
        else if (star == 2)
        {
            Vector3 d1 = new Vector3(transform.position.x, twopoint_stair_left.transform.position.y, 0);
            if (Mathf.RoundToInt(twopoint_stair_left.transform.position.y) == Mathf.RoundToInt(transform.position.y))
            {
                star = 1;
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y);
            }
            Vector3 dir_one = d1 - transform.position;
            dir_one.Normalize();
            transform.position += dir_one * (speed - 2) * Time.deltaTime;
        }
        else if(star == 1)
        {
            Vector3 d1 = new Vector3(onepoint_stair_left.transform.position.x, transform.position.y, 0);
            if (Mathf.RoundToInt(onepoint_stair_left.transform.position.x) == Mathf.RoundToInt(transform.position.x))
            {
                star = 0;
                
            }
            Vector3 dir_one = d1 - transform.position;
            dir_one.Normalize();
            transform.position += dir_one * (speed - 2) * Time.deltaTime;
        }
        else
        {
            Vector3 d1 = new Vector3(transform.position.x, twopoint.transform.position.y, 0);
            if (Mathf.RoundToInt(twopoint.transform.position.y) == Mathf.RoundToInt(transform.position.y))
            {
                wherego = 1;
                up = false;
                rb.gravityScale = 0;
                upToone = true;
            }
            Vector3 dir_one = d1 - transform.position;
            dir_one.Normalize();
            transform.position += dir_one * (speed - 2) * Time.deltaTime;
        }
    }
}


