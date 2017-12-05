using UnityEngine;

public class DestroyableBarrier : MonoBehaviour {

	public int StartingHealth;
	public int CurrentHealth;
	private bool _isDestroy;
    
	private void Start()
	{
		CurrentHealth = StartingHealth;
	}
	
	public void TakeDamage(int amount)
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
	}
	
}
