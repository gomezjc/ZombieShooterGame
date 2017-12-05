using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;
    
    private PlayerHealth _playerHealth;
    public GameObject Enemy;
    public float SpawnTime = 3f;
    public List<Transform> SpawnPoints;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start ()
    {
        _playerHealth = PlayerMovement.instance.GetComponent<PlayerHealth>();
        InvokeRepeating ("Spawn", SpawnTime, SpawnTime);
    }

    public void AddSpawnPoints(Transform spawnPoint)
    {
        SpawnPoints.Add(spawnPoint);
    }

    public void DeleteSpawnPoints(Transform spawnPoint)
    {
        SpawnPoints.Remove(spawnPoint);
    }

    void Spawn ()
    {
        if(SpawnPoints.Count == 0 || _playerHealth.CurrentHealth <= 0)
        {
            CancelInvoke("Spawn");
            enabled = false;
            return;
        }
        
        int spawnPointIndex = Random.Range (0, SpawnPoints.Count);
        GameObject enemy = Instantiate (Enemy, SpawnPoints[spawnPointIndex].position, SpawnPoints[spawnPointIndex].rotation);

        if (SpawnPoints[spawnPointIndex].gameObject.GetComponent<SpawnTarget>() != null)
        {
            enemy.GetComponent<EnemyMovement>().setDestination(
                SpawnPoints[spawnPointIndex].gameObject.GetComponent<SpawnTarget>().EnemyTarget);    
        }
        
    }
}
