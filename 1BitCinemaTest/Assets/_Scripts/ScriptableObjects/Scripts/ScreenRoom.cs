using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Screen Room", menuName = "1BitCinema/Objects/Screen Room")]
public class ScreenRoom : ScriptableObject
{
    public string name;
    public Screen screenInstalled;
    public int capacity;
    public int decoration;  // 1->10
    public int comfort;     // 1->10
    public int safety;      // 1->10
    public int condition; // 100->1
}
