﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 15f;
    float screenEdge;


    void Start()
    {
        screenEdge = Camera.main.orthographicSize + transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed *Time.deltaTime); 
        if (transform.position.y > screenEdge)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        if (triggerCollider.tag == "FallingBlock")
        {
            print("hit");
            Destroy(gameObject);
            Destroy(triggerCollider);
        }
    }
}
