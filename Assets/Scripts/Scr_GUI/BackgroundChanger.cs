using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundChanger : MonoBehaviour
{
    [Header("Select all backgrounds.")]
    public Sprite[] backgroundsSprites;

    [Header("Reference to the GUI Element")]
    public Image backgroundImage;

    [Header("How many seconds will the fade last.")]
    public float fadeDuration = 1f;

    private int currentIndex = 0;
    private float currentTime = 0.0f;

    private CanvasGroup canvasGroup;
    private bool isFading = false; 

    private void Start()
    {
        canvasGroup = backgroundImage.GetComponent<CanvasGroup>();
    }

    public void ResetBackground()
    {
        currentIndex = 0;
        isFading = false;
        InitializeFade();
    }

    public void InitializeFade()
    {
        if (isFading) return; // Can't initialize fade if there's one already occuring.
        else if (currentIndex == backgroundsSprites.Length) return; // Or if the currentIndex reached the last array index.
        isFading = true;
        backgroundImage.sprite = backgroundsSprites[currentIndex];
        canvasGroup.alpha = 0f;
        StartCoroutine(FadeCoroutine());
    }

    private IEnumerator FadeCoroutine()
    {
        currentTime = 0f;
        float startAlpha = canvasGroup.alpha;
        float endAlpha = 1.0f;
        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            float t = currentTime / fadeDuration;
            canvasGroup.alpha = BounceAnimation(t, startAlpha, endAlpha);
            yield return null;
        }
        canvasGroup.alpha = endAlpha;
        isFading = false;
        currentIndex = Mathf.Min(currentIndex + 1, backgroundsSprites.Length);
    }

    private float BounceAnimation(float t, float startValue, float endValue)
    {
        return startValue + (endValue - startValue) * (1 - Mathf.Pow(1 - t, 5)); // "easeOutQuint" easing function.
    }

    /* This script implements a fade-in animation for the background image. The fade function is called whenever the player reaches a multiplier milestone. */
}
