using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelHealthDisplay : MonoBehaviour
{
    TMP_Text levelHealthText;

    // Start is called before the first frame update
    void Start() {
        levelHealthText = GetComponent<TMP_Text>();
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        levelHealthText.text = FindObjectOfType<Level>().GetPlayerHealth().ToString();
    }
}
