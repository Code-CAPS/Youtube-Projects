using UnityEngine;

public class MainSceneController : MonoBehaviour
{
    public GameObject canvasMain = null;
    public GameObject canvasWorld = null;
    public GameObject canvasCredits = null;

    public GameState gameState = GameState.MainMenu;

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Assertions.Assert.IsNotNull(canvasMain);
        UnityEngine.Assertions.Assert.IsNotNull(canvasWorld);
        UnityEngine.Assertions.Assert.IsNotNull(canvasCredits);

        this.SetGameState(GameState.MainMenu);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetGameState(GameState theGameState)
    {
        this.gameState = theGameState;

        if (gameState == GameState.World)
        {
            canvasMain.SetActive(false);
            canvasWorld.SetActive(true);
            canvasCredits.SetActive(false);
        }
        else if (gameState == GameState.MainMenu)
        {
            canvasMain.SetActive(true);
            canvasWorld.SetActive(false);
            canvasCredits.SetActive(false);
        }
        // credits
        else
        {
            canvasMain.SetActive(false);
            canvasWorld.SetActive(false);
            canvasCredits.SetActive(true);
        }
    }
}
