using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : Defender {

    public GameObject projetile, gun;

    private GameObject projectileParent;

    private Animator animator;

    private Spawner myLaneSpawner;

    void Start()
    {
        animator = GetComponent<Animator>();
        projectileParent = GameObject.Find("Projectiles");
        {
            if (!projectileParent) {
                projectileParent = new GameObject("Projectiles");
            }
        }

        SetMyLaneSpawner();
    }

    void Update()
    {
        if (IsAttackerAheadInLane())
        {
            animator.SetBool("IsAttacking", true);
        }
        else {
            animator.SetBool("IsAttacking", false);
        }
    }

    void SetMyLaneSpawner()
    {
        Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner>();
        foreach (Spawner spawner in spawnerArray)
        {
            if (spawner.transform.position.y == transform.position.y)
            {
                myLaneSpawner = spawner;
                return;
            }
        }
    }

    bool IsAttackerAheadInLane()
    {
        if (myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }

        foreach (Transform attacker in myLaneSpawner.transform)
        {
            if (attacker.transform.position.x > transform.position.x) {
                return true;
            }
        }

        return false;
    }

    private void Fire()
    {
        GameObject newProjectile = Instantiate(projetile, gun.transform.position, Quaternion.identity) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
    }
}
