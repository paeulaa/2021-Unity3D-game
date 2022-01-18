using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController_2 : MonoBehaviour
{
    public float lookRadius = 10f;
    public float attackRadius = 2f;
    public int attackDamage = 40;
    public GameObject player;
    public AudioClip clip;
    public GameObject effect;
    public Transform dragon;

    private AudioSource audioSource;
    Transform target;
    NavMeshAgent agent;
    private Animator m_animator;
    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        m_animator = gameObject.GetComponent<Animator>();
        audioSource = GameObject.Find("dragon_s").GetComponent<AudioSource>();
        audioSource.clip = clip;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if(distance <= lookRadius){
            agent.SetDestination(target.position);
            //Attack();

            if(distance <= agent.stoppingDistance){
                //attack target
                Attack();
                //face target
                Facetarget();
            }
        }

        if(agent.velocity.magnitude < 0.4f && m_animator != null){
            m_animator.SetFloat("Speed", 0.0f);
        }else{
            m_animator.SetFloat("Speed", 5.0f);
        }
    }
    void Facetarget(){
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f); 
    }
    void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
    void Attack(){
        m_animator.SetTrigger("Attack");
        audioSource.Play();
        player.GetComponent<playerHealth>().TakeDamage(attackDamage);
        Instantiate(effect, dragon.position, dragon.rotation);
       
    }
}
