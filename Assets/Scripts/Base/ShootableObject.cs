using UnityEngine;

public class ShootableObject : MonoBehaviour
{
    public int StartingHealth;
    public int CurrentHealth;
    
    private void Start()
    {
        CurrentHealth = StartingHealth;
    }

    public virtual void TakeDamage(int amount)
    {
        
    }
}