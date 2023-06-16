using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimelineTimer : MonoBehaviour
{
    [Header("Reference to the GUI Element.")]
    public TextMeshProUGUI timer_Text;

    [Header("Timer amount + 1")]
    public float playerTime;
    protected float currentTime; //Accessible to this class and its child instances.

    public void InitializeTimer()
    {
        currentTime = playerTime;
        StartCoroutine(Countdown());
    }

    public virtual IEnumerator Countdown()
    {
        while (currentTime > 0)
        {
            UpdateTimerText();
            yield return new WaitForSeconds(1.0f);
            currentTime--;
        }
        UpdateTimerText();
    }

    public void UpdateTimerText()
    {
        timer_Text.text = Mathf.Clamp(currentTime - 1, 0, playerTime).ToString("F0");
    }

    /* This script manages the game's first timer, which is controlled by the timeline.
     * For dramatic effect, the player will have an additional second, but it won't be displayed.
     * This is intended to ensure that the number 0 remains visible for the duration of a second. */
}
