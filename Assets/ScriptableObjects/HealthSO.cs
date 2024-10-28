using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create Health Stat")]
public class HealthSO : ScriptableObject
{
    public float maxHealth;
    public float currHealth;
}
