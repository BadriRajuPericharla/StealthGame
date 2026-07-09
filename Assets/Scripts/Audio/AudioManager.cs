using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField]private AudioClip buttonClick;
    [SerializeField]private AudioClip enemyAttack;
    [SerializeField]private AudioClip playerAttack;
    [SerializeField]private AudioClip doorOpen;
    [SerializeField]private AudioClip keyCollection;
    [SerializeField]private AudioClip treasureOpening;
    [SerializeField]private AudioClip normalPlayerAttack;
    AudioSource audioSource;
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
        audioSource=GetComponent<AudioSource>();
    }
    public void PlayButtonClick()
    {
        audioSource.PlayOneShot(buttonClick);
    }
    public void PlayEnemyAttack()
    {
        audioSource.PlayOneShot(enemyAttack);
    }
    public void PlayPlayerAttack()
    {
        audioSource.PlayOneShot(playerAttack);
    }
    public void PlayDoorOpen()
    {
        audioSource.PlayOneShot(doorOpen);
    }
    public void PlayKeyCollection()
    {
        audioSource.PlayOneShot(keyCollection);
    }
    public void PlayTreasureOpening()
    {
        audioSource.PlayOneShot(treasureOpening);
    }
    public void NormalPlayerAttack()
    {
        audioSource.PlayOneShot(normalPlayerAttack);
    }
}
