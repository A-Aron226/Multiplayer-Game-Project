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
    void Start()
    {
        health.currHealth = health.maxHealth;
    }

    void Update()
    {
        healthBar.fillAmount = health.currHealth / health.maxHealth;
    }
}
