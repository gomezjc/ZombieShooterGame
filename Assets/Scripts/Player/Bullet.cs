using System;
using Core;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Weapon attributes;
    private Vector3 spawnLocation;
    private Rigidbody rigidbody;

    private void Start()
    {
        spawnLocation = transform.position;
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = transform.forward * attributes.Speed;
    }

    public void SetAttributes(Weapon attributes)
    {
        this.attributes = attributes;
    }

    private void Update()
    {
        if (Vector3.Distance(spawnLocation, transform.position) > attributes.Range)
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == Constants.SHOOTEABLE_MASK)
        {
            ShootableObject shootableObject = other.collider.GetComponent<ShootableObject>();
            if(shootableObject != null)	
            {	
                shootableObject.TakeDamage (attributes.DamagePerShot);	
            }
        }
        Destroy(gameObject);
    }
}