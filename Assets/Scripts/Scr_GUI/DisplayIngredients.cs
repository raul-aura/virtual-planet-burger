using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayIngredients : MonoBehaviour
{
    [Header("Select all created Ingredients.")]
    public List<IngredientData> ingredients;

    [Header("Select the IngredientPanel prefab.")]
    public GameObject ingredientPanelPrefab;

    [Header("Reference to the GUI Element.")]
    public GameObject ingredientsGroup;

    private void Start()
    {
        InstantiateIngredients();
    }

    public void InstantiateIngredients()
    {
        foreach (IngredientData i in ingredients)
        {
            GameObject ingredient = Instantiate(ingredientPanelPrefab, ingredientsGroup.transform);
            IngredientButton ingredientButtonData = ingredient.GetComponentInChildren<IngredientButton>();
            TextMeshProUGUI ingredientName = ingredient.GetComponentInChildren<TextMeshProUGUI>();
            Image ingredientIcon = ingredient.GetComponentInChildren<Image>();
            ingredientButtonData.SetThisIngredient(i);
            ingredientName.text = i.ingredientName;
            ingredientIcon.sprite = i.ingredientIcon;
        }
    }

    /* This is a merge between DisplayExecuter and DisplayData, but instead of sandwiches, we're managing the ingredients.
     * For each element from the IngredientData list, we're instantiating an ingredientPanel to an object with Horizontal Layout Group.
     * This approach ensures each ingredientPanel will appear organized in the GUI. */

    /* Also, we're sending the current ingredient to the IngredientButton script so it can be assigned as the IngredientData ingredient to the button. 
     * This will be extremely important to the IngredientChecker, so it can check what ingredient object each button represents when it is clicked. */
}
