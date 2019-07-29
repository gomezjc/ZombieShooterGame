using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float TimeBetweenAttacks = 0.5f;
    public int AttackDamage = 10;
    
    //Animator anim;
    private GameObject _player;
    private PlayerHealth _playerHealth;
    private EnemyHealth _enemyHealth;
    private DestroyableBarrier _destroyableBarrier;
    
    private bool _playerInRange,_barrierInRange;
    private float _timer;


    private void Awake ()
    {
        _player = PlayerMovement.instance.gameObject;
        _playerHealth = _player.GetComponent <PlayerHealth> ();
        _enemyHealth = GetComponent<EnemyHealth>();

        //anim = GetComponent <Animator> ();
    }


    private void OnTriggerEnter (Collider other)
    {
        if(other.gameObject == _player)
        {
            _playerInRange = true;
        }else if (other.gameObject.CompareTag("Barrier"))
        {
            _barrierInRange = true;
            _destroyableBarrier = other.gameObject.GetComponent<DestroyableBarrier>();
        }
    }


    private void OnTriggerExit (Collider other)
    {
        if(other.gameObject == _player)
        {
            _playerInRange = false;
        }else if (other.gameObject.CompareTag("Barrier"))
        {
            _barrierInRange = false;
            _destroyableBarrier = null;
        }
    }


    private void Update ()
    {
        _timer += Time.deltaTime;

        if(_timer >= TimeBetweenAttacks && (_playerInRange || _barrierInRange) && !_enemyHealth.destroyed)
        {
            Attack ();
        }

        /*if(playerHealth.CurrentHealth <= 0)
        {
            anim.SetTrigger ("PlayerDead");
        }*/
    }


    private void Attack ()
    {
        _timer = 0f;

        if(_playerInRange && _playerHealth.CurrentHealth > 0)
        {
            _playerHealth.TakeDamage (AttackDamage);
        }else if (_barrierInRange && _destroyableBarrier.CurrentHealth > 0)
        {
            _destroyableBarrier.TakeDamage(AttackDamage);
        }
    }
}
