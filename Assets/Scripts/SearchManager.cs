using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SearchManager : MonoBehaviour
{

    public GameObject contentHolder;

    public GameObject[] elements;

    public GameObject searchBar;

    public int totalElements;

    public GameObject userBarPrefab;
    public Button SearchButton;


    private void Start()
    {
    }

    public void CreateListOfAllUsers(List<UserData> Users)
    {
        totalElements = Users.Count;
        elements = new GameObject[totalElements];

        for (int i = 0;i < Users.Count;i++) 
        {
            GameObject InstantiatedUser =  Instantiate(userBarPrefab,contentHolder.transform);
            Debug.Log(InstantiatedUser, InstantiatedUser);
            InstantiatedUser.GetComponent<TextMeshProUGUI>().text = Users[i].isim;  
        }
        for (int i = 0; i < totalElements; i++) 
        {
            elements[i] = contentHolder.transform.GetChild(i).gameObject;
        }   

    }



    public void Search()
    {

        string searchText = searchBar.GetComponent<TMP_InputField>().text;


        foreach (GameObject element in elements)    
        { 
            if (element.transform.GetComponent<TextMeshProUGUI>().text.Length >= searchText.Length)
            {
                if (searchText.ToLower() == element.transform.GetComponent<TextMeshProUGUI>().text.Substring(0,searchText.Length).ToLower())
                {
                    element.SetActive(true);

                }
                else
                {
                    element.SetActive(false);
                }
            }
        
        }



    }

}
