using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance {
        get {
            if (_instance == null) {
                GameObject go = new GameObject("GameManager");
                go.AddComponent<GameManager>();
            }

            return _instance;
        }
    }

    public GameObject announcement;

    [HideInInspector] public int joyScore;
    [HideInInspector] public int sadnessScore;
    [HideInInspector] public int angerScore;
    [HideInInspector] public int fearScore;
    [HideInInspector] public int disgustScore;

    void Awake() {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start() {
        joyScore = 0;
        sadnessScore = 0;
        angerScore = 0;
        fearScore = 0;
        disgustScore = 0;
    }

    public void IncreaseScore(BallType ballType, int increaseValue) {
        if (ballType == BallType.Joy) {
            joyScore = joyScore + increaseValue;
            GameplayUI.Instance.UpdateScore(ballType, joyScore);
            DisplayAnnouncement("A feeling of joy washes over you.", Color.yellow);
        } else if (ballType == BallType.Sadness) {
            sadnessScore = sadnessScore + increaseValue;
            GameplayUI.Instance.UpdateScore(ballType, sadnessScore);
            DisplayAnnouncement("You feel inexplicable sadness...", Color.blue);
        } else if (ballType == BallType.Anger) {
            angerScore = angerScore + increaseValue;
            GameplayUI.Instance.UpdateScore(ballType, angerScore);
            DisplayAnnouncement("Rage fills your mind", Color.red);
        } else if (ballType == BallType.Fear) {
            fearScore = fearScore + increaseValue;
            GameplayUI.Instance.UpdateScore(ballType, fearScore);
            DisplayAnnouncement("An intense fear rushes through you", Color.magenta);
        } else if (ballType == BallType.Disgust) {
            disgustScore = disgustScore + increaseValue;
            GameplayUI.Instance.UpdateScore(ballType, disgustScore);
            DisplayAnnouncement("Suddenly you want to barf...", Color.green);
        }
    }

    public void DisplayAnnouncement(string s, Color color) {
        GameObject g = Instantiate(announcement, GameplayUI.Instance.transform);
        Text t = g.GetComponent<Text>();
        t.text = s;
        t.color = color;
        Destroy(g, 1.0f);
    }
}
