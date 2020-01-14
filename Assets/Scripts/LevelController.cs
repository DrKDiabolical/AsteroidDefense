using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winCanvas; // Contains WinCanvas
    [SerializeField] GameObject loseCanvas; // Contains LoseCanvas
    int attackerAmount = 0; // Defines Attacker amount
    bool levelTimerFinished = false; // Toggles if level timer is finished

    void Start()
    {
        winCanvas.SetActive(false); // Set WinCanvas to inactive
        loseCanvas.SetActive(false); // Set LoseCanvas to inactive
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
        yield return new WaitForSeconds(5f); // Waits for 5 seconds
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