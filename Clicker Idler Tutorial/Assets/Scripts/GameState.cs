using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public GameObject spawnPoint = null;
    public List<GameObject> enemyPrefabs = new List<GameObject>();

    Enemy enemyCurrent = null;

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Assertions.Assert.IsNotNull(spawnPoint);
        UnityEngine.Assertions.Assert.IsTrue(enemyPrefabs.Count > 0);

        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {

    }

    [ContextMenu("Spawn an enemy")]
    void SpawnEnemy()
    {
        // remove the old enemy if present
        DestroyEnemy();

        // create a new enemy
        int seed = Random.Range(0, enemyPrefabs.Count);
        GameObject enemyPrefab = enemyPrefabs[seed];

        GameObject enemyNew = Instantiate(enemyPrefab, spawnPoint.transform);
        enemyNew.transform.localPosition = Vector3.zero;
        enemyNew.transform.localRotation = Quaternion.identity;

        // store the enemy
        enemyCurrent = enemyNew.GetComponent<Enemy>();
        UnityEngine.Assertions.Assert.IsNotNull(enemyCurrent);
    }

    void DestroyEnemy()
    {
        if (enemyCurrent != null)
        {
            Destroy(enemyCurrent.gameObject);
        }
        enemyCurrent = null;
    }
}
