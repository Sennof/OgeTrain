using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Game2Manager : MonoBehaviour
{
    [SerializeField] private List<Type5Q> _questions = new();
    [SerializeField] private TMP_Text _proposal;

    [SerializeField] private GameObject _infoScreen;
    [SerializeField] private TMP_Text _infoText;

    [SerializeField] TMP_InputField _inputField;
    [SerializeField] Color _defaultColor;
    [SerializeField] Color _correctColor;
    [SerializeField] Color _wrongColor;

    private Image _inputFieldBg;

    private int? _lastQIndex = null;
    private string _correctAnswer;

    private void Awake()
    {
        _inputFieldBg = _inputField.GetComponentInParent<Image>();
        SetQuestionData();
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
            StartCoroutine(IncorrectAnswering());
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
        _infoScreen.SetActive(true);
        yield return new WaitForSeconds(1.2f);
        _infoScreen.SetActive(false);
        BackIFBgDefault();
        _inputField.text = "";
        SetQuestionData();
    }
}
