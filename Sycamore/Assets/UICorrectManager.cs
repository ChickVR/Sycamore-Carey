using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICorrectManager : MonoBehaviour
{
    bool correct = false;

    // Start is called before the first frame update
    void OnEnable()
    {
        DisableMenu();
    }


    public void DisableMenu()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    public void EnableMenu()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }

    public bool GetIsCorrect()
    {
        return correct;
    }

    public void SetIsCorrect(bool correct)
    { 
        this.correct = correct;
    }
}
