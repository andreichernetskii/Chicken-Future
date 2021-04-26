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

        //pulling the enemy info from xml
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

        //creates enemy in scene.
        GameObject enemyNew = Instantiate(prefab);

        //adding enemy info from xml.
        enemyNew.GetComponent<CharStatistics>().health = charHealth;
        enemyNew.GetComponent<CharStatistics>().exp = charXp;
        enemyNew.GetComponent<CharStatistics>().charName = charName;

        //start position of the enemy.
        enemyNew.transform.position = enemyPosition;
        //choosing the enemy model.
        enemyNew.GetComponent<MeshFilter>().mesh = enemyMesh;

        //it increase the number of enemy
        gameController.enemyCount++;
    }

}
