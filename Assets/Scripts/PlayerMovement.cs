using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 7f;
   
    float screenHalfWidth;
    public event System.Action OnPlayerDeath;

    public float timeBetweenShots = 1f;
    public bool canShoot;
    public GameObject bulletPrefab;
    public float powerUpDuration = 6f;
    float powerUpEnd;
    float nextShotTime;

    void Start()
    {
        float halfPlayerWidth = transform.localScale.x / 2f;
        screenHalfWidth = Camera.main.aspect * Camera.main.orthographicSize + halfPlayerWidth;
        
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        float inputX = Input.GetAxisRaw("Horizontal");
        float velocity = inputX * speed;
        transform.Translate(velocity * Time.deltaTime, 0, 0);
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Translate(Vector3.right * inputX * jumpSpace);
        }*/

        if (transform.position.x < -screenHalfWidth){
            transform.position = new Vector2(screenHalfWidth, transform.position.y);
        }
        if (transform.position.x > screenHalfWidth)
        {
            transform.position = new Vector2(-screenHalfWidth, transform.position.y);
        }

        //Shooting
        if (canShoot && Time.time > nextShotTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                nextShotTime = Time.time + timeBetweenShots;
                GameObject newBullet = (GameObject)Instantiate(bulletPrefab, transform.position,Quaternion.identity);
            }
            
        }
        if (Time.time > powerUpEnd)
        {
            //canShoot = false;
        }
    } 

    private void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        if (triggerCollider.tag == "FallingBlock")
        {
            OnPlayerDeath();
            Destroy(gameObject);
        }
        if (triggerCollider.tag == "BulletPowerUp")
        {
            canShoot = true;
            //PowerUpCounter();
        }
    }
    void PowerUpCounter ()
    {
        powerUpEnd = Time.time + powerUpDuration;
    }
}
