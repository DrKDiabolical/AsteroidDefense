using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider; // Contains slider for volume
    [SerializeField] float defaultVolume = 0.6f; // Defines default volume
    [SerializeField] Slider difficultySlider; // Contains slider for difficulty
    [SerializeField] float defaultDifficulty = 1f; // Defines default difficulty

    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume(); // Sets volume slider to PlayerPref value
        difficultySlider.value = PlayerPrefsController.GetDifficulty(); // Sets difficulty slider to PlayerPref value
    }

    // Update is called once per frame
    void Update()
    {
        var musicMachine = FindObjectOfType<MusicMachine>(); // Finds and references MusicMachine
        if (musicMachine)
        {
            musicMachine.SetVolume(volumeSlider.value); // Sets MusicMachine volume based on slider value
        }
        else
        {
            Debug.LogWarning("No MusicMachine found, did you start from MainMenu scene?"); // Null-check for MusicMachine
        }
    }

    // Saves all slider values to PlayerPrefs
    public void SaveAndExit()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        PlayerPrefsController.SetDifficulty(difficultySlider.value);
        FindObjectOfType<SceneMachine>().LoadMainMenu();
    }

    // Resets sliders to default value
    public void ResetToDefault()
    {
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;
    }
}
