using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndResetScore : MonoBehaviour
{
    public void Reset()
    {
        GameManager.Reset();
    }
    public void Save()
    {
        Saves.SaveGame();
    }
}
