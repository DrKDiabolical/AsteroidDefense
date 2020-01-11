using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourceDisplay : MonoBehaviour
{
    [SerializeField] int resources = 150; // Defines resource amount
    TMP_Text resourceText; // Contains resource display text

    // Start is called before the first frame update
    void Start()
    {
        resourceText = GetComponent<TMP_Text>();
        UpdateDisplay();
    }

    // Updates the text display
    void UpdateDisplay()
    {
        resourceText.text = resources.ToString();
    }

    // Checks if there is enough resources
    public bool HaveEnoughResources(int amount)
    {
        return resources >= amount;
    }

    // Adds to resources by the amount
    public void AddResources(int amount)
    {
        resources += amount;
        UpdateDisplay();
    }

    // Checks if there is enough resources, if so then subtracts from resources by amount
    public void SpendResources(int amount)
    {
        if (resources >= amount)
        {
            resources -= amount;
            UpdateDisplay();
        }
    }
}
