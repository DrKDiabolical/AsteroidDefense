using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string MASTER_VOLUME_KEY = "master_volume"; // Defines master_volume key
    const string DIFFICULTY_KEY = "difficulty"; // Defines difficulty key

    const float MIN_VOLUME = 0f; // Defines minimum volume
    const float MAX_VOLUME = 1f; // Defines maximum volume

    const float MIN_DIFFICULTY = 0f; // Defines minimum difficulty
    const float MAX_DIFFICULTY = 2f; // Defines maximum difficulty

    // Sets master volume based on given float
    public static void SetMasterVolume(float volume)
    {
        if (volume >= MIN_VOLUME && volume <= MAX_VOLUME)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("Master volume is out of range");
        }
    }

    // Gets master volume
    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    // Sets difficulty based on given float
    public static void SetDifficulty(float difficulty)
    {
        if (difficulty >= MIN_DIFFICULTY && difficulty <= MAX_DIFFICULTY)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
        }
        else
        {
            Debug.LogError("Difficulty is out of range");
        }
    }

    // Gets difficulty value
    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }
}
