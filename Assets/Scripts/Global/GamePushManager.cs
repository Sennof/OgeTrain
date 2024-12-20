using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePush;

public class GamePushManager : MonoBehaviour
{
    public static GamePushManager Instance { get; private set; }

    private async void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;

        await GP_Init.Ready;
    }

    public void ShowAdd()
    {
        GP_Ads.ShowFullscreen();
    }
}
