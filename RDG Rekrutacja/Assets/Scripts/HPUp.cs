using UnityEngine;

public class HPUp : MonoBehaviour
{
    [SerializeField] Trigger rotateTrigger = null;
    [SerializeField] Trigger resetTrigger = null;

    Animator animator;
    int _rotateAinmatorTrigger = Animator.StringToHash("Rotate");
    int _resetAnimatorTrigger = Animator.StringToHash("Reset");

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rotateTrigger.onTriggerEnter += BeginRotating;
        resetTrigger.onTriggerEnter += StopRotating;
    }

    private void BeginRotating()
    {
        animator.SetTrigger(_rotateAinmatorTrigger);
        animator.ResetTrigger(_resetAnimatorTrigger);
    }

    private void StopRotating()
    {
        animator.SetTrigger(_resetAnimatorTrigger);
    }
}
