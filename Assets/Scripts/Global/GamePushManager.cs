using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePush;

public class GamePushManager : MonoBehaviour
{
    public static GamePushManager Instancel { get; private set; }
    private Coroutine _addCor;

    private async void Awake()
    {
        await GP_Init.Ready;
        _addCor = StartCoroutine(TimedAddShowing());
    }

    public void ShowAdd()
    {
        GP_Ads.ShowFullscreen();
    }

    private IEnumerator TimedAddShowing()
    {
        while (true)
        {
            yield return new WaitForSeconds(100);
            ShowAdd();
        }
    } 
}
