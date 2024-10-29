using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] HealthSO health;
    // Start is called before the first frame update
    private void OnEnable()
    {
        health.currHealth = health.maxHealth;
    }

    private void OnDisable()
    {
        health.currHealth = 0;
    }

    public void Despawn()
    {
        if (health.currHealth == 0)
        {
            gameObject.SetActive(false);
        }
    }
}
