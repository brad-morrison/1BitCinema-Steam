using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class UIScript : MonoBehaviour
{
    // buttons
    public Button button_action;
    public Button button_movies;
    public Button button_ownedMovies;
    public Button button_screenRooms;
    public Button button_screenings;


    public ScrollView scrollView;
    public StyleSheet style;

    private void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        
        button_action = root.Q<Button>("EnterButton");
        button_movies = root.Q<Button>("MoviesButton");
        button_ownedMovies = root.Q<Button>("OwnedMoviesButton");
        button_screenRooms = root.Q<Button>("ScreenRoomsButton");
        button_screenings = root.Q<Button>("ScreeningsButton");
        scrollView = root.Q<ScrollView>("ContentAreaScrollView");

        button_action.clicked += ButtonPressed;
        button_movies.clicked += MoviesClicked;
        button_ownedMovies.clicked += OwnedMoviesClicked;
        button_screenRooms.clicked += ScreenRoomsClicked;
        button_screenings.clicked += ScreeningsClicked;
    }

    void ButtonPressed()
    {
        Label newText = new Label();
        newText.text = "The current time is -> " + Controller.instance.gameTime.GetTime();
        scrollView.Add(newText);
    }

    void MoviesClicked() {
        Label blank = new Label() { text = " " };
        scrollView.Add(blank);

        Label newText = new Label() { text = " - all movies ->" };
        scrollView.Add(newText);
        foreach (Movie m in Database.instance.movieDatabase.movies)
        {
            Label movieLabel = new Label() { text = m.name };
            scrollView.Add(movieLabel);
        }
    }

    void OwnedMoviesClicked() {
        Label blank = new Label() { text = " " };
        scrollView.Add(blank);

        Label newText = new Label() { text = " - owned movies ->" };
        scrollView.Add(newText);
        foreach (Movie m in Controller.instance.player.cinema.ownedMovies)
        {
            Label movieLabel = new Label() { text = m.name };
            scrollView.Add(movieLabel);
        }
    }

    void ScreenRoomsClicked()
    {
        Label blank = new Label() { text = " " };
        scrollView.Add(blank);

        Label newText = new Label() { text = " - screen rooms ->" };
        scrollView.Add(newText);
        foreach (ScreenRoom sr in Controller.instance.player.cinema.screenRooms)
        {
            Label movieLabel = new Label() { text = sr.name };
            scrollView.Add(movieLabel);

            Label screenType = new Label() { text = "screen - " + sr.screenInstalled.name };
            scrollView.Add(screenType);

            Label capacity = new Label() { text = "capacity - " + sr.capacity };
            scrollView.Add(capacity);

            Label blank2 = new Label() { text = " " };
            scrollView.Add(blank2);
        }
    }

    void ScreeningsClicked()
    {
        Label newText = new Label() { text = " - screenings ->" };
        scrollView.Add(newText);
        foreach (Screening s in Controller.instance.player.cinema.screenings)
        {
            Label name = new Label() { text = s.name };
            scrollView.Add(name);

            Label movie = new Label() { text = "movie playing - " + s.moviePlaying.name };
            scrollView.Add(movie);

            Label screen = new Label() { text = "screen room - " + s.screenRoom.name };
            scrollView.Add(screen);

            Label blank2 = new Label() { text = " " };
            scrollView.Add(blank2);
        }
    }
}
