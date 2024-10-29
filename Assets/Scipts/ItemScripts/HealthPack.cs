using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    [SerializeField] GameObject obj; //Uses HealthPack obj
    [SerializeField] HealthSO health;
    [SerializeField] float addHealth;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            health.currHealth += addHealth;
        }
    }
}
