using UnityEngine;

public class MainSceneController : MonoBehaviour
{
    public MainCameraController mainCameraController = null;
    public WorldController worldController = null;

    public GameObject canvasMain = null;
    public GameObject canvasWorld = null;
    public GameObject canvasCredits = null;
    public GameObject canvasCreditsWS = null;

    public GameState gameState = GameState.MainMenu;

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Assertions.Assert.IsNotNull(mainCameraController);
        UnityEngine.Assertions.Assert.IsNotNull(worldController);

        UnityEngine.Assertions.Assert.IsNotNull(canvasMain);
        UnityEngine.Assertions.Assert.IsNotNull(canvasWorld);
        UnityEngine.Assertions.Assert.IsNotNull(canvasCredits);
        UnityEngine.Assertions.Assert.IsNotNull(canvasCreditsWS);

        this.SetGameState(GameState.MainMenu);
    }

    public void SetGameState(GameState theGameState)
    {
        this.gameState = theGameState;

        if (gameState == GameState.World)
        {
            canvasMain.SetActive(false);
            canvasWorld.SetActive(true);
            canvasCredits.SetActive(false);
            canvasCreditsWS.SetActive(false);

            this.mainCameraController.StartPathWorld();
            this.worldController.SpawnDiggable();
        }
        else if (gameState == GameState.MainMenu)
        {
            canvasMain.SetActive(true);
            canvasWorld.SetActive(false);
            canvasCredits.SetActive(false);
            canvasCreditsWS.SetActive(false);

            this.mainCameraController.StartPathMain();
            this.worldController.DestroyDiggable();
        }
        // credits
        else
        {
            canvasMain.SetActive(false);
            canvasWorld.SetActive(false);
            canvasCredits.SetActive(true);
            canvasCreditsWS.SetActive(true);

            this.mainCameraController.StartPathCredits();
            this.worldController.DestroyDiggable();
        }
    }
}
