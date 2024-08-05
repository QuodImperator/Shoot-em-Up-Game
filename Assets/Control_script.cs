using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_script : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public Vector2 movementInput;
    public int movementSpeed = 300;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
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
}
