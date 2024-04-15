using System.Collections;
using System.Collections.Generic;
// using UnityEditor.UI;
using UnityEngine;

/// <summary>
/// Disables the canvas it is on. Must bedirect child of canvas.
/// </summary>
public class CanvasDisableButton : MonoBehaviour
{
    /// <summary>
    /// Method that disables the canvas component it is on.
    /// </summary>
    public void DisableParentCanvas() {
        transform.parent.GetComponent<Canvas>().enabled = false; // Fetches the canvas component of its parent, and disables it.
    }
}
