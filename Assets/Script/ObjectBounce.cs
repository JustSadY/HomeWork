using UnityEngine;

public class ObjectBounce : MonoBehaviour
{
    [SerializeField] private float bounceSpeed = 8f;
    [SerializeField] private float bounceAmplitude = 0.05f;
    [SerializeField] private float rotationSpeed = 90f;
    [SerializeField] private ObjectType objectType;

    private float startHeight;
    private float timeOffset;

    private enum ObjectType
    {
        Health,
        Ammo,
        PowerUp
    }

    void Start()
    {
        startHeight = transform.localPosition.y;
        timeOffset = Random.value * Mathf.PI * 2;
    }

    void Update()
    {
        float finalHeight = startHeight + Mathf.Sin(Time.time * bounceSpeed + timeOffset) * bounceAmplitude;
        var position = transform.localPosition;
        position.y = finalHeight;
        transform.localPosition = position;

        Vector3 rotation = transform.localRotation.eulerAngles;
        rotation.y += rotationSpeed * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (objectType)
            {
                case ObjectType.Health:
                    if(other.gameObject.TryGetComponent<GetStats>(out GetStats stats)) stats.addHealth(10);
                        Destroy(this.gameObject);
                    break;

                case ObjectType.Ammo:
                    Debug.Log("Ammo collected!");
                    Destroy(this.gameObject);
                    break;

                case ObjectType.PowerUp:
                    Debug.Log("PowerUp collected!");
                    Destroy(this.gameObject);
                    break;

                default:
                    Debug.Log("Unknown object type!");
                    break;
            }
        }
    }
}