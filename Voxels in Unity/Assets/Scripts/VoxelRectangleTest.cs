using System;
using System.Collections.Generic;
using UnityEngine;

public class VoxelRectangleTest : MonoBehaviour
{
    public MeshFilter meshFilter = null;

    public string meshName = "Voxel Rectangle";

    public int width = 10;
    public int height = 10;
    public int depth = 10;
    public int paddingWorld = 2;

    private int bufferSize = 65536;

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Assertions.Assert.IsNotNull(meshFilter);

        UnityEngine.Assertions.Assert.IsTrue(width > 0);
        UnityEngine.Assertions.Assert.IsTrue(height > 0);
        UnityEngine.Assertions.Assert.IsTrue(depth > 0);
        UnityEngine.Assertions.Assert.IsTrue(paddingWorld > 0);

        IntPtr meshMaker = Voxel_CPlusPlus.mesh_init();
        if (meshMaker != IntPtr.Zero)
        {
            int sizeWorld = (int)(Mathf.Max(new float[] { width, height, depth }) + paddingWorld);
            Voxel_CPlusPlus.mesh_set_input_test_rectangle(meshMaker, width, height, depth, sizeWorld);

            List<Vector3> verticesFinal = new List<Vector3>();
            List<int> indicesFinal = new List<int>();

            int resultGeneration = 0;
            byte[] buffer = new byte[bufferSize];
            do
            {
                // generate the mesh information
                Voxel_CPlusPlus.mesh_set_buffer(meshMaker, buffer, bufferSize);
                resultGeneration = Voxel_CPlusPlus.mesh_generate(meshMaker);

                // process the mesh information
                int quadCount = Voxel_CPlusPlus.mesh_get_quad_count(meshMaker);

                int vertexCount = quadCount * 4;

                Vector3[] vertices = new Vector3[vertexCount];
                for (int i = 0; i < vertexCount; i++)
                {
                    Vector3 vertex = Vector3.zero;

                    // the 8 is from 4 bytes for the vertex data and 4 bytes for the face data
                    int index = (i * 8);

                    // todo: use the face data
                    //       we are just using the vertex data currently
                    uint value = BitConverter.ToUInt32(buffer, index);

                    ushort x = (ushort)((value) & 127u);
                    ushort y = (ushort)((value >> 7) & 127u);
                    ushort z = (ushort)((value >> 14) & 511u);

                    vertex.x = (float)x;
                    vertex.y = (float)y;

                    float zScale = (float)(depth) / (float)(depth + 1.0f);
                    vertex.z = (float)(z * zScale);

                    vertices[i] = vertex;
                }

                // Create an index buffer to render the quads as triangles.

                // each quad is two triangles and each triangle is three indices
                int indexCount = quadCount * 6;
                int[] indices = new int[indexCount];

                for (int i = 0; i < quadCount; i++)
                {
                    // each quad has six indices
                    int theIndex = i * 6;
                    // each quad has four vertices
                    int theVertex = i * 4;

                    indices[theIndex + 0] = theVertex + 0;
                    indices[theIndex + 1] = theVertex + 3;
                    indices[theIndex + 2] = theVertex + 1;

                    indices[theIndex + 3] = theVertex + 1;
                    indices[theIndex + 4] = theVertex + 3;
                    indices[theIndex + 5] = theVertex + 2;
                }

                // the vertices we can immediately store in the larger pool of vertices
                int offsetIndex = verticesFinal.Count;
                verticesFinal.AddRange(vertices);

                // the indices are a little more complicated
                // we can not immediately store them
                // we need to offset the new set of indices by the number of pre-existing vertices

                for (int i = 0; i < indices.Length; i++)
                {
                    indices[i] = indices[i] + offsetIndex;
                }

                // now we can store them
                indicesFinal.AddRange(indices);

            } while (resultGeneration == 0);

            // center the vertices around the origin
            Vector3 max = Vector3.zero;
            max.x = float.MinValue;
            max.y = float.MinValue;
            max.z = float.MinValue;

            Vector3 min = Vector3.zero;
            min.x = float.MaxValue;
            min.y = float.MaxValue;
            min.z = float.MaxValue;

            foreach (var vertex in verticesFinal)
            {
                if (vertex.x < min.x)
                {
                    min.x = vertex.x;
                }
                if (vertex.x > max.x)
                {
                    max.x = vertex.x;
                }

                if (vertex.y < min.y)
                {
                    min.y = vertex.y;
                }
                if (vertex.y > max.y)
                {
                    max.y = vertex.y;
                }

                if (vertex.z < min.z)
                {
                    min.z = vertex.z;
                }
                if (vertex.z > max.z)
                {
                    max.z = vertex.z;
                }
            }

            // the offset is half of the average of the max and min
            Vector3 vertexOffset = (max + min) * 0.5f;
            for (int i = 0; i < verticesFinal.Count; i++)
            {
                Vector3 vertex = verticesFinal[i];
                vertex = vertex - vertexOffset;
                verticesFinal[i] = vertex;
            }

            // The mesh data is fully generated.
            // Load the mesh into Unity.

            Mesh theMesh = new Mesh();
            theMesh.name = meshName;

            Vector3[] verticesArray = new Vector3[verticesFinal.Count];
            verticesFinal.CopyTo(verticesArray);
            theMesh.vertices = verticesArray;

            int[] indicesArray = new int[indicesFinal.Count];
            indicesFinal.CopyTo(indicesArray);
            theMesh.triangles = indicesArray;

            // todo: use the normals from the voxel library
            theMesh.RecalculateNormals();
            theMesh.RecalculateBounds();

            meshFilter.sharedMesh = theMesh;

            // Clean up mesh in the DLL.
            Voxel_CPlusPlus.mesh_free(meshMaker);
            meshMaker = IntPtr.Zero;
        }
    }
}
