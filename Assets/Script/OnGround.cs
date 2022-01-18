using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGround : MonoBehaviour
{
    private bool m_isGround;
    public GameObject floor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public bool is_Grounded(){
        return m_isGround;
    }

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.gameObject.name == floor.name){
            m_isGround = true;
        }
    }

    private void OnCollisionExit(Collision collisionInfo)
    {
         if(collisionInfo.gameObject.name == floor.name){
            m_isGround = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
