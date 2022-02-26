using System;
using TMPro;
using UnityEngine;

public class Quiz : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private QuestionScriptableObject question;

    private void Start()
    {
        questionText.text = question.GetQuestion();
    }
}