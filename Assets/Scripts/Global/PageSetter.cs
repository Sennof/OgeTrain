using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageSetter : MonoBehaviour
{

    [SerializeField] private List<GameObject> _pages;

    private GameObject _currentPage;

    private void Awake()
    {
        _currentPage = _pages[0];
    }

    public void ToPage(int index) 
    {
        for (int i = 0; i < _pages.Count; i++)
        {
            if (i == index)
            {
                _pages[i].SetActive(true);
                _currentPage.SetActive(false);
                _currentPage = _pages[i];
            }
        }
    }
}
