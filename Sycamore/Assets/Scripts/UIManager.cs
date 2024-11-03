using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
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
        Debug.Log("Root finished!");
        if (videoID == "Medication_Administration_Root_New")
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void HandleAnswerCompletion()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
