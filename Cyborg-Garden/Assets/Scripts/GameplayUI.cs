using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameplayUI : MonoBehaviour
{
    private static GameplayUI _instance;

    public static GameplayUI Instance {
        get {
            if (_instance == null) {
                GameObject go = new GameObject("GameplayUI");
                go.AddComponent<GameplayUI>();
            }

            return _instance;
        }
    }

    public Text joyScore;
    public Text sadnessScore;
    public Text angerScore;
    public Text fearScore;
    public Text disgustScore;

    void Awake() {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        joyScore.text = "0";
        sadnessScore.text = "0";
        angerScore.text = "0";
        fearScore.text = "0";
        disgustScore.text = "0";
    }

    public void UpdateScore(BallType ballType, int newValue) {
        if (ballType == BallType.Joy) {
            joyScore.text = newValue.ToString();
        }
        else if (ballType == BallType.Sadness) {
            sadnessScore.text = newValue.ToString();
        }
        else if (ballType == BallType.Anger) {
            angerScore.text = newValue.ToString();
        }
        else if (ballType == BallType.Fear) {
            fearScore.text = newValue.ToString();
        }
        else if (ballType == BallType.Disgust) {
            disgustScore.text = newValue.ToString();
        }
    }
}
