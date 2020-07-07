using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class musicGame : MonoBehaviour
{
    public AudioSource _audioSource;
    private float masterVolume;
    private float changedVolume;
    private GameObject optionsObj;

    private void Awake()
    {
        optionsObj = GameObject.Find("CanvasOptions");
        masterVolume = PlayerPrefs.GetFloat("volume");
        optionsObj.GetComponentInChildren<Slider>().value = masterVolume;
        _audioSource.volume = masterVolume;
        _audioSource.Play();
    }

    public void ChangeVolume()
    {
        changedVolume = optionsObj.GetComponentInChildren<Slider>().value;
        _audioSource.volume = changedVolume;
        PlayerPrefs.SetFloat("volume", changedVolume);
    }
}
