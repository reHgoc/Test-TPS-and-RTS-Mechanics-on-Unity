using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class GunManager : Guns
{
    public GameObject BulletPrefab;
    public Transform BulletPoint;

    private Coroutine reloadCoroutine;
    private bool isCanShoot;


    private void Start()
    {
        
        CurrentCountBullets = StartCountBullets;
        isCanShoot = true;
        
    }

    void Reload()
    {
        if (reloadCoroutine != null) StopCoroutine(reloadCoroutine);
        reloadCoroutine = StartCoroutine(ReloadCoroutine());
        isCanShoot = true;
    }

    public IEnumerator ReloadCoroutine()                                // Reloading gun
    {

        while(!isCanShoot)
        {
            CurrentCountBullets = StartCountBullets;
            yield return new WaitForSeconds(reloadSpeed);
        }

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
        if (CurrentCountBullets <= 0)
        {
            isCanShoot = false;
            Reload();
        }

        if(Input.GetKeyDown(KeyCode.T))
            StopCoroutine(reloadCoroutine);

    }

    public void ChangeWeapon(Guns GunForChange)
    {
        isCanShoot = true;
        //Do change weapon
        Gun                 = GunForChange.Gun;
        CurrentCountBullets = GunForChange.StartCountBullets;
        StartCountBullets   = GunForChange.StartCountBullets;
        reloadSpeed         = GunForChange.reloadSpeed;
        Mass                = GunForChange.Mass;
        
    }

}
