using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private PlayerMove myPlayer;

    private void Start()
    {
        myPlayer = transform.parent.gameObject.GetComponent<PlayerMove>();
    }

    private void OnDestroy()
    {
        myPlayer.shielded = false;
    }
}
