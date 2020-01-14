using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{
    [SerializeField] int lives = 5; // Defines amount of lives

    // Returns the amount of lives
    public int GetLives()
    {
        return lives;
    }

    // Decreases the amount of lives when an Attacker enters the collider
    void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<Attacker>())
        {
            lives -= 1;
            // Loads Game Over scene when the player runs out of lives
            if (lives <= 0)
            {
                FindObjectOfType<LevelController>().HandleLoseCondition();
            }
            FindObjectOfType<LivesDisplay>().UpdateDisplay(); // Updates Lives Display
            Destroy(other.gameObject); // Destroys Attacker
        }
    }
}
