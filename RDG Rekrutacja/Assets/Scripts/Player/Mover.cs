using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] AnimatorController animator = null;
    [SerializeField] Transform player = null;

    float timer = 0;
    bool canWalk = false;
    bool canTurn = false;
    bool isWall = false;
    bool isWalking = false;
    bool isTurning = false;
    bool isJumping = false;
    Vector2 jumpDirection = new Vector2(0, 0);
    float nextGroundHeight = 1;
    Ground nextGround = null;

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
        if (isJumping)
        {
            Jump(jumpDirection);
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

    private void TurnLeft()
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

    private void Jump(Vector2 direction)
    {
        if (timer < 1)
        {
            player.Translate(new Vector3(0, direction.y * Time.deltaTime, direction.x * Time.deltaTime));
        }
        else
        {
            player.Translate(new Vector3(0, 1, 1));
            isJumping = false;
        }
    }

    public bool IsBusy()
    {
        return isTurning || isWalking || isJumping;
    }

    public void BeginMove()
    {
        if (CanWalk())
        {
            BeginWalk();
        }
        else if (CanJump())
        {
            BeginJump(new Vector2(1, 1));
        }
        else if (canTurn)
        {
            BeginTurn();
        }
    }

    private bool CanWalk()
    {
        return canWalk && !isWall;
    }

    private bool CanJump()
    {
        return transform.position.y < nextGroundHeight && !isWall;
    }

    private void BeginWalk()
    {
        timer = 0;
        isWalking = true;
        animator.ToggleWalk(isWalking);
    }

    private void BeginTurn()
    {
        timer = 0;
        isTurning = true;
        //animator.BeginTurnLeft();
    }

    public void BeginJump(Vector2 direction)
    {
        timer = 0;
        jumpDirection = new Vector2(direction.x - 1, direction.y - 1);
        isJumping = true;
        animator.BeginJump();
    }

    private void OnTriggerEnter(Collider other)
    {
        Ground ground = other.gameObject.GetComponent<Ground>();
        if (ground != null)
        {
            nextGround = ground;
            canTurn = ground.CanTurn();
            if (ground.IsAccessible())
            {
                nextGroundHeight = other.gameObject.transform.position.y;
                if (nextGroundHeight < transform.position.y && nextGroundHeight > transform.position.y - .5f)
                {
                    canWalk = true;
                }
                else
                {
                    canWalk = false;
                }
            }
            else
            {
                canWalk = false;
                nextGroundHeight = Mathf.NegativeInfinity;
            }
        }
        if (other.CompareTag("Wall"))
        {
            isWall = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Ground ground = other.gameObject.GetComponent<Ground>();
        if (ground != null && ground == nextGround)
        {
            canWalk = false;
            nextGroundHeight = Mathf.NegativeInfinity;
        }
        if (other.CompareTag("Wall"))
        {
            isWall = false;
        }
    }
}
