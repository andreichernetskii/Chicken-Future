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

    public string charName;

    void Start()
    {
        Debug.Log(exp + " " + health);
    }
    void Update()
    {
        if (health<=0 && transform.tag == "Enemy")
        {
            Dead();
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
