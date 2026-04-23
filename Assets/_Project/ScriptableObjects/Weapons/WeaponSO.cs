using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSO", menuName = "Scriptable Objects/WeaponSO")]
public class WeaponSO : ScriptableObject
{
    [SerializeField] private int damage;
    [SerializeField] private float fireRate;
    [SerializeField] private bool isAutomatic;
    [SerializeField] private GameObject weaponPrefab;
    [SerializeField] private bool canZoom = false;
    [SerializeField] private float zoomedFOV;
    [SerializeField] private float zoomedCameraSpeed;
    
    public float FireRate => fireRate;
    public int Damage => damage;
    public bool IsAutomatic => isAutomatic;
    public GameObject WeaponPrefab => weaponPrefab;
    public bool CanZoom => canZoom;
    public float ZoomedCameraSpeed => zoomedCameraSpeed;
    public float ZoomedFOV => zoomedFOV;
}


    
    
