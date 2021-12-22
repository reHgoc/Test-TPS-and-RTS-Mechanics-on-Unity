using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets 
{
    public enum TypeOfBullets { standart, flame, rocket,
                                plazma, riFlame, pistFlame,
                                sgFlame, sgPlazma, sgGauss,
                                Gauss, riPlazma, riGauss };

    public float dmg;
    public float speed;

    public float TakeDamage(float health)
    {

        return health -= dmg;
        
    }

}
