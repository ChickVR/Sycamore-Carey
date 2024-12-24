using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WheelchairMenuManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI text;

    [SerializeField]
    AudioClip head, feet, arms, bed, back, footrests;

    string headText = "Wrong. Kelly should raise her head.";
    string backText = "Wrong. Kelly should straighten her back.";
    string bedText = "Wrong. The chair is too far from the bed. Kelly should move the chair closer before transferring.";
    string feetText = "Correct. Kelly has a wide, stable stance, and her left foot is between David's feet.";
    string armsText = "Correct. Kelly has a stable grip around David's back.";
    string footrestText = "Wrong. Kelly should remove the footrests.";

    public GameObject wheelchairModel;
    AudioSource audioSource;

    private void OnEnable()
    {
        EventManager.OnObjectClicked += HandleObjectClicked;
        audioSource = GetComponent<AudioSource>();
        //transform.parent = null;
    }

    private void Start()
    {
        transform.parent = null;
        transform.position = Vector3.zero; 
        transform.Translate(transform.forward * 5);
        transform.Translate(Vector3.up);
    }

    private void OnDisable()
    {
        EventManager.OnObjectClicked -= HandleObjectClicked;
    }

    void HandleObjectClicked(string objectID)
    {
        switch (objectID)
        {
            case "Head":
                {
                    text.text = headText;
                    audioSource.clip = head;
                    audioSource.Play();
                    break;
                }
            case "Feet":
                {
                    audioSource.clip = feet;
                    text.text = feetText;
                    audioSource.Play();
                    break;
                }
            case "Back":
                {
                    audioSource.clip = back;
                    text.text = backText;
                    audioSource.Play();
                    break;
                }
            case "Bed":
                {
                    audioSource.clip = bed;
                    text.text = bedText;
                    audioSource.Play();
                    break;
                }
            case "Arms":
                {
                    audioSource.clip = arms;
                    text.text = armsText;
                    audioSource.Play();
                    break;
                }
            case "Footrests":
                {
                    audioSource.clip = footrests;
                    text.text = footrestText;
                    audioSource.Play();
                    break;
                }
              
        }
    }

    public void LoadModel(GameObject model)
    {
        GameObject.Destroy(wheelchairModel);
        // Load the correct model and put in the correct position
        GameObject go = GameObject.Instantiate(model);
        go.transform.parent = GameObject.Find("Scene").transform;
        go.transform.localPosition = new Vector3(0.2f, 0, 0);
        go.transform.Translate(0.6f, 0, 0, Space.World);
        go.transform.localRotation = Quaternion.identity;

        // Make spheres disappear
        GameObject.Destroy(GameObject.Find("Spheres"));
    }

    public void GoHome()
    {
        SceneManager.LoadScene(0);
    }
}
