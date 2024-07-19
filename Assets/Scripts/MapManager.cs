using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MapState {
    Class,
    Corrider
}

public class MapManager : MonoBehaviour
{
    public GameObject classSet, corridorSet;
    public MapState state;
    void Start()
    {
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
