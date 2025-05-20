using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class CanvasVideoPlayer : MonoBehaviour
{
    public RawImage targetImage;         // 캔버스 RawImage 컴포넌트 (에디터에서 할당)
    public VideoClip videoClip;          // 재생할 비디오 클립 (에디터에서 할당)
    public RenderTexture renderTexture;  // 렌더 텍스쳐 (에디터에서 할당)

    private VideoPlayer videoPlayer;
    private AudioSource audioSource;

    void Start()
    {
        // VideoPlayer 컴포넌트 생성
        videoPlayer = gameObject.AddComponent<VideoPlayer>();
        videoPlayer.clip = videoClip;

        // 비디오 출력 설정 : RenderTexture에 출력
        videoPlayer.renderMode = VideoRenderMode.RenderTexture;
        videoPlayer.targetTexture = renderTexture;

        // 오디오 출력 설정
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        videoPlayer.SetTargetAudioSource(0, audioSource);

        // RawImage에 RenderTexture 지정
        if (targetImage != null)
        {
            targetImage.texture = renderTexture;
            targetImage.enabled = false; // 처음엔 숨김
        }
    }

    public void PlayVideo()
    {
        if (targetImage != null)
            targetImage.enabled = true;

        videoPlayer.Play();
        audioSource.Play();
    }

    public void StopVideo()
    {
        videoPlayer.Stop();
        audioSource.Stop();

        if (targetImage != null)
            targetImage.enabled = false;
    }
}
