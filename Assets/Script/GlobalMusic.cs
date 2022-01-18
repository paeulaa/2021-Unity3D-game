using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalMusic : MonoBehaviour
{
    private AudioSource audioSource;
    //public AudioClip clip;
    public List<AudioClip> clipList;
    public int musicIndex = 0;
    // public GameObject menu;
    // public GameObject info;
    // public Text content;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameObject.Find("Audio Source").GetComponent<AudioSource>();
        PlayMusicClip();
        DontDestroyOnLoad(this.gameObject);
    }

    public void PlayMusicClip()
    {
        //audioSource.Stop(); //先取消正在撥放的音樂再撥放新的
        audioSource.clip = clipList[musicIndex];
        //audioSource.clip = clip;
        audioSource.Play();
    }

    public void ChangeMusicIndex(int idx)
    {
        audioSource.Stop();
        musicIndex = idx;
        PlayMusicClip();
    }

    public void ModifyVolume(float vol)
    {
        audioSource.volume = vol;
    }

    public void Pause(){
        audioSource.Pause();
    }
    public void Resume(){
        audioSource.Play();
    }
    // Update is called once per frame
    // void Update()
    // {
        
    // }
}
