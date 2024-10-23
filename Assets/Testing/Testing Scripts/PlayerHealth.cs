using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] HealthSO health;
    // Start is called before the first frame update
    void Start()
    {
        health.currHealth = health.maxHealth;
    }
}
