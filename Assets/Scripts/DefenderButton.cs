using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab; // Contains defender prefab

    void Start() {
        SetButtonCostText(); // Sets the text on the button to the cost of the Defender
    }

    // Sets the text on the button to the cost of the Defender
    void SetButtonCostText()
    {
        TMP_Text costText = GetComponentInChildren<TMP_Text>();
        if (!costText)
        {
            Debug.LogError(name + " has no cost text");
        }
        else
        {
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
            costText.text = defenderCost.ToString();
        }
    }

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
