using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timeToCompleteQuestion;
    [SerializeField] private float timeToShowCorrectAnswer;

    public bool loadNextQuestion;
    public float fillFraction;

    private bool _isAnsweringQuestion;
    private float _timerValue;

    private void Update()
    {
        UpdateTimer();
    }

    public void CancelTimer()
    {
        _timerValue = 0;
    }

    private void UpdateTimer()
    {
        _timerValue = Time.deltaTime;

        if (_isAnsweringQuestion)
        {
            if (_timerValue > 0)
            {
                fillFraction = _timerValue / timeToCompleteQuestion;
            }
            else
            {
                _isAnsweringQuestion = false;
                _timerValue = timeToShowCorrectAnswer;
            }
        }
        else
        {
            if (_timerValue > 0)
            {
                fillFraction = _timerValue / timeToShowCorrectAnswer;
            }
            else
            {
                _isAnsweringQuestion = true;
                _timerValue = timeToCompleteQuestion;
                loadNextQuestion = true;
            }
        }
    }
}