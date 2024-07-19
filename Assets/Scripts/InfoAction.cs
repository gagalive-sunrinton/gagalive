using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoAction : MonoBehaviour
{
    Vector2 defScale;
    public InfoAction connected;
    public MapState stateTo;
    void Start()
    {
        defScale = transform.localScale;
    }

    void Update()
    {
        float dist = Vector2.Distance(transform.position, Player.main.transform.position);
        if (dist <= 2) {
            transform.localScale = defScale;

            if (Input.GetKeyDown(KeyCode.F)) {
                MapManager.Instance.state = stateTo;
                Player.main.transform.position = connected.transform.position;

                UIManager.Instance.Blind();
            }
        } else {
            float rate = (7 - dist) / 5;
            if (rate < 0) rate = 0;

            transform.localScale = defScale * rate;
        }
    }
}
