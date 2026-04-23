using UnityEngine;

public class WeaponPickup : BasePickup
{
    [SerializeField] private WeaponSO weaponSo;
    
    protected override void OnPickup(Player player)
    {
        player.SwitchWeapon(weaponSo);
    }
}