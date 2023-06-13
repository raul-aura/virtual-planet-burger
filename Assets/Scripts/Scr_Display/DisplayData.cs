using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayData : MonoBehaviour
{
    [Header("Select all created Sandwiches.")]
    public List<SandwichData> sandwiches;

    private SandwichData currentSandwich;

    public SandwichData RandomizeCurrentSandwich()
    {
        if(sandwiches.Count == 0)
        {
            Debug.LogWarning("<color=yellow>[Reminder]</color> The sandwichList is currently empty and no sandwichObject was returned."); //Don't forget the list!
            return null;
        }
        int randomIndex = Random.Range(0, sandwiches.Count);
        currentSandwich = sandwiches[randomIndex];
        return currentSandwich;
    }

    /* This is a simple script containing only one function that will be called by the DisplayExecuter. 
     * The function will randomize an Index - from 0 to n. Where n represents the maximum number of elements in the list "sandwiches".
     * Then, it will assign the sandwich from the Index to the currentSandwich variable.
     * The currentSandiwch will be returned to the DisplayExecuter with all its data (name, icon and ingredients). */

    /* Randomizing each time the function is called - instead of every time the game starts - is a better option here, since there isn't a
     * limited number of times the player can finish all the elements of the list (or all created sandwiches). Another option would be to randomize
     * the List order using a "for" each time the game starts/restarts. However, with a n = 5, the randomized list tends to repeat frequently, so 
     * with this simple function it will get a similar result, consume less data and reduce the amount of code needed. */
}
