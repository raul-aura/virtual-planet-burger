using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelVisibility : MonoBehaviour
{
    private CanvasGroup canvasGroup;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>(); //This script will be in the same object as the CanvasGroup.
    }

    private void Update()
    {
        if(canvasGroup.alpha > 0.01f) //Margin error of 0.01f.
        {
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }
        else
        {
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
    }

    public void ShowCanvasGroup()
    {
        canvasGroup.alpha = 1;
    }

    public void HideCanvasGroup()
    {
        canvasGroup.alpha = 0;
    }

    /* This script controls the opacity/visibility of the CanvasGroup assigned. The functions on this scripts are called by signals from the Timeline. */
}
