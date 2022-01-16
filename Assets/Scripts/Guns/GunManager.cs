using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class GunManager : Guns
{
    public Guns CurrentGun;
    public GameObject BulletPrefab;
    public Transform BulletPoint;

    Bullets bullets;

    private bool isCanShoot;
    private bool isReloaded;

    


    private void Start()
    {
        CurrentCountBullets = StartCountBullets;
        isCanShoot = true;
        CurrentGun = GetComponent<Guns>();
        bullets = GetComponent<Bullets>();
        //print(CurrentGun.Gun);
 
    }

    void BreakingReloading()
    {
        StopCoroutine(ReloadCoroutine());
        isCanShoot = true;
    }

    public IEnumerator ReloadCoroutine()                                                        // Reloading gun
    {
        isCanShoot = false;
        yield return new WaitForSeconds(reloadSpeed);
        CurrentCountBullets = StartCountBullets;
        isCanShoot = true;
    }

    public void Shoot()
    { 
        GameObject bul = Instantiate(BulletPrefab, BulletPoint.position, BulletPoint.rotation) as GameObject; 
        CurrentCountBullets -= 1;
        
    }


    void Update()
    {
        if (Input.GetButtonDown("Fire1") && CurrentCountBullets > 0 && isCanShoot == true)
        {
            Shoot();
        }
        
        
    }

    private void LateUpdate()
    {
        if (CurrentCountBullets == 0 && isCanShoot == true)
        {
            StartCoroutine(ReloadCoroutine());
        }
    }


    public void ChangeWeapon(Guns GunForChange)                                         // Change weapon (call from Player scripts)
    {
        if (ReloadCoroutine() != null)
        {
            BreakingReloading();                                                       // Stop reloading when new weapon picked up 
        }
            

          CurrentGun = GunForChange;
          Gun = GunForChange.Gun;
          CurrentCountBullets = GunForChange.StartCountBullets;
          StartCountBullets = GunForChange.StartCountBullets;
          reloadSpeed = GunForChange.reloadSpeed;
          Mass = GunForChange.Mass;

        
        
    }


}
