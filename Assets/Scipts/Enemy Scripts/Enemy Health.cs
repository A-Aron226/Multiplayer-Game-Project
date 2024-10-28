using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] HealthSO health;
    // Start is called before the first frame update
    void Start()
    {
        health.currHealth = health.maxHealth;
    }
}
