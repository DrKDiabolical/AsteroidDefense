﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defenderPrefab; // Contains defender prefab
    GameObject defenderParent; // Contains parent object for organization
    const string DEFENDER_PARENT_NAME = "Defenders"; // Defines parent object name

    void Start() {
        CreateDefenderParent();
    }

    void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    // On mouse click down, spawn defender
    void OnMouseDown() {
        AttemptDefenderSpawn(GetSquareSelected());
    }

    // Sets the current defender prefab to the defender that is currently selected
    public void SetSelectedDefender(Defender defenderToSelect)
    {
        defenderPrefab = defenderToSelect;
    }

    // Attempts to spawn the defender if the player has enough resources
    void AttemptDefenderSpawn(Vector2 gridPos)
    {
        var resourceDisplay = FindObjectOfType<ResourceDisplay>();
        int defenderCost = defenderPrefab.GetResourceCost();
        // Alters defenderCost depending on the difficulty within the PlayerPrefs
        float difficulty = PlayerPrefsController.GetDifficulty();
        if (difficulty == 0f)
        {
            defenderCost -= 50;
        }
        if (difficulty == 2f)
        {
            defenderCost += 50;
        }
        if (resourceDisplay.HaveEnoughResources(defenderCost))
        {
            SpawnDefender(gridPos);
            resourceDisplay.SpendResources(defenderCost);
        }
    }
    
    // Gets square that the user clicked on
    Vector2 GetSquareSelected()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y); // Gets mouse position
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos); // Gets world position based on mouse position
        Vector2 gridPos = SnapToGrid(worldPos); // Rounds the world position to integer values
        return gridPos;
    }

    // Rounds the given vector2 and returns a new vector2
    Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x); // Rounds X position
        float newY = Mathf.RoundToInt(rawWorldPos.y); // Rounds Y position
        return new Vector2(newX, newY);
    }

    // Spawns selected defender on given coordinates
    void SpawnDefender(Vector2 spawnPos)
    {
        Defender newDefender = Instantiate(defenderPrefab, spawnPos, Quaternion.identity) as Defender;
        newDefender.transform.parent = defenderParent.transform; // Parents newly instantiated object to parent object
    }
}
