
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EventData
{

   public virtual string GetData()
    {
        return "Hola";
    }
}
public class PlayerData : EventData
{

    // Data from the player
    public uint id;
    public string name, country;
    public DateTime data;

    public override string GetData()
    {
        return "test";
    }
}
