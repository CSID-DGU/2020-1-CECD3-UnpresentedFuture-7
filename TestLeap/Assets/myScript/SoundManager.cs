using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] GameObject musicMuteImage;
    [SerializeField] AudioSource effectSource;
    [SerializeField] GameObject effectMuteImage;

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void MuteMusicVolume()
    {
        if (musicSource.mute)
        {
            musicSource.mute = false;
            musicMuteImage.SetActive(false);
        }
        else
        {
            musicSource.mute = true;
            musicMuteImage.SetActive(true);
        }
    }

    public void SeteffectVolume(float volume)
    {
        effectSource.volume = volume;
    }

    public void MuteEffectVolume()
    {
        if (effectSource.mute)
        {
            effectSource.mute = false;
            effectMuteImage.SetActive(false);
        }
        else
        {
            effectSource.mute = true;
            effectMuteImage.SetActive(true);
        }
    }
}
