using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeOfBullets
{
    standart, flame, rocket,
    plazma, riFlame, pistFlame,
    sgFlame, sgPlazma, sgGauss,
    Gauss, riPlazma, riGauss
};

public class Bullets : MonoBehaviour
{
    TypeOfBullets BullTypes;
 
    public float dmg;
    public float speed;

    public int BulletId;

    

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

    public void ChangeBullet(int id, Bullets bul)
    {
        BullTypes = bul.BullTypes;
        dmg       = bul.dmg;
        speed     = bul.speed;
        BulletId  = id;
    }


}
