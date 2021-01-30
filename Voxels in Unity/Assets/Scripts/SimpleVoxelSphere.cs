using UnityEngine;

public class SimpleVoxelSphere : MonoBehaviour
{
    public GameObject voxel = null;

    public int diameter = 10;

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Assertions.Assert.IsNotNull(voxel);
        UnityEngine.Assertions.Assert.IsTrue(diameter > 0);

        Vector3 offset = Vector3.zero;
        offset.x = diameter * 0.5f;
        offset.y = diameter * 0.5f;
        offset.z = diameter * 0.5f;

        for (int i = 0; i < diameter; i++)
        {
            for (int j = 0; j < diameter; j++)
            {
                for (int k = 0; k < diameter; k++)
                {
                    // Is this voxel within the sphere?

                    Vector3 position = new Vector3(i, j, k);
                    position = position - offset;

                    if (Vector3.Distance(position, Vector3.zero) <= diameter * 0.5f)
                    {
                        GameObject voxelInstance = Instantiate(voxel, transform);
                        voxelInstance.transform.localPosition = position;
                        voxelInstance.transform.localRotation = Quaternion.identity;
                    }
                }
            }
        }
    }
}
