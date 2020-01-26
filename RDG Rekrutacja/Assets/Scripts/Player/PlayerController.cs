using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Actions actions { get; private set; }
    public Mover mover { get; private set; }

    Collider collider;
    
    private void Awake()
    {
        actions = GetComponentInChildren<Actions>();
        mover = GetComponentInChildren<Mover>();
        collider = GetComponent<Collider>();
    }

    private void Update()
    {
        if (!IsBusy())
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                mover.BeginMove();
            }
        }
    }

    private bool IsBusy()
    {
        return actions.IsBusy() || mover.IsBusy();
    }

    public void ChangeParent(Transform newParent)
    {
        transform.parent = newParent;
    }

    public void ToggleCollider(bool isEnabled)
    {
        collider.enabled = isEnabled;
    }
}
