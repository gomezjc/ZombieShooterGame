public class EnemyHealth : ShootableObject
{
    public bool IsDead;
    public int CostCash;

    public override void TakeDamage(int amount)
    {
        if (IsDead)
            return;

        CurrentHealth -= amount;

        if (CurrentHealth <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        IsDead = true;
        
        // Si no es el tipo de juego Protect, se lleva un puntaje
        if (ScoreManager.instance.Type != ScoreManager.ScoreType.Timer 
            && ScoreManager.instance.Type != ScoreManager.ScoreType.Spawn)
        {
            ScoreManager.instance.addScore();
        }
        // si no es el tipo de juego Free, no se farmea Oro
        if (CashManager.instance != null)
        {
            CashManager.instance.addCash(CostCash);
        }
        
        Destroy(gameObject);
    }
}