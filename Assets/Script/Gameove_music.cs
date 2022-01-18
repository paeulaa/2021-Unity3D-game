using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gameove_music : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameObject.Find("Audio Source").GetComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.Play();
        audioSource.loop = false;
    }

    
}
