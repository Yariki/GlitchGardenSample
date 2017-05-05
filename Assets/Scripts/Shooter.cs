using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour
{
    public GameObject projectile;
    public GameObject gun;
    private GameObject projectileParent;
    private const string PROJECTILE_PARENT_NAME = "Projectiles";

    void Start()
    {
        projectileParent = FindProjectileParent();
        if (projectileParent == null)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
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
