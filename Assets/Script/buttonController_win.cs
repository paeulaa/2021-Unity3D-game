using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class buttonController_win : MonoBehaviour
{
    public void OnLoginButtonCLick(){
        SceneManager.LoadScene("menu"); 
    }
}
