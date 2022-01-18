using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Stage_script : MonoBehaviour
{
    public Transform stage;
    public Transform player;
    public float lookRadius = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.position, stage.position);
        if(distance <= lookRadius){
            SceneManager.LoadScene("Win");
        } 
    }
     void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(stage.position, lookRadius);
    }
}
