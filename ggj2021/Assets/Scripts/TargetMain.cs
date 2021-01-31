using UnityEngine;

public class TargetMain : MonoBehaviour
{
    public float speed = 10.0f;
    public Transform[] path = null;

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Assertions.Assert.IsTrue(speed > 0.0f);
        UnityEngine.Assertions.Assert.IsNotNull(path);
        UnityEngine.Assertions.Assert.IsTrue(path.Length > 0);

        this.gameObject.transform.position = path[0].transform.position;

        iTween.MoveTo(this.gameObject, iTween.Hash(
            "path", path,
            "time", speed,
            "easetype", iTween.EaseType.linear,
            "looptype", iTween.LoopType.loop
            ));
    }
}
