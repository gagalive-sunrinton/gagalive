using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance {get; private set;}
    public Image black;

    void Awake() {
        Instance = this;
    }

    public void Blind() {
        StartCoroutine(blind());
    }

    IEnumerator blind() {
        Color col = black.color;

        for (int i = 10; i >= 0; i--) {
            col.a = 0.1f * i;

            black.color = col;

            yield return new WaitForSeconds(0.1f);
        }
    }
}
