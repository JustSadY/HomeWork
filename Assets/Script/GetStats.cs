using UnityEngine;

public abstract class GetStats : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float health;
    [SerializeField] private float damage;
    [HideInInspector] public Rigidbody _Rigidbody;
    [HideInInspector] public Animator _Animator;
    
    public float GetHealth()
    {
        return health;
    }

    protected float GetDamage()
    {
        return damage;
    }

    protected float GetSpeed()
    {
        return speed;
    }

    public void addHealth(float health)
    {
        this.health += health;
    }

    protected bool Die()
    {
        if (health <= 0) return true;
        return false;
    }

    protected void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    protected void TakingDamage(float damage)
    {
        this.health -= damage;
    }
}