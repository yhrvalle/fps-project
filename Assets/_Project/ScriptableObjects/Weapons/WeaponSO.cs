using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSO", menuName = "Scriptable Objects/WeaponSO")]
public class WeaponSO : ScriptableObject
{
    [SerializeField] private int damage;
    [SerializeField] private float fireRate;
    [SerializeField] private bool isAutomatic;
    [SerializeField] private GameObject weaponPrefab;
    
    public float FireRate => fireRate;
    public int Damage => damage;
    public bool IsAutomatic => isAutomatic;
    public GameObject WeaponPrefab => weaponPrefab;
}


    
    
