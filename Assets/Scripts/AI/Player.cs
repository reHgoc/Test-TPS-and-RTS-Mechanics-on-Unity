using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : AIManager
{
    private Vector2 movement;

    [SerializeField]private Rigidbody2D rb;

    private GunManager m_Guns = new GunManager();
    private Bullets m_Bullets = new Bullets();

    void Start()
    {
        Health = 100.0f;
        speed = 5.0f;

    }

    void Update()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, angle + 90f);

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Health = m_Bullets.TakeDamage(Health);
            Debug.Log(Health);
        }
        if (Health <= 0)
            Death();

           
    }

    private void FixedUpdate()
    {
        //Other methods for moving

        //MovementX += Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        //MovementY += Input.GetAxis("Vertical") * speed * Time.deltaTime;
        //transform.position = new Vector2(MovementX, MovementY);
        //rb.velocity = new Vector2(MovementX, MovementY);
        //transform.Translate(new Vector3(MovementX, MovementY, 0f));

        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);


        
    }

}
