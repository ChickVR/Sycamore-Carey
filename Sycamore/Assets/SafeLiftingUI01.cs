using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Jobs;
using UnityEngine;

public class SafeLiftingUI01 : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip question, correct, incorrect;
    public TextMeshProUGUI text;
    public GameObject continueButton;
    private string[] messages = { "That is not correct. The wheelchair should be closer to the bed.",
    "Great Job! The wheelchair is too far away from the bed."};

    void OnEnable()
    {
        continueButton.SetActive(false);
        transform.GetChild(0).gameObject.SetActive(false); // UI is invisible until root video finishes
        EventManager.OnVideoCompleted += HandleVideoCompletion; // Subscribing to events
    }

    void HandleVideoCompletion(string videoID)
    {
        if (videoID == "Safe_Lifting_01")
        {
            transform.GetChild(0).gameObject.SetActive(true);
            audioSource.clip = question;
            audioSource.Play();
        }
    }

    public void SubmitAnswer(int answerID)
    {
        text.gameObject.SetActive(true);
        text.text = messages[answerID];
        if (answerID == 0)
        {
            audioSource.clip = incorrect;
        }
        else
        {
            audioSource.clip = correct;
        }
        audioSource.Play();
        continueButton.SetActive(true);
    }

    public void Continue()
    {
        gameObject.SetActive(false);
    }
}
