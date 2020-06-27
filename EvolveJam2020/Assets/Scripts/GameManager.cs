﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;

    /// <summary>
    /// Pickups you own
    /// </summary>
    private List<int> ownedPickups;

    /// <summary>
    /// Number of pickups still in this level
    /// </summary>
    private int remainingPickups;

    /// <summary>
    /// Pickups reference this to get color
    /// </summary>
    public Color[] pickupColors;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }

        instance = this;

        ownedPickups = new List<int>();

        StartLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Addps pickups you grab to the list
    /// </summary>
    /// <param name="pickupType">The pickups number</param>
    public void StorePickups(int pickupType)
    {
        // Store the owned ones, increment a counter
        ownedPickups.Add(pickupType);
        remainingPickups--;
        if (remainingPickups <= 0)
        {
            // End the level
            Debug.Log("This is when the level ends");
        }
    }


    /// <summary>
    /// Sets the number of pickups in the level. When it reaches 0 it does something
    /// </summary>
    public void StartLevel()
    {
        remainingPickups = GameObject.FindGameObjectsWithTag("pickup").Length;
    }
}