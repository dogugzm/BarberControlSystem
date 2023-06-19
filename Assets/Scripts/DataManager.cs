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
    [SerializeField] SearchManager searchManager;

    private void Start()
    {
        LoadData();
    }

    private void LoadData()
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
            searchManager.SearchButton.onClick.AddListener(delegate { searchManager.CreateListOfAllUsers(allUsersFromDB); });

            Debug.Log(allUsersFromDB[0].isim);
        }

    }

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
