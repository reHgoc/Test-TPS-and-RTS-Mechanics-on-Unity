using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class GunManager : Guns
{
    public GameObject BulletPrefab;
    public Transform BulletPoint;

    TypeOfGun CurrentGun;

    private void Start()
    {
        CurrentCountBullets = StartCountBullets;
        CurrentGun = TypeOfGun.pistol;
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

    }

    public void Shoot()
    {
        
        GameObject bul = Instantiate(BulletPrefab, BulletPoint.position, BulletPoint.rotation) as GameObject;

    }


    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            Shoot();

    }

    public void ChangeWeapon(TypeOfGun GunForChange)
    {
        //Do change weapon
        Gun = GunForChange;
    }

}
