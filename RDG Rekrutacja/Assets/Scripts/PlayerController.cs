using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Actions actions;
    Mover mover;

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
                mover.Move();
            }
        }
    }

    private bool IsBusy()
    {
        return actions.IsBusy() || mover.IsBusy();
    }
}
