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
    public TMP_InputField referans;

    public List<SeansArasý> seansAralarý = new List<SeansArasý>(6);
    public Toggle[] týbbiOzgecmis = new Toggle[5];
    public List<Seans> seanslar = new List<Seans>(7);

    [SerializeField] TextMeshProUGUI totalMoneyText;
    int totalMoney;



    public void UpdateList()
    {
        int userIndex = UserManager.Instance.allUsers.IndexOf(userData);

        UserManager.Instance.UserInfoPanel.GetComponent<UserInfo>().UpdateInfo(UserManager.Instance.allUsers[userIndex]);

    }

    public void SetActiveUserData(UserData newUser)
    {
        userData = newUser;
        totalMoney = 0;
        totalMoneyText.text = "";
        //setting the data
        isim.text = newUser.isim;
        gsm.text = newUser.gsm;
        tarih.text = newUser.tarih;
        referans.text = newUser.referans;


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
            for (int j = 0; j < 7; j++)
            {
                seanslar[i].textArray[j].text = newUser.seanslar[i][j];
                if (j==6)
                {
                    int newMoneyToAdd;
                    int.TryParse(seanslar[i].textArray[j].text, out newMoneyToAdd);
                    Debug.Log(newMoneyToAdd);
                    totalMoney += newMoneyToAdd;
                }
            }
        }

        totalMoneyText.text = "Toplam Ücret : " + totalMoney;

        


    }


    public void UpdateInfo(UserData newUser)
    {
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

    }




}
