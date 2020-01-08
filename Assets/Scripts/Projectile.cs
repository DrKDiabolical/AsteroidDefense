using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 5f; // Defines projectile speed
    [SerializeField] int damageAmount = 50;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime); // Translates projectile based on speed
    }

    // Handles collision with attackers
    void OnTriggerEnter2D(Collider2D other) {
        var health = other.GetComponent<Health>(); // Gets health component
        var attacker = other.GetComponent<Attacker>(); // Gets attacker component

        if (attacker && health)
        {
            health.decreaseHealth(damageAmount);
            Destroy(gameObject);
        }
    }
}
