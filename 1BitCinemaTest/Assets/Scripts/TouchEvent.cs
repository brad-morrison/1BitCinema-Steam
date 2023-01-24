using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TouchEvent : MonoBehaviour
{
    public UnityEvent touched;

    private void OnMouseDown()
    {
        touched.Invoke();
    }
}
