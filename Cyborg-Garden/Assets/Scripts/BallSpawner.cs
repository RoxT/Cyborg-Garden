using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ball;
    public float spawnIntervalTime;
    public float minHorizontalForce;
    public float maxHorizontalForce;

    private Rigidbody2D ballRb;
    private float timeSinceSpawn;

    // Start is called before the first frame update
    void Start() {
        timeSinceSpawn = 0;
    }

    // Update is called once per frame
    void Update() {
        timeSinceSpawn = timeSinceSpawn - Time.deltaTime;

        if (timeSinceSpawn <= 0)
            SpawnBall();
    }

    void SpawnBall() {
        Ball iBall = Instantiate(ball, transform.position, Quaternion.identity).GetComponent<Ball>();
        Rigidbody2D rb = iBall.GetComponent<Rigidbody2D>();
        Vector2 initDirection = new Vector2(Random.Range(minHorizontalForce, maxHorizontalForce), 0.0f);
        rb.AddForce(initDirection);
        timeSinceSpawn = spawnIntervalTime;
    }
}
