using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float radius; //field of view radius

    [Range(0, 360)] //Range attribute. Limites the range to 360 degrees
    public float angle; //field of view angle

    public GameObject playerRef; //Player reference

    public LayerMask player; //Player layer for AI to find player object
    public LayerMask obstruction; //Layer for AI to be 'blinded' by evironment objects such as a wall

    public bool canSeePlayer; //For checking if the AI can see the player

    private void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player"); //Caching
        StartCoroutine(FOVRoutine());
    }

    private IEnumerator FOVRoutine() //Fucntion to check for player less often (in seconds) than in every frame
    {
        float delay = 0.2f; //default delay timer
        WaitForSeconds wait = new WaitForSeconds(delay);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck() //Function to check if the Player is withing field of view
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, player); //What is checking the range of player in Player layer

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2) //Narrowing view by half for a better angle check
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstruction)) //Create a raycast and aim it towards the player. It then limits raycast to the distance and stops the raycast if it hits an obstruction layer
                {
                    canSeePlayer = true;
                }
                else
                {
                    canSeePlayer = false;
                }
            }
            else
            {
                canSeePlayer = false;
            }
        }
        else if (canSeePlayer) //Sets to false if Player is not within the view of the AI
        {
            canSeePlayer = false;
        }
    }
}
