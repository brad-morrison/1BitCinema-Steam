using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ImportData;
using TMPro;

public class Controller : MonoBehaviour
{
    // Refs
    public ImportData importedData;
    public SaveData saveData;
    public Screenings screenings;
    // Main data
    public Player player = new Player();
    public List<Movie> allMovies;
    public List<Screen> allScreens;
    public List<Screenings> activeScreenings;
    public GameTime gameTime = new GameTime();
    // objects
    public MovieList movieList;
    public GameObject coinsUI;
    public GameObject mainCam;
    // vars
    public float[] camZooms;
    public int cur_camZoom;


    private void Start()
    {
        Application.targetFrameRate = 600; // run at 60fps
        LoadData();
        PopulateUI();
        gameTime.PrintTime();
    }

    public void LoadData()
    {
        // movies
        foreach (Movie m in importedData.movieList.movies)
        {
            allMovies.Add(m);
        }
        // player data
        player.name = importedData.playerData.name;
        player.wealth = importedData.playerData.wealth;
        foreach (string s in importedData.playerData.ownedMovies)
        {
            player.ownedMovies.Add(importedData.GetMovieWithID(s));
        }
        player.screeningRooms = importedData.playerData.screeningRooms;

        // screens
        foreach (Screen s in importedData.screenData.screens)
        {
            allScreens.Add(s);
        }
        // screening rooms
        player.screeningRooms = importedData.screeningRoomData.screeningRooms;
        
    }

    public void PopulateUI()
    {
        coinsUI.GetComponent<TextMeshPro>().text = player.wealth.ToString();
    }

    public void CameraZoom()
    {
        if (cur_camZoom != camZooms.Length)
        {
            print("ddd");
            mainCam.GetComponent<Camera>().fieldOfView = camZooms[cur_camZoom + 1];
        }
        else
        {
            cur_camZoom = 0;
            mainCam.GetComponent<Camera>().fieldOfView = camZooms[cur_camZoom];
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown("m"))
        {
            print("+100 coins");
            player.wealth += 100;
            saveData.SavePlayerData(player);
            PopulateUI();
        }

        if (Input.GetKeyDown("p"))
        {
            screenings.PlayMovie(player.screeningRooms[1], player.ownedMovies[0]);
        }

        if (Input.GetKeyDown("q"))
        {
            print("calling populate list");
            movieList.PopulateTable(player.ownedMovies);
        }
    }


}
