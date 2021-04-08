using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FiniteStateMachine;
using UnityEngine.AI;

public class PeasantManAI : MonoBehaviour
{
    [SerializeField]private States state = States.CHASE;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject player;
    [SerializeField]private float maxDistanceToTarget = 2f;
    private bool IsAttacking = false;
    


    // Update is called once per frame
    private void Update()
    {
        switch (state)
        {
            case States.CHASE:
                Chase();
                break;
            case States.ATTACK:
                Attack();
                break;
            default:
                break;
        }
    }

    private void Chase()
    {
        SetDestination(player.transform.position);
        float distanceToTarget = Vector3.Distance(gameObject.transform.position, player.transform.position);

        if (distanceToTarget <= 2f)
        {
            agent.isStopped = true;
            SetState(States.ATTACK);
        }
    }

    private void Attack()
    {
        float distanceToTarget = Vector3.Distance(gameObject.transform.position, player.transform.position);
        IsAttacking = true;
        anim.SetBool("IsAttacking", true);

        if (distanceToTarget > 2f)
            SetState(States.CHASE);

        Wolf.Instance.IsCaught = true;
    }

    private void SetDestination(Vector3 targetVector)
    {
        agent.SetDestination(targetVector);
    }


    private void SetState(States newState)
    {
        state = newState;
    }
}

namespace FiniteStateMachine
{
    public enum States
    {
        CHASE,
        ATTACK
    }
}


