using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets 
{
    public enum TypeOfBullets { standart, flame, rocket,
                                plazma, riFlame, pistFlame,
                                sgFlame, sgPlazma, sgGauss,
                                Gauss, riPlazma, riGauss };

    private float dmg;
    private float speed;

    public float TakeDamage(TypeOfBullets bullets)
    {
        float  damage;
        string b_name;

        switch (bullets)
        {
            case TypeOfBullets.standart:
                dmg   = 33.3f;
                speed = 15.0f;
                break;
            case TypeOfBullets.flame:
                dmg = 27.1f;
                speed = 5.0f;
                break;
            case TypeOfBullets.rocket:
                dmg = 52f;
                speed = 5.0f;
                break;
            case TypeOfBullets.plazma:
                dmg = 48.9f;
                speed = 5.0f;
                break;
            case TypeOfBullets.riFlame:
                dmg = 87.89f;
                speed = 15.0f;
                break;
            case TypeOfBullets.pistFlame:
                dmg = 90f;
                speed = 5.0f;
                break;
            case TypeOfBullets.sgFlame:
                dmg = 88.8852f;
                speed = 15.0f;
                break;
            case TypeOfBullets.sgPlazma:
                dmg = 47.525f;
                speed = 9.0f;
                break;
            case TypeOfBullets.sgGauss:
                dmg = 102.83456f;
                speed = 21.0f;
                break;
            case TypeOfBullets.Gauss:
                dmg = 107.527f;
                speed = 25.0f;
                break;
            case TypeOfBullets.riPlazma:
                dmg = 29.81f;
                speed = 12.0f;
                break;
            case TypeOfBullets.riGauss:
                dmg = Random.Range(99.78956f, 103.5471f);
                speed = 33.0f;
                break;
            default:
                bullets = TypeOfBullets.standart;
                break;


        }
        b_name = bullets.ToString();
        return damage = dmg;
        
    }
}
