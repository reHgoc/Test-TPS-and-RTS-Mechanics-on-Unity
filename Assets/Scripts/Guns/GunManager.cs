using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class GunManager : Guns
{
    public List<Guns> GunsList = new List<Guns>();
    public GameObject BulletPrefab;
    public Transform BulletPoint;

    private IEnumerator Reload;
    private bool isCanShoot;

    


    private void Start()
    {
        Reload = ReloadCoroutine();
        CurrentCountBullets = StartCountBullets;
        isCanShoot = true;
        
    }

    void BreakingReloading()
    {
        StopCoroutine(Reload);
        isCanShoot = true;
    }

    public IEnumerator ReloadCoroutine()                                // Reloading gun
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
        if (CurrentCountBullets == 0 && isCanShoot == true)
        {
            StartCoroutine(Reload);
        }
    }


    public void ChangeWeapon(Guns GunForChange)
    {
        if(Reload != null)
        {

            BreakingReloading();
        }

        foreach(Guns NewGun in GunsList)
        {
            if(NewGun.name == GunForChange.name)
            {
                //Do change weapon
                /* Gun = NewGun.Gun;
                 CurrentCountBullets = GunForChange.StartCountBullets;
                 StartCountBullets = GunForChange.StartCountBullets;
                 reloadSpeed = GunForChange.reloadSpeed;
                 Mass = GunForChange.Mass;
                */
                NewGun.Gun = Gun;
                NewGun.StartCountBullets = StartCountBullets;
                NewGun.reloadSpeed = reloadSpeed;
                NewGun.Mass = Mass;
            }
            
        }
        
        
    }

}
