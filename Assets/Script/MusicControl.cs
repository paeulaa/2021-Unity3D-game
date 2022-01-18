using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{
    public GameObject GlobalMusic;
    GameObject sceneMusic;
    // Start is called before the first frame update
    void Start()
    {
        sceneMusic = GameObject.FindGameObjectWithTag("GlobalMusic");
        if(sceneMusic == null){
            sceneMusic = (GameObject)Instantiate(GlobalMusic);
        }
    }


    public void ModifyPause()
    {
        sceneMusic.GetComponent<GlobalMusic>().Pause();
    }

     public void ModifyResume()
    {
        sceneMusic.GetComponent<GlobalMusic>().Resume();
    }
    public void ModifyMusicA()
    {
        sceneMusic.GetComponent<GlobalMusic>().ChangeMusicIndex(0);
    }
     public void ModifyMusicB()
    {
        sceneMusic.GetComponent<GlobalMusic>().ChangeMusicIndex(1);
    }
    // public void ModifyVolume(float vol)
    // {
    //     sceneMusic.volume = vol;
    // }
}
