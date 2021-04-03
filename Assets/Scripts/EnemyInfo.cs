using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Xml.Serialization;

[Serializable()]
public class EnemyInfo
{
    [System.Xml.Serialization.XmlElementAttribute("EnemyId")]
    public int enemyId { get; set; }
    [System.Xml.Serialization.XmlElementAttribute("Name")]
    public string name { get; set; }
    [System.Xml.Serialization.XmlElementAttribute("Health")]
    public float health { get; set; }
    [System.Xml.Serialization.XmlElementAttribute("XP")]
    public float xp { get; set; }
}

[Serializable()]
[System.Xml.Serialization.XmlRoot("EnemyInfo")]
public class Enemies
{
    [XmlArray("enemies")]
    [XmlArrayItem("enemy", typeof(EnemyInfo))]
    public List<EnemyInfo> enemy { get; set; }

}