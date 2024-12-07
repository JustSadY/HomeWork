using Unity.Cinemachine;
using UnityEngine;

public class WeaponStats : MonoBehaviour
{
    [SerializeField] private string WeaponName;
    [SerializeField] private float FireRate;
    [SerializeField] private float Damage;
    [SerializeField] private float BulletSpeed;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform spawnLocation;
    [SerializeField] private AudioClip bulletSound;

    private float lastFireTime = 0f;

    public void Fire(CinemachineImpulseSource cinemachineImpulseChannels)
    {
        if (Time.time - lastFireTime < 1 / FireRate) return;

        lastFireTime = Time.time;
        cinemachineImpulseChannels.GenerateImpulseWithForce(1f);
        UI.instance.PlayAudio(bulletSound);
        GameObject bullet = Instantiate(
            bulletPrefab,
            spawnLocation.position,
            spawnLocation.rotation
        );
        bullet.GetComponent<Bullet>().damage = Damage;
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = spawnLocation.forward * BulletSpeed;
        }

        Destroy(bullet, 3f);
    }
}