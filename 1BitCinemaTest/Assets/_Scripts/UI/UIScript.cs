using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class UIScript : MonoBehaviour
{
    public Button button_action;
    public ScrollView scrollView;
    public StyleSheet style;

    private void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        
        button_action = root.Q<Button>("EnterButton");
        scrollView = root.Q<ScrollView>("ContentAreaScrollView");

        button_action.clicked += ButtonPressed;
    }

    void ButtonPressed()
    {
        ConsoleBlank();
        AddToConsole("The current time is -> " + Controller.instance.gameTime.GetTime());
    }

    public void MoviesClicked()
    {
        ConsoleBlank();
        AddToConsole(" - all movies ->");
        foreach (Movie m in Database.instance.movieDatabase.movies)
        {
            ConsoleBlank();
            AddToConsole("name - " + m.name);
            AddToConsole("genre - " + m.genre);
            AddToConsole("runtime - " + m.runtime);
        }
    }

    public void OwnedMoviesClicked()
    {
        ConsoleBlank();

        AddToConsole(" - owned movies ->");
        foreach (Movie m in Controller.instance.player.cinema.ownedMovies)
        {
            ConsoleBlank();
            AddToConsole("name - " + m.name);
            AddToConsole("genre - " + m.genre);
            AddToConsole("runtime - " + m.runtime);
        }
    }

    public void ScreenRoomsClicked()
    {
        ConsoleBlank();
        AddToConsole(" - screen rooms ->");
        foreach (ScreenRoom sr in Controller.instance.player.cinema.screenRooms)
        {
            ConsoleBlank();
            AddToConsole(sr.name);
            AddToConsole("screen - " + sr.screenInstalled.name);
            AddToConsole("capacity - " + sr.capacity);
        }
    }

    public void ScreensClicked()
    {
        ConsoleBlank();
        AddToConsole(" - screens ->");
        foreach (Screen s in Database.instance.screenDatabase.screens)
        {
            ConsoleBlank();
            AddToConsole("name - " + s.name);
            AddToConsole("size - " + s.size);
            AddToConsole("cost - " + s.value);
            AddToConsole("tech - " + s.tech);
        }
    }

    public void ScreeningsClicked()
    {
        ConsoleBlank();
        AddToConsole(" - screenings ->");
        foreach (Screening s in Controller.instance.player.cinema.screenings)
        {
            ConsoleBlank();
            AddToConsole("screening ID - " + s.id);
            AddToConsole("movie playing - " + s.moviePlaying.name);
            AddToConsole("screen room - " + s.screenRoom.name);
        }
    }

    public void TicketsClicked()
    {
        ConsoleBlank();
        AddToConsole(" - available tickets ->");
        ConsoleBlank();
        foreach (TicketCategory t in Controller.instance.player.cinema.tickets.tickets)
        {
            AddToConsole(t.name + " - $" + t.price.ToString("00.00"));
        }
    }

    void AddToConsole(string text)
    {
        Label label = new Label() { text = text };
        scrollView.Add(label);
        StartCoroutine(scroll(label));

        Button button = new Button() { text = "BUTTON" };
    }

    void ConsoleBlank()
    {
        AddToConsole(" ");
    }

    IEnumerator scroll(VisualElement element)
    {
        yield return new WaitForSeconds(0.1f);
        scrollView.ScrollTo(element);
    }
}
