using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    private static AudioSource audioSource;
    public static bool IsPlaying;

    private void Awake()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    private void Start()
    {
        IsPlaying = true;
    }

    public static void PlaySound()
    {
        IsPlaying = true;
        audioSource.Play();
    }

    public static void StopSound()
    {
        IsPlaying = false;
        audioSource.Stop();
    }

    public void SetMusicVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
