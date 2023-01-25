using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Screening : MonoBehaviour
{
    public ScreeningRoom screeningRoom;
    public Movie movie;

    
    public void Countdown()
    {
        StartCoroutine(_Countdown());
    }

    IEnumerator _Countdown()
    {
        yield return new WaitForSeconds(1);
        print("movie finished");
    }
    
}
