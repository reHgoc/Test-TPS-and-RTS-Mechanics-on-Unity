using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class GunManager : Guns
{
    public GameObject BulletPrefab;
    public Transform BulletPoint;

    private bool isCanShoot;


    private void Start()
    {
        
        CurrentCountBullets = StartCountBullets;
        isCanShoot = true;
        print(CurrentCountBullets);
        
    }

    void BreakingReloading()
    {
        StopCoroutine(ReloadCoroutine());
    }

    public IEnumerator ReloadCoroutine()                                // Reloading gun
    {
            yield return new WaitForSeconds(reloadSpeed);
            CurrentCountBullets = StartCountBullets;
            isCanShoot = true;
        print($"now is {CurrentCountBullets}");
        BreakingReloading();
    }

    public void Shoot()
    {
        
        GameObject bul = Instantiate(BulletPrefab, BulletPoint.position, BulletPoint.rotation) as GameObject;
        CurrentCountBullets -= 1;

    }


    void Update()
    {
        if (Input.GetButtonDown("Fire1") && CurrentCountBullets >= 0 && isCanShoot == true)
            Shoot();
        if (CurrentCountBullets == 0)
        {
            isCanShoot = false;
            StartCoroutine(ReloadCoroutine());
        }


    }

    public void ChangeWeapon(Guns GunForChange)
    {
        BreakingReloading();
        //Do change weapon
        Gun                 = GunForChange.Gun;
        CurrentCountBullets = GunForChange.StartCountBullets;
        StartCountBullets   = GunForChange.StartCountBullets;
        reloadSpeed         = GunForChange.reloadSpeed;
        Mass                = GunForChange.Mass;
        
    }

}
