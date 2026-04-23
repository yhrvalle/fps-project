using UnityEngine;

public abstract class BasePickup : MonoBehaviour
{
    private const float RotationSpeed = 60f;
    private const string PlayerTag = "Player";

    private void Update()
    {
        transform.Rotate(Vector3.up, RotationSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(PlayerTag))
        {
            return;
        }
        Player player = other.GetComponent<Player>();
        OnPickup(player);
        Destroy(gameObject);
    }
    protected abstract void OnPickup(Player player);
    
}
