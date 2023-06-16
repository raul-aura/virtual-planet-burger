using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Globalization; //I'm using this namespace so that decimal formats are displayed using dots instead of commas.

public class DisplayPoints : MonoBehaviour
{
    [Header("Reference to the GUI Element.")]
    public TextMeshProUGUI playerPoints_Text;
    public TextMeshProUGUI pointMultiplier_Text;

    [Header("Reference to elements in Restart Panel")]
    public TextMeshProUGUI currentScore_Text;
    public TextMeshProUGUI highestScore_Text;

    public void DisplayCurrentPoints(int p)
    {
        playerPoints_Text.text = p.ToString();
    }

    public void DisplayCurrentMultiplier(float m)
    {
        pointMultiplier_Text.text = $"{m.ToString("F1", CultureInfo.InvariantCulture)}x";
    }

    public void DisplayFinalPoints(int p, int h)
    {
        currentScore_Text.text = p.ToString();
        highestScore_Text.text = h.ToString();
    }

    /* Instead of the Update method, I've decided to update the texts only when the points or point multiplier is modified by the PlayerPoints script. */
}
