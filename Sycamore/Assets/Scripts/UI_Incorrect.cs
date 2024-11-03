using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class UI_Incorrect : MonoBehaviour
{
    bool correct = false; // Was the user correct when they answered the question?
    [SerializeField]
    AudioClip clip1, clip2, clip3, clip4;
    private AudioSource audioSource;
    public TextMeshProUGUI text;

    private string[] messages = {"That is incorrect. Mark should have told Nathan that he needed to help Neal right away. He should have put the medication back in the locked cabinet before leaving the room. After helping Neal, Mark should go back to giving Nathan his medication. Let’s watch.",
    "Way to go! You understood Mark needed to put the medication away and check on Neal right away.",
    "That is incorrect. Mark should not have told Nathan to take his own medication. He should have taken the medication and locked it in the cabinet before leaving the room to help Neal. Mark cannot be certain Nathan took his pills, and he should not wait to document in the MAR. Let’s watch.",
    "That is not correct. Mark should not have left the medication out.  He should have taken the medication and locked it in the cabinet before leaving the room to help Neal. Let’s watch."};
    
    void OnEnable()
    {
        transform.GetChild(0).gameObject.SetActive(false); // UI is invisible until root video finishes
        EventManager.OnVideoCompleted += HandleVideoCompletion; // Subscribing to events
        EventManager.OnAnswerSubmitted += HandleAnswerCompletion;
    }

    private void OnDisable()
    {
        EventManager.OnVideoCompleted -= HandleVideoCompletion;
        EventManager.OnAnswerSubmitted -= HandleAnswerCompletion;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void HandleVideoCompletion(string videoID)
    {
        if (videoID == "Medication_Administration_02") return;
        if (videoID != "Medopening" && videoID != "Wrapup with text" && videoID != "Medication_Administration_Root_New"
            && videoID != "Medication_Administration_02")
        {
            transform.GetChild(0).gameObject.SetActive(true);
            audioSource = transform.GetChild(0).GetComponent<AudioSource>();
        }

        switch (videoID)
        {
            case "Medication_Administration_01":
                {
                    text.text = messages[0];
                    audioSource.clip = clip1;
                    audioSource.Play();
                    break;
                }
            case "Medication_Administration_02":
                {
                    text.text = messages[1];
                    audioSource.clip = clip2;
                    audioSource.Play();
                    break;
                }
            case "Medication_Administration_03":
                {
                    text.text = messages[2];
                    audioSource.clip = clip3;
                    audioSource.Play();
                    break;

                }
            case "Medication_Administration_04":
                {
                    text.text = messages[3];
                    audioSource.clip = clip4;
                    audioSource.Play();
                    break;
                }
        }
    }

    void HandleAnswerCompletion()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    public void GuessCorrectly()
    {
        correct = true;
    }
}
