using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientChecker : MonoBehaviour
{
    [Header("Reference to DisplayData Script")]
    public DisplayData displayData;

    [Header("Reference to PlayerPoints Script")]
    public PlayerPoints playerPoints;

    [Header("Maximum number of Ingredients the player can select.")]
    public int maxIngredients = 5;

    private List<IngredientData> correctIngredients = new();
    private List<IngredientData> wrongIngredients = new();
    private int selectedIngredients = 0;

    private List<Button> buttonList = new();

    private bool ingredientFound;

    /* Function called by the button. It desables the button, gets the ingredient the button represents and checks if it matches with
     * any ingredient from the sandwich ingredients.*/
    public void CheckIngredientClicked(Button b, IngredientData currentI)
    {
        b.enabled = false;
        buttonList.Add(b);
        SandwichData sandwich = displayData.GetCurrentSandwich();
        List<IngredientData> sandwichIngredients = sandwich.sandwichIngredient;
        foreach(IngredientData sandwichI in sandwichIngredients)
        {
            if(currentI == sandwichI)
            {
                ingredientFound = true;
                break;
            }
            else
            {
                ingredientFound = false;
            }
        }
        selectedIngredients++;
        EvaluateIngredient(currentI);
        EvaluateRecipe(sandwichIngredients);
    }

    /* This function evaluates the ingredient selected and adds to a list that will be evaluated next. */
    private void EvaluateIngredient(IngredientData currentI)
    {
        if (ingredientFound)
        {
            correctIngredients.Add(currentI);
        }
        else
        {
            wrongIngredients.Add(currentI);
        }
    }

    /* This function evaluates the lists according to the established number of elements in the sandwich ingredients list.
     * Additionally, this limits the amount of buttons the player can click. By doing so, The player won't have to press all 
     * the buttons or have the chance to get the recipe right when including one or more wrong ingredients. */
    private void EvaluateRecipe(List<IngredientData> currentIngredientList)
    {
        bool isRightRecipe = correctIngredients.Count == currentIngredientList.Count;
        bool isWrongRecipe = selectedIngredients >= maxIngredients && wrongIngredients.Count >= 1;
        if (isRightRecipe)
        {
            playerPoints.AddPoints();
            ResetData();
        }
        else if (isWrongRecipe)
        {
            playerPoints.RemovePoints();
            ResetData();
        }
    }

    /* The list is cleared, the buttons are enabled again and the function to display a new sandwich will be called, alongside with the updated points. */
    private void ResetData()
    {
        correctIngredients.Clear();
        wrongIngredients.Clear();
        foreach (Button b in buttonList)
        {
            b.enabled = true;
        }
        selectedIngredients = 0;
    }
}
