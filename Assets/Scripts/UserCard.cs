using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UserCard : MonoBehaviour
{
    UserData userData;
    public TextMeshProUGUI nameText;
    Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        ClickedUser();
    }

    public void SetInfo(UserData data)
    {
        userData = data;
        nameText.text = data.isim;
    }

    void ClickedUser() 
    {       
        button.onClick.AddListener(ActivateUserInfo);   
    }

    void ActivateUserInfo()
    {
        UserManager.Instance.UserSearchPanel.SetActive(false);
        UserManager.Instance.UserInfoPanel.SetActive(true); 
        UserManager.Instance.UserInfoPanel.GetComponent<UserInfo>().SetActiveUserData(userData);
    }


 





}
