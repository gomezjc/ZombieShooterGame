using UnityEngine;

public class DestroyableObject : ShootableObject
{
    public Transform SpawnPoint;
    private bool _isDestroy;

    private ExplosiveObject explosive;

    private void Start()
    {
        explosive = GetComponent<ExplosiveObject>();
    }

    public override void TakeDamage(float amount)
    {
        if (_isDestroy)
            return;
        
        CurrentHealth -= amount;

        if (CurrentHealth <= 0)
        {
            Destroy();
        }
    }


    private void Destroy()
    {
        _isDestroy = true;
        
        Destroy(gameObject);

        if(explosive != null)
        {
            explosive.enabled = true;
        }
        
        if (SpawnPoint == null) return;
        
        EnemyManager.instance.DeleteSpawnPoints(SpawnPoint);
            
        if (ScoreManager.instance.Type == ScoreManager.ScoreType.Spawn)
        {
            ScoreManager.instance.addScore();
        }
    }
}