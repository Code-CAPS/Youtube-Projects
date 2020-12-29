using UnityEngine;

public class VoxelMeshNoise : MonoBehaviour
{
    public Noise theNoise = null;

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Assertions.Assert.IsNotNull(theNoise);

        // use the noise to create voxel input data
        // use the voxel input data to create a mesh
        // render the mesh

        // TODO: implement later
    }

    // Update is called once per frame
    void Update()
    {

    }
}
