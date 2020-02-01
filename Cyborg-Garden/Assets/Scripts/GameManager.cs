using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        } else if (ballType == BallType.Sadness) {
            sadnessScore = sadnessScore + increaseValue;
            GameplayUI.Instance.UpdateScore(ballType, sadnessScore);
        } else if (ballType == BallType.Anger) {
            angerScore = angerScore + increaseValue;
            GameplayUI.Instance.UpdateScore(ballType, angerScore);
        } else if (ballType == BallType.Fear) {
            fearScore = fearScore + increaseValue;
            GameplayUI.Instance.UpdateScore(ballType, fearScore);
        } else if (ballType == BallType.Disgust) {
            disgustScore = disgustScore + increaseValue;
            GameplayUI.Instance.UpdateScore(ballType, disgustScore);
        }
    }
}
