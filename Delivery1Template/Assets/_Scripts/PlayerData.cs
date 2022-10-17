
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
    public string name, country;
    public DateTime data;

    // Sessions
    public DateTime dataSession;
    public DateTime dataSessionEnd;
    public uint id;
    public uint idSession;

    // Purchases
    public int idItem;
    public int idPurchase;
    public DateTime datePurchase;

    public override string GetData()
    {
        return "test";
    }
}
