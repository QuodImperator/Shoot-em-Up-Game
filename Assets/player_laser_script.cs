using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_laser_script : MonoBehaviour
{
    public float laserSpeed = 70f;
    public Vector2 velocity = new Vector2(1, 0);

    void Start()
    {

    }

    void Update()
    {
        Vector2 pos = transform.position;
        pos += velocity * laserSpeed * Time.fixedDeltaTime;
        transform.position = pos;

        if (pos.x > 9.5)
        {
            Destroy(gameObject);
        }
    }
}
