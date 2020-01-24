using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    [SerializeField] Actions actions = null;

    Animator animator;
    int _isWalkingAnimatorBool = Animator.StringToHash("isWalking");
    int _attackAnimatorTrigger = Animator.StringToHash("Attack");
    int _turnLeftAnimatorTrigger = Animator.StringToHash("TurnLeft");

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

    //Received from animation events

    public void Hit()
    {
        actions.HitTarget();
    }
}
