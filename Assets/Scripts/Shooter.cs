using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile; // Contains prefab for projectile

    public void Fire()
    {
        Instantiate(projectile, transform.position + new Vector3(0.5f, 0, 0), Quaternion.identity); // Instantiates firing projectile
    }
}
