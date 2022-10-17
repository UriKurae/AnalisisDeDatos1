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
    private string urlPurchases = "https://citmalumnes.upc.es/~ismaeltc1/PHPPurchases.php";
    private bool canSave, canSaveSession, canSavePurchases, canSaveSessionEnd = false;
    WWW web;

    IEnumerator UpdateInfo()
    {
        WWWForm form = new WWWForm();

        form.AddField("Name", player.name);
        form.AddField("Country", player.country);
        form.AddField("Date", player.data.ToString("yyyy-MM-dd"));
      
        web = new WWW(urlUser,form);
        yield return web;

        if (web.error != null)
        {
            Debug.Log("Failed" + web.error);
        }
        else
        {
            string idUser = web.text;
            Debug.Log("userID: " + idUser);
            player.id = uint.Parse(idUser);
            CallbackEvents.OnAddPlayerCallback?.Invoke(player.id);
        }
        web.Dispose();
    }

    IEnumerator UpdateSessions(uint userID)
    {

        WWWForm form = new WWWForm();

        form.AddField("StartSession", player.dataSession.ToString("yyyy-MM-dd"));
        form.AddField("IdUser", userID.ToString());

        web = new WWW(urlSessions, form);
        yield return web;

        if (web.error != null)
        {
            Debug.Log("Failed" + web.error);
        }
        else
        {
            string idSession = web.text;
            Debug.Log("sessionID: " + idSession);
            player.idSession = uint.Parse(idSession);
            CallbackEvents.OnNewSessionCallback?.Invoke(player.idSession);
        }
        web.Dispose();
    }
    IEnumerator UpdatePurchases(uint sessionId)
    {

        WWWForm form = new WWWForm();

        form.AddField("IdSession", sessionId.ToString());
        form.AddField("IdItem", player.idItem.ToString());
        form.AddField("Date", player.datePurchase.ToString("yyyy-MM-dd"));

        web = new WWW(urlPurchases, form);
        yield return web;

        if (web.error != null)
        {
            Debug.Log("Failed" + web.error);
        }
        else
        {
            string idPurchase = web.text;
            Debug.Log("purchaseID: " + idPurchase);
            player.idPurchase = int.Parse(idPurchase);
            CallbackEvents.OnItemBuyCallback?.Invoke();
        }
        web.Dispose();
    }
    IEnumerator UpdateSessionsEnd(uint sessionID)
    {

        WWWForm form = new WWWForm();

        form.AddField("EndSession", player.dataSessionEnd.ToString("yyyy-MM-dd"));
        form.AddField("IdSession", sessionID.ToString());

        web = new WWW(urlSessions, form);
        yield return web;

        if (web.error != null)
        {
            Debug.Log("Failed" + web.error);
        }
        else
        {
            string idSession = web.text;
            Debug.Log("endSessionID: " + idSession);
            player.idSession = uint.Parse(idSession);
            CallbackEvents.OnEndSessionCallback?.Invoke(player.idSession);
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
        if (canSaveSession)
        {
            StartCoroutine(UpdateSessions(player.id));
            canSaveSession = false;
        }
        if (canSavePurchases)
        {
            StartCoroutine(UpdatePurchases(player.idSession));
            canSavePurchases = false;
        }
        if (canSaveSessionEnd)
        {
            StartCoroutine(UpdateSessionsEnd(player.idSession));
            canSaveSessionEnd = false;
        }
    }

    public void Save(PlayerData data)
    {
        player = data;
        canSave = true;
    }
    public void SaveSessions(DateTime obj)
    {
        player.dataSession = obj;
        canSaveSession = true;
    }
    public void SaveSessionsEnd(DateTime obj)
    {
        player.dataSessionEnd = obj;
        canSaveSession = true;
    }
    public void SavePurchase(int idItem, DateTime date)
    {
        player.idItem = idItem;
        player.datePurchase = date;
        canSavePurchases = true;
    }
}
