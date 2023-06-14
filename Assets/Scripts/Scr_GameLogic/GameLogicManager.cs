using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogicManager : MonoBehaviour
{
    [Header("Reference to DisplayData Script")]
    public DisplayData displayData;

    [Header("Reference to DisplayExecuter Script")]
    public DisplayExecuter displayExecuter;

    [Header("Reference to PlayerPoints Script")]
    public PlayerPoints playerPoints;

    [Header("Reference to PlayerTimer Script")]
    public PlayerTimer playerTimer;

    private void Start()
    {
        InitializeEvents();
    }

    public void InitializeEvents()
    {
        playerTimer.InitializeTimer();
        playerPoints.ResetPoints();
        playerPoints.DisplayTexts();
    }

    public void DisplayNewSandwich()
    {
        displayData.RandomizeCurrentSandwich();
        displayExecuter.DisplaySandwich();
    }

    /* This script handles the control of the data stored in the referenced scripts. The first function is invoked by the timeline signal, thus, every time the
     * game starts or restarts. The second function is called every time we need a new sandwich to be displayed and stored. */
}
