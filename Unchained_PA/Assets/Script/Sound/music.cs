using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class music : MonoBehaviour
{
    public AudioSource _audioSource;
    public float masterVolume;
    private GameObject optionsObj;

    private void Awake()
    {
        optionsObj = GameObject.Find("CanvasOptions");
        masterVolume = PlayerPrefs.GetFloat("volume");

        optionsObj.GetComponentInChildren<Slider>().value = masterVolume;
        _audioSource.volume = masterVolume;
        
        _audioSource.Play();

    }

    private void Update()
    {
        masterVolume = optionsObj.GetComponentInChildren<Slider>().value;
    }

    public void ChangeVolume()
    {
        _audioSource.volume = masterVolume;
        PlayerPrefs.SetFloat("volume", _audioSource.volume);
    }
}
