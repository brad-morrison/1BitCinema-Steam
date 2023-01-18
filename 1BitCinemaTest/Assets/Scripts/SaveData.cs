using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveData : MonoBehaviour
{
    public void SavePlayerData(Player data)
    {

        string output = JsonUtility.ToJson(data);
        File.WriteAllText(Application.dataPath + "/Resources/Player.json", output);

    }
}
