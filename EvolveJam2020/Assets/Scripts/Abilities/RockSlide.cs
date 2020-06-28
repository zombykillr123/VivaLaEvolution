using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSlide : MonoBehaviour
{
    int level;

    // Start is called before the first frame update
    void Start()
    {
        level = GameManager.instance.earthLevel;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * (Time.deltaTime * (1+level/10)));
    }

    public void Done()
    {
        Destroy(gameObject);
    }
}
