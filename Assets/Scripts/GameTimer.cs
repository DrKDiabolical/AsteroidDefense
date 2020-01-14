using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("The Length Of The Level In Seconds")]
    [SerializeField] float levelTime = 10f; // Defines level length in seconds
    bool triggeredLevelFinished = false; // Toggles if level is finished

    // Update is called once per frame
    void Update()
    {
        if (triggeredLevelFinished) { return; } // If the level has been finished, return
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime; // Sets level timer value

        bool timerFinshed = (Time.timeSinceLevelLoad >= levelTime);
        // If timer is finished, then call level controller function
        if (timerFinshed)
        {
            FindObjectOfType<LevelController>().LevelTimerFinshed();
            triggeredLevelFinished = true;
        }
    }
}
