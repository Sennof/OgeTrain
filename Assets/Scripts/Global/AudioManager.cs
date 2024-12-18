using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] private List<Sprite> _soundSprites = new();
    [SerializeField] private List<AudioSource> _soundSources = new();
    [SerializeField] private List<AudioClip> _sounds = new();

    [SerializeField] private Image _soundButton;
    
    private bool isSoundActive = true;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }

    public void ChangeSoundState()
    {
        if (isSoundActive)
        {
            isSoundActive = false;
            _soundButton.sprite = _soundSprites[0];
            foreach (AudioSource source in _soundSources)
            {
                source.enabled = false;
            }
        }
        else
        {
            isSoundActive = true;
            _soundButton.sprite = _soundSprites[1];
            foreach (AudioSource source in _soundSources)
            {
                source.enabled = true;
            }
        }
    }

    public void PlayYes()
    {
        if (isSoundActive)
        {
            _soundSources[1].clip = _sounds[1];
            _soundSources[1].Play();
        }
    }
       
    public void PlayNo()
    {
        if (isSoundActive)
        {
            _soundSources[1].clip = _sounds[2];
            _soundSources[1].Play();
        }
    }
}
