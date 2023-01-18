using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScreeningRoom
{
    public string name;
    public Screen screenInstalled;
    public Movie moviePlaying;
    public int capacity;
    public int decoration;  // 1->10
    public int comfort;     // 1->10
    public int safety;      // 1->10
    public int condition; // 100->1
}
