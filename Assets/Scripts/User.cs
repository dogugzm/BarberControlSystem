using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class User : MonoBehaviour
{
    public UserData UserData;

    public TextMeshProUGUI nameText;

    private void Start()
    {
        SetInfo();
    }

    void SetInfo()
    {
        nameText.text = UserData.isim;
    }





}
