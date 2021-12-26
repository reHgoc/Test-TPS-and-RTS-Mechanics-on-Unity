using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
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

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);

        }
    }



}
