using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent navMesh;

    public LayerMask playerLayerMask;

    float time;
    float gunTime;
    public float updatePerSecond = 2;

    //gamecontroller sınıfı çağırıldı
    GameController gameController;

    //Ateş ediyor mu kontrolü
    bool isShooting = false;

    //Merminin objesi (model vs.)
    public GameObject bulletObject;

    //İki atış arası geçen süre.
    float fireRate = .25f;
    //Merminin sürati
    float bulletSpeed = 50;
    //Merminin gücü
    float hitPoint = 5;
    //Merminin yok olma süresi.
    float destroyTime = 3;


    //elinde tuttuğu silahın ID numarası.
    public int startGun = 2;

    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();

        //silah verisini çekip tek seferlik silah veriliyor bota.
        foreach (BulletInfo item in gameController.gunList.gun)
        {
            if (startGun == item.gunId)
            {
                fireRate = item.fireRate;
                bulletSpeed = item.bulletSpeed;
                hitPoint = item.hitPoint;

                break;
            }
        }

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
        gunTime += Time.deltaTime;

        if (time > updatePerSecond)
        {
            navMesh.destination = GameObject.FindGameObjectWithTag("Player").transform.position;
            time = 0;
        }

        AimAndShoot(GameObject.FindGameObjectWithTag("Player").transform);
    }

    void DropGun(int gunRandomRange)
    {
        //silahı yerde alınmak üzere hazır bırakır.
        GameObject gunDrop = Instantiate(gameController.GunPrefab);

        gunDrop.transform.position = gameObject.transform.position;

        //Burası düzeltilecek. Düşen silahın modeli
        //gunDrop.GetComponent<MeshFilter>().mesh = ;
        gunDrop.name = (Random.Range(0,gunRandomRange)).ToString();
        gunDrop.tag = "Gun";
    }

    public void Dead()
    {
        DropGun(3);
        Destroy(gameObject);
    }


    public void AimAndShoot(Transform target)
    {
        RaycastHit hit;

        

        if (Physics.Raycast(transform.position, transform.forward, out hit, 10, playerLayerMask))
        {
            if (gunTime>fireRate)
            {
                //Belirlenen konumda kurşunu oluşturur.
                GameObject bullet = Instantiate(bulletObject, transform.position, transform.rotation);
                bullet.GetComponent<BulletScript>()._bulletSpeed = bulletSpeed;
                bullet.GetComponent<BulletScript>()._hitPoint = hitPoint;
                bullet.tag = transform.tag + "Bullet";

                gunTime = 0;
            }
            Debug.DrawRay(transform.position, transform.forward * 10, Color.green);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.forward * 10,Color.red);
        }

    }

}
