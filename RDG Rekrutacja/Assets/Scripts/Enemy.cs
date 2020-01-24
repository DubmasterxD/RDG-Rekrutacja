using UnityEngine;

public class Enemy : MonoBehaviour
{
    public void ReceiveHit()
    {
        Die();
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
