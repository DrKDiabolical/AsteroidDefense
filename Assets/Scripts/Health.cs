using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100; // Defines base health stat
    [SerializeField] float deathAnimationTime = 0f; // Defines death animation time
    Animator anim; // Contains animator compenent

    void Start() {
        anim = GetComponent<Animator>();   
        if (anim == null)
        {
            Debug.LogError("ANIMATOR NOT FOUND");
        } 
    }

    // Decreases health by amount given
    public void decreaseHealth(float amount)
    {
        health -= amount;
        // If object reaches 0 health, then delete gameObject
        if (health <= 0)
        {
            anim.SetTrigger("Death");
            StartCoroutine(waitThenDie(deathAnimationTime));
        }
    }

    // Waits a few seconds for the animation to finish, then deletes the gameObject
    IEnumerator waitThenDie(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}
