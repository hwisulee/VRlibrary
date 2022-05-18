using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    [Header("Settings")]
    public AudioMixer mixer;
    public Slider slider;

    public void AudioControl(float soundLevel)
    {
        mixer.SetFloat("BGM", soundLevel);
    }
}
