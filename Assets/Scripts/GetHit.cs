using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharStatistics))]
public class GetHit : MonoBehaviour
{
    public string getHitBUlletTag;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == getHitBUlletTag)
        {
            Debug.Log("vuruldu");
            //Karakterin canı hitpoint kadar azalır.
            GetComponent<CharStatistics>().HealthIncDec(-other.GetComponent<BulletScript>()._hitPoint);
        }
    }
}