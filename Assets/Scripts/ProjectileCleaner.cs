using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCleaner : MonoBehaviour
{   
    // Destroy any projectiles that enter this collider
    void OnTriggerEnter2D(Collider2D other) {
        Destroy(other.gameObject);
    }
}
