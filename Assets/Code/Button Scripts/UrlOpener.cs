using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrlOpener : MonoBehaviour
{
    public string _url;

    public void OpenUrl() {
        Application.OpenURL(_url);
    }
}
