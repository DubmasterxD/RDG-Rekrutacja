using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Item/Weapon", order = 0)]
public class Weapon : ScriptableObject
{
    [SerializeField] GameObject weaponPrefab = null;
    [SerializeField] float weaponRange = 1;
    [SerializeField] int usages = 2;

    GameObject weaponObject;

    public void Spawn(Transform hand)
    {
        weaponObject = Instantiate(weaponPrefab, hand);
    }

    public void Destroy()
    {
        if (weaponObject != null)
        {
            Destroy(weaponObject);
        }
    }
}
