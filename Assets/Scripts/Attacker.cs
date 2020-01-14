using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    float currentSpeed = 1f; // Defines speed for attacker
    GameObject currentTarget; // Contains current target

    void Awake() {
        FindObjectOfType<LevelController>().IncreaseAttackerAmount(); // Increases amount of Attackers
    }

    void OnDestroy() {
        if (FindObjectOfType<LevelController>())
        {
            FindObjectOfType<LevelController>().DecreaseAttackerAmount(); // Decreases amount of Attackers
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * currentSpeed); // Moves the attacker to the left depending on the speed
        UpdateAnimationState();
    }

    // Sets current movement speed based on parameter
    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    // Updates the animation state
    void UpdateAnimationState()
    {
        if (!currentTarget)
        {
            GetComponent<Animator>().SetBool("IsAttacking", false);
        }
    }

    // Attacks the given target
    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("IsAttacking", true);
        currentTarget = target;
    }

    // Decreases the health of the current target
    public void StrikeCurrentTarget(float damage)
    {
        if (!currentTarget) { return; }
        Health health = currentTarget.GetComponent<Health>();

        if (health)
        {
            health.decreaseHealth(damage);
        }
    }
}
