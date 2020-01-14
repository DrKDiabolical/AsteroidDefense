using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesDisplay : MonoBehaviour
{
    TMP_Text livesText; // Contains Lives Text

    // Start is called before the first frame update
    void Start() {
        livesText = GetComponent<TMP_Text>();
        UpdateDisplay();
    }

    // Updates Lives Display
    public void UpdateDisplay()
    {
        livesText.text = FindObjectOfType<Lives>().GetLives().ToString();
    }
}
