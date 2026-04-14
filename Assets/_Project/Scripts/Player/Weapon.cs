using StarterAssets;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private RaycastHit _hit;
    private StarterAssetsInputs _input;
    private Camera _camera;
    private const float MaxRange = 25f;

    private void Awake()
    {
        _camera = Camera.main;
        _input = GetComponentInParent<StarterAssetsInputs>();
    }
    
    private void Update()
    {
        ShootLogic();
    }
    
    private void ShootLogic()
    {

        if (!_input.shoot)
        {
            return;
        }

        if (!Physics.Raycast(_camera.transform.position, _camera.transform.forward, out _hit, MaxRange))
        {
            return;
        }

        Debug.Log(_hit.transform.name);
        _input.ShootInput(false);
    }

    private void OnDrawGizmos()
    {
        if (_camera == null)
        {
            return;
        }
        Gizmos.color = Color.red;
        Gizmos.DrawLine(_camera.transform.position, _camera.transform.position + _camera.transform.forward * MaxRange);
    }


}
