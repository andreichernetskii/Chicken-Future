using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public void EnemyCreate(int enemyId,GameObject prefab, Enemies enemies, Vector3 enemyPosition,Mesh enemyMesh)
    {

        GameController gameController = GetComponent<GameController>();

        int charId = 0;
        string charName = "deneme";
        float charHealth = 100;
        float charXp = 10;

        //Bu foreach, karakterin sayısal özelliklerini enemyId'den bulur ve saklar.
        foreach (EnemyInfo item in enemies.enemy)
        {
            if (enemyId == item.enemyId)
            {
                charName = item.name;
                charHealth = item.health;
                charXp = item.xp;
                charId = item.enemyId;

                break;
            }
        }

        //Sahnede yeni bir karakter olurşturur.
        GameObject enemyNew = Instantiate(prefab);

        //Oluşturulan yeni karakterin sayısal özelliklerini ekler.
        enemyNew.GetComponent<CharStatistics>().health = charHealth;
        enemyNew.GetComponent<CharStatistics>().exp = charXp;
        enemyNew.GetComponent<CharStatistics>().charName = charName;

        //Oluşturulan yeni karakterin başlangıç pozisyonu ayarlanır.
        enemyNew.transform.position = enemyPosition;
        //Oluşturulan karakterin modeli seçilir.
        enemyNew.GetComponent<MeshFilter>().mesh = enemyMesh;

        //sahnedeki düşman sayısını tutar
        gameController.enemyCount++;
    }

}
