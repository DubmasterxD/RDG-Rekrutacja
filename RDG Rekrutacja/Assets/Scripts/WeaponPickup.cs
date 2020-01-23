using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public Weapon weapon;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && weapon!=null)
        {
            other.gameObject.GetComponent<PlayerController>().EquipWeapon(weapon);
            gameObject.SetActive(false);
        }
    }
}
