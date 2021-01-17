using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FireScript : MonoBehaviour
{

    public bool isShooting = false;

    void Start()
    {
    }

    void Update()
    {

    }

    public void FireOn()
    {
        isShooting = true;
    }
    public void FireOff()
    {
        isShooting = false;

    }
}