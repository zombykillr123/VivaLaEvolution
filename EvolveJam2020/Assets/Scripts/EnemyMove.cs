using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [Header("Set target, leave blank for random")]
    [SerializeField]
    private Transform target;

    private float speed;

    private SpriteRenderer mySP;

    
    // Start is called before the first frame update
    void Start()
    {        
        mySP = GetComponent<SpriteRenderer>();

        speed = GameManager.instance.enemySpeed;

        TargetNewPickup();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {
            // Pick a random pickup
            TargetNewPickup();
        }
        mySP.flipX = (target.position.x > transform.position.x);
    }

    private void TargetNewPickup()
    {
        GameObject[] pickups = GameManager.instance.allPickups;
        if (pickups.Length == 0)
        {
            TargetPlayer();
        }
        else
        {
            int randPickup = Random.Range(0, pickups.Length);
            if (pickups[randPickup] == null)
            {
                TargetPlayer();
            }
            else
            {
                target = pickups[randPickup].transform;
            }
        }
    }

    private void TargetPlayer()
    {
        // Pick a player instead
        int randPlayer = Random.Range(1, 3);

        target = GameManager.instance.GetPlayer(randPlayer).transform;
    }

}
