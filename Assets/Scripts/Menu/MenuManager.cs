using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _infoPage;

    [SerializeField] private Image _soundButton;

    [SerializeField] private List<Sprite> _soundSprites = new();
    [SerializeField] private List<AudioSource> _soundSources = new();

    private bool isSoundActive = true;
    private bool isInfoPageOpened = false;

    public void ChangeSoundState()
    {
        if (isSoundActive)
        {
            isSoundActive = false;
            _soundButton.sprite = _soundSprites[0];
            foreach(AudioSource source in _soundSources)
            {
                source.enabled = false;
            }
        }
        else
        {
            isSoundActive = true;
            _soundButton.sprite = _soundSprites[1];
            foreach(AudioSource source in _soundSources)
            {
                source.enabled = true;
            }
        }
    }

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
