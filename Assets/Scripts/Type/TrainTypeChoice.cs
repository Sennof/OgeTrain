using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainTypeChoice : MonoBehaviour
{
    [SerializeField] private PageSetter PageSetter;

    [SerializeField] private Animator _typeCardsAnim;
    [SerializeField] private Animator _hintAnim;

    [SerializeField] private List<GameObject> _cards = new();

    private int _curCardIndex = 0;

    public void NextCard()
        {
        if(_curCardIndex < _cards.Count - 1)
        {
            _curCardIndex++;
            _typeCardsAnim.Play($"from{_curCardIndex-1}next");
        }
    }

    public void PrevCard()
    {
        if(_curCardIndex > 0)
        {
            _curCardIndex--;
            _typeCardsAnim.Play($"from{_curCardIndex+1}prev");
        }
    }

    public void Play()
    {
        GamePushManager.Instance.ShowAdd();
        PageSetter.ToPage(_curCardIndex + 2);     
    }
}
