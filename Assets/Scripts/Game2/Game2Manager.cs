using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Game2Manager : MonoBehaviour
{
    [SerializeField] private List<Type5Q> _questions = new();
    [SerializeField] private TMP_Text _proposal;

    [SerializeField] private GameObject _infoButton;
    [SerializeField] private GameObject _infoScreen;
    [SerializeField] private TMP_Text _infoText;

    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private Color _correctColor;
    [SerializeField] private Color _wrongColor;
    [SerializeField] private Color _defaultColor;

    [SerializeField] private List<GameObject> _buttons;

    private Image _inputFieldBg;

    private int? _lastQIndex = null;
    private string _correctAnswer;

    private void Awake()
    {
        _inputFieldBg = _inputField.GetComponentInParent<Image>();
    }

    private void OnEnable()
    {
        BackIFBgDefault();
        SetQuestionData();
    }

    public void Answer()
    {
        if (_inputField.text == _correctAnswer)
        {
            StartCoroutine(CorrectAnswering());
        }
        else
        {
            ChangeButtons();
            _infoButton.SetActive(true);
            StartCoroutine(IncorrectAnswering());
            BackIFBgDefault();
        }
    }

    public void AddToAnswer(string value)
    {
        _inputField.text = $"{_inputField.text}{value}";
    }

    public void DelFromAnswer()
    {
        _inputField.text = _inputField.text.Remove(_inputField.text.Length - 1);
    }

    public void ChangeInfoScrState()
    {
        if (_infoScreen.activeInHierarchy)
            _infoScreen.SetActive(false);
        else
            _infoScreen.SetActive(true);
    }

    public void NextQ()
    {
        ChangeButtons();
        SetQuestionData();
        _inputField.text = "";
    }
    private void SetQuestionData()
    {
        int randomQuestionIndex = UnityEngine.Random.Range(0, _questions.Count);

        if(_lastQIndex != randomQuestionIndex)
        {
            _lastQIndex = randomQuestionIndex;
            _proposal.text = _questions[randomQuestionIndex].Proposal;
            _correctAnswer = _questions[randomQuestionIndex].CorrectAnswer;
            _infoText.text = $"Правильный ответ: {_correctAnswer}";
        }
        else
            SetQuestionData();
    }

    private void BackIFBgDefault()
    {
        _inputFieldBg.color = _defaultColor;
    }

    private void ChangeButtons()
    {
        if (_buttons[0].activeInHierarchy)
        {
            _buttons[0].SetActive(false);
            _buttons[1].SetActive(true);
        }
        else
        {
            _buttons[0].SetActive(true);
            _buttons[1].SetActive(false);
        }
    }


    private IEnumerator CorrectAnswering()
    {
        _inputFieldBg.color = _correctColor;
        yield return new WaitForSeconds(0.5f);
        BackIFBgDefault();
        _inputField.text = "";
        SetQuestionData();
    }

    private IEnumerator IncorrectAnswering()
    {
        _inputFieldBg.color = _wrongColor;
        ChangeInfoScrState();
        yield return new WaitForSeconds(1.2f);
        ChangeInfoScrState();
        _infoScreen.SetActive(false);
    }
}
