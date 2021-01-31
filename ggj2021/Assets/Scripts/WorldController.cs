using System.Collections;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    public AudioClip[] shovelSounds = null;

    public float shakeTime = 0.15f;
    public float shakeDeltaPosition = 0.1f;
    public float shakeDeltaRotation = 8.0f;
    public float shakeDeltaScale = 0.05f;

    public float tweenSuccessTime = 1.0f;
    public Vector3 tweenSuccessPositionDelta = new Vector3(0.0f, 1.0f, 0.0f);
    public Vector3 tweenSuccessRotation = new Vector3(0.0f, 360.0f, 0.0f);

    public Ground ground = null;
    public Player player = null;

    private Diggable diggable = null;
    private bool animatedSuccess = false;

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Assertions.Assert.IsNotNull(shovelSounds);
        UnityEngine.Assertions.Assert.IsTrue(shovelSounds.Length > 0);

        UnityEngine.Assertions.Assert.IsNotNull(ground);
        UnityEngine.Assertions.Assert.IsNotNull(player);
    }

    public void SpawnDiggable()
    {
        this.animatedSuccess = false;

        this.DestroyDiggable();

        GameObject diggableGO = ground.SpawnDiggable();
        diggable = diggableGO.GetComponent<Diggable>();
        UnityEngine.Assertions.Assert.IsNotNull(diggable);

        var onClick = diggable.GetComponent<OnClick>();
        UnityEngine.Assertions.Assert.IsNotNull(onClick);

        onClick.theDelegate = OnClickDelegate;
    }

    public void DestroyDiggable()
    {
        if (diggable != null)
        {
            Destroy(diggable.gameObject);
        }
        diggable = null;
    }

    // player click delegate
    public void OnClickDelegate(OnClick onClickScript)
    {
        if (this.animatedSuccess)
        {
            this.DestroyDiggable();
            this.SpawnDiggable();
        }
        else
        {
            iTween.StopByName(Constants.SHAKE_PUNCH_POSITION);
            iTween.StopByName(Constants.SHAKE_PUNCH_ROTATION);
            iTween.StopByName(Constants.SHAKE_PUNCH_SCALE);

            Vector3 deltaPosition = new Vector3(shakeDeltaPosition, shakeDeltaPosition, shakeDeltaPosition);
            iTween.ShakePosition(diggable.gameObject, iTween.Hash(
                "name", Constants.SHAKE_PUNCH_POSITION,
                "amount", deltaPosition,
                "time", shakeTime
                ));

            Vector3 deltaRotation = new Vector3(shakeDeltaRotation, shakeDeltaRotation, shakeDeltaRotation);
            iTween.ShakeRotation(diggable.gameObject, iTween.Hash(
                "name", Constants.SHAKE_PUNCH_ROTATION,
                "amount", deltaRotation,
                "time", shakeTime
                ));

            Vector3 deltaScale = new Vector3(shakeDeltaScale, shakeDeltaScale, shakeDeltaScale);
            iTween.ShakeScale(diggable.gameObject, iTween.Hash(
                "name", Constants.SHAKE_PUNCH_SCALE,
                "amount", deltaScale,
                "time", shakeTime
                ));

            diggable.value = diggable.value - player.clickStrength;
            diggable.value = Mathf.Clamp(diggable.value, 0.0f, float.MaxValue);

            int seed = Random.Range(0, this.shovelSounds.Length);
            var digSoundFX = this.shovelSounds[seed];
            diggable.PlayDigSoundFX(digSoundFX);

            if (diggable.value <= 0.0f)
            {
                var collider = diggable.GetComponent<Collider>();
                collider.enabled = false;

                StartCoroutine("AnimateSuccessfulDig");
            }
        }
    }

    public IEnumerator AnimateSuccessfulDig()
    {
        iTween.StopByName(Constants.TWEEN_SUCCESS_POSITION);
        iTween.StopByName(Constants.TWEEN_SUCCESS_ROTATION);

        Vector3 position = this.diggable.transform.position + this.tweenSuccessPositionDelta;
        iTween.MoveTo(this.diggable.gameObject, iTween.Hash(
            "name", Constants.TWEEN_SUCCESS_POSITION,
            "position", position,
            "time", tweenSuccessTime,
            "easetype", iTween.EaseType.easeOutCubic,
            "looptype", iTween.LoopType.none
            ));

        iTween.RotateAdd(this.diggable.gameObject, iTween.Hash(
            "name", Constants.TWEEN_SUCCESS_ROTATION,
            "amount", this.tweenSuccessRotation,
            "time", tweenSuccessTime,
            "easetype", iTween.EaseType.easeOutCubic,
            "looptype", iTween.LoopType.none
            ));

        yield return new WaitForSeconds(this.tweenSuccessTime);

        this.animatedSuccess = true;

        yield return null;

        var collider = diggable.GetComponent<Collider>();
        collider.enabled = true;

        yield return null;
    }
}
