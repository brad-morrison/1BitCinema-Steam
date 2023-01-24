using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player : MonoBehaviour
{
    // stored and retrieved from file
    public string name;
    public float wealth;
    // filled at runtime
    public List<Movie> ownedMovies;
    public List<ScreeningRoom> screeningRooms;
}
