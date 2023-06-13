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
            TextMeshProUGUI ingredientName = ingredient.GetComponentInChildren<TextMeshProUGUI>();
            Image ingredientIcon = ingredient.GetComponentInChildren<Image>();
            ingredientName.text = i.ingredientName;
            ingredientIcon.sprite = i.ingredientIcon;
        }
    }

    /* This is a merge between DisplayExecuter and DisplayData, but instead of sandwiches, we're managing the ingredients.
     * For each element from the IngredientData list, we're instantiating an ingredientPanel to an object with Horizontal Layout Group.
     * This way, each ingredientPanel will appear organized in the GUI. */
}
