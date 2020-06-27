using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [Header("Set target, leave blank for random")]
    [SerializeField]
    private Transform targetPlayer;

    /// <summary>
    /// Which pickup it's targetting. Randomly chosen if not set above
    /// </summary>
    private int targetPickup;

    [SerializeField]
    private float speed;

    private SpriteRenderer mySP;

    
    // Start is called before the first frame update
    void Start()
    {        
        mySP = GetComponent<SpriteRenderer>();
        if (targetPlayer == null)
        {
            TargetNewPickup();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (targetPlayer != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPlayer.position, speed * Time.deltaTime);
        }
        else
        {
            // Pick a random pickup
            TargetNewPickup();
        }
        mySP.flipX = (targetPlayer.position.x > transform.position.x);
    }

    private void TargetNewPickup()
    {
        GameObject[] pickups = GameManager.instance.allPickups;
        int randPickup = Random.Range(0, pickups.Length);
        targetPlayer = pickups[randPickup].transform;
    }
}
