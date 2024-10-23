using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Create Item Stat")]
public class ItemStats : ScriptableObject
{
    public float addHealth; //temp variable until able to see player setup
    public int coinCount;
    public int maxItem;
}
