using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPellet : MonoBehaviour
{
    //[SerializeField] HealthSO health; //calling from health script in testing folder
    public Damageable Damageable;
    public float attackDamage;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);

            //Code for enemy health to decrease from attackDamage value
            //health.currHealth -= attackDamage;
            Damageable.currentHp -= attackDamage;
        }
    }
}
