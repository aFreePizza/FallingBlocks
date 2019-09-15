using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject bulletPowerUpPrefab;

    public float timeBetweenPowerUps = 10f;
    Vector2 screenHalfSize;
    float nextSpawnTime;
    public int spawnChance = 2;

    // Start is called before the first frame update
    void Start()
    {
        screenHalfSize = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            nextSpawnTime = Time.time + timeBetweenPowerUps;
            int shouldSpawn = Random.Range(0, spawnChance + 1);
            if (shouldSpawn == 0)
            {
                Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSize.x, screenHalfSize.x), screenHalfSize.y);
                GameObject newBulletPowerUp = (GameObject)Instantiate(bulletPowerUpPrefab, spawnPosition, Quaternion.identity);
            }
        }
        
    }
}
