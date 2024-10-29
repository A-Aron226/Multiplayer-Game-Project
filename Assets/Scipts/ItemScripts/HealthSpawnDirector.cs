using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class HealthSpawnDirector : MonoBehaviour
{
    [SerializeField] HealthSO health;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject healthPack;
    public float timer;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 25)
        {
            timer = 0;
        }

        if (health.currHealth < 50f && timer >= 15 && timer <= 20) //Spawns health pack if the player is less than 50% health within the timer range
        {
            Spawn();
            Debug.Log("Health Pack Spawned");
        }
    }

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
