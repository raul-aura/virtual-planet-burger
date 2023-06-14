using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPoints : MonoBehaviour
{
    [Header("Reference to the GameLogicManager.")]
    public GameLogicManager gameLogicManager;

    [Header("Reference to PlayerPoints Script")]
    public DisplayPoints displayPoints;

    [Header("Define the limits of the points.")]
    public int minPoints = 0;
    public int maxPoints = 10000;

    [Header("Define how many points the player will win/lose.")]
    public int pointsDelta; //It needs to be a positive number, or it won't work.

    private int playerPoints = 0;
    private int winStreak = 0;
    private float pointMultiplier = 1.0f; //This multiplier will be used if the player is on a win streak.

    public void AddPoints()
    {
        if(pointsDelta >= 0)
        {
            winStreak++;
            EvaluateWinStreak(); //Evaluate before summing up the points, ensuring that a 5-win streak is counted on the 5th win rather than the 6th.
            playerPoints += Mathf.RoundToInt(pointsDelta * pointMultiplier);
        }
        playerPoints = Mathf.Clamp(playerPoints, minPoints, maxPoints);
        DisplayTexts();
    }

    public void RemovePoints()
    {
        if (pointsDelta >= 0)
        {
            winStreak = 0; //The win streak is lost each time the player misses the recipe.
            EvaluateWinStreak();
            playerPoints -= pointsDelta;
        }
        playerPoints = Mathf.Clamp(playerPoints, minPoints, maxPoints);
        DisplayTexts();
    }

    private void EvaluateWinStreak()
    {
        if(winStreak >= 1 && winStreak % 5 == 0) //Every 5 wins, the point multiplier will increase.
        {
            pointMultiplier += 1.84f;
        }
        else if (winStreak == 0)
        {
            pointMultiplier = 1.0f;
        }
    }

    public void DisplayTexts()
    {
        gameLogicManager.DisplayNewSandwich();
        displayPoints.DisplayCurrentPoints(playerPoints);
        displayPoints.DisplayCurrentMultiplier(pointMultiplier);
    }

    public void ResetPoints()
    {
        playerPoints = 0;
        winStreak = 0;
        pointMultiplier = 1.0f;
    }
}