using PlayFab;
using PlayFab.ClientModels;
using System;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{

    string _json;
    //List<UserData> allUsers = new List<UserData>();

    public void SaveUserData()
    {

        Debug.Log(UserManager.Instance.GetActiveUserData().isim);
        UserManager.Instance.allUsers.Add(UserManager.Instance.GetActiveUserData());
        
       _json = JsonConvert.SerializeObject(UserManager.Instance.allUsers);

        SaveAppearance();
    }

    public void SaveAppearance()
    {
        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                {"User List", _json},
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnDataSend, OnErrorSaving);
    }

    private void OnErrorSaving(PlayFabError obj)
    {
        Debug.Log(" data doesnt send");
    }

    private void OnDataSend(UpdateUserDataResult obj)
    {
        Debug.Log("succesfuly data send");
    }

   

   



}
