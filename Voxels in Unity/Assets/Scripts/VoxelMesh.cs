using System;
using UnityEngine;

public class VoxelMesh : MonoBehaviour
{
    public MeshFilter meshFilter = null;

    public int meshBufferSize = 65536;
    public string meshName = "Voxel Mesh";

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Assertions.Assert.IsNotNull(meshFilter);

        IntPtr meshMaker = Voxel_CPlusPlus.mesh_init();
        if (meshMaker != IntPtr.Zero)
        {
            // TODO: We need to expand this implementation to actually give it input.
            Voxel_CPlusPlus.mesh_set_input(meshMaker);

            byte[] theBufferMesh = new byte[meshBufferSize];
            Voxel_CPlusPlus.mesh_set_buffer(meshMaker, theBufferMesh, theBufferMesh.Length);

            int resultGeneration = Voxel_CPlusPlus.mesh_generate(meshMaker);
            if (resultGeneration == 0)
            {
                // TODO: Implement buffer swaps.
                Debug.LogWarning("TODO: Swapping buffers not implemented yet.");
            }
            else
            {
                // The mesh data is fully generated.
                // Load the mesh into Unity.

                Mesh theMesh = new Mesh();
                theMesh.name = meshName;

                // Load the quads into the vertex buffer.
                int quadCount = Voxel_CPlusPlus.mesh_get_quad_count(meshMaker);
                Vector3[] quads = new Vector3[quadCount];
                for (int i = 0; i < quadCount; i++)
                {
                    // TODO: Construct the quad from the mesh data.
                    quads[i] = Vector3.zero;
                }
                theMesh.vertices = quads;

                // Create an index buffer to render the quads as triangles.
                UnityEngine.Assertions.Assert.IsTrue(quadCount % 4 == 0);

                int indexCount = quadCount / 4 * 2;
                int[] indices = new int[indexCount];
                for (int i = 0; i < indexCount; i++)
                {
                    // TODO: Construct the indices.
                    indices[i] = 0;
                }
                theMesh.triangles = indices;

                meshFilter.sharedMesh = theMesh;
            }

            // Clean up mesh in the DLL.
            Voxel_CPlusPlus.mesh_free(meshMaker);
            meshMaker = IntPtr.Zero;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
