using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UserInfo : MonoBehaviour
{
    UserData userData;
    public TMP_InputField isim;
    public TMP_InputField gsm;
    public TMP_InputField tarih;
    public List<SeansArasý> seansAralarý = new List<SeansArasý>(6);
    public Toggle[] týbbiOzgecmis = new Toggle[5];
    public List<Seans> seanslar = new List<Seans>(6);


    public void UpdateList()
    {
        int userIndex = UserManager.Instance.allUsers.IndexOf(userData);

        UserManager.Instance.UserInfoPanel.GetComponent<UserInfo>().UpdateInfo(UserManager.Instance.allUsers[userIndex]);

    }

    public void SetActiveUserData(UserData newUser)
    {
        userData = newUser;    
        //setting the data
        isim.text = newUser.isim;
        gsm.text = newUser.gsm;
        tarih.text = newUser.tarih;

        for (int i = 0; i < seansAralarý.Count; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                seansAralarý[i].toggleArray[j].isOn = newUser.seansAralarý[i][j];
            }
        }

        for (int i = 0; i < týbbiOzgecmis.Length; i++)
        {
            týbbiOzgecmis[i].isOn = newUser.týbbiOzgecmis[i];
        }

        for (int i = 0; i < seanslar.Count; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                seanslar[i].textArray[j].text = newUser.seanslar[i][j];
            }
        }


    }


    public void UpdateInfo(UserData newUser)
    {
        newUser.isim = isim.text;
        newUser.gsm = gsm.text;
        newUser.tarih = tarih.text;

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
            for (int j = 0; j < 6; j++)
            {
                newUser.seanslar[i][j] = seanslar[i].textArray[j].text;
            }
        }

    }




}
