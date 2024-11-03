using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager.OnIntroCompleted += HandleIntroCompletion;
        EventManager.OnVideoCompleted += HandleConclusion;
    }

    private void OnDisable()
    {
        EventManager.OnIntroCompleted -= HandleIntroCompletion;
        EventManager.OnVideoCompleted -= HandleConclusion;
    }

    void HandleIntroCompletion()
    {
        GetComponent<Renderer>().enabled = false;
    }

    void HandleConclusion(string videoID)
    {
        if (videoID == "Medication_Administration_02")
        {
            GetComponent<Renderer>().enabled = true;
        }
    }
}
