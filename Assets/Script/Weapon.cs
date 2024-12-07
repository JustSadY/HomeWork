using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponStats[] weapons;
    private int currentWeaponIndex = 0;

    public WeaponStats CurrentWeapon => weapons[currentWeaponIndex];

    public void SwitchWeapon(int newIndex)
    {
        if (newIndex >= 0 && newIndex < weapons.Length)
        {
            currentWeaponIndex = newIndex;
            UpdateWeaponVisibility();
        }
    }
    
    private void UpdateWeaponVisibility()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].gameObject.SetActive(i == currentWeaponIndex);
        }
    }
}