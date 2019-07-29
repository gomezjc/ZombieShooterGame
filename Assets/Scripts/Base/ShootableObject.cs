using UnityEngine;
using UnityEngine.UI;

public class ShootableObject : MonoBehaviour
{
    public float StartingHealth;
    public float CurrentHealth;
    public Image HealthBar;
    public bool destroyed;

    protected void Start()
    {
        CurrentHealth = StartingHealth;
    }

    public void TakeDamage(float amount)
    {
        if (destroyed)
            return;

        CurrentHealth -= amount;
        HealthBar.fillAmount = CurrentHealth / StartingHealth;

        if (CurrentHealth <= 0)
        {
            Destroy();
        }
    }

    protected virtual void Destroy(){}

}