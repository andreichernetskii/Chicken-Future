using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharStatistics : MonoBehaviour
{
    float health;
    float exp;

    void Start()
    {
        //Veriler çekilemediyse oyunu tekrar başlatır.
        if (PlayerPrefs.HasKey("name") && PlayerPrefs.HasKey("exp"))
        {
            SceneManager.LoadScene(0);
        }
                
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
