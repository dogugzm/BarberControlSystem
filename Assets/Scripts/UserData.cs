using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserData
{
    public string isim;
    public string gsm;
    public string tarih;
    public string referans;
    public List<bool[]> seansAralar� = new List<bool[]>();
    public bool[] t�bbiOzgecmis = new bool[5];
    public List<string[]> seanslar = new List<string[]>();

}
