using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyAttack : MonoBehaviour
{
    //Accessible in Editor
    public float attackDamage;
    public float speed;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform target;


    //Accessible in Script
    Rigidbody rb;
    FieldOfView view;
    NavMeshPath path;
    GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        path = new NavMeshPath();

        agent.CalculatePath(target.position, path);

        player = GameObject.FindGameObjectWithTag("Player");

        view = GetComponent<FieldOfView>();
    }

    // Update is called once per frame
    void Update()
    {

        if (view.canSeePlayer)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {

        }
    }*/
}
