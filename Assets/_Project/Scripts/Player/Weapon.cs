using UnityEngine;

public class Weapon : MonoBehaviour, IWeapon
{
    [SerializeField] private WeaponSO weaponSo;
    
    
    public void Fire(IDamageable target)
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
