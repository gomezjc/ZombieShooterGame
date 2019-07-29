using UnityEngine;

public class DestroyableObject : ShootableObject
{
    public Transform SpawnPoint;
    private ExplosiveObject explosive;

    protected void Start()
    {
        base.Start();
        explosive = GetComponent<ExplosiveObject>();
    }

    public void TakeDamage(float amount)
    {
        base.TakeDamage(amount);
    }

    protected override void Destroy()
    {
        destroyed = true;
        
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