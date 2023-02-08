using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Screening", menuName = "1BitCinema/Objects/Screening")]
public class Screening : ScriptableObject
{
    public string id;
    public Movie moviePlaying;
    public ScreenRoom screenRoom;

    public void PlayScreening()
    {
        Controller.instance.StartScreening(this);
    }
}
