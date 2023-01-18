using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screens : MonoBehaviour
{
    public TextAsset textJSON;

    [System.Serializable]
    public class Screen
    {
        public string name;
        public int value;
        public string size;
        public string tech;

    }

    [System.Serializable]
    public class ScreenList
    {
        public Screen[] screen;
    }

    public ScreenList screenList = new ScreenList();

    void Awake()
    {
        screenList = JsonUtility.FromJson<ScreenList>(textJSON.text);
    }
}
