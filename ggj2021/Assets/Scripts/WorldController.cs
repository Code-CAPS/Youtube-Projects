using UnityEngine;

public class WorldController : MonoBehaviour
{
    public Ground ground = null;
    public Player player = null;

    private Diggable diggable = null;

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Assertions.Assert.IsNotNull(ground);
        UnityEngine.Assertions.Assert.IsNotNull(player);

        this.SpawnDiggable();
    }

    // Update is called once per frame
    void Update()
    {
        // todo idling
        if (diggable.value <= 0.0f)
        {
            Destroy(diggable.gameObject);
            diggable = null;

            this.SpawnDiggable();
        }
    }

    public void SpawnDiggable()
    {
        if (diggable != null)
        {
            Destroy(diggable.gameObject);
            diggable = null;
        }

        GameObject diggableGO = ground.SpawnDiggable();
        diggable = diggableGO.GetComponent<Diggable>();
        UnityEngine.Assertions.Assert.IsNotNull(diggable);

        var onClick = diggable.GetComponent<OnClick>();
        UnityEngine.Assertions.Assert.IsNotNull(onClick);

        onClick.theDelegate = OnClickDelegate;
    }

    // player click delegate
    public void OnClickDelegate(OnClick onClickScript)
    {
        diggable.value = diggable.value - player.clickStrength;
        diggable.value = Mathf.Clamp(diggable.value, 0.0f, float.MaxValue);

        if (diggable.value <= 0.0f)
        {
            Destroy(diggable.gameObject);
            diggable = null;

            this.SpawnDiggable();
        }
    }
}
