using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public enum EnemyStates
{
    Idle,
    Patrol,
    Pursue
}
public class Enemy : MonoBehaviour
{
    //For patrol functions
    NavMeshAgent agent;
    public Transform[] waypoints;
    int waypointIndex;
    Vector3 target;
    FieldOfView view;
    [SerializeField] bool patrols = false;


    //For enemy Attack/Pursue functions
    //Accessible in Editor
    //public float speed;
    [SerializeField] Transform playerTarget; //plyaer object
    [SerializeField] private float timer = 5; //rate of fire (default is 5)
    private float bulletTime;
    public GameObject enemyBullet; //pellet object
    public Transform spawnPoint; //where the pellet will spawn from
    public float pelletSpeed;


    //Accessible in Script
    Rigidbody rb;
    NavMeshPath path;
    GameObject player;
    public EnemyStates state = EnemyStates.Idle;

    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<FieldOfView>();
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        path = new NavMeshPath();

        player = GameObject.FindGameObjectWithTag("Player");
        //UpdateDestination();
    }

    // Update is called once per frame
    void Update()
    {
        if (!view.canSeePlayer && patrols)
        {
            state = EnemyStates.Patrol;
        }

        else if (view.canSeePlayer)
        {
            state = EnemyStates.Pursue;
        }

        else
        {
            state = EnemyStates.Idle;
        }

        switch (state)
        {
            case EnemyStates.Idle:
                break;
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

        else if (!view.canSeePlayer)
        {
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

    //Functions for Pursue state
    public void UpdatePursue() //Chases player while shooting if spotted
    {
        //transform.position = Vector3.MoveTowards(transform.position, playerTarget.transform.position, speed * Time.deltaTime); //Unused code but might be implememnted back in
        agent.SetDestination(playerTarget.position);
        ShootAtPlayer();
    }

    void ShootAtPlayer() //Sets the rate of fire for when spawning the pellet prefab
    {
        
        bulletTime -= Time.deltaTime;

        if (bulletTime > 0)
        {
            return;
        }

        bulletTime = timer;

        GameObject pelletObj = Instantiate(enemyBullet, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
        Rigidbody bulletRig = pelletObj.GetComponent<Rigidbody>();
        bulletRig.AddForce(bulletRig.transform.forward * pelletSpeed);
        Destroy(bulletRig, 5f);
    }
}
