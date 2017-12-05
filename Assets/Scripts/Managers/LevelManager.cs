using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    // 0: Free, 1: Kill, 2: Spawn, 3: Protect
    public List<Button> Actions;

    public static List<int> HiddenButtons = new List<int>();
    public static LevelManager instance;
    public const int FREE_GAME = 0;
    public const int KILL_GAME = 1;
    public const int SPAWN_GAME = 2;
    public const int PROTECT_GAME = 3;
    public static int ActualGame = 0;
    public static bool LevelWon = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        hideGame();
    }

    public void ChangeLevel(int index)
    {
        setActiveGame(index);
        SceneManager.LoadScene(index);
    }

    public void hideGame()
    {
        if (ActualGame == 0) return;

        if (LevelWon)
        {
            HiddenButtons.Add(ActualGame);
        }

        foreach (int index in HiddenButtons)
        {
            if (Actions[index].gameObject.activeSelf)
            {
                Actions[index].gameObject.SetActive(false);
            }
        }
    }

    public void setActiveGame(int level)
    {
        switch (level)
        {
            case 1:
                ActualGame = FREE_GAME;
                break;

            case 2:
                ActualGame = KILL_GAME;
                break;

            case 3:
                ActualGame = PROTECT_GAME;
                break;

            case 4:
                ActualGame = SPAWN_GAME;
                break;
            default:
                ActualGame = 0;
                break;
        }
    }
}