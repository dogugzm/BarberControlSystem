using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Seans
{
    public TMP_InputField[] textArray = new TMP_InputField[6];
}

[System.Serializable]
public class SeansArasý
{
    public Toggle[] toggleArray = new Toggle[6];
}

public class UserManager : MonoBehaviour
{
    public List<UserData> allUsers = new List<UserData>();

    public GameObject GeneralPanel;
    public GameObject UserSearchPanel;
    public GameObject UserCreatePanel;
    public GameObject UserInfoPanel;


    public TMP_InputField isim;
    public TMP_InputField gsm;
    public TMP_InputField tarih;
    public TMP_InputField referans;

    public List<SeansArasý> seansAralarý = new List<SeansArasý>(6);
    public Toggle[] týbbiOzgecmis = new Toggle[5];
    public List<Seans> seanslar = new List<Seans>(6);

    public static UserManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public UserData GetActiveUserData()
    {
        UserData newUser = new();

        //initial empty datas for range error
        for (int i = 0; i < seansAralarý.Count; i++)
        {
            newUser.seansAralarý.Add(new bool[8]);
        }

        //initial empty datas for range error
        for (int i = 0; i < seanslar.Count; i++)
        {
            newUser.seanslar.Add(new string[7]);
        }

        //setting the data
        newUser.isim = isim.text;
        newUser.gsm = gsm.text;
        newUser.tarih = tarih.text;
        newUser.referans = referans.text;

        for (int i = 0; i < seansAralarý.Count; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                newUser.seansAralarý[i][j] = seansAralarý[i].toggleArray[j].isOn;
            }
        }

        for (int i = 0; i < týbbiOzgecmis.Length; i++)
        {
            newUser.týbbiOzgecmis[i] = týbbiOzgecmis[i].isOn;
        }

        for (int i = 0; i < seanslar.Count; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                newUser.seanslar[i][j] = seanslar[i].textArray[j].text;
            }
        }

        return newUser;
    }

    

    public void DeactivateAll()
    {
        GeneralPanel.SetActive(false);
        UserCreatePanel.SetActive(false);
        UserSearchPanel.SetActive(false);
    }

    public void ActivateMain()
    {
        DeactivateAll();
        GeneralPanel.SetActive(true);
    }




}
