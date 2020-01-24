using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public Weapon weapon;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && weapon!=null)
        {
            other.gameObject.GetComponentInChildren<Actions>().EquipWeapon(weapon);
            gameObject.SetActive(false);
        }
    }
}
