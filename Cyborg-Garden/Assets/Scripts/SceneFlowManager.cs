﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFlowManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 2) {
            GameplayData.Money = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextScene() {
        if (SceneManager.GetActiveScene().buildIndex == 0)
            SceneManager.LoadScene(1);
        else if (SceneManager.GetActiveScene().buildIndex == 1)
            SceneManager.LoadScene(12);
        else if (SceneManager.GetActiveScene().buildIndex == 11)
            if (GameplayData.LevelsCompleted == 8) {
                SceneManager.LoadScene(13);
            } else {
                SceneManager.LoadScene(12);
            }
        else if (SceneManager.GetActiveScene().buildIndex == 10) {
            if (GameplayData.LevelsCompleted == 8) {
                SceneManager.LoadScene(13);
            }
            else
                SceneManager.LoadScene(GameplayData.LevelsCompleted + 2);
        }

        else if (SceneManager.GetActiveScene().buildIndex == 12)
            SceneManager.LoadScene(GameplayData.LevelsCompleted + 2);
        else if (SceneManager.GetActiveScene().buildIndex == 13)
            SceneManager.LoadScene(14);
    }
}
