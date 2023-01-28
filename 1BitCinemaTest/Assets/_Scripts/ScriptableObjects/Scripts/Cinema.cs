using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Cinema", menuName = "1BitCinema/Objects/Cinema")]
public class Cinema : ScriptableObject
{
    public string name;
    public List<Movie> ownedMovies;
    public List<ScreenRoom> screenRooms;
    public List<Screen> ownedScreens;
}
