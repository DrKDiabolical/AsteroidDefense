using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winCanvas; // Contains WinCanvas
    [SerializeField] GameObject loseCanvas; // Contains LoseCanvas
    [SerializeField] float timeBeforeNextScene = 5f; // Defines the amount of time in seconds before the next scene loads
    int attackerAmount = 0; // Defines Attacker amount
    bool levelTimerFinished = false; // Toggles if level timer is finished
    
    void Start()
    {
        winCanvas.SetActive(false); // Set WinCanvas to inactive
        loseCanvas.SetActive(false); // Set LoseCanvas to inactive
    }

    void Update()
    {
        if (FindObjectOfType<Lives>().GetLives() <= 0)
        {
            HandleLoseCondition();
        }
    }

    // Increases amount of Attackers
    public void IncreaseAttackerAmount()
    {
        attackerAmount++;
    }

    // Decreases amount of Attackers
    public void DecreaseAttackerAmount()
    {
        attackerAmount--;
        if (attackerAmount <= 0 && levelTimerFinished)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    // Handles the player winning the level
    IEnumerator HandleWinCondition()
    {
        winCanvas.SetActive(true); // Sets WinCanvas to active
        GetComponent<AudioSource>().Play(); // Plays win audio clip
        yield return new WaitForSeconds(timeBeforeNextScene); // Waits for 5 seconds
        FindObjectOfType<SceneMachine>().LoadNextScene(); // Loads next level
    }

    // Handles the player losing the level
    public void HandleLoseCondition()
    {
        loseCanvas.SetActive(true); // Sets LoseCanvas to active
    }

    // Stops spawners if the timer is finished
    public void LevelTimerFinshed()
    {
        levelTimerFinished = true;
        StopSpawners(); // Stops all spawners
    }

    // Stops all spawners from spawning Attackers
    void StopSpawners()
    {
        AttackerSpawner[] attackerSpawners = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in attackerSpawners)
        {
            spawner.StopSpawning();
        }
    }
}