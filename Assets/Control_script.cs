using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_script : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public Vector2 movementInput;
    public float movementSpeed = 300f;
    public player_laser_script player_laser;
    public GameObject pewSound;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Shoot();
    }

    void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (horizontal == 0 && vertical == 0)
        {
            myRigidbody.velocity = new Vector2(0, 0);
            return;
        }

        movementInput = new Vector2(horizontal, vertical);
        myRigidbody.velocity = movementInput * movementSpeed * Time.fixedDeltaTime;
    }

    void Shoot()
    {
        Vector2 gunPos = new Vector2(transform.position.x + 0.7f, transform.position.y - 0.15f);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject pew = Instantiate(player_laser.gameObject, gunPos, Quaternion.identity);
            pewSound.SetActive(true);
            Instantiate(pewSound, gunPos, Quaternion.identity);
        }
    }
}
