using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    GameObject playerObject;

    FireScript bulletScript;

    //Kurşunun sürati.
    float bulletSpeed=0;

    //Kurşunun yok olma süresi
    float destroyTime=0;
    //Geçen zaman
    float time;
    
    private void Start()
    {
        //Ana karakter çağrıldı.
        playerObject = GameObject.FindGameObjectWithTag("Player");

        //firescript componentini çeker.
        bulletScript = playerObject.GetComponent<FireScript>();
        
        //Mermi sürati ve yok olma sürelerini karakterden çeker.
        bulletSpeed = bulletScript.bulletSpeed;
        destroyTime = bulletScript.destroyTime;
    }
    void Update()
    {
        //Zamanın akışı
        time += Time.deltaTime;

        //Merminin süratine göre hareketi
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime,Space.Self);

        //Belirtilen zaman geçtiğinde kurşunu yok eder.
        if (time>destroyTime)
        {
            Destroy(gameObject);
        }
    }
}
