using UnityEngine;

public class VoxelMeshNoise : MonoBehaviour
{
    public Noise theNoise = null;

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Assertions.Assert.IsNotNull(theNoise);

        // create some 3D noise
        // use the noise to create an input data set for voxel generation
        // create a mesh from the voxel input data
        // render the mesh

        // todo: implement later
    }

    // Update is called once per frame
    void Update()
    {

    }
}
