using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int resourceCost = 100; // Defines defender resource cost

    // Returns the resource cost
    public int GetResourceCost()
    {
        // Alters resourceCost depending on the difficulty within the PlayerPrefs
        float difficulty = PlayerPrefsController.GetDifficulty();
        if (difficulty == 0f)
        {
            resourceCost -= 50;
        }
        if (difficulty == 2f)
        {
            resourceCost += 50;
        }
        return resourceCost; // Returns resourceCost
    }

    // Adds to resources by the amount
    public void AddResources(int amount)
    {
        FindObjectOfType<ResourceDisplay>().AddResources(amount);
    }
}