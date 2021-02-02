using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    GameObject playerObject;

    FireScript fireScript;

    //Kurşunun sürati.
    public float _bulletSpeed=0;
    //Kurşunun gücü.
    public float _hitPoint;

    //Kurşunun yok olma süresi
    float _destroyTime=3;
    //Geçen zaman
    float time;
    

    void Update()
    {
        //Zamanın akışı
        time += Time.deltaTime;

        //Merminin süratine göre hareketi
        transform.Translate(Vector3.forward * _bulletSpeed * Time.deltaTime,Space.Self);

        //Belirtilen zaman geçtiğinde kurşunu yok eder.
        if (time>_destroyTime)
        {
            Destroy(gameObject);
        }
    }
}
