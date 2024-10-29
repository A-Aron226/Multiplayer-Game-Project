using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] HealthSO health;
    [SerializeField] Image healthBar;
    // Start is called before the first frame update
    private void OnEnable()
    {
        health.currHealth = health.maxHealth;
    }

    private void OnDisable()
    {
        health.currHealth = health.maxHealth;
    }

    void Update()
    {
        healthBar.fillAmount = health.currHealth / health.maxHealth; //Updates health bar HUD
    }
}
