using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] Attacker attackerPrefab; // Contains attacker prefab
    [SerializeField] float minSpawnDelay = 1f; // Minimum spawn delay
    [SerializeField] float maxSpawnDelay = 5f; // Maximum spawn delay
    bool spawn = true; // Toggles the spawner on and off

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    // Spawns an attacker at the position of the attacker spawner
    void SpawnAttacker()
    {
        Attacker newAttacker = Instantiate(attackerPrefab, transform.position, Quaternion.identity) as Attacker;
        newAttacker.transform.parent = transform; // Sets the attacker as a child of the spawner
    }
}
