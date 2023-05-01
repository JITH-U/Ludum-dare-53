using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform player;
    private Animator animator;
    float distance;
    [SerializeField] float attackOffset;
    [SerializeField] AudioSource attackSFX;
    [SerializeField] float zombieSpeed;
    // Start is called before the first frame update
    void Start()
    {
        animator= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
       

        distance =Vector3.Distance(player.transform.position,enemy.transform.position);
       // print(distance);
        if (distance < 5)
        {
            if(animator.GetBool("isAttacking")==true)
            {
                animator.SetBool("isAttacking", false);
            }
            if(animator.GetBool("isDead")==false) animator.SetBool("isDead", true);
            if(attackSFX.isPlaying)
            {
                attackSFX.Stop();
            }
            Invoke("DisablingObj",1f);
        }
        // print(distance);
        if (distance<=enemy.stoppingDistance+attackOffset)
        {
            
            transform.LookAt(player.transform.position);
            animator.SetBool("isAttacking", true);
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                if (!attackSFX.isPlaying)
                {
                    attackSFX.PlayDelayed(0.02f);
                }

            }
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }

        enemy.SetDestination(player.transform.position);
    }
    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);    
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject==GameObject.FindGameObjectWithTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }

    void DisablingObj()
    {
        gameObject.SetActive(false);
    }
}
