using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public float health;
    public GameObject dieEffect;
    //ranger
    public bool isSniper;
    public bool isRifle;
    private Vector3 startingPos;
    public bool isRanger;
    public GameObject bullet;
    public Transform bulletPos;


    public NavMeshAgent agent;  
    public Transform Player;
    public LayerMask GroundLayer, playerLayer;
    private Animator animator;
    private AudioSource audio;
    public AudioClip attackSound;

    //Patroling
    public Vector3 walkpoint;
    private bool walkpointSet;
    public float walkpointRange;

    //Attacking
    public float timeBetweenAttacks;
    private bool alreadyAttacked = false;

    //States
    public float sightRange, attackRange;
    private bool playerinSightrange, playerinAttackrange;

    private void Awake()
    {
        if (isRanger)
            audio = GetComponent<AudioSource>();
        agent = GetComponent<NavMeshAgent>();
        if (isRifle)
            startingPos = gameObject.transform.position;
        animator = GetComponent<Animator>();

    }

    private void Update()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        //Check for sight and attack range
        playerinSightrange = Physics.CheckSphere(transform.position, sightRange, playerLayer);
        playerinAttackrange = Physics.CheckSphere(transform.position, attackRange, playerLayer);
        if(!isSniper)
        {
            if (!playerinAttackrange && !playerinSightrange) Patroling();
            else if (!playerinAttackrange && playerinSightrange) ChasePlayer();
            else if (playerinAttackrange && playerinSightrange) AttackPlayer();
        }
        else
        {
            if (playerinAttackrange)
                AttackPlayer();
        }
        
    }
    public void takeDamage(float damage)
    {
        health -= damage;
        if(health<=0f)
        {
            Invoke(nameof(die),0.2f);
        }
    }
    private void die()
    {
        Instantiate(dieEffect, gameObject.transform.position + new Vector3(0, 3, 0), Quaternion.LookRotation(gameObject.transform.position));
        Destroy(gameObject);
    }
    private void Patroling()
    {
        if(!isRifle)
        {
            if (!walkpointSet) newWalkpoint();
            if (walkpointSet)
                agent.SetDestination(walkpoint);
            Vector3 distanceToWalkpoint = transform.position - walkpoint;
            if (distanceToWalkpoint.magnitude < 1f)
                walkpointSet = false;
        }
        else
        {
            agent.SetDestination(startingPos);
            animator.SetBool("chase", false);
        }
    }
    private void newWalkpoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkpointRange, walkpointRange);
        float randomX = Random.Range(-walkpointRange, walkpointRange);
        walkpoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if (Physics.Raycast(walkpoint, -transform.up, 2f, GroundLayer))
            walkpointSet = true;
    }
    private void ChasePlayer()
    {
        if (isRifle)
            animator.SetBool("chase", true);
        Invoke(nameof(stopAttackAnim), 1);
        agent.SetDestination(Player.position);
    }
    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        animator.SetBool("attack", true);
        if (isRanger)
            transform.LookAt(Player.transform.position + new Vector3(0, 0, 0));
        if (!alreadyAttacked)
        {
            //Attack
            if (isRanger)
            {
                audio.clip = attackSound;
                audio.Play();
                animator.SetBool("attack", true);
                Rigidbody rb = Instantiate(bullet, bulletPos.position, Quaternion.identity).GetComponent<Rigidbody>();
                rb.AddForce(((Player.transform.position-new Vector3(0,1,0)) - transform.position).normalized * 32f, ForceMode.Impulse);

            }
            alreadyAttacked = true;
            Invoke(nameof(resetAttack), timeBetweenAttacks);
        }
    }
    private void stopAttackAnim()
    {
        animator.SetBool("attack", false);
    }
    private void resetAttack()
    {
        alreadyAttacked = false;
    }
}
