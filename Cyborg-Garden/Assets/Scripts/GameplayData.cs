using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameplayData
{
    private static int levelsCompleted;

    private static float money, moneyEarnedThisLevel;
    
    public static int LevelsCompleted {
        get {
            return levelsCompleted;
        } set {
            levelsCompleted = value;
        }
    }

    public static float Money {
        get {
            return money;
        } set {
            money = value;
        }
    }

    public static float MoneyEarnedThisLevel {
        get {
            return moneyEarnedThisLevel;
        }
        set {
            moneyEarnedThisLevel = value;
        }
    }
}
