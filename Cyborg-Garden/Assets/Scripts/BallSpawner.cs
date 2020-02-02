using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ball;
    public float spawnIntervalTime;
    public float minHorizontalForce;
    public float maxHorizontalForce;

    public bool spawnJoy;
    public bool spawnSadness;
    public bool spawnAnger;
    public bool spawnDisgust;
    public bool spawnFear;
    private bool[] emotions = new bool[5];

    private Rigidbody2D ballRb;
    private float timeSinceSpawn;

    // Start is called before the first frame update
    void Start() {
        timeSinceSpawn = 0;
        emotions[0] = spawnJoy;
        emotions[1] = spawnSadness;
        emotions[2] = spawnAnger;
        emotions[3] = spawnDisgust;
        emotions[4] = spawnFear;
        PreventInfinateLoops();

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
        int ballInt = Random.Range(0, 5);
        while (!emotions[ballInt])
        {
            ballInt = Random.Range(0, 5);
        }
        BallType ballType = (BallType)ballInt;
        iBall.SetType(ballType);
        Vector2 initDirection = new Vector2(Random.Range(minHorizontalForce, maxHorizontalForce), 0.0f);
        rb.AddForce(initDirection);
        timeSinceSpawn = spawnIntervalTime;
    }

    // When a ball is created, it randomly generates balltype until one is 'allowed'
    // If no types are allowed, there would be an infinate loop
    private void PreventInfinateLoops()
    {
        bool atLeastOneEMotion = false;
        foreach (bool emot in emotions)
        {
            if (emot == true)
            {
                atLeastOneEMotion = true;
                break;
            }
        }
        if (atLeastOneEMotion == false)
        {
            emotions = new bool[] { true, true, true, true, true};
        }
    } 
}
