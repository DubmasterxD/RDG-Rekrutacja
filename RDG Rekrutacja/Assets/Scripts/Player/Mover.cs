using RDGRekru.Environment;
using UnityEngine;

namespace RDGRekru.Player
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] AnimatorController animator = null;
        [SerializeField] Transform player = null;
        [SerializeField] float yPositionOffset = 0.148f;

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
                Reposition();
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
                Reposition();
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
                Reposition();
            }
        }

        public void Reposition()
        {
            Vector3 newPosition = player.localPosition;
            newPosition.x = Round(newPosition.x, 1);
            newPosition.y = Round(newPosition.y - yPositionOffset, 1) + yPositionOffset;
            newPosition.z = Round(newPosition.z, 1);
            player.localPosition = newPosition;

            Vector3 newRotation = player.localRotation.eulerAngles;
            newRotation.x = Round(newRotation.x, 90);
            newRotation.y = Round(newRotation.y, 90);
            newRotation.z = Round(newRotation.z, 90);
            player.localRotation = Quaternion.Euler(newRotation);
        }

        private float Round(float value, float precision)
        {
            float reminder = value % precision;
            value -= reminder;
            if (value >= 0 && reminder > precision / 2)
            {
                value += precision;
            }
            else if (value <= 0 && reminder < -precision / 2)
            {
                value -= precision;
            }
            return value;
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
}