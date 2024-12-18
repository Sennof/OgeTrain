using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _infoPage;

    private bool isInfoPageOpened = false;

    public void ToggleInfoPage()
    {
        if (isInfoPageOpened)
        {
            isInfoPageOpened = false;
            _infoPage.SetActive(false);
        }
        else
        {
            isInfoPageOpened = true;
            _infoPage.SetActive(true); 
        }
    }
}
