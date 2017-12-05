using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int StartingHealth = 100;
    public int CurrentHealth;

    private PlayerMovement _playerMovement;
    private PlayerShooting _playerShooting;
    private bool _isDead;

    private void Awake ()
    {
        _playerMovement = GetComponent <PlayerMovement> ();
        _playerShooting = GetComponentInChildren <PlayerShooting> ();
        CurrentHealth = StartingHealth;
    }

    public void TakeDamage (int amount)
    {
        CurrentHealth -= amount;

        if(CurrentHealth <= 0 && !_isDead)
        {
            Death ();
        }
    }


    private void Death ()
    {
        _isDead = true;
        GameManager.instance.GameOver();
        _playerMovement.enabled = false;
        _playerShooting.enabled = false;
    }

}
