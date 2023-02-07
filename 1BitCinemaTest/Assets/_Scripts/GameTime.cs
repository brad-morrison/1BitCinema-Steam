using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class GameTime : MonoBehaviour
{
    // data
    public int day;
    public int month;
    public int year;
    public int hour;
    public int mins;
    // controls
    public float tickInterval;
    public int tickIncrement;
    // flags
    public bool timeIsMoving;
    // gets and sets
    public void SetHour(int _hour) => hour = _hour;
    public void SetMins(int _mins) => mins = _mins;
    public int GetHour() => hour;
    public int GetMins() => mins;
    // ui
    public GameObject timeUI;
    // events
    public UnityEvent timeChanged;

    private void Awake()
    {
        StartCoroutine(Tick());
        SetTimeUI();
    }

    public string GetTime()
    {
        return GetHour().ToString() + ":" + GetMins().ToString();
    }

    public void PrintTime()
    {
        Debug.Log("the time is " + GetHour() + ":" + GetMins());
    }

    public void SetTimeUI()
    {
        timeUI.GetComponent<TextMeshPro>().text = GetHour().ToString("00") + ":" + GetMins().ToString("00");
    }

    public void PauseTime()
    {
        timeIsMoving = false;
    }

    public void PlayTime()
    {
        timeIsMoving = true;
        tickInterval = 1;
    }

    public void FastForward()
    {
        timeIsMoving = true;
        tickInterval = 0.5f;
    }

    public int[] timeCalc(float timeToAdd)
    {
        int[] time = new int[2];
        time[0] = hour + (int)timeToAdd;
        time[1] = mins;
        return time;
    }

    IEnumerator Tick()
    {
        yield return new WaitWhile(() => timeIsMoving == false);

        while (timeIsMoving)
        {
            if (mins + tickIncrement >= 60)
            {
                SetMins((mins + tickIncrement) - 60);
                if (hour == 23)
                {
                    SetHour(0);
                }
                else
                {
                    SetHour(hour + 1);
                }
                
            }
            else
            {
                SetMins(mins + tickIncrement);
            }

            timeChanged.Invoke();
            yield return new WaitForSeconds(tickInterval);
            
        }
        StartCoroutine(Tick());
    }
}
