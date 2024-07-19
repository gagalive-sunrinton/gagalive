using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MapState {
    Class,
    Corrider
}

public class MapManager : MonoBehaviour
{
    public static MapManager Instance {get; private set;}
    public GameObject classSet, corridorSet, spawnpos,monster;
    public MapState state;
    public InfoAction classGate1, classGate2;
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
                    GameObject mon = Instantiate(monster, spawnpos.transform.position,Quaternion.identity);
                    timer = 10000f;

                }
        }
        else
        {
            Destroy(monster);
        }
        corridorSet.SetActive(state == MapState.Corrider);

        if (state == MapState.Class) {
            if (Input.GetKeyDown(KeyCode.F)) {
            }
        }
    }
}
