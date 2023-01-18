using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ListItem : MonoBehaviour
{
    public MovieList movieList;

    private void Start()
    {
        movieList = GetComponentInParent<MovieList>();
    }

    private void OnMouseDown()
    {
        movieList.RemoveMovie(GetComponent<TextMeshPro>().text);
        movieList.RefreshTable();
        Destroy(this.gameObject);
    }
}
