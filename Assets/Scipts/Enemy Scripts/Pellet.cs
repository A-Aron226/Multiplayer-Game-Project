using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : MonoBehaviour
{
    [SerializeField] HealthSO health;
    public float attackDamage;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);

            //Code for player health to decrease from attackDamage value
            health.currHealth -= attackDamage;
        }
    }
}
