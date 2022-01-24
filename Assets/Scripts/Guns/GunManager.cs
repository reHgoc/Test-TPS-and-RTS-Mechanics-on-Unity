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

    private Rigidbody2D RB2D;

    


    private void Start()
    {
        FireTime = 0f;
        CurrentCountBullets = StartCountBullets;
        isCanShoot = true;

        CurrentGun = GetComponent<Guns>();
        bullets    = GetComponent<Bullets>();
        RB2D       = GetComponent<Rigidbody2D>();
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

    public IEnumerator Shoot()                                                                  // while for rocket or same guns
    {

        GameObject bul = Instantiate(BulletPrefab, BulletPoint.position, BulletPoint.rotation) as GameObject;
        CurrentCountBullets -= 1;
        yield return 0.03f;

    }

    private IEnumerator ShootWithRay()                                                          // Shoot with raycast
    {
        RaycastHit2D hit = Physics2D.Raycast(BulletPoint.transform.position, Vector2.up);
        Debug.DrawRay(BulletPoint.transform.position, Vector2.up * hit.distance, Color.green);

        if (hit.collider != null)
            print(hit.collider.name);

        
        yield return FireRange;
    }




    void Update()
    {
        if (Input.GetButton("Fire1") && CurrentCountBullets > 0 && isCanShoot == true)
        {
            FireTime = Time.time + 1f / FireRange;

            switch (WeaponId)
            {
                
                case 3:
                    if (Time.time >= FireTime)
                    {
                        int count = Random.Range(4, 7);
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
                        //StartCoroutine(Shoot());

                        StartCoroutine(ShootWithRay());

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
