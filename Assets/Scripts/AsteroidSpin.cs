using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpin : MonoBehaviour
{
    [SerializeField] float _spinSpeed = 15f; // Defines speed of the asteroid spinning

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, _spinSpeed) * Time.deltaTime, Space.Self); // Rotates asteroid by rate of speed
    }
}
