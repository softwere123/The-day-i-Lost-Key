using UnityEngine;

public class ObjectSwitcher : MonoBehaviour
{
    public GameObject objectToHide;     // 클릭 시 사라질 오브젝트
    public GameObject objectToShow;     // 클릭 시 나타날 오브젝트
    public AudioClip clickSound;        // 클릭 시 재생할 사운드

    private AudioSource audioSource;

    void Start()
    {
        // AudioSource가 없으면 자동으로 추가
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void OnMouseDown()
    {
        // 사운드 재생: 컴포넌트에 있는 오디오 소스의 clip에 할당 후 Play()
        if (clickSound != null && audioSource != null)
        {
            audioSource.clip = clickSound;
            audioSource.Play();
        }

        // 오브젝트 치환
        if (objectToHide != null)
            objectToHide.SetActive(false);

        if (objectToShow != null)
            objectToShow.SetActive(true);

        Debug.Log("오브젝트 치환 + 사운드 재생 완료");
    }
}
