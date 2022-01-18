using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class buttonContoller : MonoBehaviour
{
    public void OnLoginButtonCLick(){
        SceneManager.LoadScene("story"); 
    }
}
