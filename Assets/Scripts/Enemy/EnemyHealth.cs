public class EnemyHealth : ShootableObject
{
    public int CostCash;

    protected override void Destroy()
    {
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

    public void TakeDamage(float amount)
    {
        base.TakeDamage(amount);
    }
}