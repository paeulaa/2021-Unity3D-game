using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public Animator animator; 
    public int maxHealth = 100;
    public int currentHealth;

    public playerHealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKey(KeyCode.D)){
        //     TakeDamage(5);
        // }
    }

    public void TakeDamage(int damage){
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        //animator.SetTrigger("Take Damage");
        if(currentHealth <= 0){
            animator.SetTrigger("Take Damage");
            Die();
        }
    }

    void Die(){
        Debug.Log("Enemy die");
        //Die animation
        animator.SetBool("isDead", true);
        //Destory enemy
        this.enabled = false;
        GetComponent<Collider>().enabled = false;

        Score.score = Score.score + 1;
        Destroy(gameObject);
    }

        
}
