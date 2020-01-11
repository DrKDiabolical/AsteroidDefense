using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int resourceCost = 100; // Defines defender resource cost

    // Returns the resource cost
    public int GetResourceCost()
    {
        return resourceCost;
    }

    // Adds to resources by the amount
    public void AddResources(int amount)
    {
        FindObjectOfType<ResourceDisplay>().AddResources(amount);
    }
}
