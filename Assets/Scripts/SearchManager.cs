using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SearchManager : MonoBehaviour
{

    public Transform contentHolder;

    public GameObject[] elements;

    public GameObject searchBar;

    public int totalElements;

    public GameObject userBarPrefab;

    float timer = 3;
    public bool canClick = true;

    [SerializeField] DataManager dataManager;
    
    private void Start()
    {
        //CreateListOfAllUsers(dataManager.allUsersFromDB);
    }

    private void Update()
    {
        if (timer>0)
        {
            timer -= Time.deltaTime;
            if (timer<=0)
            {
                canClick = true;
            }
        }
    }

    public void Reload()
    {
        if (canClick)
        {
            canClick = false;
            timer = 3;
            foreach (Transform element in contentHolder) 
            { 
                Destroy(element.gameObject);
            }
            dataManager.LoadData();
        }

    }

    public void CreateListOfAllUsers(List<UserData> Users)
    {
        totalElements = Users.Count;
        elements = new GameObject[totalElements];

        for (int i = 0;i < Users.Count;i++) 
        {
            GameObject InstantiatedUser =  Instantiate(userBarPrefab,contentHolder.transform);
            InstantiatedUser.GetComponent<UserCard>().SetInfo(Users[i]);
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
