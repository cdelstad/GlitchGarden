using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

    public GameObject projectile, gun;

    private GameObject projectileParent;
    private Animator anim;
    private Spawner myLaneSpawner;

    private void Start ()
    {
        anim = GameObject.FindObjectOfType <Animator>();

        // Creates a parent if necessary
        projectileParent = GameObject.Find ("Projectiles");

        if (!projectileParent)
        {
            projectileParent = new GameObject("Projectiles");
        }

        SetMylaneSpawner();
        print(myLaneSpawner);
    }

    private void Update ()
    {
        if (IsAttackerAheadInLane())
        {
            anim.SetBool("isAttacking", true);
        } else
        {
            anim.SetBool("isAttacking", false);
        }
    }

    private bool IsAttackerAheadInLane()
    {
        if (myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }

        foreach (Transform attackers in myLaneSpawner.transform)
        {
            if (attackers.transform.position.x > transform.position.x)
            {
                return true;
            }
        }
/*
        Attacker[] arrackerArray = GameObject.FindObjectsOfType<Attacker>();

        foreach (Attacker thisAttacker in arrackerArray)
        {
            if (thisAttacker.transform.position.y == transform.position.y)
            {
                print("yes attacker");
                return true;
            } else
            {
                print("no attacker");
                return false;
            }
        }
        */
        Debug.LogError(name + " cannot find attacker in lane!");
        // attackers in lane but behind us
        return false;
    }

    void SetMylaneSpawner ()
    {
        Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner>();
        foreach (Spawner thisSpawner in spawnerArray)
        {
            if ( thisSpawner.transform.position.y == transform.position.y)
            {
                myLaneSpawner = thisSpawner;
                return;
            }
        }
        Debug.LogError(name + " cannot find spawner in lane!");
    }

    private void Fire ()
    {
        GameObject newProjectile = Instantiate(projectile) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = gun.transform.position;
    }
}
