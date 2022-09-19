using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] UIController uiController;
    [SerializeField] TargetInputController targetInputController;
    [SerializeField] Player player;
    void InitializeUIController()
    {
        uiController.Initialize();
    }

    private void InitializeTargetInputController()
    {
        targetInputController.Initialize();
    }

    void InitializePlayer()
    {
        player.Initialize();
    }

    public void StartGame()
    {
        InitializeUIController();
        InitializeTargetInputController();
        InitializePlayer();      
    }

}
