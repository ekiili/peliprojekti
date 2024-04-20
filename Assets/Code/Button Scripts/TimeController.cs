using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public void PauseTime() {
        Time.timeScale = 0;
    }

    public void ResumeTime() {
        Time.timeScale = 1;
    }
}
