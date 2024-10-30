using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;

public class Gun : MonoBehaviour
{
    //references
    [SerializeField] protected Transform gunBarrelEnd;
    [SerializeField] protected GameObject bulletPrefab;
    [SerializeField] protected Animator anim;

    //stats
    [SerializeField] protected int maxAmmo;
    [SerializeField] protected float timeBetweenShots = 0.1f;

    //protected
    protected int ammo;
    protected float elapsed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        ammo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
    }

    public void Reload()
    {
        ammo = maxAmmo;
    }

    public void AttemptFire()
    {
        if (ammo <= 0)
        {
            return;
        }

        if (elapsed < timeBetweenShots)
        {
            return;
        }

        var b = Instantiate(bulletPrefab, gunBarrelEnd.transform.position, gunBarrelEnd.rotation);
        b.GetComponent<Projectile>().Initialize(5, 50, 2, 5, null);

        anim.SetTrigger("shoot");
        elapsed = 0;
        ammo -= 1;
    }
}
