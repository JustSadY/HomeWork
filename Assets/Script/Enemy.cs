using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : GetStats
{
    private NavMeshAgent _agent;
    private bool enableAttack;
    private bool walkPlayer = true;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _Rigidbody = GetComponent<Rigidbody>();
        _Animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _agent.speed = GetSpeed();
    }

    private void Update()
    {
        if (Die()) return;
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        if (walkPlayer)
        {
            _Animator.SetBool("attackEnable", false);
            _Animator.SetBool("Moving", true);
            _agent.SetDestination(PlayerController.playerLocation);
        }
        else
        {
            _Animator.SetBool("Moving", false);
            _Animator.SetBool("attackEnable", true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            walkPlayer = false;
            enableAttack = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            walkPlayer = true;
            enableAttack = false;
        }
    }

    public new void TakingDamage(float damage)
    {
        base.TakingDamage(damage);
        if (Die()) StartCoroutine(OnDeath());
    }

    private IEnumerator OnDeath()
    {
        _Animator.SetBool("Death", true);
        _agent.isStopped = true;
        this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
        if (GameObject.FindWithTag("Script") != null)
            GameObject.FindWithTag("Script").GetComponent<EnemySpawner>().EnemyDie();
        yield return new WaitForSeconds(10f);
        Destroy(this.gameObject);
    }

    private void Attack()
    {
        if (enableAttack)
        {
            GameObject.FindWithTag("Player").gameObject.GetComponent<PlayerController>().TakingDamage(GetDamage());
        }
    }
}