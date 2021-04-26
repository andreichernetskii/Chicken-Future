using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class GameController : MonoBehaviour
{

    //List of gun class.
    public Guns gunList;

    //list of the enemies class.
    public Enemies enemyList = new Enemies();

    //standard model of character
    public GameObject EnemyPreafab;
    public Mesh enemyMesh;

    //standard model of the gun
    public GameObject GunPrefab;
    public Mesh gunMesh;

    //it is going to control the gamecontroller.
    public bool isReady = false;

    [HideInInspector]
    //count of the enemies in the map
    public int enemyCount = 0;

    EnemyScript enemyScript;
    void Awake()
    {
        //pulling data from xml's
        gunList = GunDataHook();
        enemyList = EnemyDataHook();

        isReady = true;
    }

    void Start()
    {
        enemyScript = GetComponent<EnemyScript>();

        //test
        GetComponent<EnemyScript>().EnemyCreate(2,EnemyPreafab,enemyList,new Vector3(-2,0.7f,2),enemyMesh);
        GetComponent<EnemyScript>().EnemyCreate(2, EnemyPreafab, enemyList, new Vector3(2, 0.7f, 2), enemyMesh);
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
            //xml file path to string
            string path = "Assets/Scripts/gunList.xml";

            //Guns serialization
            XmlSerializer serializer = new XmlSerializer(typeof(Guns));

            //xml data.
            StreamReader reader = new StreamReader(path);
            //Deserialize.
            Guns gunDeserialize = ((Guns)serializer.Deserialize(reader));
            //xml reader closed.
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
        //same things like GunDataHook method
        Debug.Log("Karakter bilgileri çekiliyor");

        try
        {
           
            string path = "Assets/Scripts/enemyList.xml";

           
            XmlSerializer serializer = new XmlSerializer(typeof(Enemies));

           
            System.IO.StreamReader reader = new StreamReader(path);
           
            Enemies enemyDeserialize = ((Enemies)serializer.Deserialize(reader));
           
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
