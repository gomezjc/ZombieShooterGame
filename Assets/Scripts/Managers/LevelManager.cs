using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    public List<Button> actions;
    
    public void ChangeLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
}