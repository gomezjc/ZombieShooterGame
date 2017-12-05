using UnityEngine;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;

    public PlayerData playerInfo;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    [System.Serializable]
    public class PlayerData
    {
        public int Day;
        public int Money;
        public int LevelsComplete;
    }

    public void addMoney(int money)
    {
        playerInfo.Money += money;
    }

    public void addLevel()
    {
        playerInfo.LevelsComplete += 1;

        if (playerInfo.LevelsComplete >= 3)
        {
            nextLevel();
        }
    }

    public void nextLevel()
    {
        playerInfo.Day += 1;
        playerInfo.LevelsComplete = 0;
        LevelManager.HiddenButtons.Clear();
    }
}