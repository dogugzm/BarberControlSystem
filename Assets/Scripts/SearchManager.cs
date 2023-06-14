using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SearchManager : MonoBehaviour
{

    public GameObject contentHolder;

    public GameObject[] elements;

    public GameObject searchBar;

    public int totalElements;




    private void Start()
    {
        totalElements = contentHolder.transform.childCount;

        elements = new GameObject[totalElements];

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
