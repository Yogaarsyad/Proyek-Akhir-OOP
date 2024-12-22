using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundMixerManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    public Slider soundFXSlider;
    public Slider musicSlider;
    public Slider masterSlider;

    void Start()
    {
        float savedLevelSFX = PlayerPrefs.GetFloat("soundFXVolume", 1.0f);
        float savedLevelMusic = PlayerPrefs.GetFloat("musicVolume", 1.0f);
        float savedLevelMaster = PlayerPrefs.GetFloat("masterVolume", 1.0f);

        audioMixer.SetFloat("soundFXVolume", Mathf.Log10(savedLevelSFX) * 20f);
        audioMixer.SetFloat("musicVolume", Mathf.Log10(savedLevelMusic) * 20f);
        audioMixer.SetFloat("masterVolume", Mathf.Log10(savedLevelMaster) * 20f);

        if (soundFXSlider != null)
        {
            soundFXSlider.value = savedLevelSFX;
        }

        if (musicSlider != null)
        {
            musicSlider.value = savedLevelMusic;
        }

        if (masterSlider != null)
        {
            masterSlider.value = savedLevelMaster;
        }
    }

    void Awake()
    {
        if (soundFXSlider != null)
        {
            soundFXSlider.onValueChanged.AddListener(SetSoundFXVolume);
        }

        if (musicSlider != null)
        {
            musicSlider.onValueChanged.AddListener(SetMusicVolume);
        }

        if (masterSlider != null)
        {
            masterSlider.onValueChanged.AddListener(SetMasterVolume);
        }
    }

    public void SetMasterVolume(float level)
    {
        PlayerPrefs.SetFloat("masterVolume", level);
        audioMixer.SetFloat("masterVolume", Mathf.Log10(level) * 20f);
    }

    public void SetSoundFXVolume(float level)
    {
        PlayerPrefs.SetFloat("soundFXVolume", level);
        audioMixer.SetFloat("soundFXVolume", Mathf.Log10(level) * 20f);
    }

    public void SetMusicVolume(float level)
    {
        PlayerPrefs.SetFloat("musicVolume", level);
        audioMixer.SetFloat("musicVolume", Mathf.Log10(level) * 20f);
    }
}
