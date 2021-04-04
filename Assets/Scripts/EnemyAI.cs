using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent navMesh;

    float time;
    public float updatePerSecond = 1;

    GameController gameController;
    
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();

        //Yapay zekanın başlangıç hedef ayarları
        navMesh = GetComponent<NavMeshAgent>();
        navMesh.destination = GameObject.FindGameObjectWithTag("Player").transform.position;
        navMesh.updateRotation = true;
        navMesh.speed = 1f;
        navMesh.Move(Vector3.forward);
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time > updatePerSecond)
        {
            navMesh.destination = GameObject.FindGameObjectWithTag("Player").transform.position;
            time = 0;
        }
    }


    void DropGun(int gunId)
    {
        //silahı yerde alınmak üzere hazır bırakır.
        GameObject gunDrop = Instantiate(gameController.GunPrefab);

        gunDrop.transform.position = gameObject.transform.position;

        //Burası düzeltilecek. Düşen silahın modeli
        //gunDrop.GetComponent<MeshFilter>().mesh = ;
        gunDrop.name = gunId.ToString();
        gunDrop.tag = "Gun";
    }

    public void Dead()
    {
        DropGun(0);
        Destroy(gameObject);
    }

}
