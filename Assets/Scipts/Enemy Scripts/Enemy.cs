using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public enum EnemyStates
{
    Patrol,
    Pursue
}
public class Enemy : MonoBehaviour
{
    //For patrol functions
    //Accessible in Script
    NavMeshAgent agent;
    public Transform[] waypoints;
    int waypointIndex;
    Vector3 target;
    FieldOfView view;


    //For enemy Attack/Pursue functions
    //Accessible in Editor
    public float attackDamage;
    public float speed;
    [SerializeField] Transform playerTarget;
    [SerializeField] private float timer = 5;
    private float bulletTime;
    public GameObject enemyBullet;
    public Transform spawnPoint;
    public float enemySpeed;


    //Accessible in Script
    Rigidbody rb;
    NavMeshPath path;
    GameObject player;
    EnemyStates state;

    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<FieldOfView>();
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        path = new NavMeshPath();

        agent.CalculatePath(playerTarget.position, path);

        player = GameObject.FindGameObjectWithTag("Player");
        UpdateDestination();
    }

    // Update is called once per frame
    void Update()
    {
        if (!view.canSeePlayer)
        {
            state = EnemyStates.Patrol;
        }

        else
        {
            state = EnemyStates.Pursue;
        }

        switch (state)
        {
            case EnemyStates.Patrol:
                UpdatePatrol();
                break;
            case EnemyStates.Pursue:
                UpdatePursue();
                break;
        }
    }

    //Functions for the patrol state
    public void UpdatePatrol()
    {
        if (Vector3.Distance(transform.position, target) < 1)
        {
            IterateWaypointIndex();
            UpdateDestination();
        }
    }

    void UpdateDestination()
    {
        target = waypoints[waypointIndex].position;
        agent.SetDestination(target);
    }

    void IterateWaypointIndex()
    {
        waypointIndex++;
        if (waypointIndex == waypoints.Length) //When AI reaches to last waypoint, it will go back to the first point
        {
            waypointIndex = 0;
        }
    }

    public void UpdatePursue()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerTarget.transform.position, speed * Time.fixedDeltaTime);
        ShootAtPlayer();
    }

    void ShootAtPlayer()
    {
        bulletTime -= Time.deltaTime;

        if (bulletTime > 0)
        {
            return;
        }

        bulletTime = timer;

        GameObject pelletObj = Instantiate(enemyBullet, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
        Rigidbody bulletRig = pelletObj.GetComponent<Rigidbody>();
        bulletRig.AddForce(bulletRig.transform.forward * enemySpeed);
        Destroy(bulletRig, 5f);
    }
}
