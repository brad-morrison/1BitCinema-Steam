using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player : MonoBehaviour
{
    public string name;
    public float wealth;
    public List<Movie> ownedMovies;
    public List<ScreeningRoom> screeningRooms;
}
