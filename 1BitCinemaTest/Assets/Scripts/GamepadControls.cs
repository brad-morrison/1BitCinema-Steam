using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GamepadControls : MonoBehaviour
{
    public Controller controller;
    public PlayerInput playerInput;
    public GameObject up, left, right, down;
    public bool touchActive;

    public void ButtonEventTriggered(string buttonName, bool isOn)
    {
        switch (buttonName)
        {
            case "up":
                if (isOn)
                    playerInput.up = true;
                else
                    playerInput.up = false;
                break;

            case "left":
                if (isOn)
                    playerInput.left = true;
                else
                    playerInput.left = false;
                break;

            case "right":
                if (isOn)
                    playerInput.right = true;
                else
                    playerInput.right = false;
                break;

            case "down":
                if (isOn)
                    playerInput.down = true;
                else
                    playerInput.down = false;
                break;

            case "a":
                controller.movieList.PopulateTable(controller.player.ownedMovies);
                break;

            case "b":
                print("+100 coins");
                controller.player.wealth += 100;
                controller.saveData.SavePlayerData(controller.player);
                controller.PopulateUI();
                break;

            case "zoom":
                controller.CameraZoom();
                break;
        }
    }
}
