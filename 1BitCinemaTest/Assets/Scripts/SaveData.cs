using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveData : MonoBehaviour
{
    public class PlayerData
    {
        public string name;
        public float wealth;
        public List<string> ownedMovies = new List<string>();
        //public List<ScreeningRoom> screeningRooms;
    }

    public void SavePlayerData(Player data)
    {
        // convert Player.cs object to PlayerData object
        //
        PlayerData playerData = new PlayerData();
        // name
        playerData.name = data.name;
        // wealth
        playerData.wealth = data.wealth;
        // movies
        foreach (Movie m in data.ownedMovies)
        {
            playerData.ownedMovies.Add(m.id);
        }


        // save to file
        //
        string output = JsonUtility.ToJson(playerData);

        File.WriteAllText(Application.dataPath + "/Resources/Player.json", output);

        Debug.Log("Saved Data");

    }

}

// === load
// player json file -> name, wealth, movieIDs
// imported and converted to PlayerData object
// Player class is built from PlayerData

// === save
// Player class converted to PlayerData object
// save to file

