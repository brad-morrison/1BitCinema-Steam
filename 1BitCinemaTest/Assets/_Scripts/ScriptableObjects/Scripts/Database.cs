using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Database : MonoBehaviour
{
    public static Database instance; // Singleton

    // these databases hold all items of their type and
    // are not dynamic, therefore they have their own
    // database list scripts
    public MovieDatabase movieDatabase;
    public ScreenDatabase screenDatabase;
    // these lists are dynamic so they are handled here
    // by the main database object.
    public List<ScreenRoom> screenRooms;

    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static Movie GetMovieByID(string id)
    {
        return instance.movieDatabase.movies.FirstOrDefault(i => i.id == id);
    }

    public static Screen GetScreenByID(string id)
    {
        return instance.screenDatabase.screens.FirstOrDefault(i => i.id == id);
    }

    public static Movie GetRandomMovie()
    {
        return instance.movieDatabase.movies[Random.Range(0, instance.movieDatabase.movies.Count())];
    }
}
