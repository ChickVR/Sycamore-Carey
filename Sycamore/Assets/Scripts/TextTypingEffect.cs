using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class TextTypingEffect : MonoBehaviour
{

    public string textToType;

    private TMP_Text _tmpText;

    public bool used = false;

    [SerializeField]
    private float waitBetweenCharacters = 0.1f;

    [SerializeField]
    private char suffix = '|';

    // Start is called before the first frame update
    void Start()
    {
        _tmpText = GetComponent<TMP_Text>();
        //StartCoroutine(TypeText(_tmpText, textToType));
    }

    public void AnimateText(TMP_Text text)
    {
        StartCoroutine(TypeText(_tmpText, text.text, waitBetweenCharacters));
    }
    
    private IEnumerator TypeText(TMP_Text tmpText, string text, float waitTime = 0.1f)
    {
        if (!used)
        {
            used = true;
            foreach (var character in text)
            {
                if (tmpText.text.Length > 1)
                {
                    tmpText.text = tmpText.text.Substring(0, tmpText.text.Length - 1);
                }

                tmpText.text += character + suffix.ToString();
                yield return new WaitForSeconds(waitTime);
            }

            tmpText.text = tmpText.text.Substring(0, tmpText.text.Length - 1);
        }

    }
}
