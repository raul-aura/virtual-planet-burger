using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayExecuter : MonoBehaviour
{
    [Header("Reference to DisplayData Script")]
    public DisplayData displayData; 

    [Header("References to GUI Elements")]
    public TextMeshProUGUI sandwichName_Text;
    public Image sandwichIcon_Image;
    public TextMeshProUGUI[] sandwichIngredients_Texts;

    public void DisplaySandwich()
    {
        SandwichData sandwich = displayData.GetCurrentSandwich();
        if(sandwich != null)
        {
            sandwichName_Text.text = sandwich.sandwichName;
            sandwichIcon_Image.sprite = sandwich.sandwichIcon;
            foreach (IngredientData i in sandwich.sandwichIngredient)
            {
                sandwichIngredients_Texts[sandwich.sandwichIngredient.IndexOf(i)].text = i.ingredientName;
            }
        }
    }

    /* This script assigns all the data stored in the currentSandwich (randomized by the DisplayData script) to its respective GUI elements in the scene. 
     * The DisplaySandwich function is called every time we need a new sandwich on the GUI. */
}

