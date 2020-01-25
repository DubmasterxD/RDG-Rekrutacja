using UnityEngine;

public class Actions : MonoBehaviour
{
    [SerializeField] AnimatorController animator = null;
    [SerializeField] Transform hand = null;

    Enemy target;
    Weapon equippedWeapon;

    public bool IsBusy()
    {
        return false;
    }

    public void EquipWeapon(Weapon newWeapon)
    {
        if (equippedWeapon != null)
        {
            equippedWeapon.Destroy();
        }
        equippedWeapon = newWeapon;
        equippedWeapon.Spawn(hand);
    }

    private void UnequipWeapon()
    {
        equippedWeapon.Destroy();
    }

    private void Attack(Enemy newTarget)
    {
        target = newTarget;
        animator.BeginAttack();
    }

    public void HitTarget()
    {
        equippedWeapon.Use();
        target.ReceiveHit();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Attack(other.GetComponent<Enemy>());
        }
    }
}
