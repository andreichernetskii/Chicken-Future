using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    //Merminin gücü
    public float hitPoint;
    //Merminin yok olma süresi.
    public float destroyTime=3;

    //Geçen zaman
    float time = 0;

    //elinde tuttuğu silahın ID numarası.
    public int currentGun = 0;

    //GameController bağlantısı
    GameController gameController;

    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        takeGun(currentGun);
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
        GameObject bullet = Instantiate(bulletObject,transform.position + GetComponent<CapsuleCollider>().bounds.extents.y * Vector3.up,transform.rotation);
        bullet.GetComponent<BulletScript>()._bulletSpeed = bulletSpeed;
        bullet.GetComponent<BulletScript>()._hitPoint = hitPoint;
        bullet.tag = transform.tag+"Bullet";
    }

    void takeGun(int id)
    {
        //Silahı aramak için foreach
        //Kısacası Id'si girilmiş silahı bulup çıkartır ve bunu silah özelliklerine ekler.
        foreach (BulletInfo item in gameController.gunList.gun)
        {
            if (id == item.gunId)
            {
                fireRate = item.fireRate;
                bulletSpeed = item.bulletSpeed;
                hitPoint = item.hitPoint;

                Debug.Log($"Current gun name:{item.name} , id:{item.gunId} , firerate:{item.fireRate} , bulletspeed:{item.bulletSpeed}");
                break;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        //Eğer silaha dokunursa o silahı otomatik olarak alır.
        if (other.transform.tag == "Gun")
        {
            //Silahın özellikleri eklenir
            takeGun(int.Parse(other.transform.name));
            //Silah yok edilir.
            Destroy(other.gameObject);
        }
    }
}