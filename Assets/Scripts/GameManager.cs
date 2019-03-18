using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static bool GameIsOver;

    public GameObject gameOverUI;
    public GameObject completeLevelUI;


    public SceneFader sceneFader;
    private LevelComplete level;
    

    void Start()
    {
        GameIsOver = false; //если поставить значение false в обьявлении переменной, то при перезапуске игры у нас 
                            //будет сохранятся последнее значение (GameIsOver = true), а если в методе Start() 
                            //прописать значение false, то при каждом новом запуске игры панель GameIsOver будет выкл.
    }

    // Update is called once per frame
    void Update () {
        if (GameIsOver)
            return;
       

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
	}
    private void EndGame()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        GameIsOver = true;
        completeLevelUI.SetActive(true);
    }
}
