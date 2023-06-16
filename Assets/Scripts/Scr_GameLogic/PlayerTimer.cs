using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerTimer : TimelineTimer
{
    [Header("Reference to the GameLogicManager.")]
    public GameLogicManager gameLogicManager;

    public override IEnumerator Countdown()
    {
        yield return base.Countdown();
        gameLogicManager.ShowRestart();
    }

    /* This script handles the game's second timer, determining the available time for the player to make sandwiches. 
     * It also displays the Restart panel when the timer ends, utilizing the countdown from the parent class. */
}
