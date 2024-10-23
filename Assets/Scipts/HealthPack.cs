using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    [SerializeField] GameObject obj;
    [SerializeField] ItemStats health;

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(obj);
        health.addHealth += 25.0f;
    }
}
