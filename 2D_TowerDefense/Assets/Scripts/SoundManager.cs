using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundManager : MonoBehaviour
{
    [Header("Assign AudioSource of Background music")]
    public AudioSource backgroudMusicSource;
    [Header("Assign AudioSource of SFX")]
    public AudioSource[] musicSFXSource;

    public Slider sliderVolume;

    public Slider sliderSFX;


    // Start is called before the first frame update
    void Awake()
    {   //IF there is no file saved with music, create n set as 1 the value
        if (!PlayerPrefs.HasKey("musicVolume"))
        { 
            PlayerPrefs.SetFloat("musicVolume", 1);
            
            PlayerPrefs.SetFloat("musicSFX", 1);
        }
        //IF there is one, take the value n assign it
        else
        { Load(); }
    }

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeVolume() 
    {
        //Adjust volume according slider
        //AudioListener.volume = sliderVolume.value;

        backgroudMusicSource.volume = sliderVolume.value;
        for (int i = 0; i < musicSFXSource.Length; i++)
        {
            musicSFXSource[i].volume = sliderSFX.value;
        }

        //Save this value
        Save();
    }
    // IF saved info related/regarding to the volume is there,
    // it is going to be inserted
    public void Load()
    {
        sliderVolume.value = PlayerPrefs.GetFloat("musicVolume");

        sliderSFX.value = PlayerPrefs.GetFloat("musicSFX");

    }

    public void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", sliderVolume.value);
        
        PlayerPrefs.SetFloat("musicSFX", sliderSFX.value);

    }

    public void PlayClick()
    {
        musicSFXSource[1].Play();
    }
}
