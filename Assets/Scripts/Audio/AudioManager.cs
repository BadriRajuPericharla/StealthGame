using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField]private Slider musicSlider;
    [SerializeField]private Slider sfxSlider;
    [SerializeField]private AudioClip buttonClick;
    [SerializeField]private AudioClip enemyAttack;
    [SerializeField]private AudioClip playerAttack;
    [SerializeField]private AudioClip doorOpen;
    [SerializeField]private AudioClip keyCollection;
    [SerializeField]private AudioClip treasureOpening;
    [SerializeField]private AudioClip normalPlayerAttack;
    [SerializeField]private AudioClip detectionAudio;
    public AudioSource musicAudioSource;
    public AudioSource sfxAudioSource;
    void Awake()
    {
        if (instance == null)
        {
            instance=this;
        }
        else
        {
            Destroy(gameObject);
        }
       
    }
    void Start()
    {
        float musicVolume=PlayerPrefs.GetFloat("MusicVolume", 1f);
        musicAudioSource.volume=musicVolume;
        musicSlider.value=musicVolume;
        float sfxAudioVolume=PlayerPrefs.GetFloat("SFXVolume", 1f);
        sfxAudioSource.volume=sfxAudioVolume;
        sfxSlider.value=sfxAudioVolume;
        musicSlider.onValueChanged.AddListener(MusicSlider);
        sfxSlider.onValueChanged.AddListener(SFXSlider);
    }
    public void PlayButtonClick()
    {
        sfxAudioSource.PlayOneShot(buttonClick);
    }
    public void PlayEnemyAttack()
    {
        sfxAudioSource.PlayOneShot(enemyAttack);
    }
    public void PlayPlayerAttack()
    {
        sfxAudioSource.PlayOneShot(playerAttack);
    }
    public void PlayDoorOpen()
    {
        sfxAudioSource.PlayOneShot(doorOpen);
    }
    public void PlayKeyCollection()
    {
        sfxAudioSource.PlayOneShot(keyCollection);
    }
    public void PlayTreasureOpening()
    {
        sfxAudioSource.PlayOneShot(treasureOpening);
    }
    public void NormalPlayerAttack()
    {
        sfxAudioSource.PlayOneShot(normalPlayerAttack);
    }
    public void PlayDetectionAudio()
    {
        sfxAudioSource.PlayOneShot(detectionAudio);
    }
    public void MusicSlider(float value)
    {
        musicAudioSource.volume=value;
        PlayerPrefs.SetFloat("MusicVolume", value);
        PlayerPrefs.Save();
    }
    public void SFXSlider(float value)
    {
        sfxAudioSource.volume=value;
        PlayerPrefs.SetFloat("SFXVolume", value);
        PlayerPrefs.Save();
    }
}
