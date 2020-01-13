using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int playerHealth = 5;

    public int GetPlayerHealth()
    {
        return playerHealth;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<Attacker>())
        {
            playerHealth -= 1;
            if (playerHealth <= 0)
            {
                FindObjectOfType<SceneMachine>().LoadGameOver();
            }
            FindObjectOfType<LevelHealthDisplay>().UpdateDisplay();
            Destroy(other.gameObject);
        }
    }
}
