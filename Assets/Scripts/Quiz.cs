using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private QuestionScriptableObject question;
    [SerializeField] private GameObject[] answerButtons;
    [SerializeField] private Sprite defaultAnswerSprite;
    [SerializeField] private Sprite correctAnswerSprite;

    private void Start()
    {
        GetNextQuestion();
        // DisplayQuestion();
    }

    public void OnAnswerSelected(int index)
    {
        Image buttonImage;

        if (index == question.GetCorrectAnswerIndex())
        {
            questionText.text = "Correct!";
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
        else
        {
            var correctAnswerIndex = question.GetCorrectAnswerIndex();
            var correctAnswer = question.GetAnswer(correctAnswerIndex);
            questionText.text = "Incorrect. The correct answer was:\n" + correctAnswer;
            buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }

        SetButtonState(false);
    }

    private void GetNextQuestion()
    {
        SetButtonState(true);
        SetDefaultButtonSprites();
        DisplayQuestion();
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
        questionText.text = question.GetQuestion();

        for (var index = 0; index < answerButtons.Length; index++)
        {
            var buttonText = answerButtons[index].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetAnswer(index);
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