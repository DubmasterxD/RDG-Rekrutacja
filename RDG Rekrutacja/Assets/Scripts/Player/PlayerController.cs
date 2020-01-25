using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Actions actions { get; private set; }
    public Mover mover { get; private set; }

    private void Awake()
    {
        actions = GetComponentInChildren<Actions>();
        mover = GetComponentInChildren<Mover>();
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
}
