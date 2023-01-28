using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Movie Database", menuName = "1BitCinema/Databases/Movie Database")]
public class MovieDatabase : ScriptableObject
{
    public List<Movie> movies;
}
