using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MovieList : MonoBehaviour
{
    public Controller controller;
    public GameObject listPrefab;
    public int listItemsCount;
    public float listItemOffsetY;

    public void PopulateTable(List<Movie> movieList)
    {
        foreach (Movie m in movieList)
        {
            listItemsCount++;
            SpawnListEntry(new Vector2(
                transform.position.x,
                transform.position.y + (listItemOffsetY * listItemsCount))
                , m.name);
        }
    }

    public void RefreshTable()
    {
        listItemsCount = 0;
        DestroyAllListItems();
        PopulateTable(controller.player.ownedMovies);
        
    }

    public void DestroyAllListItems()
    {
        foreach (ListItem li in GetComponentsInChildren<ListItem>())
        {
            Destroy(li.gameObject);
        }
    }

    private void SpawnListEntry(Vector2 position, string text)
    {
        print("adding entry");
        GameObject listObj = Instantiate(listPrefab, position, Quaternion.identity);
        listObj.GetComponent<TextMeshPro>().text = text;
        listObj.transform.parent = transform;
    }

    public void RemoveMovie(string name)
    {
        // remove from list
        int atIndex = 0;
        foreach (Movie m in controller.player.ownedMovies)
        {
            if (m.name == name)
            {
                controller.player.ownedMovies.Remove(m);
                print("movie removed");
                break;
            }
            //atIndex++;
        }

        // save data
        controller.saveData.SavePlayerData(controller.player);
    }
}
