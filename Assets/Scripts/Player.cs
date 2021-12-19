using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : AIManager
{
    private GameObject Enemy;

    // Start is called before the first frame update
    void Start()
    {
        Health = 100.0f;

        Enemy = GameObject.FindGameObjectWithTag("Enemy");

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, angle + 90f);
    }
}
