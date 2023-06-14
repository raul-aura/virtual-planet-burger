using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerTimer : MonoBehaviour
{
    [Header("Reference to the GameLogicManager.")]
    public GameLogicManager gameLogicManager;

    [Header("Reference to the GUI Element.")]
    public TextMeshProUGUI timer_Text;

    [Header("Time limit for making sandwiches.")]
    public float playerTime = 120f;

    private float currentTime;

    public void InitializeTimer()
    {
        currentTime = playerTime;
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        while (currentTime > 0)
        {
            UpdateTimerText();
            yield return new WaitForSeconds(1.0f);
            currentTime--;
        }
        UpdateTimerText();
        Debug.Log("The timer is over!");
        gameLogicManager.InitializeEvents();
    }

    private void UpdateTimerText()
    {
        timer_Text.text = currentTime.ToString("F0");
    }
}
