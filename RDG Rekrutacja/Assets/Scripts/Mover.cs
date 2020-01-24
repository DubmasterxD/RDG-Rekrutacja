using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] AnimatorController animator = null;
    [SerializeField] Transform player = null;

    float timer = 0;
    public bool canWalk = true;
    bool isWall = false;
    bool isWalking = false;
    bool isTurning = false;
    public float nextGroundHeight = 1;

    private void Update()
    {
        timer += Time.deltaTime;
        if (isWalking)
        {
            Walk();
        }
        if (isTurning)
        {
            TurnLeft();
        }
    }

    public void Move()
    {
        if (CanWalk())
        {
            canWalk = false;
            BeginWalk();
        }
        else
        {
            BeginTurn();
        }
    }

    private void Walk()
    {
        if (timer < 1)
        {
            player.Translate(new Vector3(0, 0, Time.deltaTime));
        }
        else
        {
            isWalking = false;
            animator.ToggleWalk(isWalking);
        }
    }

    public void TurnLeft()
    {
        if (timer < 1)
        {
            player.localRotation = Quaternion.Euler(0, player.localRotation.eulerAngles.y - 90 * Time.deltaTime, 0);
        }
        else
        {
            isTurning = false;
        }
    }

    public bool IsBusy()
    {
        return isTurning || isWalking;
    }

    public void BeginWalk()
    {
        timer = 0;
        isWalking = true;
        animator.ToggleWalk(isWalking);
    }

    public void BeginTurn()
    {
        timer = 0;
        isTurning = true;
        //animator.BeginTurnLeft();
    }

    private void OnTriggerEnter(Collider other)
    {
        Ground ground = other.gameObject.GetComponent<Ground>();
        if (ground != null && ground.isAccessible)
        {
            canWalk = true;
            nextGroundHeight = other.gameObject.transform.position.y;
        }
        if (other.CompareTag("Wall"))
        {
            isWall = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            isWall = false;
        }
    }

    public bool CanWalk()
    {
        return canWalk && !isWall;
    }
}
