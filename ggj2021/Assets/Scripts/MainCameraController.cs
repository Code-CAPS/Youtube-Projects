using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    public float slerpFactor = 0.2f;

    public float speedMain = 10.0f;
    public Transform[] pathMain = null;
    public Transform targetMain = null;

    public float speedCredits = 10.0f;
    public Transform[] pathCredits = null;
    public Transform targetCredits = null;

    public float speedWorld = 10.0f;
    public Transform locationWorld = null;
    public Transform targetWorld = null;

    public MainCameraControllerState mainCameraControllerState = MainCameraControllerState.MainMenu;

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Assertions.Assert.IsTrue(speedMain > 0.0f);
        UnityEngine.Assertions.Assert.IsNotNull(pathMain);
        UnityEngine.Assertions.Assert.IsTrue(pathMain.Length > 0);
        UnityEngine.Assertions.Assert.IsNotNull(targetMain);

        UnityEngine.Assertions.Assert.IsTrue(speedCredits > 0.0f);
        UnityEngine.Assertions.Assert.IsNotNull(pathCredits);
        UnityEngine.Assertions.Assert.IsTrue(pathCredits.Length > 0);
        UnityEngine.Assertions.Assert.IsNotNull(targetCredits);

        UnityEngine.Assertions.Assert.IsTrue(speedWorld > 0.0f);
        UnityEngine.Assertions.Assert.IsNotNull(locationWorld);
        UnityEngine.Assertions.Assert.IsNotNull(targetWorld);

        this.transform.LookAt(this.targetMain);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.mainCameraControllerState == MainCameraControllerState.MainMenu)
        {
            Vector3 relativePosition = targetMain.position - this.transform.position;
            Quaternion orientation = Quaternion.LookRotation(relativePosition, Vector3.up);
            orientation = Quaternion.Slerp(this.transform.rotation, orientation, slerpFactor * Time.deltaTime);

            this.transform.rotation = orientation;
        }
        else if (this.mainCameraControllerState == MainCameraControllerState.Credits)
        {
            Vector3 relativePosition = targetCredits.position - this.transform.position;
            Quaternion orientation = Quaternion.LookRotation(relativePosition, Vector3.up);
            orientation = Quaternion.Slerp(this.transform.rotation, orientation, slerpFactor * Time.deltaTime);

            this.transform.rotation = orientation;
        }
        else if (this.mainCameraControllerState == MainCameraControllerState.World)
        {
            Vector3 relativePosition = targetWorld.position - this.transform.position;
            Quaternion orientation = Quaternion.LookRotation(relativePosition, Vector3.up);
            orientation = Quaternion.Slerp(this.transform.rotation, orientation, slerpFactor * Time.deltaTime);

            this.transform.rotation = orientation;
        }
    }

    public void StartPathMain()
    {
        this.mainCameraControllerState = MainCameraControllerState.MainMenu;

        iTween.StopByName(Constants.TWEEN_MAIN_CAMERA);
        iTween.MoveTo(this.gameObject, iTween.Hash(
            "name", Constants.TWEEN_MAIN_CAMERA,
            "path", pathMain,
            "time", speedMain,
            "easetype", iTween.EaseType.linear,
            "looptype", iTween.LoopType.loop
            ));
    }

    public void StartPathWorld()
    {
        this.mainCameraControllerState = MainCameraControllerState.World;

        iTween.StopByName(Constants.TWEEN_MAIN_CAMERA);
        iTween.MoveTo(this.gameObject, iTween.Hash(
            "name", Constants.TWEEN_MAIN_CAMERA,
            "position", locationWorld,
            "time", speedWorld,
            "easetype", iTween.EaseType.easeOutCubic,
            "looptype", iTween.LoopType.none
            ));
    }

    public void StartPathCredits()
    {
        this.mainCameraControllerState = MainCameraControllerState.Credits;

        iTween.StopByName(Constants.TWEEN_MAIN_CAMERA);
        iTween.MoveTo(this.gameObject, iTween.Hash(
            "name", Constants.TWEEN_MAIN_CAMERA,
            "path", pathCredits,
            "time", speedCredits,
            "easetype", iTween.EaseType.linear,
            "looptype", iTween.LoopType.loop
            ));
    }
}
