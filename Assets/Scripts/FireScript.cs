using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FireScript : MonoBehaviour
{
    //Ateş ediyor mu kontrolü
    public bool isShooting = false;

    //Merminin objesi (model vs.)
    public GameObject bulletObject;

    //İki atış arası geçen süre.
    public float fireRate=.25f;
    //Merminin sürati
    public float bulletSpeed=50;
    //Merminin yok olma süresi.
    public float destroyTime=5;

    //Geçen zaman
    float time = 0;

    void Start()
    {
    }

    void Update()
    {
        //Zaman akışı
        time += Time.deltaTime;
        
        //eğer atış aktifse, belli zaman aralıkları dahilinde ateş etsin.
        if(isShooting && time > fireRate)
        {
            //Ateş etme işleminin gerçekleştiği metod.
            fire();
            //Her ateş etmede geçen zaman sıfırlanır.
            time = 0;
        }
    }

    //Buton kontrolü için gerekli methodlar. Butona basılınca atışık aktif veya deaktif etme.
    public void FireOn()
    {
        isShooting = true;
    }
    public void FireOff()
    {
        isShooting = false;

    }

    void fire()
    {
        //Belirlenen konumda kurşunu oluşturur.
        Instantiate(bulletObject,transform.position + GetComponent<CapsuleCollider>().bounds.extents.y * Vector3.up,transform.rotation);
    }
}

public class HitInfo : MonoBehaviour
{
    private void Start()
    {

        BulletInfo bullet = new BulletInfo();

        bullet.GunId = 5;

        Debug.Log(bullet.Name + bullet.FireRate);
    }
}