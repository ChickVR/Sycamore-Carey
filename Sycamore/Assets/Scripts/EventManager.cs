using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager
{
    // Define a delegate type for the click event
    public delegate void VideoCompletedHandler(string videoID);

    // Define an event based on the delegate
    public static event VideoCompletedHandler OnVideoCompleted;

    // Method to trigger the event
    public static void TriggerVideoCompleted(string videoID)
    {
        OnVideoCompleted?.Invoke(videoID);
    }

    public delegate void IntroCompletedHandler();
    public static event IntroCompletedHandler OnIntroCompleted;
    public static void TriggerIntroCompleted() 
    { 
        OnIntroCompleted?.Invoke(); 
    }

    public delegate void AnswerSubmittedHandler();
    public static event AnswerSubmittedHandler OnAnswerSubmitted;
    public static void TriggerAnswerSubmitted() 
    {  
        OnAnswerSubmitted?.Invoke(); 
    }

    public delegate void ObjectClickedHandler(string objectID);
    public static event ObjectClickedHandler OnObjectClicked;
    public static void TriggerObjectClicked(string objectID)
    {
        OnObjectClicked?.Invoke(objectID);
    }

    public delegate void SceneHandler();
    public static event SceneHandler OnTriggerScene;
    public static void Trigger3DScene()
    {
        OnTriggerScene?.Invoke();
    }


}
