
using UnityEngine;

public class ExplosiveObject : MonoBehaviour
{
    public LayerMask m_explosionMask;                        
    public ParticleSystem m_ExplosionParticles;         
    public AudioSource m_ExplosionAudio;                
    public float m_MaxDamage = 100f;                    
    public float m_ExplosionForce = 1000f;              
    public float m_MaxLifeTime = 2f;                    
    public float m_ExplosionRadius = 5f;                


    private void Start()
    {
        CreateExplosion();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
        Gizmos.DrawWireSphere(transform.position, m_ExplosionRadius);
    }

    private void CreateExplosion()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, m_ExplosionRadius, m_explosionMask);

        // Go through all the colliders...
        for (int i = 0; i < colliders.Length; i++)
        {
            // ... and find their rigidbody.
            Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();

            // If they don't have a rigidbody, go on to the next collider.
            if (!targetRigidbody)
                continue;

            // Add an explosion force.
            targetRigidbody.AddExplosionForce(m_ExplosionForce, transform.position, m_ExplosionRadius);

            // Find the TankHealth script associated with the rigidbody.
            EnemyHealth targetHealth = targetRigidbody.GetComponent<EnemyHealth>();

            // If there is no TankHealth script attached to the gameobject, go on to the next collider.
            if (!targetHealth)
                continue;

            // Calculate the amount of damage the target should take based on it's distance from the shell.
            float damage = CalculateDamage(targetRigidbody.position);

            // Deal this damage to the tank.
            targetHealth.TakeDamage(damage);
        }

        // Unparent the particles from the shell.
        //m_ExplosionParticles.transform.parent = null;

        // Play the particle system.
        //m_ExplosionParticles.Play();

        // Play the explosion sound effect.
        //m_ExplosionAudio.Play();

        // Once the particles have finished, destroy the gameobject they are on.
        //Destroy(m_ExplosionParticles.gameObject, m_ExplosionParticles.duration);

        // Destroy the shell.
        Destroy(gameObject);
    }


    private float CalculateDamage(Vector3 targetPosition)
    {
        // Create a vector from the shell to the target.
        Vector3 explosionToTarget = targetPosition - transform.position;

        // Calculate the distance from the shell to the target.
        float explosionDistance = explosionToTarget.magnitude;

        // Calculate the proportion of the maximum distance (the explosionRadius) the target is away.
        float relativeDistance = (m_ExplosionRadius - explosionDistance) / m_ExplosionRadius;

        // Calculate damage as this proportion of the maximum possible damage.
        float damage = relativeDistance * m_MaxDamage;

        // Make sure that the minimum damage is always 0.
        damage = Mathf.Max(0f, damage);

        return damage;
    }
}
