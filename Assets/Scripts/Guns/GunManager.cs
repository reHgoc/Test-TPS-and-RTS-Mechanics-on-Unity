using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class GunManager : Guns
{
    public GameObject BulletPrefab;
    public Transform BulletPoint;

    private IEnumerator reloadCoroutine;
    private bool isCanShoot;

    private void Start()
    {
        reloadCoroutine = Reload();
        CurrentCountBullets = StartCountBullets;
        isCanShoot = true;
        
    }

    public IEnumerator Reload()                                // Reloading gun
    {

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
        if (Input.GetButtonDown("Fire1") && CurrentCountBullets >= 0 && isCanShoot == true)
            Shoot();
        if (CurrentCountBullets == 0)
        {
            isCanShoot = false;
            StopCoroutine(reloadCoroutine);
        }
        if (isCanShoot == true)
            StopCoroutine(reloadCoroutine);    //Need to stoped reloading when we change weapon

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
