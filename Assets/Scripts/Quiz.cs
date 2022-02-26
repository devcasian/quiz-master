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
    // private int _correctAnswerIndex;

    private void Start()
    {
        questionText.text = question.GetQuestion();

        for (var index = 0; index < answerButtons.Length; index++)
        {
            var buttonText = answerButtons[index].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetAnswer(index);
        }
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
    }
}