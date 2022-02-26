using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class QuestionScriptableObject : ScriptableObject
{
    [TextArea(2, 6)] [SerializeField] private string question = "Enter new question text here";
    [SerializeField] private string[] answers = new string[4];
    [Range(0, 3)] [SerializeField] private int correctAnswerIndex;

    public string GetQuestion()
    {
        return question;
    }

    public string GetAnswer(int index)
    {
        return answers[index];
    }

    public int GetCorrectAnswerIndex()
    {
        return correctAnswerIndex;
    }
}