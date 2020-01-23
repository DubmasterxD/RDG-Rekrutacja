using UnityEngine;

public class PlayerFeet : MonoBehaviour
{
    public bool canWalk = true;
    public float nextGroundHeight = 1;

    private void OnTriggerEnter(Collider other)
    {
        Ground ground = other.gameObject.GetComponent<Ground>();
        if (ground != null && ground.isAccessible)
        {
            canWalk = true;
            nextGroundHeight = other.gameObject.transform.position.y;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Ground ground = other.gameObject.GetComponent<Ground>();
        if (ground != null)
        {
            canWalk = false;
        }
    }
}
