﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField]
    private Transform targetPlayer;

    [SerializeField]
    private float speed;

    private SpriteRenderer mySP;

    // Start is called before the first frame update
    void Start()
    {
        mySP = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPlayer.position, speed * Time.deltaTime);
    }
}
