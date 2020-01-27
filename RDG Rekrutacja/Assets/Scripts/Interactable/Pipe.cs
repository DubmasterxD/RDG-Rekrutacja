using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] Transform exit = null;
    [SerializeField] Transform entrance = null;
    [SerializeField] int middleSegments = 1;

    PlayerController player;
    Animator animator;
    int _enterAnimatorTrigger = Animator.StringToHash("Enter");

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Switch()
    {
        player.ChangeParent(exit);
        player.transform.Translate(new Vector3(0, -middleSegments - 1, 0));
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
            player.animator.PipeIn();
            animator.SetTrigger(_enterAnimatorTrigger);
        }
    }
}
