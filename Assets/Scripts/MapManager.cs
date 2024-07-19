using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MapState {
    Class,
    Corrider,
    Science,
}

public class MapManager : MonoBehaviour
{
    public static MapManager Instance {get; private set;}
    public GameObject classSet, corridorSet, ScienceSet, spawnpos,monster;
    public MapState state;
    public InfoAction classGate1, classGate2, lastClass;
    public InfoAction scienceGate1, scienceGate2;
    public Ghost_move classMob;
    public float timer; 
    void Start()
    {
        Instance = this;
    }

    void Update()
    {
        classSet.SetActive(state == MapState.Class);
        if (state == MapState.Class)
        {
            
                timer += Time.deltaTime;
                if (timer > 5f && timer < 6f)
                {
                    classMob.gameObject.SetActive(true);
                    timer = 10000f;

                }
        }
        else
        {
            classMob.gameObject.SetActive(false);
            classMob.transform.position = spawnpos.transform.position;
            timer = 0;
        }
        corridorSet.SetActive(state == MapState.Corrider);
        ScienceSet.SetActive(state == MapState.Science);

        if (state == MapState.Class) {
            if (Input.GetKeyDown(KeyCode.F)) {
            }
        }
    }
}
