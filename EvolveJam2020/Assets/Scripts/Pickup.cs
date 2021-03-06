﻿using System;
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
    private int myType;

    [Header("Time in seconds it takes to pick this up")]
    [SerializeField]
    private float timerDefault;

    private float currentTime;

    private GameObject timerObject;

    /// <summary>
    /// Which spawn point it spawned at
    /// </summary>
    private int spawnPoint;

    /// <summary>
    /// Are we getting picked up currently?
    /// </summary>
    private bool pickingUp; 


    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = GameManager.instance.pickupSprites[myType];

        timerObject = transform.GetChild(0).gameObject;
        timerObject.SetActive(false);

        //GetComponent<Animator>().runtimeAnimatorController = GameManager.instance.pickupAnimations[myType];

        myClockAnim = timerObject.GetComponent<Animator>();

        myClockAnim.speed = 1 / timerDefault;

        Destroy(gameObject, 30);
    }

    // Update is called once per frame
    void Update()
    {
        if (pickingUp)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                GameManager.instance.LosePickup(myType, false);
                Destroy(gameObject);
            }
        }
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
            timerObject.SetActive(false);
            currentTime = timerDefault;
        }
    }

    public void SetUp(int typeId, int spawnId)
    {
        myType = typeId;
        spawnPoint = spawnId;
    }

    private void OnDestroy()
    {
        GameManager.instance.occupiedSpawns[spawnPoint] = false;
    }
}
