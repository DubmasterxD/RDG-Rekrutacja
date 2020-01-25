using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] bool isAccessible = true;
    [SerializeField] bool canTurn = false;

    public bool IsAccessible()
    {
        return isAccessible;
    }

    public bool CanTurn()
    {
        return canTurn;
    }
}
