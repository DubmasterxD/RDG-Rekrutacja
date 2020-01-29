using RDGRekru.Combat;
using RDGRekru.Core;
using UnityEngine;

namespace RDGRekru.Player
{
    public class WeaponPickup : MonoBehaviour
    {
        [SerializeField] Weapon weapon = null;
        [SerializeField] Trigger spawnTrigger = null;

        private void Start()
        {
            spawnTrigger.onTriggerEnter += Spawn;
        }

        private void Spawn()
        {
            gameObject.SetActive(true);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && weapon != null)
            {
                other.gameObject.GetComponent<PlayerController>().fighter.EquipWeapon(weapon);
                gameObject.SetActive(false);
            }
        }
    }
}