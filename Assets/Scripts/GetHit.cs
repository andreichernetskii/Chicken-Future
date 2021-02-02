using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharStatistics))]
public class GetHit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Bullet")
        {
            Debug.Log("vuruldu");
            //Karakterin canı hitpoint kadar azalır.
            GetComponent<CharStatistics>().healthIncDec(-other.GetComponent<BulletScript>()._hitPoint);
        }
    }
}