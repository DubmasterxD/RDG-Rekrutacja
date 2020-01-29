using RDGRekru.Combat;
using UnityEngine;

namespace RDGRekru.Player
{
    public class Fighter : MonoBehaviour
    {
        [SerializeField] AnimatorController animator = null;
        [SerializeField] Transform hand = null;

        Enemy target;
        Weapon equippedWeapon;

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
            equippedWeapon = null;
        }

        private void Attack(Enemy newTarget)
        {
            target = newTarget;
            animator.BeginAttack();
        }

        public void HitTarget()
        {
            equippedWeapon.Use();
            if (equippedWeapon.GetUsagesLeft() <= 0)
            {
                UnequipWeapon();
            }
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
}