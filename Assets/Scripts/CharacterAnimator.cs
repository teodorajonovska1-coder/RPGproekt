using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimator : MonoBehaviour
{
    const float locomationAnimationSmoothTime = .1f;

    protected NavMeshAgent agent;
    protected Animator animator;
    CharacterCombat combat;

    protected virtual void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();

        combat = GetComponent<CharacterCombat>();
        if (combat != null)
        {
            combat.OnAttack += OnAttack;
        }
    }

    protected virtual void Update()
    {
        if (agent == null || animator == null) return;

        float speedPercent = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("speedPercent", speedPercent, locomationAnimationSmoothTime, Time.deltaTime);
    }

    protected virtual void OnAttack()
    {
        if (animator != null)
        {
            animator.SetTrigger("Attack");
        }
    }
}