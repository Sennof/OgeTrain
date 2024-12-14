using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Image _soundButton;

    [SerializeField] private List<Sprite> sprites = new();
    [SerializeField] private List<AudioSource> sources = new();

    private bool isActive = true;

    public void ChangeSoundState()
    {
        if (isActive)
        {
            isActive = false;
            _soundButton.sprite = sprites[0];
            foreach(AudioSource source in sources)
            {
                source.enabled = false;
            }
        }
        else
        {
            isActive = true;
            _soundButton.sprite = sprites[1];
            foreach(AudioSource source in sources)
            {
                source.enabled = true;
            }
        }
    }
}
