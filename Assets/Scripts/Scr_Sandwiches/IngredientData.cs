using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewIngredient", menuName = "Ingredient")]
public class IngredientData : ScriptableObject
{
    public string ingredientName;
    public Sprite ingredientIcon;
}

//I've decided to also create a scriptable object for the ingredients, so that every Sandwich object created has the same elements of ingredients, without unique ingredients.
