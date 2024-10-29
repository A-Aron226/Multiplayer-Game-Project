using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class HealthSpawnDirector : MonoBehaviour
{
    [SerializeField] HealthSO health;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject healthPack;
    [SerializeField] float time;

    void Spawn() //Will spawn a health pack item from pool
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        healthPack = HealthPackPool.SharedInstance.GetPooledObject("Health");
        if (healthPack != null)
        {
            healthPack.transform.position = spawnPoints[spawnPointIndex].position;
            healthPack.transform.rotation = spawnPoints[spawnPointIndex].rotation;
            healthPack.SetActive(true);
        }
    }
}
