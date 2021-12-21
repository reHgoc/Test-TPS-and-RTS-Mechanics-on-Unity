using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guns
{
    Bullets.TypeOfBullets bullets;

    public enum TypeOfGun { 
        pistol, riffle, rocketLauncher,
        shotGun, miniGun, uzi, gaussGun,
        plazmaGun, plazmaRiffle, plazmashotgun,
        electroGun, fireGun, freezeGun, pulseGun,
        fireWorks, rocketRiffle, miniRocketGun };

    public int   StartCountBullets;
    public int   CurrentCountBullets;
    //public int[] id;

    private float reloadSpeed;
    private float Mass;

    public float Reload(int Gun_Id) // Reloading gun
    {
       float CountTimer;
       CountTimer = reloadSpeed - Time.deltaTime;

        if (CountTimer <= 0)
        {
            CurrentCountBullets = StartCountBullets;
            CountTimer = reloadSpeed;
        }
        Debug.Log($"{ChoisingGun(Gun_Id)} reloading with a speed {reloadSpeed}");
       return Gun_Id;
    }

    public int ChoisingGun(int id_Gun)
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
                    bullets = Bullets.TypeOfBullets.standart;
                    NameOfGun = guns.ToString();
                    reloadSpeed = Random.Range(1.0f, 2.25f);
                    Debug.Log($"This gun is {NameOfGun} \nwith mass: {Mass} \nand bullets count: {StartCountBullets} and {reloadSpeed} speed reload");
                    break;
            }
            case 1:
            {
                    guns = TypeOfGun.riffle;
                    Mass = 3.35f;
                    StartCountBullets = 30;
                    bullets = Bullets.TypeOfBullets.standart;
                    NameOfGun = guns.ToString();
                    reloadSpeed = Random.Range(2.0f, 3.25f);
                    break;
            }
            case 2:
                {
                    guns = TypeOfGun.rocketLauncher;
                    Mass = 5.75f;
                    StartCountBullets = 1;
                    bullets = Bullets.TypeOfBullets.rocket;
                    NameOfGun = guns.ToString();
                    reloadSpeed = Random.Range(2.0f, 3.25f);
                    //Debug.Log($"This gun is {NameOfGun} \nwith mass: {Mass} \nand bullets count: {StartCountBullets}");   
                    break;
                }
            case 3:
                {
                    guns = TypeOfGun.shotGun;
                    Mass = 2.183f;
                    StartCountBullets = 8;
                    bullets = Bullets.TypeOfBullets.standart;
                    NameOfGun = guns.ToString();
                    reloadSpeed = Random.Range(4.0f, 6.25f);
                    break;
                }
            case 4:
                {
                    guns = TypeOfGun.miniGun;
                    Mass = 19.2175f;
                    StartCountBullets = 200;
                    bullets = Bullets.TypeOfBullets.standart;
                    NameOfGun = guns.ToString();
                    reloadSpeed = Random.Range(6.0f, 10.25f);
                   
                    break;
                }
            case 5:
                {
                    guns = TypeOfGun.uzi;
                    Mass = 0.525f;
                    StartCountBullets = 25;
                    bullets = Bullets.TypeOfBullets.standart;
                    NameOfGun = guns.ToString();
                    reloadSpeed = Random.Range(1.0f, 2.05f);
                    break;
                }
            case 6:
                {
                    guns = TypeOfGun.gaussGun;
                    Mass = 4.185f;
                    StartCountBullets = 3;
                    bullets = Bullets.TypeOfBullets.Gauss;
                    NameOfGun = guns.ToString();
                    //Debug.Log($"This gun is {NameOfGun} \nwith mass: {Mass} \nand bullets count: {StartCountBullets}");   
                    break;
                }
            case 7:
                {
                    guns = TypeOfGun.plazmaGun;
                    Mass = 4.13f;
                    StartCountBullets = 3;
                    bullets = Bullets.TypeOfBullets.plazma;
                    NameOfGun = guns.ToString();
                    break;
                }
            case 8:
                {
                    guns = TypeOfGun.plazmaRiffle;
                    Mass = 4.375f;
                    StartCountBullets = 20;
                    bullets = Bullets.TypeOfBullets.riPlazma;
                    NameOfGun = guns.ToString();
                    //Debug.Log($"This gun is {NameOfGun} \nwith mass: {Mass} \nand bullets count: {StartCountBullets}");   
                    break;
                }
            case 9:
                {
                    guns = TypeOfGun.plazmashotgun;
                    Mass = 4.35f;
                    StartCountBullets = 8;
                    bullets = Bullets.TypeOfBullets.sgPlazma;
                    NameOfGun = guns.ToString();
                    break;
                }
            case 10:
                {
                    guns = TypeOfGun.electroGun;
                    Mass = 2.75f;
                    StartCountBullets = 100;
                    bullets = Bullets.TypeOfBullets.flame;
                    NameOfGun = guns.ToString();
                    //Debug.Log($"This gun is {NameOfGun} \nwith mass: {Mass} \nand bullets count: {StartCountBullets}");   
                    break;
                }
            case 11:
                {
                    guns = TypeOfGun.fireGun;
                    Mass = 5.19f;
                    StartCountBullets = 100;
                    bullets = Bullets.TypeOfBullets.flame;
                    NameOfGun = guns.ToString();
                    break;
                }
            case 12:
                {
                    guns = TypeOfGun.freezeGun;
                    Mass = 5.2175f;
                    StartCountBullets = 100;
                    bullets = Bullets.TypeOfBullets.flame;
                    NameOfGun = guns.ToString();
                    //Debug.Log($"This gun is {NameOfGun} \nwith mass: {Mass} \nand bullets count: {StartCountBullets}");   
                    break;
                }
            case 13:
                {
                    guns = TypeOfGun.pulseGun;
                    Mass = 0.4725f;
                    StartCountBullets = 10;
                    bullets = Bullets.TypeOfBullets.standart;
                    NameOfGun = guns.ToString();
                    break;
                }
            case 14:
                {
                    guns = TypeOfGun.fireWorks;
                    Mass = 1.185f;
                    StartCountBullets = 9;
                    bullets = Bullets.TypeOfBullets.rocket;
                    NameOfGun = guns.ToString();
                    //Debug.Log($"This gun is {NameOfGun} \nwith mass: {Mass} \nand bullets count: {StartCountBullets}");   
                    break;
                }
            case 15:
                {
                    guns = TypeOfGun.rocketRiffle;
                    Mass = 5.13f;
                    StartCountBullets = 18;
                    bullets = Bullets.TypeOfBullets.rocket;
                    NameOfGun = guns.ToString();
                    break;
                }
            case 16:
                {
                    guns = TypeOfGun.miniRocketGun;
                    Mass = 6.33f;
                    StartCountBullets = 52;
                    bullets = Bullets.TypeOfBullets.rocket;
                    NameOfGun = guns.ToString();
                    break;
                }
            default:
            {
                    Debug.Log("Thats all");
                    break;
            }

        }

        return id_Gun;

    }

}
