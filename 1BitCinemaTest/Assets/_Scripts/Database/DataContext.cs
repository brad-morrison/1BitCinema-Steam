using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Bootstrapper
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Excecte() => Object.DontDestroyOnLoad(Object.Instantiate(Resources.Load("Database")));
}

namespace MovieJSON
{
    public class DataContext : MonoBehaviour
    {
        public MovieModel[] movies;
        public ScreenModel[] screens;

        private void Awake()
        {
            movies = JsonSerializer.LoadFromJsonFile<MovieModel[]>("Movie", true);


            var data = new List<CustomerToken>()
            {
                new CustomerToken(){ }
            };

            JsonSerializer.SaveObjectToFile("Customers", data);
            var customers = JsonSerializer.LoadFromJsonFile<CustomerToken[]>("Customers");
            
        }
    }


    public class CustomerToken
    {
        public string Name;
        public Vector2 Location;
    }


    public enum MovieGenre
    {
        SciFi = 0
    }

    public enum ScreenType
    {
        Small = 0,
        Medium = 1,
        Large = 2
    }

    [System.Serializable]
    public class MovieModel
    {
        public MovieGenre Genre;
        public string Title;

        public MovieModel(MovieGenre genre, string title)
        {
            Genre = genre;
            Title = title;
        }
    }

    [System.Serializable]
    public class ScreenModel
    {
        public ScreenType Type { get; set; }
    }
}
