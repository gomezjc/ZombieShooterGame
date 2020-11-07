using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    public new string name;
    public float DamagePerShot;
    public float TimeBetweenBullets;
    public float Range;
    public float Speed;
}
