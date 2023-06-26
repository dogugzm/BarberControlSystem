using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class CustomDebug : MonoBehaviour
{
    public static CustomDebug Instance;

    public Image SuccesfulBox;
    public Image WrongBox;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }


    public IEnumerator  SuccesfulText(string text)
    {
        SuccesfulBox.gameObject.SetActive(true);
        SuccesfulBox.GetComponentInChildren<TextMeshProUGUI>().text = text; 
        SuccesfulBox.DOFade(1, 1f);
        yield return new WaitForSeconds(1f);
        SuccesfulBox.DOFade(0, 1f);
        SuccesfulBox.gameObject.SetActive(false);

    }

    public IEnumerator WrongText(string text)
    {
        WrongBox.gameObject.SetActive(true);

        WrongBox.GetComponentInChildren<TextMeshProUGUI>().text = text;
        WrongBox.DOFade(1, 1);
        yield return new WaitForSeconds(1);
        WrongBox.DOFade(0, 1);
        WrongBox.gameObject.SetActive(false);

    }



}
