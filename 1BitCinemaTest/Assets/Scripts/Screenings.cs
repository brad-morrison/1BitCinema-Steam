using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenings : MonoBehaviour
{
    public Controller controller;
    public string mostPopularGenre;
    // genre multipliers
    public float genrePopularity_Action = 1.5f;
    public float genrePopularity_Adventure = 0.6f;
    public float genrePopularity_Romance = 1.0f;
    public float genrePopularity_Horror = 0.8f;
    public float genrePopularity_Animation = 1.3f;
    // prices
    public float ticketPrice = 4.99f;
    // things that will affect customers
    /* genre popularity
     * mood
     * money
     * prices
     * age
     * length of movie
     * technology
     * busy
     * time of day
     * month of the year
     * personal genre taste
     * film rating
    */
    private void Start()
    {
        //Debug.Log("about to play - " + controller.player.ownedMovies[1].name + " in " + controller.player.screeningRooms[0].name);
        //PlayMovie(controller.player.screeningRooms[0], controller.player.ownedMovies[1]);
    }

    public void PlayMovie(ScreeningRoom room, Movie movie)
    {
        Debug.Log("Playing [" + movie.name + "] in [" + room.name + "] tickets sold = [" + HowMuchCustomers(room, movie) + "/" + room.capacity + "]");
        float earnings = CalculateEarnings(HowMuchCustomers(room, movie));
        Debug.Log("Made £" + earnings + " from screening");
        controller.player.wealth += earnings;

    }

    public int HowMuchCustomers(ScreeningRoom room, Movie movie)
    {
        // start off full
        float customerCount = room.capacity;

        // is the movie genre the most popular?
        if (mostPopularGenre != movie.genre)
            customerCount = customerCount * 0.8f;

        // multiply by genre multiplier
        float multiplier=0;
        switch (movie.genre)
        {
            case "action":
                multiplier = genrePopularity_Action;
                break;

            case "adventure":
                multiplier = genrePopularity_Adventure;
                break;

            case "romance":
                multiplier = genrePopularity_Romance;
                break;

            case "horror":
                multiplier = genrePopularity_Horror;
                break;

            case "animation":
                multiplier = genrePopularity_Animation;
                break;

            default:
                multiplier = 0;
                break;
        }
        customerCount = customerCount * multiplier;

        // randomness
        customerCount = customerCount * Random.Range(0.8f, 1.2f);

        // set to full if over
        if (customerCount > room.capacity)
            customerCount = room.capacity;


        int value = (int)customerCount;
        return value;
    }

    public float CalculateEarnings(int customers)
    {
        float earnings = 0;
        earnings = (float)customers * ticketPrice;
        return earnings;
    }
}
