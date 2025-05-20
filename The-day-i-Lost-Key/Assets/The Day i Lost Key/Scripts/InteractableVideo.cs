using UnityEngine;
using UnityEngine.Video;

public class InteractableVideo : MonoBehaviour
{
    public GameObject videoScreen;      // 카메라 앞에 보이는 Quad
    public VideoPlayer videoPlayer;     // 비디오 플레이어
    public AudioSource audioSource;     // 오디오 소스

    public void Play()
    {
        videoScreen.SetActive(true);
        videoPlayer.Play();
        audioSource.Play();
    }

    public void Stop()
    {
        videoPlayer.Stop();
        audioSource.Stop();
        videoScreen.SetActive(false);
    }

    public bool IsPlaying()
    {
        return videoScreen.activeSelf;
    }
}
