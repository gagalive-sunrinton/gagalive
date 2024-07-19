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
    public GameObject classSet, corridorSet;
    public MapState state;
    void Start()
    {
        Instance = this;
    }

    void Update()
    {
        classSet.SetActive(state == MapState.Class);
        corridorSet.SetActive(state == MapState.Corrider);

        if (state == MapState.Class) {
            if (Input.GetKeyDown(KeyCode.F)) {
            }
        }
    }
}
