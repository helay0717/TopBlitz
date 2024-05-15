using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    [SerializeField] Slider audioSlider;

    void Start()
    {
        if(!PlayerPrefs.HasKey("AudioControl"))
        {
            PlayerPrefs.SetFloat("AudioControl", 1);
            Load();
        }

        else
        {
            Load();
        }
    }

    public void ChangeAudio()
    {
        AudioListener.volume = audioSlider.value;
        Save();
    }

    private void Load()
    {
        audioSlider.value = PlayerPrefs.GetFloat("AudioControl");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("AudioControl", audioSlider.value);
    }
}
