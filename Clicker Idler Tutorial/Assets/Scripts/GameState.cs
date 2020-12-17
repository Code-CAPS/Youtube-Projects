using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public GameObject spawnPoint = null;
    public List<GameObject> enemyPrefabs = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Assertions.Assert.IsNotNull(spawnPoint);
        UnityEngine.Assertions.Assert.IsTrue(enemyPrefabs.Count > 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
