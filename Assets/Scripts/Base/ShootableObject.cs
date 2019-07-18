using UnityEngine;

public class ShootableObject : MonoBehaviour
{
    public int StartingHealth;
    public float CurrentHealth;
    
    private void Start()
    {
        CurrentHealth = StartingHealth;
    }

    public virtual void TakeDamage(float amount)
    {
        
    }
}