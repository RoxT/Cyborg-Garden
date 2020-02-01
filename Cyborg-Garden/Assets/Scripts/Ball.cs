using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private BallType ballType;

    private SpriteRenderer sr;
    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start() {
        sr = GetComponent<SpriteRenderer>();
        InitBall();
    }

    public void InitBall() {
        ballType = (BallType)Random.Range(0, 5);
        if (ballType == BallType.Joy) {
            sr.color = Color.yellow;
        }
        else if (ballType == BallType.Sadness) {
            sr.color = Color.blue;
        }
        else if (ballType == BallType.Anger) {
            sr.color = Color.red;
        }
        else if (ballType == BallType.Disgust) {
            sr.color = Color.green;
        } else if (ballType == BallType.Fear) {
            sr.color = Color.magenta;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Collector") {
            Collector c = collision.gameObject.GetComponent<Collector>();
            if (c.collectorType == ballType) {
                GameManager.Instance.IncreaseScore(ballType, 1);
                Destroy(gameObject);
            }
        }
    }

}

public enum BallType {
    Joy,
    Sadness,
    Anger,
    Disgust,
    Fear
}
