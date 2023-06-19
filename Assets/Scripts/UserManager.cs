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
public class SeansAras�
{
    public Toggle[] toggleArray = new Toggle[6];
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
    public List<SeansAras�> seansAralar� = new List<SeansAras�>(6);
    public Toggle[] t�bbiOzgecmis = new Toggle[5];
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
        for (int i = 0; i < seansAralar�.Count; i++)
        {
            newUser.seansAralar�.Add(new bool[8]);
        }

        //initial empty datas for range error
        for (int i = 0; i < seanslar.Count; i++)
        {
            newUser.seanslar.Add(new string[6]);
        }

        //setting the data
        newUser.isim = isim.text;
        newUser.gsm = gsm.text;
        newUser.tarih = tarih.text;

        for (int i = 0; i < seansAralar�.Count; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                newUser.seansAralar�[i][j] = seansAralar�[i].toggleArray[j].isOn;
            }
        }

        for (int i = 0; i < t�bbiOzgecmis.Length; i++)
        {
            newUser.t�bbiOzgecmis[i] = t�bbiOzgecmis[i].isOn;
        }

        for (int i = 0; i < seanslar.Count; i++)
        {
            for (int j = 0; j < 6; j++)
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
