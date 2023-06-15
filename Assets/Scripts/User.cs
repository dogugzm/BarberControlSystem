using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class User : MonoBehaviour
{        
    public string name;
    public string gsm;
    public bool isSick;

    public TextMeshProUGUI nameText;

    private void Start()
    {
        SetInfo();
    }

    void SetInfo()
    {
        nameText.text = name;
    }





}
