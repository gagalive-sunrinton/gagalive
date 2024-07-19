using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost_move : MonoBehaviour
{
    public sight2D sight = new sight2D();
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (sight.isSeePlayer == true)
        {
            Vector3 xd = new Vector3(sight.targetpos1.x, transform.position.y, 0);
            Vector3 dir = xd - transform.position;
            dir.Normalize();
            transform.position += dir * speed * Time.deltaTime;
        }
    }
}
