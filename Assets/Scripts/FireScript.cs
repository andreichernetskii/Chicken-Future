using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
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

    Guns guns = new Guns();

    void Start()
    {

        Debug.Log("Silah bilgileri çekiliyor");
        
        string path = "Assets/Scripts/gunList.xml";

        XmlSerializer serializer = new XmlSerializer(typeof(Guns));

        StreamReader reader = new StreamReader(path);
        guns = ((Guns)serializer.Deserialize(reader));
        reader.Close();
        Debug.Log("Silah özellikleri isim:" + guns.gun[0].name + " fireRate:" + guns.gun[0].fireRate + "bulletSpeed" + guns.gun[0].bulletSpeed);
        Debug.Log("Silah özellikleri isim:" + guns.gun[1].name + " fireRate:" + guns.gun[1].fireRate + "bulletSpeed" + guns.gun[1].bulletSpeed);
        Debug.Log("Silah özellikleri isim:" + guns.gun[2].name + " fireRate:" + guns.gun[2].fireRate + "bulletSpeed" + guns.gun[2].bulletSpeed);

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
        Debug.Log("çalıştı");
        XmlDocument doc = new XmlDocument();
        doc.Load("gunList.xml");

        //Get the first element with an attribute of type ID and value of A111.
        //This displays the node <Person SSN="A111" Name="Fred"/>.
        XmlElement elem = doc.GetElementById("1");
        Debug.Log(elem.OuterXml);

        //Get the first element with an attribute of type ID and value of A222.
        //This displays the node <Person SSN="A222" Name="Tom"/>.
        elem = doc.GetElementById("2");
        Debug.Log(elem.OuterXml);
    }
}