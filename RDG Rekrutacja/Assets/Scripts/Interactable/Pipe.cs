using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] Transform exit = null;
    [SerializeField] Transform entrance = null;
    [SerializeField] int middleSegments = 1;

    PlayerController player;
    Animator animator;
    int _enterAnimatorTrigger = Animator.StringToHash("Enter");
    int _exitAnimatorTrigger = Animator.StringToHash("Exit");

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Switch()
    {
        player.ChangeParent(exit);
        player.transform.Translate(new Vector3(0, -middleSegments - 1, 0));
        animator.SetTrigger(_exitAnimatorTrigger);
    }

    public void End()
    {
        player.ToggleCollider(true);
        player.ChangeParent(null);
        player.mover.Reposition();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.GetComponent<PlayerController>();
            player.ChangeParent(entrance);
            player.ToggleCollider(false);
            animator.SetTrigger(_enterAnimatorTrigger);
        }
    }
}
