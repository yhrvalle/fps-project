using StarterAssets;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const string ShootString = "Shoot";
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private Animator animator;
    private IWeapon _weapon;
    private Camera _camera;
    private StarterAssetsInputs _inputs;
    
    private void Awake()
    {
        _camera = Camera.main;
        _inputs = GetComponent<StarterAssetsInputs>();
        _weapon = GetComponentInChildren<IWeapon>();
    }
    
    private void Update()
    {
        if (!_inputs.shoot)
        {
            return;
        }

        TryShoot();
        _inputs.ShootInput(false);
    }
    private void TryShoot()
    {
        IDamageable target = null;
        muzzleFlash.Play();
        animator.Play(ShootString, 0, 0f);
        _inputs.ShootInput(false);
        if (!Physics.Raycast(_camera.transform.position, _camera.transform.forward, out RaycastHit hit, Mathf.Infinity))
        {
            return;
        }
        
        target = hit.collider.GetComponent<IDamageable>(); // if the target doesnt have this interface = null
        _weapon.Fire(target);
    }
        

}
