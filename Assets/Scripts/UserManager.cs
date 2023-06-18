using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Seans
{
    public TextMeshProUGUI[] textArray = new TextMeshProUGUI[6];
}

public class UserManager : MonoBehaviour
{

    public List<UserData> allUsers = new List<UserData>();

    public GameObject GeneralPanel;
    public GameObject UserSearchPanel;
    public GameObject UserCreatePanel;

    public TMP_InputField isim;
    public TMP_InputField gsm;
    public TMP_InputField tarih;
    public Toggle[] seansArasý = new Toggle[8];
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

        newUser.isim = isim.text;
        newUser.gsm = gsm.text;
        newUser.tarih = tarih.text;

        //for (int i = 0; i < seansArasý.Length; i++)
        //{
        //    newUser.seansArasý[i] = seansArasý[i].isOn;
        //}

        //for (int i = 0; i < týbbiOzgecmis.Length; i++)
        //{
        //    newUser.týbbiOzgecmis[i] = týbbiOzgecmis[i].isOn;
        //}
        //for (int i = 0; i < seanslar.Count; i++)
        //{
        //    newUser.seanslar[i][i] = seanslar[i].textArray[i].text;
        //}

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
