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

    [Header("Reference to PanelVisibility Script from the Restart Panel.")]
    public PanelVisibility startBackgroundCanvasGroup;

    [Header("Reference to PanelVisibility Script from the Restart Panel.")]
    public PanelVisibility restartCanvasGroup;

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

    public void ShowRestart()
    {
        playerPoints.UpdateFinalPoints();
        startBackgroundCanvasGroup.ShowCanvasGroup();
        restartCanvasGroup.ShowCanvasGroup();
    }

    /* This script handles the control of the data stored in the referenced scripts. The first function is invoked by the timeline signal, thus, every time the
     * game starts or restarts. The second function is called every time we only need a new sandwich to be displayed and stored. This script also handles the function
     * that will show the restart panel for the player. */
}
