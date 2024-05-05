using System.Collections;
using System.Collections.Generic;
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
            _score = Mathf.Clamp(value, 0, int.MaxValue);

            if (ScoreChanged != null)
            {
                ScoreChanged(_score);
            }
        }
    }

    public static void Reset()
    {
        Score = 0;
    }
}
