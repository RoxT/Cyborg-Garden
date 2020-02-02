using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCompleteUI : MonoBehaviour
{
    public Text levelMoneyValue;
    public Text totalMoneyValue;

    // Start is called before the first frame update
    void Start() {
        levelMoneyValue.text = "$" + GameplayData.MoneyEarnedThisLevel.ToString("F2");
        totalMoneyValue.text = "$" + GameplayData.Money.ToString("F2");
    }
}
