using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Movie", menuName = "1BitCinema/Objects/Movie")]
public class Movie : ScriptableObject
{
    public string id;
    public string name;
    public Genre genre;
    public float runtime;
}

public enum Genre
{
    action,
    adventure,
    children,
    animation,
    scifi,
    romance,
    comedy,
    drama,
    horror,
    musical,
    fantasy
}
