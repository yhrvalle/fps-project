using System;
using StarterAssets;
using Unity.Cinemachine;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const string ShootString = "Shoot";
    [SerializeField] private CinemachineVirtualCamera _cinemachineVirtualCamera;
    [SerializeField] private GameObject zoomVignette;
    [SerializeField] private WeaponSO weaponSo;
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private ParticleSystem hitVFX;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform weaponHolder;
    private FirstPersonController _controller;
    private Weapon _weapon;
    private Camera _camera;
    private StarterAssetsInputs _inputs;
    private float _timeSinceLastShot = 0f;
    private float _originalFOV;
    private float _originalCameraSpeed;
    
    
    private void Awake()
    {
        _camera = Camera.main;
        _inputs = GetComponent<StarterAssetsInputs>();
        _weapon = GetComponentInChildren<Weapon>();
        _controller = GetComponent<FirstPersonController>();
        _originalCameraSpeed = _controller.RotationSpeed;
        if (_camera != null)
        {
            _originalFOV = _camera.fieldOfView;
        }
    }
    
    private void Update()
    {
        TryShoot();
        HandleZoom();
    }
    private void TryShoot()
    {
        _timeSinceLastShot += Time.deltaTime;
        if (!_inputs.shoot || _timeSinceLastShot < weaponSo.FireRate)
        {
            return;
        }
        
        if (!weaponSo.IsAutomatic)
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
        _weapon.Fire(target, weaponSo);
        _timeSinceLastShot = 0f;
    }

    public void SwitchWeapon(WeaponSO weaponSo)
    {
        if (_weapon)
        {
            Destroy(_weapon.gameObject);
        }

        Weapon nextWeapon = Instantiate(weaponSo.WeaponPrefab, weaponHolder).GetComponent<Weapon>();
        this.weaponSo = weaponSo;
        _weapon = nextWeapon;
    }

    private void HandleZoom()
    {
        if (!weaponSo.CanZoom)
        {
            return;
        }
        if (_inputs.zoom)
        {
            _cinemachineVirtualCamera.m_Lens.FieldOfView = weaponSo.ZoomedFOV;
            _controller.ChangeRotationSpeed(weaponSo.ZoomedCameraSpeed);
            zoomVignette.SetActive(true);
        }
        else
        {
            _cinemachineVirtualCamera.m_Lens.FieldOfView =  _originalFOV;
            zoomVignette.SetActive(false);
            _controller.ChangeRotationSpeed(_originalCameraSpeed);
        }
        
        Debug.Log(_inputs.zoom ? "Zooming" : "Not zooming");
    }

}
