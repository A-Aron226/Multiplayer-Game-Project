using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    [SerializeField] float maxHp = 100;
    public UnityEvent<Vector3> OnHit;

    float currentHp;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        currentHp = maxHp;
    }

    public void Hit(Vector3 knockback, float damageAmount)
    {
        //owner.ApplyKnockback(knockback);
        OnHit.Invoke(knockback);//, damageAmount);
        TakeDamage(damageAmount);
    }

    public void TakeDamage(float amount)
    {
        currentHp -= amount;

        if (currentHp < 0)
            currentHp = 0;
        if (currentHp == 0)
        {
            gameObject.GetComponent<NavMeshAgent>().enabled = false;
            gameObject.GetComponent<Animator>().SetTrigger("Death");
            Destroy(gameObject, 3f);
        }
    }
}
