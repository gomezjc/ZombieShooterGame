using UnityEngine;
using UnityEngine.UI;

public class ShootableObject : MonoBehaviour
{
    public int StartingHealth;
    public float CurrentHealth;
    public Image HealthBar;
    
    private void Start()
    {
        CurrentHealth = StartingHealth;
    }

    public virtual void TakeDamage(float amount)
    {
        
    }
}