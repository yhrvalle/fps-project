using StarterAssets;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const string ShootString = "Shoot";
    [SerializeField] private WeaponSO weaponSO;
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private ParticleSystem hitVFX;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform weaponHolder;
    private Weapon _weapon;
    private Camera _camera;
    private StarterAssetsInputs _inputs;
    private float _timeSinceLastShot = 0f;
    
    private void Awake()
    {
        _camera = Camera.main;
        _inputs = GetComponent<StarterAssetsInputs>();
        _weapon = GetComponentInChildren<Weapon>();
    }
    
    private void Update()
    {
        _timeSinceLastShot += Time.deltaTime;
        if (!_inputs.shoot || _timeSinceLastShot < weaponSO.FireRate)
        {
            return;
        }

        TryShoot();
        _timeSinceLastShot = 0f;
        
    }
    private void TryShoot()
    {
        if (!weaponSO.IsAutomatic)
        {
            _inputs.ShootInput(false);
        }
        IDamageable target = null;
        muzzleFlash.Play();
        animator.Play(ShootString, 0, 0f);
        if (!Physics.Raycast(_camera.transform.position, _camera.transform.forward, out RaycastHit hit, Mathf.Infinity))
        {
            return;
        }
        Instantiate(hitVFX, hit.point, hit.transform.rotation);
        target = hit.collider.GetComponent<IDamageable>(); // if the target doesnt have this interface = null
        _weapon.Fire(target, weaponSO);
    }

    public void SwitchWeapon(WeaponSO weaponSo)
    {
        if (_weapon)
        {
            Destroy(_weapon.gameObject);
        }

        Weapon nextWeapon = Instantiate(weaponSo.WeaponPrefab, weaponHolder).GetComponent<Weapon>();
        this.weaponSO = weaponSo;
        _weapon = nextWeapon;
    }

}
