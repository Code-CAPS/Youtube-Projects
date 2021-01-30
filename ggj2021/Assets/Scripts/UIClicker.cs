using UnityEngine;
using UnityEngine.SceneManagement;

public class UIClicker : MonoBehaviour
{
    public void OnQuit()
    {
        SceneManager.LoadScene(Constants.SCENE_MAIN);
    }
}
