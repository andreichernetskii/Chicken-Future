using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharInfo
{
    private int id;
    private int type;
    private string name;
    private float health;
    private int exp;
    
    public int Id
    {
        set
        {
            if (value == 3)
            {
                type = 1;
                name = "player";
                health = 500.4f;
                exp = 5000;
            }
        }
    }
}
