using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public GameObject spawnPoint = null;
    public List<Diggable> diggablePrefabs = new List<Diggable>();

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Assertions.Assert.IsNotNull(spawnPoint);
        UnityEngine.Assertions.Assert.IsTrue(diggablePrefabs.Count > 0);

        this.SpawnDiggable();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnDiggable()
    {
        int seed = Random.Range(0, diggablePrefabs.Count);
        var diggablePrefab = diggablePrefabs[seed];

        var diggable = Instantiate(diggablePrefab, spawnPoint.transform);
        diggable.transform.localPosition = Vector3.zero;
        diggable.transform.localRotation = Quaternion.identity;
    }
}
