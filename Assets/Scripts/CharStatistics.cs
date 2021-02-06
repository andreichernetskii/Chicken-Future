using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharStatistics : MonoBehaviour
{
   // [HideInInspector]
    public float health = 100;
   // [HideInInspector]
    public float exp;

    void Start()
    {
        LoadStats();

        Debug.Log(exp + " " + health);
    }
    void Update()
    {
        if (health<=0 && transform.tag == "Enemy")
        {
            Dead();
        }    
    }
    public void SaveStats()
    {
        PlayerPrefs.SetFloat("exp",exp);
        PlayerPrefs.SetFloat("health",health);
    }
    public void LoadStats()
    {
        if (PlayerPrefs.HasKey("health") && PlayerPrefs.HasKey("exp"))
        {
        PlayerPrefs.GetFloat("exp", exp);
        PlayerPrefs.GetFloat("health", health);
            Debug.Log("Aldı");
        }
        else
        {
            PlayerPrefs.SetFloat("exp", 0f);
            PlayerPrefs.SetFloat("health", 0f);
        }
    }
    public void Dead()
    {
        if (transform.tag != "Player")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<CharStatistics>().XPIncDec(exp);
            Destroy(gameObject);
        }
    }

    public void HealthIncDec(float hitPoint)
    {
        health += hitPoint;
    }

    public void XPIncDec(float xp)
    {
        exp += xp;
    }

}
