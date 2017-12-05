using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Weapon Weapon;

    private float _timer;
    private Ray _shootRay = new Ray();
    private RaycastHit _shootHit;
    private int _shootableMask;
    private ParticleSystem _gunParticles;
    private LineRenderer _gunLine;

    private Light _gunLight;
    //AudioSource gunAudio;

    private float _effectsDisplayTime = 0.2f;

    private void Awake()
    {
        _shootableMask = LayerMask.GetMask("Shootable");
        _gunParticles = GetComponent<ParticleSystem>();
        _gunLine = GetComponent<LineRenderer>();
        _gunLight = GetComponent<Light>();
        //gunAudio = transform.GetChild(1).GetComponent<AudioSource> ();
    }

    void Update()
    {
        _timer += Time.deltaTime;

        if (Input.GetButton("Fire1") && _timer >= Weapon.TimeBetweenBullets && Time.timeScale != 0)
        {
            Shoot();
        }

        if (_timer >= Weapon.TimeBetweenBullets * _effectsDisplayTime)
        {
            DisableEffects();
        }
    }


    public void DisableEffects()
    {
        _gunLine.enabled = false;
        _gunLight.enabled = false;
        _gunParticles.Stop();
    }
    
    void Shoot ()
    {
        _timer = 0f;

        //gunAudio.Play ();
        
        _gunLight.enabled = true;

        _gunParticles.Stop ();
        _gunParticles.Play ();

        _gunLine.enabled = true;
        _gunLine.SetPosition (0, transform.position);

        _shootRay.origin = transform.position;
        _shootRay.direction = transform.forward;

        if(Physics.Raycast (_shootRay, out _shootHit, Weapon.Range, _shootableMask))
        {
            ShootableObject shootableObject = _shootHit.collider.GetComponent <ShootableObject> ();

            if(shootableObject != null)
            {
                shootableObject.TakeDamage (Weapon.DamagePerShot);
            }
            _gunLine.SetPosition (1, _shootHit.point);
        }
        else
        {
            _gunLine.SetPosition (1, _shootRay.origin + _shootRay.direction * Weapon.Range);
        }
    }
}