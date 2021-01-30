using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMain : MonoBehaviour
{
    public void OnNew()
    {
        SceneManager.LoadScene(Constants.SCENE_CLICKER);
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}
