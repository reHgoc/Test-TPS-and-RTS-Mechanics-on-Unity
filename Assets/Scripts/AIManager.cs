using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    public float speed;
    public float MovementX;
    public float MovementY;

    protected float Health;
    protected float Armor;



    public void RotationToObject(Transform rotObject)
    {
        Vector2 direction = rotObject.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, angle + 90f);
    }
}
