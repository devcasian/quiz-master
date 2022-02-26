using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class QuestionScriptableObject : ScriptableObject
{
    [TextArea(2, 6)] 
    [SerializeField] string question = "Enter new question text here";

    public string GetQuestion()
    {
        return question;
    }
}