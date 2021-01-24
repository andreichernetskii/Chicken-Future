using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletInfo
{
    private int gunId;
    private string name;
    private float fireRate;
    private float bulletSpeed;

    public string Name
    {
        get{return name;}
    }

    public float FireRate
    {
        get{return fireRate;}
    }

    public float BulletSpeed
    {
        get{return bulletSpeed;}
    }

    public int GunId
    {
        set
        {
            //bu kısımda silah verileri çekilecek.
            if (value == 5)
            {
                name = "merhaba";
                fireRate = 32.32f;
                bulletSpeed = 45.542f;
            }
        }
    }


}
