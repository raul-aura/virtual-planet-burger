using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientButton : MonoBehaviour
{
    private Button thisButton;
    private IngredientData thisIngredient;

    private IngredientChecker ingredientChecker;

    private void Start()
    {
        thisButton = GetComponent<Button>();
        ingredientChecker = FindObjectOfType<IngredientChecker>();
        if(ingredientChecker == null)
        {
            Debug.LogWarning("<color=yellow>[Reminder]</color> Object with IngredientChecker not found in the scene."); //Don't forget the IngredientChecker!
        }
        else
        {
            thisButton.onClick.AddListener(() => ingredientChecker.CheckIngredientClicked(thisButton, thisIngredient));
        }
    }

    public void SetThisIngredient(IngredientData i)
    {
        thisIngredient = i;
    }

    /* Since the button prefab will be instantiated in the scene, we can't drag the IngredientChecker script in the inspector, 
     * so we're trying to find the object in the scene.
     * If the script is found, we add a listener to this button so that every time that is clicked, it will call the check function, 
     * sending the ingredient this button represents. This can only work thanks to the "SetThisIngredient" function, called by the 
     * DisplayIngredients instantiator. Thanks, DisplayIngredients! */
}
