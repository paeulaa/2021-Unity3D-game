using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    public float forwardSpeed = 7.0f ;
    public float backwardSpeed = 2.0f;
    public float rotateSpeed = 2.0f;
    public float jumpPower = 8.0f;
    public float useCurveHeight = 0.5f;
    public int attackDamage = 40;
    public Transform attackPoint;
    public float attackRange = 0.05f;
    public LayerMask enemyLayers;
    public AudioClip clip;
    public GameObject effect;

    private AudioSource audioSource;
    private Animator m_animator;
    private Rigidbody m_rb;
    private CapsuleCollider m_col;

    private int idleState;
    private int walkState;
    private int runState;
    private int jumpState;
    private int attackState;
    private float m_origColliderHeight;
    private Vector3 m_origColliderCenter;
    // Start is called before the first frame update
    void Start()
    {
        m_animator = gameObject.GetComponent<Animator>();
        m_rb = gameObject.GetComponent<Rigidbody>();
        audioSource = GameObject.Find("Battle").GetComponent<AudioSource>();
        audioSource.clip = clip;
       
        //Get state Hash
        idleState = Animator.StringToHash("Base Layer.Idle");
        walkState = Animator.StringToHash("Base Layer.Walk");
        runState = Animator.StringToHash("Base Layer.Run");  
        jumpState = Animator.StringToHash("Base Layer.Jump");
        //attack state
        attackState = Animator.StringToHash("Base Layer.Attack");

        //adjust collider
        m_col = gameObject.GetComponent<CapsuleCollider>();
        m_origColliderHeight = m_col.height;
        m_origColliderCenter = m_col.center;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        bool lockMoving = false;

        m_animator.SetFloat("Speed", v);
        // m_animator.SetFloat("Direction", h);
        Vector3 velocity = new Vector3(0.0f, 0.0f, v);

        gameObject.transform.Rotate(0, h * rotateSpeed, 0);
            
        if (v < -0.1)
        {
            gameObject.transform.Translate(velocity * backwardSpeed * Time.fixedDeltaTime);
        }
        else if (v > 0.1)
        {
            gameObject.transform.Translate(velocity * forwardSpeed * Time.fixedDeltaTime);
        }

         //Get Animatior initial State
        AnimatorStateInfo state = m_animator.GetCurrentAnimatorStateInfo(0);
        //Enemy = GameObject.FindGameObjectWithTag("Enemy");

        //if now is in locomotion
        if(state.fullPathHash == runState || state.fullPathHash == idleState || state.fullPathHash == walkState){
            if(Input.GetKey(KeyCode.Space)){
                bool isGround = gameObject.gameObject.GetComponent<OnGround>().is_Grounded();
                //if(!m_animator.IsInTransition(0) && isGround){
                if(isGround){
                    m_animator.SetBool("Jump", true);
                    m_rb.AddForce(Vector3.up* jumpPower, ForceMode.VelocityChange);
                }
            }
            else if(Input.GetKey(KeyCode.X)){
                m_animator.SetBool("Attack", true);
                Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);
                foreach(Collider enemy in hitEnemies){
                    enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
                    Instantiate(effect, attackPoint.position, attackPoint.rotation);
                    audioSource.Play();
                }
            }
        }else if(state.fullPathHash == jumpState){
            m_animator.SetBool("Jump", false);

            if(Input.GetKey(KeyCode.X)){
                m_animator.SetBool("Attack", true);
                Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);
                foreach(Collider enemy in hitEnemies){
                    enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
                    Instantiate(effect, attackPoint.position, attackPoint.rotation);
                    audioSource.Play();
                }
            }
            //in jump state, adjusting collider's position
            this.adjustCollider();
        }
        else if(state.fullPathHash == attackState){
            m_animator.SetBool("Attack", false);
            lockMoving = true;
        }
    }

    public void adjustCollider(){
        //Get current model height
        Ray ray = new Ray(gameObject.transform.position, -Vector3.up);
        RaycastHit hitInfo = new RaycastHit();
        
        //If the height is too large, use curve to adjust
        if(Physics.Raycast(ray, out hitInfo)){
            if(hitInfo.distance > useCurveHeight){
                float jumpHeight = m_animator.GetFloat("JumpGeight");
                //adjust collider's height
                m_col.height = m_origColliderHeight - jumpHeight;
                //adjust collider's center
                float adjCenterY = m_origColliderCenter.y + jumpHeight;
                m_col.center = new Vector3(0, adjCenterY, 0);
            }else{
                m_col.height = m_origColliderHeight;
                m_col.center = m_origColliderCenter;
            }
        }
    }  

     void OnDrawGizmosSelected() 
    {
        if(attackPoint == null){
            return;
        }
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
