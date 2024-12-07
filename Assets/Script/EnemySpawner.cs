using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] prefab;
    [SerializeField] private int MaxSpawns = 5;
    private int EnemyCount;
    private float timer;

    private void Update()
    {
        OnTimer();
        Spawn();
    }

    private void Spawn()
    {
        if (EnemyCount < MaxSpawns)
        {
            Instantiate(prefab[Random.Range(0, prefab.Length)], SpawnLocation(), Quaternion.identity);
            EnemyCount++;
        }
    }

    private Vector3 SpawnLocation()
    {
        Vector3 location = new Vector3(Random.Range(-50.0f, 50.0f), 0, Random.Range(-50.0f, 50.0f));
        if (Vector3.Distance(location, PlayerController.playerLocation) >= 20f)
        {
            return location;
        }

        return SpawnLocation();
    }

    private void OnTimer()
    {
        timer += Time.deltaTime;
        if (timer >= 10f)
        {
            timer = 0;
            MaxSpawns++;
        }
    }

    public void EnemyDie()
    {
        EnemyCount--;
    }
}