using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animator;
    [SerializeField] Transform player;
    [SerializeField] LayerMask bossGround, ktoToPlayer;

    [SerializeField] float timeBetweenAttacks;
    bool alreadyAttacked;

    [SerializeField] float sightRange, attackRange;
    bool playerInSightRange, playerInAttackRange;

    [SerializeField] double hp = 200;
    

    [SerializeField] GameObject bossSpell;

    Vector2 smoothDeltaPosition;
    Vector2 velocity;

    string naame = "locomotion";

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        double bossmaxhp = hp;
    }

    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, ktoToPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, ktoToPlayer);

        if (playerInSightRange && !playerInAttackRange)
            Chase();
    }

    void Chase()
    {
        agent.isStopped = false;
        agent.SetDestination(player.position);
       // Debug.Log("Chasing player at position: " + player.position);
    }

    private void OnAnimatorMove()
    {
        if (agent.remainingDistance > agent.stoppingDistance)
        {
            Vector3 worldDeltaPosition = agent.velocity * Time.deltaTime;
            Vector3 localDeltaPosition = transform.InverseTransformVector(worldDeltaPosition);

            smoothDeltaPosition = Vector2.Lerp(smoothDeltaPosition, new Vector2(localDeltaPosition.x, localDeltaPosition.z), 0.5f);
            velocity = smoothDeltaPosition / Time.deltaTime;

            animator.SetFloat("locomotion", velocity.magnitude);
            animator.SetFloat(naame, velocity.magnitude);
            Debug.Log(velocity.magnitude);

            transform.position += worldDeltaPosition;
        }
        else
        {
            animator.SetFloat("locomotion", 0f);
            animator.SetFloat(naame, 0f);
        }
    }

}