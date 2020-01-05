using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] float _speed = 5f; // Defines speed for attacker

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * _speed, Space.Self); // Moves the attacker to the left depending on the speed
    }
}
