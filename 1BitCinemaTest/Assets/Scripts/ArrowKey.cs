using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ArrowKey : MonoBehaviour
{
    public GamepadControls controls;
    public UnityEvent<string, bool> clicked;
    public UnityEvent<string, bool> clickEnded;
    public string function;
    

    private void OnMouseDown()
    {
        clicked.Invoke(function, true);
        controls.touchActive = true;
    }

    private void OnMouseOver()
    {
        if (controls.touchActive)
            if (function != "a" && function != "b" && function != "zoom")
                clicked.Invoke(function, true);
    }

    private void OnMouseExit()
    {
        if (function != "a" && function != "b" && function != "zoom")
            clickEnded.Invoke(function, false);
    }

    private void OnMouseUp()
    {
        if (function != "a" && function != "b" && function != "zoom")
        {
            clickEnded.Invoke(function, false);
            controls.touchActive = false;
        }
    }
}
