using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private int _correctAnswers;
    private int _questionsSeen;

    public int GetCorrectAnswers()
    {
        return _correctAnswers;
    }

    public void IncrementCorrectAnswers()
    {
        _correctAnswers++;
    }

    public int GetQuestionsSeen()
    {
        return _questionsSeen;
    }

    public void IncrementQuestionsSeen()
    {
        _questionsSeen++;
    }

    public int CalculateScore()
    {
        return Mathf.RoundToInt(_correctAnswers / (float) _questionsSeen * 100);
    }
}