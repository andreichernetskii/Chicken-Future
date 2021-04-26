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
    public bool isShooting = false;

    //object of the bullet (model etc.)
    public GameObject bulletObject;

    //fire rate in seconds.
    public float fireRate=.25f;
    //speetof the bullet
    public float bulletSpeed=50;
    //power of the bullet
    public float hitPoint=5;
    //destroy time of bullet.
    public float destroyTime=3;

    //time in secs
    float time = 0;

    //ID number of the current weapon.
    public int currentGun = 2;

    //GameController class created
    GameController gameController;

    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        takeGun(currentGun);
    }

    void Update()
    {
        //time in secs
        time += Time.deltaTime;
        
        //shot with fire rate.
        if(isShooting && time > fireRate)
        {
            //fire method starts.
            fire();
            
            time = 0;
        }
    }

    //button control methods for touchscreen (look at the ui system).
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
        //creates bullet.
        GameObject bullet = Instantiate(bulletObject,transform.position + GetComponent<CapsuleCollider>().bounds.extents.y * Vector3.up,transform.rotation);
        bullet.GetComponent<BulletScript>()._bulletSpeed = bulletSpeed;
        bullet.GetComponent<BulletScript>()._hitPoint = hitPoint;
        bullet.tag = transform.tag+"Bullet";
    }

    void takeGun(int id)
    {
        //searching gun in xml
        //pulling the gun via gunID.
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Gun")
        {
            //adds gun info
            takeGun(int.Parse(collision.transform.name));
            //destroys the gun (dropped gun).
            Destroy(collision.gameObject);
        }
    }
}