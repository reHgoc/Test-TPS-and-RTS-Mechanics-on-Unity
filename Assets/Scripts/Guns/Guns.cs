using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guns
{
    public enum TypeOfGun { pistol, riffle, rocketLauncher,
        shotGun, miniGun, uzi, gaussGun,
        plazmaGun, plazmaRiffle, plazmashotgun,
        electroGun, fireGun, freezeGun, pulseGun,
        fireWorks, rocketRiffle, miniRocketGun };

    private int   StartCountBullets;

    private float reloadSpeed;
    private float Mass;

    public float Reload(float CountTimer, int CurrentCountBullets) // Reloading gun
    {
       CountTimer = reloadSpeed - Time.deltaTime;

        if (CountTimer <= 0)
        {
            CurrentCountBullets = StartCountBullets;
            CountTimer = reloadSpeed;
        }
     
       return CurrentCountBullets;
    }

    public void ChoisingGun(int id_Gun)
    {
        TypeOfGun guns;
        string NameOfGun;

        switch (id_Gun)
        {
            case 0:
            {
                    guns = TypeOfGun.pistol;
                    Mass = 0.375f;
                    StartCountBullets = 7;
                    NameOfGun = guns.ToString();
                    Debug.Log($"This gun is {NameOfGun} \nwith mass: {Mass} \nand bullets count: {StartCountBullets}");   
                    break;
            }
            case 1:
            {
                    break;
            }
            default:
            {
                    Debug.Log("Thats all");
                    break;
            }

        }
    }

}
