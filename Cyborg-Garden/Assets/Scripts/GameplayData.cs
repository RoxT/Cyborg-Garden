using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameplayData
{
    private static int levelsCompleted;
    
    public static int LevelsCompleted {
        get {
            return levelsCompleted;
        } set {
            levelsCompleted = value;
        }
    }
}
