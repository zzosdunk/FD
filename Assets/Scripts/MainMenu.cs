using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public string levelToLoad;
    public SceneFader sceneFader;
    private PauseMenu unfreeze;

    public void Play()
    {
        
        sceneFader.FadeTo(levelToLoad);
        //PlayerPrefs.DeleteKey("levelReached");
        int currentLevel = PlayerPrefs.GetInt("levelReached");
        Debug.Log("timeScale " + Time.timeScale);
        Debug.Log("currentLevel " + currentLevel);
    }

    public void Exit()
    {
        Debug.Log("Exitiing...");
        Application.Quit();
    }
}
