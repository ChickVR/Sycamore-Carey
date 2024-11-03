using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SphereManager : MonoBehaviour
{
    public Transform headset;
    bool correct = false;

    // Start is called before the first frame update
    private void OnEnable()
    {
        // Spheres should be disabled at the start
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

        EventManager.OnIntroCompleted += HandleIntroCompletion;
        EventManager.OnVideoCompleted += HandleConclusion;
        EventManager.OnTriggerScene += DisableSpheres;

    }

    private void OnDisable()
    {
        EventManager.OnIntroCompleted -= HandleIntroCompletion;
        EventManager.OnVideoCompleted -= HandleConclusion;
        EventManager.OnTriggerScene -= DisableSpheres;
    }

    //private void Update()
    //{
    //    if (headset != null)
    //    {
    //        transform.position = headset.position;
    //    }
    //}

    void HandleIntroCompletion()
    {
        Debug.Log("Intro completed!");
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    void HandleConclusion(string videoID)
    {
        if (videoID == "Medication_Administration_02")
        {
            if (!correct)
            {
                DisableSpheres();
            }           
        }
    }

    public void DisableSpheres()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void SetCorrect(bool correct)
    {
        this.correct = correct;
    }
}
