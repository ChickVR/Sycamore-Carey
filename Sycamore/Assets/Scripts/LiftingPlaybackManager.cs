using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class LiftingPlaybackManager : MonoBehaviour
{
    [SerializeField]
    VideoClip intro, lifting1, lifting2, closing;

    VideoPlayer videoPlayer;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();

        videoPlayer.clip = intro;
        videoPlayer.Play();
        videoPlayer.loopPointReached += HandleVideoCompletion;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void HandleVideoCompletion(VideoPlayer videoPlayer)
    {
        EventManager.TriggerVideoCompleted(videoPlayer.clip.name);
        switch (videoPlayer.clip.name)
        {
            // If we just played the intro, we switch to VR video clip
            case "LiftingOpening":
                {
                    EventManager.TriggerIntroCompleted();
                    videoPlayer.clip = lifting1;
                    break;
                }
            case "Medication_Administration_02":
                {
                    videoPlayer.clip = closing;
                    break;
                }

        }
    }

    public void PlayVideo(VideoClip clip)
    {
        videoPlayer.clip = clip;
        videoPlayer.Play();
    }

    public void HandleQuestion01(VideoClip clip)
    {
        EventManager.TriggerAnswerSubmitted();
        videoPlayer.clip = clip;
        videoPlayer.Play();
    }
}
