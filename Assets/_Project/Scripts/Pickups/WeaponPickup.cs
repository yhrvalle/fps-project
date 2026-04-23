using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] private WeaponSO weaponSo;
    private const string PlayerTag = "Player";
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(PlayerTag))
        {
            return;
        }

        Player player = other.GetComponent<Player>();
        player.SwitchWeapon(weaponSo);
        Destroy(gameObject);
    }
}