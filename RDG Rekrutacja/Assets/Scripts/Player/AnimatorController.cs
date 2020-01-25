﻿using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    [SerializeField] Actions actions = null;

    Animator animator;
    int _isWalkingAnimatorBool = Animator.StringToHash("isWalking");
    int _attackAnimatorTrigger = Animator.StringToHash("Attack");
    int _turnLeftAnimatorTrigger = Animator.StringToHash("TurnLeft");
    int _jumpAnimatorTrigger = Animator.StringToHash("Jump");

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void ToggleWalk(bool isWalking)
    {
        animator.SetBool(_isWalkingAnimatorBool, isWalking);
    }

    public void BeginAttack()
    {
        animator.SetTrigger(_attackAnimatorTrigger);
    }

    public void BeginTurnLeft()
    {
        animator.SetTrigger(_turnLeftAnimatorTrigger);
    }

    public void BeginJump()
    {
        animator.SetTrigger(_jumpAnimatorTrigger);
    }

    //Received from animation events

    public void Hit()
    {
        actions.HitTarget();
    }
}