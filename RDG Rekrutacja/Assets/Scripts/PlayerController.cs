using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerFeet feet = null;
    [SerializeField] Transform hand = null;

    Weapon equippedWeapon;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Move();
        }
    }

    private void Move()
    {
        if (feet.canWalk)
        {
            transform.Translate(new Vector3(0, 0, 1));
        }
        else
        {
            TurnLeft();
        }
    }

    private void TurnLeft()
    {
        transform.localRotation = Quaternion.Euler(0, transform.localRotation.eulerAngles.y - 90, 0);
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
}
