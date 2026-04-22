using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSO", menuName = "Scriptable Objects/WeaponSO")]
public class WeaponSO : ScriptableObject
{
    [SerializeField] private int damage;
    [SerializeField] private float fireRate;
    
    public float FireRate => fireRate;
    public int Damage => damage;
}


    
    
