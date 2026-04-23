using UnityEngine;

public interface IWeapon
{
    public void Fire(IDamageable target, WeaponSO weaponSo);
}
