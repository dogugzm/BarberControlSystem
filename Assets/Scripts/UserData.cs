using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserData
{
    public string isim;
    public string gsm;
    public string tarih;
    public bool[] seansArasý = new bool[8];
    public bool[] týbbiOzgecmis = new bool[5];
    public string[] seans = new string[6];
    public List<string[]> seanslar = new List<string[]>(6);

}
