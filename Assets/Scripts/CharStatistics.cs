using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharStatistics : MonoBehaviour
{
    [HideInInspector]
    public float health = 100;
    [HideInInspector]
    public float exp;

    void Start()
    {
        /*
        //Veriler çekilemediyse oyunu tekrar başlatır.
        if (PlayerPrefs.HasKey("name") && PlayerPrefs.HasKey("exp"))
        {
            SceneManager.LoadScene(0);
        }
        */    
    }

    public void healthIncDec(float hitPoint)
    {
        health += hitPoint;
        Debug.Log(health);
    }

}
