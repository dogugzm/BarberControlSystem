using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserData
{
    public string isim;
    public string gsm;
    public string tarih;
    public List<bool[]> seansAralar� = new List<bool[]>(6);
    public bool[] t�bbiOzgecmis = new bool[5];
    public List<string[]> seanslar = new List<string[]>(6);

}
