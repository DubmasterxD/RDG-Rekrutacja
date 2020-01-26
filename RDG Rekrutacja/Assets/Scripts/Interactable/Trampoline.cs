using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField] Vector2 jumpDirection = new Vector2(0, 0);
    [SerializeField] Transform top = null;

    PlayerController player;
    Animator animator;
    int _springAnimatorTrigger = Animator.StringToHash("Spring");

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Activate()
    {
        player.ChangeParent(null);
        player.mover.BeginJump(jumpDirection);
        player = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.GetComponent<PlayerController>();
            player.ChangeParent(top);
            animator.SetTrigger(_springAnimatorTrigger);
        }
    }
}
