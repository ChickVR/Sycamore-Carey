using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerTracker : MonoBehaviour
{
    bool Q1Correct = false;

    public void SetQ1Correct(bool Q1Correct)
    {
        this.Q1Correct = Q1Correct;
    }

    public bool GetQ1Correct()
    {
        return this.Q1Correct;
    }
}
