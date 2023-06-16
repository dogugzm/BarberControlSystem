using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserManager : MonoBehaviour
{

    public GameObject GeneralPanel;
    public GameObject UserSearchPanel;
    public GameObject UserCreatePanel;

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
