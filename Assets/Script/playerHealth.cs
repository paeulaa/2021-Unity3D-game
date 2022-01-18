using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public int maxHealth = 500;
    public int currentHealth;
    public Animator animator;
    public AudioClip clip;
    private AudioSource audioSource;
     public GameObject effect;
    public Transform player;

    public playerHealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        audioSource = GameObject.Find("Player_s").GetComponent<AudioSource>();
        audioSource.clip = clip;
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKey(KeyCode.D)){
        //     TakeDamage(5);
        // }
    }

    public void TakeDamage(int damage){
        audioSource.Play();
        Instantiate(effect, player.position, player.rotation);
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if(currentHealth <= 0){
            animator.SetTrigger("Take Damage");
            Die();
        }
    }

    void Die(){
        Debug.Log("player die");
        SceneManager.LoadScene("Gameover"); 
        // //Die animation
        // animator.SetBool("isDead", true);
        // //Destory enemy
        // this.enabled = false;
        // GetComponent<Collider>().enabled = false;
    }
}
