using System.Collections;
using UnityEngine;

public class DelayedAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public float delayTime = 10f;

    void Start()
    {
        if (audioSource != null)
        {
            audioSource.enabled = false; // Ã³À½¿£ ²¨Áü
            StartCoroutine(EnableAudioAfterDelay());
        }
    }

    IEnumerator EnableAudioAfterDelay()
    {
        yield return new WaitForSeconds(delayTime);

        audioSource.enabled = true;
    }
}
