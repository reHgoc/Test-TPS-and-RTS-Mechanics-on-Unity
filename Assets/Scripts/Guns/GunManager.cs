using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : Guns
{
    Bullets bullet = new Bullets();

    public GameObject BulletPrefab;
    public Transform BulletPoint;


    private void Start()
    {
        CurrentCountBullets = StartCountBullets;
        bullet.speed = 20.0f; //temporary
    }

    public void Reload()                                // Reloading gun
    {
        float CountTimer;
        CountTimer = reloadSpeed - Time.deltaTime;

        if (CountTimer <= 0)
        {
            CurrentCountBullets = StartCountBullets;
            CountTimer = reloadSpeed;
        }
        Debug.Log($"{Guns.TypeOfGun.fireGun} reloading with a speed {reloadSpeed}");

    }

    public void Shoot()
    {
        
        GameObject bul = Instantiate(BulletPrefab, BulletPoint.position, BulletPoint.rotation) as GameObject;
        Rigidbody2D rb = bul.GetComponent<Rigidbody2D>();
        rb.AddForce(BulletPoint.right * bullet.speed, ForceMode2D.Impulse);

    }

     void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            Shoot();
    }
}
