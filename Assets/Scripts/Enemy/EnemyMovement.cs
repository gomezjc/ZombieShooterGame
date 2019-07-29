using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{

	private Transform _destinationTarget;
	private NavMeshAgent _navMeshAgent;
	private PlayerMovement _player;
	private EnemyHealth _enemyHealth;
	private PlayerHealth _playerHealth;

	private void Awake()
	{
		_navMeshAgent = GetComponent<NavMeshAgent>();
		_enemyHealth = GetComponent<EnemyHealth>();
	}

	private void Start()
	{
		_player = PlayerMovement.instance;
		_playerHealth = _player.GetComponent<PlayerHealth>();
	}
	
	private void Update()
	{
		if(!_enemyHealth.destroyed && _playerHealth.CurrentHealth > 0)
		{
			_navMeshAgent.SetDestination(getDestination().position);
		}
		else
		{
			_navMeshAgent.enabled = false;
		}
	}
	
	public void setDestination(Transform target)
	{
		_destinationTarget = target;
	}

	public Transform getDestination()
	{
		if (_destinationTarget == null)
		{
			return _player.transform;
		}
		return _destinationTarget;
	}
}
