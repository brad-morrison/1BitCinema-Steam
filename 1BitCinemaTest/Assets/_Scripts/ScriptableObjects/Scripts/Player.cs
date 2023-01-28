using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "1BitCinema/Objects/Player")]
public class Player : ScriptableObject
{
    public string name;
    public float money;
    public Cinema cinema;
}
