using System.Collections.Generic;
using UnityEngine;

public class FeedbackPlayer : MonoBehaviour
{
    private List<Feedback> _feedbackToPlay = null;

    private void Awake()
    {
        _feedbackToPlay = new List<Feedback>();
        GetComponents<Feedback>(_feedbackToPlay); //나한테 붙은 피드백 전부 가져와
    }

    public void PlayFeedback()
    {
        foreach (Feedback f in _feedbackToPlay)
        {
            f.CreateFeedback();
        }

        FinishFeedback();
    }

    public void FinishFeedback()
    {
        foreach (Feedback f in _feedbackToPlay)
        {
            f.FinishFeedback();
        }
    }
}
