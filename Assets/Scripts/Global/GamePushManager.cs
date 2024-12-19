using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePush;

public class GamePushManager : MonoBehaviour
{
    public static GamePushManager Instance { get; private set; }

    private async void Awake()
    {
        await GP_Init.Ready;
    }

    public void ShowAdd()
    {
        GP_Ads.ShowFullscreen();
    }
}
