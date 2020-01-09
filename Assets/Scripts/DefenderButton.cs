using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab; // Contains defender prefab

    // On mouse down, highlights clicked on defender and darkens other selectable defenders
    void OnMouseDown() {
        var buttons = FindObjectsOfType<DefenderButton>(); // Finds all defender buttons
        // For each defender button within buttons, set their color to a darker shade
        foreach(DefenderButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(90, 90, 90, 255);
        }
        GetComponent<SpriteRenderer>().color = Color.white; // Sets clicked on defender button color to white
        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab); // Sets defender clicked on to selected defender
    }
}
