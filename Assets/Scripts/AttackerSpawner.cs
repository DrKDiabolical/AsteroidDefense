using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] Attacker[] attackerPrefabs; // Contains attacker prefab
    [SerializeField] float minSpawnDelay = 1f; // Minimum spawn delay
    [SerializeField] float maxSpawnDelay = 5f; // Maximum spawn delay
    bool spawn = true; // Toggles the spawner on and off

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(minSpawnDelay, maxSpawnDelay));
            Spawn(SelectAttacker(attackerPrefabs));
        }
    }

    // Stops the spawner from spawning more Attackers
    public void StopSpawning()
    {
        spawn = false;
    }

    // Spawns an attacker at the position of the attacker spawner
    void Spawn(Attacker attackerPrefab)
    {
        Attacker newAttacker = Instantiate(attackerPrefab, transform.position, Quaternion.identity) as Attacker;
        newAttacker.transform.parent = transform; // Sets the attacker as a child of the spawner
    }

    // Randomly selects an attacker from an array of attackers
    Attacker SelectAttacker(Attacker[] attackerPrefabs)
    {
        Attacker attackerPrefab = attackerPrefabs[(int)UnityEngine.Random.Range(0, attackerPrefabs.Length)];
        return attackerPrefab;
    }
}
