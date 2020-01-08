using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    [SerializeField] GameObject defenderPrefab; // Contains defender prefab

    // On mouse click down, spawn defender
    void OnMouseDown() {
        SpawnDefender(GetSquareSelected());
    }
    
    // Gets square that the user clicked on
    Vector2 GetSquareSelected()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        return worldPos;
    }

    // Spawns defender on given coordinates
    void SpawnDefender(Vector2 worldCoords)
    {
        GameObject newDefender = Instantiate(defenderPrefab, worldCoords, Quaternion.identity) as GameObject;
    }
}
