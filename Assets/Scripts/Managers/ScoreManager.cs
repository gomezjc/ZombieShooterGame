using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text ScoreText;
    public ScoreType Type;

    public enum ScoreType
    {
        Increase,
        Decrease,
        Spawn,
        Timer
    }

    private int Limit;

    private int _score;

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

    private void Start()
    {
        if (Type == ScoreType.Timer)
        {
            _score = Limit + GameControl.instance.playerInfo.Day * 15;
            setScoreTimer();
            StartCoroutine(addTimer());
        }
        else
        {
            if (Type == ScoreType.Spawn)
                Limit = EnemyManager.instance.SpawnPoints.Count;
            else if (Type == ScoreType.Decrease)
            {
                Limit = GameControl.instance.playerInfo.Day * 3;
            }
            _score = 0;
            setScoreText();
        }
    }

    public void addScore()
    {
        _score++;
        setScoreText();
    }

    private void setScoreText()
    {
        ScoreText.text = "Score: " + _score;

        if (Type == ScoreType.Increase) return;
        ScoreText.text += "/" + Limit;

        if (_score == Limit)
        {
            GameManager.instance.GameWon();
        }
    }

    IEnumerator addTimer()
    {
        while (_score > 0)
        {
            yield return new WaitForSeconds(1f);
            _score--;
            setScoreTimer();
        }
        GameManager.instance.GameWon();
    }

    private void setScoreTimer()
    {
        ScoreText.text = string.Format("{0:0}:{1:00}", Mathf.Floor(_score / 60), _score % 60);
    }
}