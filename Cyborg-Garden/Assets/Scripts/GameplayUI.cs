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

    public float horizontalSpacing;

    public Text joyScore;
    public Text sadnessScore;
    public Text angerScore;
    public Text fearScore;
    public Text disgustScore;

    public GameObject joyLED;
    public GameObject sadnessLED;
    public GameObject angerLED;
    public GameObject fearLED;
    public GameObject disgustLED;

    private Image[] joyLED_List;
    private Image[] sadnessLED_List;
    private Image[] angerLED_List;
    private Image[] fearLED_List;
    private Image[] disgustLED_List;

    public Sprite LED_on;
    public Image LED_off;

    public Text timeRemaining;

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

        GenerateLEDLightUI();
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

    void GenerateLEDLightUI() {
        
        /*
        Image image = Instantiate(LED_off, GameplayUI.Instance.gameObject.transform);
        image.gameObject.transform.position = joyLED.transform.position;
        */

        joyLED_List = new Image[5];

        for (int i = 0; i < 5; i++) {
            joyLED_List[i] = Instantiate(LED_off, GameplayUI.Instance.gameObject.transform);
            joyLED_List[i].gameObject.transform.position = joyLED.transform.position + new Vector3 (i * horizontalSpacing, 0, 0);
        }

        sadnessLED_List = new Image[5];

        for (int i = 0; i < 5; i++) {
            sadnessLED_List[i] = Instantiate(LED_off, GameplayUI.Instance.gameObject.transform);
            sadnessLED_List[i].gameObject.transform.position = sadnessLED.transform.position + new Vector3(i * horizontalSpacing, 0, 0);
        }

        angerLED_List = new Image[5];

        for (int i = 0; i < 5; i++) {
            angerLED_List[i] = Instantiate(LED_off, GameplayUI.Instance.gameObject.transform);
            angerLED_List[i].gameObject.transform.position = angerLED.transform.position + new Vector3(i * horizontalSpacing, 0, 0);
        }

        fearLED_List = new Image[5];

        for (int i = 0; i < 5; i++) {
            fearLED_List[i] = Instantiate(LED_off, GameplayUI.Instance.gameObject.transform);
            fearLED_List[i].gameObject.transform.position = fearLED.transform.position + new Vector3(i * horizontalSpacing, 0, 0);
        }

        disgustLED_List = new Image[5];

        for (int i = 0; i < 5; i++) {
            disgustLED_List[i] = Instantiate(LED_off, GameplayUI.Instance.gameObject.transform);
            disgustLED_List[i].gameObject.transform.position = disgustLED.transform.position + new Vector3(i * horizontalSpacing, 0, 0);
        }
    }

    public void UpdateLED(BallType ballType, int level) {
        if (ballType == BallType.Joy) {
            if (level < 5) {
                joyLED_List[level].sprite = LED_on;
                joyLED_List[level].color = Color.yellow;
            }
        } else if (ballType == BallType.Sadness) {
            if (level < 5) {
                sadnessLED_List[level].sprite = LED_on;
                sadnessLED_List[level].color = Color.blue;
            }
        } else if (ballType == BallType.Anger) {
            if (level < 5) {
                angerLED_List[level].sprite = LED_on;
                angerLED_List[level].color = Color.red;
            }
        } else if (ballType == BallType.Fear) {
            if (level < 5) {
                fearLED_List[level].sprite = LED_on;
                fearLED_List[level].color = Color.magenta;
            }
        } else if (ballType == BallType.Disgust) {
            if (level < 5) {
                disgustLED_List[level].sprite = LED_on;
                disgustLED_List[level].color = Color.green;
            }
        }
    }

    public void UpdateTime(float time) {
        timeRemaining.text = time.ToString("F2");
    }
}
