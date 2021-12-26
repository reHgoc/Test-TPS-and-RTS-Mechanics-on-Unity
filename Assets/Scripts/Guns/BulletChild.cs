using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletChild : Bullets
{
    Rigidbody2D rb;
    GunManager GM;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GM = GameObject.Find("Player").GetComponent<GunManager>();
    }
    private void FixedUpdate()
    {
        rb.AddForce(GM.BulletPoint.right * speed, ForceMode2D.Impulse);
    }
}
