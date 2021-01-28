using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

[Serializable()]
public class BulletInfo
{
    public int gunId { get; set; }
    [System.Xml.Serialization.XmlElementAttribute("Name")]
    public string name { get; set; }
    [System.Xml.Serialization.XmlElementAttribute("FireRate")]
    public float fireRate { get; set; }
    [System.Xml.Serialization.XmlElementAttribute("BulletSpeed")]
    public float bulletSpeed { get; set; }

}

[Serializable()]
[System.Xml.Serialization.XmlRoot("BulletInfo")]
public class Guns
{
    [XmlArray("guns")]
    [XmlArrayItem("gun", typeof(BulletInfo))]
    public BulletInfo[] gun { get; set; }

    void dene()
    {
    }
}