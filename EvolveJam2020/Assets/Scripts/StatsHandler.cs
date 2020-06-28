using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsHandler : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textBlock;

    // Start is called before the first frame update
    void Start()
    {
        float t = GameManager.instance.timeSurvived;
        int kills = GameManager.instance.enemiesKilled;
        int water = GameManager.instance.waterLevel;
        int earth = GameManager.instance.earthLevel;
        int fire = GameManager.instance.fireLevel;
        int air = GameManager.instance.airLevel;

        int total = water + earth + fire + air;

        textBlock.text = Mathf.FloorToInt(t / 60).ToString() + ":" + Mathf.FloorToInt(t % 60).ToString("00") +
            "\n" + kills.ToString() +
            "\n" + total.ToString() +
            "\n" + water.ToString() +
            "\n" + earth.ToString() +
            "\n" + fire.ToString() +
            "\n" + air.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
