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

    private void FixedUpdate()
    {
        if (health.currHealth <= 75)
        {
            timer += Time.fixedDeltaTime;

            if (timer >= 11)
            {
                timer = 0;
            }
            if (timer >= 10)
            {
                Spawn();
                Debug.Log("Health Pack Spawned");
            }
           
        }

        else
        {
            timer = 0;
        }
    }


    void Spawn() //Will spawn a health pack item from pool
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        healthPack = HealthPackPool.SharedInstance.GetPooledObject("Health");
         //Spawns health pack if the player is less than 50% health within the timer range
   
        if (healthPack != null)
        {
            healthPack.transform.position = spawnPoints[spawnPointIndex].position;
            healthPack.transform.rotation = spawnPoints[spawnPointIndex].rotation;
            healthPack.SetActive(true);     
        }
    }
}
