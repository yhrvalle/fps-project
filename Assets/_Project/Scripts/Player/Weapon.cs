using UnityEngine;

public class Weapon : MonoBehaviour, IWeapon
{
    public void Fire(IDamageable target, WeaponSO weaponSo)
    {
        if (target == null)
        {
            Debug.Log("No IDamageable target found");
            return;
        }
        
        target.TakeDamage(weaponSo.Damage);
        Debug.Log("Fired at " + target);
    }
}
