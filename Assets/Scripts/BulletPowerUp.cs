using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPowerUp : MonoBehaviour
{
    public Vector2 speedMinMax;
    public float screenEdge;

    // Start is called before the first frame update
    void Start()
    {
        screenEdge = -Camera.main.orthographicSize - transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        float speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Difficulty.GetDifficultyPercent());
        transform.Translate(0, -speed * Time.deltaTime, 0);
        if (transform.position.y < screenEdge)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
