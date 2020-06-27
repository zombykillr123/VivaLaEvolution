using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameManager instance;

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null)
        {
            Destroy(this);
        }

        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StorePickups(int pickupType)
    {
        // Store the owned ones, increment a counter
    }
}
