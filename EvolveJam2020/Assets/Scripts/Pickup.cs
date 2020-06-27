using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    /// <summary>
    /// Animation of the clock
    /// </summary>
    private Animator myClockAnim; 

    [SerializeField]
    private int myType; // not using enums right now, can do it later

    [Header("Time in seconds it takes to pick this up")]
    [SerializeField]
    private float timerDefault;

    private float currentTime;

    private GameObject timerObject;

    /// <summary>
    /// Are we getting picked up currently?
    /// </summary>
    private bool pickingUp; 

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().color = GameManager.instance.pickupColors[myType];

        timerObject = transform.GetChild(0).gameObject;
        timerObject.SetActive(false);

        myClockAnim = timerObject.GetComponent<Animator>();

        myClockAnim.speed = 1 / timerDefault;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                // Start counting down
                currentTime = timerDefault;
                timerObject.SetActive(true);
                pickingUp = true;
                StartCoroutine(TimerToPickup());
                break;
            case "Enemy":
                GameManager.instance.LosePickup(myType, true);
                Destroy(gameObject);
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Resest timer stats
            pickingUp = false;
            StopCoroutine(TimerToPickup());
            timerObject.SetActive(false);
        }
    }

    IEnumerator TimerToPickup()
    {
        while (currentTime > 0 && pickingUp)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                // When timer is 0, destroy it
                GameManager.instance.LosePickup(myType, false);
                Destroy(gameObject);
            }
            yield return null;
        }
        
    }
}
