using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Movie", menuName = "1BitCinema/Objects/Movie")]
public class Movie : ScriptableObject
{
    public string id;
    public string name;
    public string genre;
    public float runtime;
}
