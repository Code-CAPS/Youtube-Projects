using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    public float speedMain = 10.0f;
    public Transform[] pathMain = null;
    public Transform targetMain = null;

    public MainCameraControllerState mainCameraControllerState = MainCameraControllerState.MainMenu;

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Assertions.Assert.IsTrue(speedMain > 0.0f);
        UnityEngine.Assertions.Assert.IsNotNull(pathMain);
        UnityEngine.Assertions.Assert.IsTrue(pathMain.Length > 0);
        UnityEngine.Assertions.Assert.IsNotNull(targetMain);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.mainCameraControllerState == MainCameraControllerState.MainMenu)
        {
            this.transform.LookAt(targetMain);
        }
    }

    public void StartPathMain()
    {
        this.mainCameraControllerState = MainCameraControllerState.MainMenu;

        iTween.MoveTo(this.gameObject, iTween.Hash(
            "path", pathMain,
            "time", speedMain,
            "easetype", iTween.EaseType.linear,
            "looptype", iTween.LoopType.loop
            ));
    }

    public void ResumePathMain()
    {

    }
}
