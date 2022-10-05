using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Server : MonoBehaviour
{

    // Player Data
    PlayerData player;

    private string url = "https://citmalumnes.upc.es/~ismaeltc1/PHPConect.php";
    private bool canSave = false;
    WWW web;

    IEnumerator UpdateInfo()
    {
        WWWForm form = new WWWForm();

        form.AddField("Name", player.name);
        form.AddField("Country", player.country);
        form.AddField("Date", DateTime.Now.ToString("yyyy-MM-dd"));
      
        web = new WWW(url,form);
        yield return web;

        if (web.error != null)
        {
            Debug.Log("Failed" + web.error);
        }
        else
        {
            Debug.Log("Success!");
            string test = web.text;
            Debug.Log(test);
        }
        web.Dispose();
    }

    private void Update()
    {
        if (canSave)
        {
            StartCoroutine(UpdateInfo());
            canSave = false;
        }
    }

    public void Save(PlayerData data)
    {
        player = data;
        canSave = true;
    }
}
