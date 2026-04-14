using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private RaycastHit _hit;
    private Camera _camera;
    private const float MaxRange = 25f;

    private void Awake()
    {
        _camera = Camera.main;
    }
    
    private void Update()
    {
        if (!Physics.Raycast(_camera.transform.position, _camera.transform.forward, out _hit, MaxRange))
        {
            return;
        }
        Debug.Log(_hit.transform.name);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(_camera.transform.position, _camera.transform.position + _camera.transform.forward * MaxRange);
    }


}
