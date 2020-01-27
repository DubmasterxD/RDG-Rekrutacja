using UnityEngine;

public class MovingEnemy : MonoBehaviour
{
    [SerializeField] Trigger startMovingTrigger = null;
    [SerializeField] Trigger stopMovinfTrigger = null;
    [SerializeField] int repeatMove = 2;
    [SerializeField] Transform body = null;

    int movesLeft = 0;

    Animator animator;
    int _startAnimatorTrigger = Animator.StringToHash("Start");
    int _stopAnimatorTrigger = Animator.StringToHash("Stop");
    int _nextMoveAnimatorTrigger = Animator.StringToHash("NextMove");

    private void Awake()
    {
        animator = GetComponent<Animator>();
        startMovingTrigger.onTriggerEnter += StartMovement;
        stopMovinfTrigger.onTriggerEnter += StopMovement;
        movesLeft = repeatMove;
    }

    private void StartMovement()
    {
        animator.SetTrigger(_startAnimatorTrigger);
        animator.ResetTrigger(_stopAnimatorTrigger);
    }

    private void StopMovement()
    {
        animator.SetTrigger(_stopAnimatorTrigger);
        animator.ResetTrigger(_startAnimatorTrigger);
    }

    private void DoNextMove()
    {
        animator.SetTrigger(_nextMoveAnimatorTrigger);
    }

    public void FinishedMoving()
    {
        movesLeft--;
        if (movesLeft <= 0)
        {
            movesLeft = repeatMove;
            DoNextMove();
        }
    }

    public void MovedFront()
    {
        transform.Translate(new Vector3(0, 0, 1));
    }

    public void MovedBack()
    {
        transform.Translate(new Vector3(0, 0, -1));
    }
}
