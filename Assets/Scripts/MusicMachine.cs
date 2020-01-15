using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicMachine : MonoBehaviour
{
    AudioSource audioSource; // Contains audio source

    // Start is called before the first frame update
    void Start()
    {
        MusicMachineSingleton(); // Handles Singleton
        audioSource = GetComponent<AudioSource>(); // Gets AudioSource component
        audioSource.volume = PlayerPrefsController.GetMasterVolume(); // Sets volume of audio source to PlayerPrefs value
    }

    // Handles MusicMachine Singleton
    void MusicMachineSingleton()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Sets volume of audioSource
    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
