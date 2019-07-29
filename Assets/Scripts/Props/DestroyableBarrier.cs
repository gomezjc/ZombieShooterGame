using UnityEngine;

public class DestroyableBarrier : ShootableObject {
    
	protected override void Destroy()
	{
		destroyed = true;
		Destroy(gameObject);
	}

    public void TakeDamage(float amount)
    {
        base.TakeDamage(amount);
    }

}
