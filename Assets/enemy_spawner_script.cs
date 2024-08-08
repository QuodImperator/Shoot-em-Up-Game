using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_spawner_script : MonoBehaviour
{
    public GameObject enemy;
    public float spawnRate = 0.4f;
    public float timer = 0;
    public float heightOffset = 8;

    void Start()
    {
        
    }

    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnEnemy();
            timer = 0;
        }
    }

    void spawnEnemy()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(enemy, new Vector2(transform.position.x, Random.Range(lowestPoint, highestPoint)), transform.rotation);
    }
}
