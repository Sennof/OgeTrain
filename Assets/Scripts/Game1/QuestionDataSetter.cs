using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestionDataSetter : MonoBehaviour
{
    [SerializeField] private List<Question> _questions;

    [SerializeField] private List<TMP_Text> _answerTexts;
    [SerializeField] private List<Image> _buttons;

    [SerializeField] private GameObject _infoButton;

    [SerializeField] private TMP_Text _infoText;


    private int _correctAnswerIndex;

    private void OnEnable()
    {
        SetQuestionData();
    }

    private void SetQuestionData()
    {
        if(_infoButton.activeInHierarchy)
            _infoButton.SetActive(false);

        int randomQuestionIndex = Random.Range(0, _questions.Count);

        _correctAnswerIndex = _questions[randomQuestionIndex].CorrectAnswer;
        
        for(int i = 0; i < _answerTexts.Count; i++)
        {
            _answerTexts[i].text = _questions[randomQuestionIndex].Answers[i];
        }
    }

    private void SetInfoData()
    {

    }

    public void Answer(int index)
    {
        if (index == _correctAnswerIndex)
        {
            StartCoroutine(correctAnswering());
        }
        else
        {
            SetButtonsColor(_buttons[index].color ,index);
            _infoButton.SetActive(true);
        }
    }

    private void SetButtonsColor(Color color)
    {
        foreach(Image btn in _buttons)
        {
            btn.color = color;
        }
    }

    private void SetButtonsColor(Color color, int index)
    {
        _buttons[index].color = color;
    }

    private IEnumerator correctAnswering()
    {
        Color defColor = _buttons[0].color;

        for(int i =0; i < _buttons.Count; i++)
        {
            if(i == _correctAnswerIndex)
                _buttons[i].color = Color.green;
            else
                _buttons[i].color = Color.red;
        }

        yield return new WaitForSeconds(0.5f);

        SetButtonsColor(defColor);
    }
    

}
