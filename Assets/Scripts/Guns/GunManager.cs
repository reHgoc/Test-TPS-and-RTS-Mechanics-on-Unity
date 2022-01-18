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
        FireTime = 0f;
        CurrentCountBullets = StartCountBullets;
        isCanShoot = true;

        CurrentGun = GetComponent<Guns>();
        bullets    = GetComponent<Bullets>();
        //print(CurrentGun.Gun);
 
    }

    void BreakingReloading()
    {
        StopCoroutine(ReloadCoroutine());
        isCanShoot = true;
        FireTime = 0f;
    }

    public IEnumerator ReloadCoroutine()                                                        // Reloading gun
    {
        isCanShoot = false;
        FireTime = 0f;
        yield return new WaitForSeconds(reloadSpeed);
        CurrentCountBullets = StartCountBullets;
        isCanShoot = true;
    }

    public IEnumerator Shoot()
    {

        GameObject bul = Instantiate(BulletPrefab, BulletPoint.position, BulletPoint.rotation) as GameObject;
        CurrentCountBullets -= 1;
        yield return 0.03f;

    }




    void Update()
    {
        if (Input.GetButton("Fire1") && CurrentCountBullets > 0 && isCanShoot == true)
        {
            FireTime += Time.deltaTime;

            switch (WeaponId)
            {
                
                case 3:
                    if (FireTime > FireRange)
                    {
                        int count = Random.RandomRange(4, 7);
                        GameObject[] bulls = new GameObject[count];

                        for(int i = 0; i<= count; i++)
                        {

                        }
                        CurrentCountBullets -= 1;

                    }
                    break;
                default:
                    if (FireTime > FireRange)
                    {
                        StartCoroutine(Shoot());
                        FireTime = 0.00f;

                    }
                    break;
            }
            
            
            
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
          FireRange = GunForChange.FireRange;
          WeaponId = GunForChange.WeaponId;
        
        
    }


}
