using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSandwich", menuName = "Sandwich")]
public class SandwichData : ScriptableObject
{
    public string sandwichName;
    public Sprite sandwichIcon;
    public List<IngredientData> sandwichIngredient;
}

/* Scriptable object that contains all the information needed: name, icon, and an array for all the ingredients needed. 
 * The IngredientData[] is not limited to 3 elements because we can simply choose just three ingredients while creating the object. */
