using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    Enemies enemies = new Enemies();

    [Header("karakterin id numarası")]
    public int charId=0;
    string charName="deneme";
    float charHealth=100;
    float charXp=10;

    void Start()
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
            enemies = ((Enemies)serializer.Deserialize(reader));
            //xml okuyucu kapatıldı.
            reader.Close();
            
            EnemyChoose(charId);

        }
        catch
        {
            Debug.Log("Karakter verileri çekilirken hata oluştur. Oyun kapanıyor");
            Application.Quit();
        }

    }

    void EnemyStatisticsAdd()
    {
        GetComponent<CharStatistics>().health = 100;
    }


    void EnemyChoose(int id)
    {
        foreach (EnemyInfo item in enemies.enemy)
        {
            if (id == item.enemyId)
            {
                charName = item.name;
                charHealth = item.health;
                charXp = item.xp;

                Debug.Log($"Current char name:{item.name} , id:{item.enemyId} , health:{item.health} , bulletspeed:{item.xp}");
                break;
            }
        }

        GetComponent<CharStatistics>().health = charHealth;
        GetComponent<CharStatistics>().exp = charXp;
        GetComponent<CharStatistics>().charName = charName;
    }
}
