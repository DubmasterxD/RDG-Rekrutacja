using UnityEngine;

public class TextBlink : MonoBehaviour
{
    [SerializeField] Trigger blinkTrigger = null;

    Animator animator;
    int _blinkAnimatorState = Animator.StringToHash("Blink");

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        blinkTrigger.onTriggerEnter += Blink;
    }

    private void Blink()
    {
        animator.Play(_blinkAnimatorState, 0, 0);
    }
}
