using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Item/Weapon", order = 0)]
public class Weapon : ScriptableObject
{
    [SerializeField] GameObject weaponPrefab = null;
    [SerializeField] int startingUsages = 2;

    int usagesLeft = 0;
    GameObject weaponObject;

    public void Spawn(Transform hand)
    {
        weaponObject = Instantiate(weaponPrefab, hand);
        usagesLeft = startingUsages;
    }

    public void Destroy()
    {
        if (weaponObject != null)
        {
            Destroy(weaponObject);
        }
    }

    public void Use()
    {
        usagesLeft--;
    }

    public int GetUsagesLeft()
    {
        return usagesLeft;
    }
}
