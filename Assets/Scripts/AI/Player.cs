using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : AIManager
{
    private GameObject Enemy;

    private Vector2 movement;

    [SerializeField]private Rigidbody2D rb;

    private Guns m_Guns = new Guns();
    private Bullets m_Bullets = new Bullets();

    // Start is called before the first frame update
    void Start()
    {
        Health = 100.0f;

        Enemy = GameObject.FindGameObjectWithTag("Enemy");
        
        speed = 5.0f;

        m_Guns.ChoisingGun(0); // tested gun from class Guns
        //rb = GetComponent<Rigidbody2D>();

        

    }

    // Update is called once per frame
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
            Debug.Log($"Damage: {m_Bullets.dmg.ToString()} Health {Health}");
            
        }
        if (Health <= 0)
            Death();

        if (Input.GetKeyDown(KeyCode.T))
        {
            for(int i = 0; i <=  i++)
             {
                 m_Guns.Reload(m_Guns.ChoisingGun(++i));
             }
        }
           
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
