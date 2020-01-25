using UnityEngine;

public class Trampoline : MonoBehaviour, IActivable
{
    [SerializeField] Vector2 jumpDirection = new Vector2(0, 0);

    PlayerController player;
    Animator animator;
    int _springAnimatorTrigger = Animator.StringToHash("Spring");

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Activate()
    {
        player.mover.BeginJump(jumpDirection);
        player = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.GetComponent<PlayerController>();
            animator.SetTrigger(_springAnimatorTrigger);
        }
    }
}
