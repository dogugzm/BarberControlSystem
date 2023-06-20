using PlayFab;
using PlayFab.ClientModels;
using System;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.PackageManager;

public class DataManager : MonoBehaviour
{

    string _json;
    public List<UserData> allUsersFromDB = new List<UserData>();
    public SearchManager searchManager;

    private void Start()
    {
        LoadData();
    }

    public void LoadData()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnDataRecieved, OnError);
    }

    private void OnError(PlayFabError obj)
    {
        Debug.Log("Room data getting error");
    }

    private void OnDataRecieved(GetUserDataResult obj)
    {
        Debug.Log("data reciveded");

        if (obj.Data != null && obj.Data.ContainsKey("User List"))
        {
            allUsersFromDB = JsonConvert.DeserializeObject<List<UserData>>(obj.Data["User List"].Value);
            //TODO call only if object active.
            UserManager.Instance.allUsers = allUsersFromDB;
            searchManager.CreateListOfAllUsers(allUsersFromDB);
        }

    }

    public void SaveUserData()
    {     
        UserManager.Instance.allUsers.Add(UserManager.Instance.GetActiveUserData());      
       _json = JsonConvert.SerializeObject(UserManager.Instance.allUsers);
        SaveAppearance();
    }

    public void UpdateUserData()
    {
        //UserManager.Instance.allUsers.Add(UserManager.Instance.GetActiveUserData());
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
