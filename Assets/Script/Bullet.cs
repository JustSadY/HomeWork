using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) return;
        if (collision.gameObject.TryGetComponent<Enemy>(out var enemy))
        {
            enemy.TakingDamage(damage);
        }

        Destroy(this.gameObject);
    }
}