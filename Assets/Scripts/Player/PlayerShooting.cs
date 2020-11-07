using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Weapon Weapon;
    public Transform FirePoint;
    public GameObject BulletPrefab;

    private float FireCountdown;
    private int _shootableMask;

    private void Awake()
    {
        _shootableMask = LayerMask.GetMask("Shootable");
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && FireCountdown <= 0 && Time.timeScale != 0)
        {
            Shoot();
            FireCountdown = 1f * Weapon.TimeBetweenBullets;
        }
        FireCountdown -= Time.deltaTime;
    }

    void Shoot ()
    {
        GameObject bulletGO = (GameObject)Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if (bullet)
        {
            bullet.SetAttributes(Weapon);
        }
    }
}