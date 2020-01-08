using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 100; // Defines base health stat
    Animator anim;

    void Start() {
        anim = GetComponent<Animator>();   
        if (anim == null)
        {
            Debug.LogError("ANIMATOR NOT FOUND");
        } 
    }

    // Decreases health by amount given
    public void decreaseHealth(int amount)
    {
        health -= amount;
        // If attacker reaches 0 health, then delete gameObject
        if (health <= 0)
        {
            anim.SetTrigger("Death");
            StartCoroutine(waitThenDie(0.75f));
        }
    }

    // Waits a few seconds for the animation to finish, then deletes the gameObject
    IEnumerator waitThenDie(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}
