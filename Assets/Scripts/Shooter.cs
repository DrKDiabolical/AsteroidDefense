using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile; // Contains prefab for projectile
    AttackerSpawner myLaneSpawner; // Contains Attacker Spawner within the Defender's lane
    Animator animator; // Contains Defender Animator

    void Start() {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
    }

    void Update() {
        if (IsAttackerInLane())
        {
            animator.SetBool("IsShooting", true);
        }
        else
        {
            animator.SetBool("IsShooting", false);
        }
    }

    // Sets the lane at which the Defender is in
    void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in spawners)
        {
            bool IsCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);
            if (IsCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    // Checks to see if there is an Attacker in the lane of the Defender
    bool IsAttackerInLane()
    {
        if (myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    // Instantiates a projectile
    public void Fire()
    {
        Instantiate(projectile, transform.position + new Vector3(0.5f, 0, 0), Quaternion.identity); // Instantiates firing projectile
    }
}
