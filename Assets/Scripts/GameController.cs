using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class GameController : MonoBehaviour
{

    //silah listesi verisi.
    public Guns gunList;

    //düşman verisi.
    public Enemies enemyList = new Enemies();

    //standart karakter modeli
    public GameObject EnemyPreafab;
    public Mesh enemyMesh;

    //standart silah modeli
    public GameObject GunPrefab;
    public Mesh gunMesh;

    //GameController sınıfının hazır olup olmadığını bildirir.
    public bool isReady = false;

    [HideInInspector]
    public int enemyCount = 0;

    EnemyScript enemyScript;
    void Awake()
    {
        gunList = GunDataHook();
        enemyList = EnemyDataHook();

        isReady = true;
    }

    void Start()
    {
        enemyScript = GetComponent<EnemyScript>();

        //test
        GetComponent<EnemyScript>().EnemyCreate(2,EnemyPreafab,enemyList,new Vector3(-2,0.7f,2),enemyMesh);
        //test
    }
    void Update()
    {
        
    }

    /// <summary>
    /// Bu method xml dosyasından silah verilerini çeker.
    /// </summary>
    Guns GunDataHook()
    {
        Debug.Log("Silah bilgileri çekiliyor");

        try
        {
            //xml dosyasının yolu stringe atandı.
            string path = "Assets/Scripts/gunList.xml";

            //Guns tipinde xmlSerializer oluşturuldu
            XmlSerializer serializer = new XmlSerializer(typeof(Guns));

            //Dosya yolundaki xml verisi reader'da saklandı.
            StreamReader reader = new StreamReader(path);
            //Deserialize edilerek guns isimli listeye tüm değerler atandı.
            Guns gunDeserialize = ((Guns)serializer.Deserialize(reader));
            //xml okuyucu kapatıldı.
            reader.Close();

            return gunDeserialize;

        }
        catch
        {
            Debug.Log("Silah verileri çekilirken hata oluştur. Oyun kapanıyor");
            Application.Quit();
            return null;
        }

    }

    /// <summary>
    /// Bu method xml dosyasından düşman verilerini çeker.
    /// </summary>
    Enemies EnemyDataHook()
    {
        Debug.Log("Karakter bilgileri çekiliyor");

        try
        {
            //xml dosyasının yolu stringe atandı.
            string path = "Assets/Scripts/enemyList.xml";

            //Guns tipinde xmlSerializer oluşturuldu
            XmlSerializer serializer = new XmlSerializer(typeof(Enemies));

            //Dosya yolundaki xml verisi reader'da saklandı.
            System.IO.StreamReader reader = new StreamReader(path);
            //Deserialize edilerek guns isimli listeye tüm değerler atandı.
            Enemies enemyDeserialize = ((Enemies)serializer.Deserialize(reader));
            //xml okuyucu kapatıldı.
            reader.Close();

            return enemyDeserialize;
        }
        catch
        {
            Debug.Log("Karakter verileri çekilirken hata oluştur. Oyun kapanıyor");
            Application.Quit();
            return null;
        }
    }
}
