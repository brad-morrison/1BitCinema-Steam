using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Poster : MonoBehaviour
{
    public GameObject floatingText;
    public int screeningNumber; // temp for just now

    private void Start()
    {
        SetMovie();
    }

    public void SetMovie()
    {
        floatingText.GetComponent<TextMeshPro>().text = Controller.instance.player.cinema.screenings[screeningNumber].moviePlaying.name;
    }

    private void OnMouseOver()
    {
        floatingText.SetActive(true);
    }

    private void OnMouseExit()
    {
        floatingText.SetActive(false);
    }
}
