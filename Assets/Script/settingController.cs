using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class settingController : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject GlobalMusic;
    private int count = 1;

    public AudioSource audioSource;
    Canvas settingCanvas;
    GameObject sceneMusic;
    // Start is called before the first frame update
    void Start()
    {
        settingCanvas = GameObject.Find("Canvas_setting").GetComponent<Canvas>();
        settingCanvas.enabled = false;
        audioSource = GameObject.Find("Audio Source").GetComponent<AudioSource>();
        sceneMusic = GameObject.FindGameObjectWithTag("GlobalMusic"); 
        if(sceneMusic == null){
            sceneMusic = (GameObject)Instantiate(GlobalMusic);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void printMessage()
    {
        print("print buttton");
    }

    public void ShowCanvas()
    {
        settingCanvas.enabled = true;
    }

    public void HideCanvas()
    {
       settingCanvas.enabled = false; 
    }
    public void OnLoginButtonCLick(){
        SceneManager.LoadScene("menu"); 
    }

    public void Pause(){
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume(){
        //pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void SetQuality(int q_index){
        QualitySettings.SetQualityLevel(q_index);
    }
    public void ChangeMusic(int index){
        count = count + index;
        if(count%2 == 0){
            audioSource.GetComponent<MusicControl>().ModifyMusicB(); 
        }else{
            audioSource.GetComponent<MusicControl>().ModifyMusicA(); 
        }
    }
}
