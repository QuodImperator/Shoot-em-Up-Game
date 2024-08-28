using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed = 10f;
    public Logic_script logic;
    public GameObject explosion;
    public GameObject explosionSound;
    public GameObject ouchSound;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic_script>();
    }

    void Update()
    {
        Vector2 pos = transform.position;
        pos.x -=  speed * Time.deltaTime;
        transform.position = pos;

        if(pos.x < -9.5)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player_laser_script player_laser = collision.GetComponent<player_laser_script>();
        Control_script player_plane = collision.GetComponent<Control_script>();

        if(player_laser != null)
        {
            Destroy(gameObject);
            Destroy(player_laser.gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
            explosionSound.SetActive(true);
            Instantiate(explosionSound, transform.position, Quaternion.identity);
            logic.addScore();
        }

        if (player_plane != null)
        {
            if (logic.playerHealth <= 0)
            {
                logic.playerHealth -= 1;
                Destroy(player_plane.gameObject);
                Destroy(gameObject);
                Instantiate(explosion, transform.position, Quaternion.identity);
                explosionSound.SetActive(true);
                Instantiate(explosionSound, transform.position, Quaternion.identity);
                logic.gameOver();
            }
            else
            {
                logic.playerHealth -= 1;
                Destroy(gameObject);
                ouchSound.SetActive(true);
                Instantiate(ouchSound, transform.position, Quaternion.identity);
            }
        }
    }
}
