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
    int wherego;
    public float speed = 5f;
    private int a = 0;
    public SpriteRenderer spriterender;
    // Start is called before the first frame update
    void Start()
    {
        spriterender = new SpriteRenderer();
        wherego = Mathf.RoundToInt(Random.Range(0f, 1f));
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(wherego);
        if (sight.isSeePlayer == true)
        {
            Vector3 xd = new Vector3(sight.targetpos1.x, transform.position.y, 0);
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
                    wherego = 1;
                    Debug.Log("앙");
                }

                Vector3 dir_one = d1 - transform.position;
                dir_one.Normalize();
                transform.position += dir_one * (speed - 2) * Time.deltaTime;

            }
            else
            {
               
                Vector3 d2 = new Vector3(twopoint.transform.position.x, transform.position.y, 0);
                if (Mathf.RoundToInt(twopoint.transform.position.x) == Mathf.RoundToInt(transform.position.x))
                {
                    wherego = 0;;
                    Debug.Log("앙");
                }
                Vector3 dir_two = d2 - transform.position;
                dir_two.Normalize();
                transform.position += dir_two * (speed - 2) * Time.deltaTime;

            }
        }
    }
}
