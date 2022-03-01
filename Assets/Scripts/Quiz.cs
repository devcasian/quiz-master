using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField]
    private TextMeshProUGUI questionText;

    [SerializeField]
    private List<QuestionScriptableObject> questions = new List<QuestionScriptableObject>();

    private QuestionScriptableObject _currentQuestion;

    [Header("Answers")]
    [SerializeField]
    private GameObject[] answerButtons;

    private bool _hasAnsweredEarly = true;

    [Header("Button Colors")]
    [SerializeField]
    private Sprite defaultAnswerSprite;

    [SerializeField]
    private Sprite correctAnswerSprite;

    [Header("Timer")]
    [SerializeField]
    private Image timerImage;

    private Timer _timer;

    private void Start()
    {
        _timer = FindObjectOfType<Timer>();
    }

    private void Update()
    {
        timerImage.fillAmount = _timer.fillFraction;

        if (_timer.loadNextQuestion)
        {
            _hasAnsweredEarly = false;
            GetNextQuestion();
            _timer.loadNextQuestion = false;
        }
        else if (!_hasAnsweredEarly && !_timer.isAnsweringQuestion)
        {
            DisplayAnswer(-1);
            SetButtonState(false);
        }
    }

    public void OnAnswerSelected(int index)
    {
        _hasAnsweredEarly = true;
        DisplayAnswer(index);
        SetButtonState(false);
        _timer.CancelTimer();
    }

    private void DisplayAnswer(int index)
    {
        Image buttonImage;

        if (index == _currentQuestion.GetCorrectAnswerIndex())
        {
            questionText.text = "Correct!";
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
        else
        {
            var correctAnswerIndex = _currentQuestion.GetCorrectAnswerIndex();
            var correctAnswer = _currentQuestion.GetAnswer(correctAnswerIndex);
            questionText.text = "Incorrect. The correct answer was:\n" + correctAnswer;
            buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
    }

    private void GetNextQuestion()
    {
        if (questions.Count > 0)
        {
            SetButtonState(true);
            SetDefaultButtonSprites();
            GetRandomQuestion();
            DisplayQuestion();
        }
    }

    private void GetRandomQuestion()
    {
        var index = Random.Range(0, questions.Count);
        _currentQuestion = questions[index];

        if (questions.Contains(_currentQuestion))
        {
            questions.Remove(_currentQuestion);
        }
    }

    private void SetDefaultButtonSprites()
    {
        foreach (var answer in answerButtons)
        {
            var buttonImage = answer.GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
        }
    }

    private void DisplayQuestion()
    {
        questionText.text = _currentQuestion.GetQuestion();

        for (var index = 0; index < answerButtons.Length; index++)
        {
            var buttonText = answerButtons[index].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = _currentQuestion.GetAnswer(index);
        }
    }

    private void SetButtonState(bool state)
    {
        foreach (var answer in answerButtons)
        {
            var button = answer.GetComponent<Button>();
            button.interactable = state;
        }
    }
}