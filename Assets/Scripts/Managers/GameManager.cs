using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject CanvasState,RestartButton,MenuButton;
    public Text StateText;

    #region Singleton

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
        CanvasState.SetActive(false);
        RestartButton.SetActive(false);
        MenuButton.SetActive(false);
    }

    #endregion

    public void GameWon()
    {
        ChangeState("You Won!");
        StopGame();        
        MenuButton.SetActive(true);
        GameControl.instance.addLevel();       
        LevelManager.LevelWon = true;
    }

    public void GameOver()
    {
        ChangeState("You Loose!");
        StopGame();
        RestartButton.SetActive(true);
        MenuButton.SetActive(true);
        LevelManager.LevelWon = false;
    }

    public void Restart()
    {
        StartGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMenu()
    {
        StartGame();
        SceneManager.LoadScene(0);
    }

    private void ChangeState(string text)
    {
        CanvasState.SetActive(true);
        StateText.text = text;
    }

    private void StartGame()
    {
        Time.timeScale = 1;
    }

    private void StopGame()
    {
        Time.timeScale = 0;
        PlayerMovement.instance.GetComponentInChildren<PlayerShooting>().DisableEffects();
    }
}