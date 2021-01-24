using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStatistics : MonoBehaviour
{
    float health;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void HealthDecrease(float hitPoint)
    {
        health -= hitPoint;
    }

    void HealthIncrase(float hitPoint)
    {
        health += hitPoint;
    }
}
