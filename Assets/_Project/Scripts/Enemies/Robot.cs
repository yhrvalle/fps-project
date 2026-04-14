using StarterAssets;
using UnityEngine;
using UnityEngine.AI;

public class Robot : MonoBehaviour, IDamageable
{
    private int _health = 3;
    public bool IsAlive => _health > 0;
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
    public void TakeDamage(int damageAmount)
    {
        if (!IsAlive)
        {
            return;
        }
        _health -= damageAmount;
        // in case the target dies from this damage, we want to call the Die() method
        if (!IsAlive)
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
        Debug.Log("Robot died");
    }
}
