using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Transform startLocation;
    public GameObject playerPrefab;
    void Start()
    {
        Instantiate (playerPrefab, startLocation.position, startLocation.rotation);
    }
}
