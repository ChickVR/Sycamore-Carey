using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class WrapUpManager : MonoBehaviour
{
    public bool[] answers = { true, true, false, true, false }; // Set from inspector
    bool[] guesses = { false, false, false, false, false };
    int numCorrect = 0;

    public TextMeshProUGUI text;
    public GameObject panel;

    public AudioSource audioSource;
    public GameObject continueButton;
    public GameObject homeButton;

    private void OnEnable()
    {
        panel.SetActive(false);
        audioSource.enabled = false;
        EventManager.OnVideoCompleted += HandleVideoCompletion; // Subscribing to events
    }

    private void OnDisable()
    {
        EventManager.OnVideoCompleted -= HandleVideoCompletion;
    }

    private void Update()
    {
        text.text = "Number correct: " + numCorrect.ToString();
    }

    void HandleVideoCompletion(string videoID)
    {
        if (videoID == "Wrapup with text") // Medication Scenario
        {
            panel.SetActive(true);
            audioSource.enabled = true;
        }
        if (videoID == "Safe_Lifting_02") // Lifting Scenario
        {
            panel.SetActive(true);
            audioSource.enabled = true;
        }
    }

    public void HandleGuessChanged(int guessID)
    {
        guesses[guessID] = !guesses[guessID]; // change the guess
        CalculateNumCorrect();
    }

    public void CalculateNumCorrect()
    {
        numCorrect = 0;
        for (int i = 0; i < answers.Length; i++)
        {
            if (answers[i] == guesses[i]) numCorrect++;
        }
    }

    public void SubmitGuesses()
    {
        CalculateNumCorrect();

        // Loop through each toggle and change its background color
        for (int i = 0; i < guesses.Length; i++)
        {
            Transform toggleTransform = panel.transform.GetChild(i); // Get the i-th child in the panel
            Toggle toggle = toggleTransform.GetComponent<Toggle>();
            if (toggle != null)
            {
                // Assuming the background is the first child of the toggle
                Image background = toggle.transform.GetChild(0).GetComponent<Image>();
                if (background != null)
                {
                    if (answers[i])
                    {
                        background.color = Color.green; // Correct guess
                    }
                    else
                    {
                        background.color = Color.red; // Incorrect guess
                    }
                }
            }
        }
        if (continueButton != null)
        {
            continueButton.SetActive(true);
        }
        if (SceneManager.GetActiveScene().buildIndex == 1)
        homeButton?.SetActive(true);

    }

    public void Continue()
    {
        panel.SetActive(false);
        audioSource.enabled = false;
        EventManager.Trigger3DScene();
    }

    public void GoHome()
    {
        SceneManager.LoadScene(0);
    }

    public void ChangeAudioClip(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

}
