using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Server : MonoBehaviour
{

    // Player Data
    PlayerData player;

    private string urlUser = "https://citmalumnes.upc.es/~ismaeltc1/PHPConect.php";
    private string urlSessions = "https://citmalumnes.upc.es/~ismaeltc1/PHPSessions.php";
    private bool canSave = false;
    private bool canSaveSession = false;
    WWW web;

    IEnumerator UpdateInfo()
    {
        WWWForm form = new WWWForm();

        form.AddField("Name", player.name);
        form.AddField("Country", player.country);
        form.AddField("Date", DateTime.Now.ToString("yyyy-MM-dd"));
      
        web = new WWW(urlUser,form);
        yield return web;

        if (web.error != null)
        {
            Debug.Log("Failed" + web.error);
        }
        else
        {
            Debug.Log("Success!");
            string idUser = web.text;
            Debug.Log(idUser);
            player.id = uint.Parse(idUser);
            CallbackEvents.OnAddPlayerCallback?.Invoke(player.id);
        }
        web.Dispose();
        Debug.Log("Courutineee");
    }

    IEnumerator UpdateSessions(uint userID)
    {

        WWWForm form = new WWWForm();

        form.AddField("StartSession", DateTime.Now.ToString("yyyy-MM-dd"));
        form.AddField("IdUser", userID.ToString());

        web = new WWW(urlSessions, form);
        yield return web;

        if (web.error != null)
        {
            Debug.Log("Failed" + web.error);
        }
        else
        {
            Debug.Log("Success!");
            string idSession = web.text;
            Debug.Log(idSession);
        }
        web.Dispose();
    }
    private void Update()
    {
        if (canSave)
        {
            StartCoroutine(UpdateInfo());
            canSave = false;
            Debug.Log("canSave False");
        }
        if (canSaveSession)
        {
            StartCoroutine(UpdateSessions(player.id));
            canSaveSession = false;
        }
    }

    public void Save(PlayerData data)
    {
        player = data;
        canSave = true;
    }
    public void SaveSessions()
    {
        canSaveSession = true;
    }
}
