using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaterStats : MonoBehaviour
{
   public int maxHealth = 100;
   public int currentHealth {get; private set;}

   public Stats damage; 

   void Awake(){
       currentHealth = maxHealth;
   }

   void Updata(){
       if(Input.GetKeyDown(KeyCode.T)){
           TakeDamage(10);
       }
   }
   public void TakeDamage(int damage){
       currentHealth -= damage;
       Debug.Log(transform.name + "takes" + damage + "damages.");

       if(currentHealth <= 0){
           Die();
       }
   }
   public virtual void Die(){
       Debug.Log(transform.name + "died.");
   }
}


