using UnityEngine;

public class SimpleVoxelRectangle : MonoBehaviour
{
    public GameObject voxel = null;

    public int width = 10;
    public int height = 10;
    public int depth = 10;

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Assertions.Assert.IsNotNull(voxel);
        UnityEngine.Assertions.Assert.IsTrue(width > 0);
        UnityEngine.Assertions.Assert.IsTrue(height > 0);
        UnityEngine.Assertions.Assert.IsTrue(depth > 0);

        Vector3 offset = Vector3.zero;
        offset.x = width * 0.5f;
        offset.y = height * 0.5f;
        offset.z = depth * 0.5f;

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                for (int k = 0; k < depth; k++)
                {
                    GameObject voxelInstance = Instantiate(voxel, transform);

                    Vector3 position = new Vector3(i, j, k);
                    position = position - offset;

                    voxelInstance.transform.localPosition = position;
                    voxelInstance.transform.localRotation = Quaternion.identity;
                }
            }
        }
    }
}
