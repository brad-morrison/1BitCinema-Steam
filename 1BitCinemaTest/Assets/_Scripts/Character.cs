using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Genre genre_Fav;
    public Genre genre_Hate;

    private void Awake()
    {
        if (Random.Range(0, 2) == 0)
        {
            genre_Fav = Genre.scifi;
            genre_Hate = Genre.adventure;
        }
        else
        {
            genre_Fav = Genre.adventure;
            genre_Hate = Genre.scifi;
        }
    }

    private void Start()
    {
        if (ShouldIEnterCinema())
        {
            if (MovieIWantToWatch() != null)
            {
                if (DoIAgreeWithPrices() == true)
                {
                    Debug.Log("A customer purchased tickets for [" + MovieIWantToWatch() + "]");
                }
                else
                {
                    print("customer didn't agree with prices");
                }
            }
            else
            {
                print("customer coudln't find a movie");
            }
        }
        else
        {
            Destroy(this.gameObject);
            print("customer didn't want to enter cinema");
        }
    }

    // come into cinema decision
    private bool ShouldIEnterCinema()
    {
        if (Random.Range(0, 2) == 1)
            return true;
        else
            return false;
    }

    // do i want to watch the movies on show
    private Screening MovieIWantToWatch()
    {
        foreach (Screening s in Controller.instance.player.cinema.screenings)
        {
            if (s.moviePlaying.genre == genre_Fav)
            {
                return s;
            }
        }

        return null;
    }

    // do i agree with the prices
    private bool DoIAgreeWithPrices()
    {
        return true;
    }

    // buy tickets
    // what did i think
    // leavehh

}
