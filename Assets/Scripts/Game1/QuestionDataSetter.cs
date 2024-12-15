using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestionDataSetter : MonoBehaviour
{
    [SerializeField] private List<Question> _questions;
    [SerializeField] private List<TMP_Text> _answerTexts;
    [SerializeField] private TMP_Text _proposal;

    [SerializeField] private List<Image> _buttons;
    [SerializeField] private List<Color> _buttonsColors; //0-def; 1-right; 2-wrong

    [SerializeField] private GameObject _infoButton;
    [SerializeField] private GameObject _infoScreen;

    [SerializeField] private TMP_Text _infoText;

    private int _correctAnswerIndex;

    private int? _lastQueIndex = null;

    private void OnEnable()
    {
        SetQuestionData();
    }

    private void SetQuestionData()
    {
        int randomQuestionIndex = Random.Range(0, _questions.Count);

        if (_lastQueIndex != randomQuestionIndex)
        {
            if (_infoButton.activeInHierarchy)
                _infoButton.SetActive(false);

            _correctAnswerIndex = _questions[randomQuestionIndex].CorrectAnswer;

            _proposal.text = _questions[randomQuestionIndex].Proposal;
            for (int i = 0; i < _questions[randomQuestionIndex].Answers.Count; i++)
            {
                _answerTexts[i].text = _questions[randomQuestionIndex].Answers[i];
            }

            SetInfoData(randomQuestionIndex);
            _lastQueIndex = randomQuestionIndex;
        }
        else
            SetQuestionData();
    }

    private void SetInfoData(int index)
    {
        _infoText.text = _questions[index].InfoText;
    }

    private void SetButtonsColor(Color color)
    {
        foreach (Image btn in _buttons)
        {
            btn.color = color;
        }
    }

    private void SetButtonsColor(Color color, int index)
    {
        _buttons[index].color = color;
    }

    public void Answer(int index)
    {
        if (index == _correctAnswerIndex)
        {
            StartCoroutine(correctAnswering());
        }
        else
        {
            SetButtonsColor(_buttonsColors[2] ,index);
            _infoButton.SetActive(true);
        }
    }

    public void ToggleInfoScreen()
    {
        if(_infoScreen.activeInHierarchy)
            _infoScreen.SetActive(false);
        else
            _infoScreen.SetActive(true);
    }

    private IEnumerator correctAnswering()
    {
        for(int i =0; i < _buttons.Count; i++)
        {
            if(i == _correctAnswerIndex)
                _buttons[i].color = _buttonsColors[1];
            else
                _buttons[i].color = _buttonsColors[2];
        }

        yield return new WaitForSeconds(0.5f);

        SetButtonsColor(_buttonsColors[0]);
        SetQuestionData();
    }
    

}
