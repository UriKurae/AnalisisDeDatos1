using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnalyticsController : MonoBehaviour
{
    [SerializeField]
    private Server phpServer;

    private void OnEnable()
    {
        Simulator.OnNewPlayer += PlayerAdded;
        Simulator.OnNewSession += NewSessionAdded;
        Simulator.OnEndSession += EndSessionAdded;
        Simulator.OnBuyItem += ItemBought;
    }

    private void ItemBought(int arg1, DateTime arg2)
    {
        //throw new NotImplementedException();
    }

    private void EndSessionAdded(DateTime obj)
    {
        phpServer.SaveSessionsEnd(obj);
    }

    private void NewSessionAdded(DateTime obj)
    {
        phpServer.SaveSessions(obj);
    }

    private void PlayerAdded(string arg1, string arg2, DateTime arg3)
    {
        PlayerData newPlayerData = new PlayerData();

        newPlayerData.name = arg1;
        newPlayerData.country = arg2;
        newPlayerData.data = arg3;

        phpServer.Save(newPlayerData);

        Debug.Log("Player Added");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
