using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoAction : MonoBehaviour
{
    Vector2 defScale;
    public InfoAction connected;
    public MapState stateTo;
    public InfoAction gate1, gate2;
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
                Go();
            }
        } else {
            float rate = (7 - dist) / 5;
            if (rate < 0) rate = 0;

            transform.localScale = defScale * rate;
        }
    }

    public void Go() {
        MapManager.Instance.state = stateTo;
        Player.main.transform.position = connected.transform.position;

        UIManager.Instance.Blind();

        if (stateTo == MapState.Class) {
            MapManager.Instance.lastClass = this;
            MapManager.Instance.classGate1.connected = gate1;
            MapManager.Instance.classGate2.connected = gate2;
        }

        if (stateTo == MapState.Science) {
            MapManager.Instance.scienceGate1.connected = gate1;
            MapManager.Instance.scienceGate2.connected = gate2;
        }
    }
}
