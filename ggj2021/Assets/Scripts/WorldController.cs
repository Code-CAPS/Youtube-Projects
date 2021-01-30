using UnityEngine;

public class WorldController : MonoBehaviour
{
    public Ground ground = null;
    public Player player = null;

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Assertions.Assert.IsNotNull(ground);
        UnityEngine.Assertions.Assert.IsNotNull(player);

        GameObject diggable = ground.SpawnDiggable();



    }

    // Update is called once per frame
    void Update()
    {

    }
}
