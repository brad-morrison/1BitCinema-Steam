using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Controller : MonoBehaviour
{
    public static Controller instance; // Singleton

    public Player player;
    public GameTime gameTime;
    // gameobjects
    public GameObject infoText;
    // prefabs
    public Prefabs prefabs;
    public GameObject character;

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

    private void Start()
    {
        Application.targetFrameRate = 600; // run at 60fps
        infoText.GetComponent<TextMeshPro>().text = "";
        PrintAllScreenings();
    }

    public void PrintAllScreenings()
    {
        foreach (Screening s in instance.player.cinema.screenings)
        {
            Debug.Log("Movie [" + s.moviePlaying.name + "] is playing in [" + s.screenRoom.name + "]");
        }
    }

    public void StartScreening(Screening s)
    {
        StartCoroutine(PlayMovie(s.moviePlaying));
    }

    IEnumerator PlayMovie(Movie moviePlaying)
    {
        yield return new WaitForSeconds(moviePlaying.runtime);
        Debug.Log(moviePlaying.name + " finished playing");
    }

    public void SpawnCharacter()
    {
        Instantiate(character);
    }

    private void Update()
    {
        if (Input.GetKeyDown("c"))
        {
            SpawnCharacter();
        }
    }


}


// menu button brainstorming

// cinema admin
// - owned movies
// - staff
// - sreenings
// - screenrooms
// - prices

// store
// - movies
// - screens
// - decor
// - expansions

// news
// - latest news

// stats

// options

