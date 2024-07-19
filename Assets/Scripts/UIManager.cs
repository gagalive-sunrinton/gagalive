using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance {get; private set;}
    public Image black;
    public Image health;
    public Text hp;
    public Text timerText;
    public Text saltsalt;
    public float timer;
    public Sprite h0, h1, h2, h3, h4, h5;

    void Awake() {
        Instance = this;
    }

    void Update() {
        timer += Time.deltaTime;

        timerText.text = ((timer / 60 < 10) ? "0" + ((int)(timer / 60)) : ((int)(timer / 60)).ToString()) + ":" + ((timer % 60 < 10) ? "0" + ((int)timer % 60) : ((int)timer % 60).ToString());

        switch (Player.main.health) {
            case 6:
            health.sprite = h0;
            break;
            case 5:
            health.sprite = h1;
            break;
            case 4:
            health.sprite = h2;
            break;
            case 3:
            health.sprite = h3;
            break;
            case 2:
            health.sprite = h4;
            break;
            case 1:
            health.sprite = h5;
            break;
        }

        hp.text = Player.main.health.ToString() + "/6";
        saltsalt.text = Player.main.salt.ToString() + "/2";
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
