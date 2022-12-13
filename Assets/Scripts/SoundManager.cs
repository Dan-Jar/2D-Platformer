using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [Header("Sound Sliders")]
    [SerializeField]
    private Slider MasterLevel;

    [SerializeField]
    private Slider MusicLevel;

    [SerializeField]
    private Slider SFXLevel;

    private void Start()
    {
       //load previous audio settings
       LoadValues();
    }

    public void MasterVolumeSlider()
    {
        //save the currrent volume value
        float volume = MasterLevel.value;
        PlayerPrefs.SetFloat("MasterVolume", volume);
        LoadValues();
    }

    public void MusicSlider()
    {
        //save the currrent volume value
        float music = MusicLevel.value;
        PlayerPrefs.SetFloat("Music", music);
        //get the level soundtrack
        AudioSource level = gameObject.GetComponent<AudioSource>();
        level.volume = music;//adjust the music level to the slider value
        LoadValues();
    }

    public void SFXSlider()
    {
        //save the currrent volume value
        float sfx = SFXLevel.value;
        PlayerPrefs.SetFloat("SFX", sfx);
        LoadValues();
    }

    void LoadValues()
    {

        float master = PlayerPrefs.GetFloat("MasterVolume");
        float sfx = PlayerPrefs.GetFloat("SFX");
        float music = PlayerPrefs.GetFloat("Music");
        MusicLevel.value = music;
        SFXLevel.value = sfx;
        MasterLevel.value = master;
        AudioListener.volume = master;//master volume
    }
}
