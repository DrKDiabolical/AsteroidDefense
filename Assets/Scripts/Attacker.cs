using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    float currentSpeed = 1f; // Defines speed for attacker

    // Sets current movement speed based on parameter
    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * currentSpeed); // Moves the attacker to the left depending on the speed
    }
}
