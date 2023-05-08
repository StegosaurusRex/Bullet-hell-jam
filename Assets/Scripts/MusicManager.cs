using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MusicManager : MonoBehaviour
{
    ToAnotherPlanetTrigger toAnotherPlanetTrigger;
    [SerializeField] Slider volumeSlider;
    private AudioSource audioSource; // Add this variable for playing the sound
    private void Start()
    {
        toAnotherPlanetTrigger = FindAnyObjectByType<ToAnotherPlanetTrigger>();

        audioSource = GetComponent<AudioSource>(); // Get the audio source component
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume" , 1);
            Load();
        }
        else
        {
            Load();
        }
    }
    void Update()
    {
        

    }
    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }
    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }
    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume" , volumeSlider.value);
    }
}
