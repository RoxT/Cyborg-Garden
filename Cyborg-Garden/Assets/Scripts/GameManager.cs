using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    [HideInInspector] public int joyLevel;
    public int joyLevelThreshold;
    private int joyPointsThisLevel;

    [HideInInspector] public int sadnessLevel;
    public int sadnessLevelThreshold;
    private int sadnessPointsThisLevel;

    [HideInInspector] public int angerLevel;
    public int angerLevelThreshold;
    private int angerPointsThisLevel;

    [HideInInspector] public int fearLevel;
    public int fearLevelThreshold;
    private int fearPointsThisLevel;

    [HideInInspector] public int disgustLevel;
    public int disgustLevelThreshold;
    private int disgustPointsThisLevel;

    [HideInInspector] public int joyScore;
    [HideInInspector] public int sadnessScore;
    [HideInInspector] public int angerScore;
    [HideInInspector] public int fearScore;
    [HideInInspector] public int disgustScore;

    private float timeElapsed;

    void Awake() {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start() {
        ResetGameManager();

    }

    void Update() {
        timeElapsed += Time.deltaTime;
        GameplayUI.Instance.UpdateTime(timeElapsed);
        CheckWinCondition();
    }

    public void IncreaseScore(BallType ballType, int increaseValue) {
        if (ballType == BallType.Joy) {
            joyScore = joyScore + increaseValue;

            joyPointsThisLevel++;
            if (joyPointsThisLevel >= joyLevelThreshold) {
                LevelUpEmotion(ballType);
                joyPointsThisLevel = 0;
            }

            GameplayUI.Instance.UpdateScore(ballType, joyScore);
            DisplayAnnouncement("A feeling of joy washes over you.", Color.yellow);
        } else if (ballType == BallType.Sadness) {
            sadnessScore = sadnessScore + increaseValue;

            sadnessPointsThisLevel++;
            if (sadnessPointsThisLevel >= sadnessLevelThreshold) {
                LevelUpEmotion(ballType);
                sadnessPointsThisLevel = 0;
            }

            GameplayUI.Instance.UpdateScore(ballType, sadnessScore);
            DisplayAnnouncement("You feel inexplicable sadness...", Color.blue);
        } else if (ballType == BallType.Anger) {
            angerScore = angerScore + increaseValue;

            angerPointsThisLevel++;
            if (angerPointsThisLevel >= angerLevelThreshold) {
                LevelUpEmotion(ballType);
                angerPointsThisLevel = 0;
            }

            GameplayUI.Instance.UpdateScore(ballType, angerScore);
            DisplayAnnouncement("Rage fills your mind", Color.red);
        } else if (ballType == BallType.Fear) {
            fearScore = fearScore + increaseValue;

            fearPointsThisLevel++;
            if (fearPointsThisLevel >= fearLevelThreshold) {
                LevelUpEmotion(ballType);
                fearPointsThisLevel = 0;
            }

            GameplayUI.Instance.UpdateScore(ballType, fearScore);
            DisplayAnnouncement("An intense fear rushes through you", Color.magenta);
        } else if (ballType == BallType.Disgust) {
            disgustScore = disgustScore + increaseValue;

            disgustPointsThisLevel++;
            if (disgustPointsThisLevel >= disgustLevelThreshold) {
                LevelUpEmotion(ballType);
                disgustPointsThisLevel = 0;
            }

            GameplayUI.Instance.UpdateScore(ballType, disgustScore);
            DisplayAnnouncement("Suddenly you want to barf...", Color.green);
        }
    }

    public void LevelUpEmotion(BallType ballType) {
        if (ballType == BallType.Joy) {
            joyLevel++;
            GameplayUI.Instance.UpdateLED(ballType, joyLevel - 1);
        } else if (ballType == BallType.Sadness) {
            sadnessLevel++;
            GameplayUI.Instance.UpdateLED(ballType, sadnessLevel - 1);
        } else if (ballType == BallType.Anger) {
            angerLevel++;
            GameplayUI.Instance.UpdateLED(ballType, angerLevel - 1);
        } else if (ballType == BallType.Fear) {
            fearLevel++;
            GameplayUI.Instance.UpdateLED(ballType, fearLevel - 1);
        } else if (ballType == BallType.Disgust) {
            disgustLevel++;
            GameplayUI.Instance.UpdateLED(ballType, disgustLevel - 1);
        }
    }

    public void DisplayAnnouncement(string s, Color color) {
        GameObject g = Instantiate(announcement, GameplayUI.Instance.transform);
        Text t = g.GetComponent<Text>();
        t.text = s;
        t.color = color;
        Destroy(g, 1.0f);
    }

    public void ResetGameManager() {
        joyScore = 0;
        sadnessScore = 0;
        angerScore = 0;
        fearScore = 0;
        disgustScore = 0;

        joyPointsThisLevel = 0;
        sadnessPointsThisLevel = 0;
        angerPointsThisLevel = 0;
        fearPointsThisLevel = 0;
        disgustPointsThisLevel = 0;

        joyLevel = 0;
        sadnessLevel = 0;
        angerLevel = 0;
        fearLevel = 0;
        disgustLevel = 0;

        timeElapsed = 0;
    }

    public void CheckWinCondition() {
        Debug.Log(fearScore);
        if (SceneManager.GetActiveScene().buildIndex == 2) {
            if (joyLevel >= 5 && sadnessLevel >= 5 && angerLevel >= 5 && fearLevel >= 5 && disgustLevel >= 5) {
                GameplayData.LevelsCompleted = 1;
                SceneManager.LoadScene(11);
            }
        } else if (SceneManager.GetActiveScene().buildIndex == 3) {
            if (angerLevel >= 5 && sadnessLevel >=5 ) {
                GameplayData.LevelsCompleted = 2;
                SceneManager.LoadScene(11);
            }
        }
    }
}
