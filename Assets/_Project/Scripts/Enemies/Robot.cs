using StarterAssets;
using UnityEngine;
using UnityEngine.AI;

public class Robot : MonoBehaviour
{
    private NavMeshAgent _agent;
    private FirstPersonController _player;
    
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        _player = FindAnyObjectByType<FirstPersonController>();
    }

    private void Update()
    {
        _agent.SetDestination(_player.transform.position);
    }
}
