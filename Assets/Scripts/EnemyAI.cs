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

    //gamecontroller class has created
    GameController gameController;

    //Is it shooting?
    bool isShooting = false;

    //object of bullet (model vs.)
    public GameObject bulletObject;

    //second between the shots.
    float fireRate = .25f;
    //speed of bullet
    float bulletSpeed = 50;
    //power of the bullet
    float hitPoint = 5;
    //destroy time of bullet.
    float destroyTime = 3;


    //starting gun id.
    public int startGun = 2;

    void Start()
    {
        //gamecontroller class pulled from the scene
        gameController = GameObject.Find("GameController").GetComponent<GameController>();

        //pull the gun info from xml.
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

        //start point of artificial intelligence character
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
        //drops gun to take.
        GameObject gunDrop = Instantiate(gameController.GunPrefab);

        //drop the gun to the dead char position.
        gunDrop.transform.position = gameObject.transform.position;

        //gonna be fix
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
                //setting of bullet(when gun fire).
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
