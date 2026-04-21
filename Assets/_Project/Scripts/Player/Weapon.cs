using UnityEngine;

public class Weapon : MonoBehaviour, IWeapon
{
    [SerializeField] private int damage = 1;
    
    
    public void Fire(IDamageable target)
    {
        if (target == null)
        {
            Debug.Log("No IDamageable target found");
            return;
        }
        target.TakeDamage(damage);
        Debug.Log("Fired at " + target);
    }
}
