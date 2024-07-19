using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickSalt : MonoBehaviour
{
    Vector2 defScale;
    void Start()
    {
        defScale = transform.localScale;
    }

    void Update()
    {
        float dist = Vector2.Distance(transform.position, Player.main.transform.position);
        if (dist <= 3) {
            transform.localScale = defScale;

            if (Input.GetKeyDown(KeyCode.F)) {
                if (Player.main.salt < 2) Player.main.salt++;
            }
        } else {
            float rate = (8 - dist) / 5;
            if (rate < 0) rate = 0;

            transform.localScale = defScale * rate;
        }
    }
}
