using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public static class GameManager
{
    public static event System.Action<int> ScoreChanged;
    private static int _score = 0;
    public static int Score
    {
        get => _score;
        set
        {
            _score = Mathf.Clamp(value, int.MinValue, int.MaxValue);

            if (ScoreChanged != null)
            {
                ScoreChanged(_score);
            }
        }
    }

    static GameManager()
    {
        Reset();
    }

    private static void Reset()
    {
        Score = 0;
    }
}
