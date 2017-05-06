using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour
{
    public GameObject projectile;
    public GameObject gun;
    private GameObject projectileParent;
    private const string PROJECTILE_PARENT_NAME = "Projectiles";
    private Spawner myLaneSpawner;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        projectileParent = FindProjectileParent();
        if (projectileParent == null)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }

        SetMyLaneSpawner();
    }

    void Update()
    {
        if(animator)
            animator.SetBool("isAttacking", IsAttackerInLane());
    }

    private bool IsAttackerInLane()
    {
        if (myLaneSpawner == null || myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }

        foreach (Transform attacker in myLaneSpawner.transform)
        {
            if (attacker.position.x > transform.position.x)
            {
                return true;
            }
        }
        return false;
    }


    private void SetMyLaneSpawner()
    {
        Spawner[] spawners = GameObject.FindObjectsOfType<Spawner>();

        foreach (var spawner in spawners)
        {
            if (spawner.transform.position.y == transform.position.y)
            {
                myLaneSpawner = spawner;
                break;
            }
        }
    }



    private GameObject FindProjectileParent()
    {
        return GameObject.Find(PROJECTILE_PARENT_NAME);
    }

    private void Fire()
    {
        GameObject bullet = Instantiate(projectile) as GameObject;
        bullet.transform.parent = projectileParent.transform;
        bullet.transform.position = gun.transform.position;
    }


}
