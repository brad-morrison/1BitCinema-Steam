using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ImportData : MonoBehaviour
{
    public TextAsset moviesJSON;
    public TextAsset playerJSON;
    public TextAsset screenJSON;
    public TextAsset screeningRoomJSON;

    [System.Serializable]
    public class MovieList
    {
        public Movie[] movies;
    }

    [System.Serializable]
    public class PlayerData
    {
        public string name;
        public float wealth;
        public List<Movie> ownedMovies;
        public List<ScreeningRoom> screeningRooms;
    }

    [System.Serializable]
    public class ScreenData
    {
        public List<Screen> screens;
    }

    [System.Serializable]
    public class ScreeningRoomData
    {
        public List<ScreeningRoom> screeningRooms;
    }

    public MovieList movieList = new MovieList();
    public PlayerData playerData = new PlayerData();
    public ScreenData screenData = new ScreenData();
    public ScreeningRoomData screeningRoomData = new ScreeningRoomData();

    void Awake()
    {
        movieList = JsonUtility.FromJson<MovieList>(moviesJSON.text);
        playerData = JsonUtility.FromJson<PlayerData>(playerJSON.text);
        screenData = JsonUtility.FromJson<ScreenData>(screenJSON.text);
        screeningRoomData = JsonUtility.FromJson<ScreeningRoomData>(screeningRoomJSON.text);
    }

    // get movie from imported data by ID
    public Movie GetMovieWithID(string id)
    {
        foreach (Movie m in movieList.movies)
        {
            if (id == m.id)
                return m;
        }
        return null;
    }

    // get screen from imported data by ID
    public Screen GetScreenWithID(string id)
    {
        foreach (Screen s in screenData.screens)
        {
            if (id == s.id)
                return s;
        }
        return null;
    }
}
