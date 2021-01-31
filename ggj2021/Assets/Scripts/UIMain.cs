using UnityEngine;

public class UIMain : MonoBehaviour
{
    public MainSceneController mainSceneController = null;

    void Start()
    {
        UnityEngine.Assertions.Assert.IsNotNull(mainSceneController);
    }

    public void OnNew()
    {
        mainSceneController.SetGameState(GameState.World);
    }

    public void OnCredits()
    {
        mainSceneController.SetGameState(GameState.Credits);
    }

    public void OnQuitMain()
    {
        Application.Quit();
    }

    public void OnQuitCredits()
    {
        mainSceneController.SetGameState(GameState.MainMenu);
    }

    public void OnQuitWorld()
    {
        mainSceneController.SetGameState(GameState.MainMenu);
    }
}
