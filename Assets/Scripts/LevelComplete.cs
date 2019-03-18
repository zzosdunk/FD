using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour {

    public SceneFader sceneFader;

    public string loadMenu = "MainMenu";

    public string nextLevel;
    public int levelToUnlock;
    private int currentLevelReached;
    private string currentScene;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
    }

    public void Continue ()
    {
        levelToUnlock = PlayerPrefs.GetInt("levelReached");

        PlayerPrefs.SetInt("levelReached", levelToUnlock + 1);

        sceneFader.FadeTo(nextLevel);

        currentLevelReached = PlayerPrefs.GetInt("levelReached");
        Debug.Log("levelToUnlock" + levelToUnlock);
        Debug.Log("currentLevel" + currentLevelReached);
    }

 

    public void Menu()
    {
        sceneFader.FadeTo(loadMenu);
    }
}
