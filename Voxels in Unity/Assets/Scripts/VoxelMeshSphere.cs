using System;
using System.Collections.Generic;
using UnityEngine;

public class VoxelMeshSphere : MonoBehaviour
{
    public MeshFilter meshFilter = null;

    public string meshName = "Voxel Sphere";

    public int diameter = 5;
    public int padding = 2;

    private int bufferSize = 6553;

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Assertions.Assert.IsNotNull(meshFilter);

        UnityEngine.Assertions.Assert.IsTrue(diameter > 0);
        UnityEngine.Assertions.Assert.IsTrue(padding > 0);

        UnityEngine.Assertions.Assert.IsTrue(bufferSize > 0);

        IntPtr meshMaker = Voxel_CPlusPlus.mesh_init();
        if (meshMaker != IntPtr.Zero)
        {
            int sizeWorld = diameter + padding;
            Voxel_CPlusPlus.mesh_set_input_test_sphere(meshMaker, diameter / 2, sizeWorld);

            List<Vector3> vertices = new List<Vector3>();
            List<int> indices = new List<int>();

            int resultGeneration = 0;
            byte[] buffer = new byte[bufferSize];
            do
            {
                Voxel_CPlusPlus.mesh_set_buffer(meshMaker, buffer, buffer.Length);

                resultGeneration = Voxel_CPlusPlus.mesh_generate(meshMaker);

                int quadCount = Voxel_CPlusPlus.mesh_get_quad_count(meshMaker);
                int vertexCount = quadCount * 4;

                Vector3[] verticesInner = new Vector3[vertexCount];
                for (int i = 0; i < vertexCount; i++)
                {
                    Vector3 vertex = Vector3.zero;

                    // note: there are 4 bytes of vertex data and 4 bytes of face data
                    int index = (i * 8);

                    uint value = BitConverter.ToUInt32(buffer, index);

                    ushort x = (ushort)((value) & 127u);
                    ushort y = (ushort)((value >> 7) & 127u);
                    ushort z = (ushort)((value >> 14) & 511u);

                    vertex.x = (float)x;
                    vertex.y = (float)y;
                    vertex.z = (float)z;

                    vertex.z = vertex.z + ((float)diameter / ((float)diameter + 1.0f));

                    vertices[i] = vertex;
                }

                // create an index buffer

                // each quad has two triangles where each triangle has three indices
                int indexCount = quadCount * 6;
                int[] indicesInner = new int[indexCount];

                for (int i = 0; i < quadCount; i++)
                {
                    // each quad has 6 indices
                    int theIndex = i * 6;
                    // each quad has 4 vertices
                    int theVertex = i * 4;

                    // triangle one
                    indicesInner[theIndex + 0] = theVertex + 0;
                    indicesInner[theIndex + 1] = theVertex + 3;
                    indicesInner[theIndex + 2] = theVertex + 1;

                    // triangle two
                    indicesInner[theIndex + 3] = theVertex + 1;
                    indicesInner[theIndex + 4] = theVertex + 3;
                    indicesInner[theIndex + 5] = theVertex + 2;
                }

                // we can immediately store the vertices
                int indexOffset = vertices.Count;
                vertices.AddRange(verticesInner);

                // for the indices, we need to offset them by any pre-existing vertices
                for (int i = 0; i < indicesInner.Length; i++)
                {
                    indicesInner[i] = indicesInner[i] + indexOffset;
                }

                indices.AddRange(indicesInner);

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

            for (int i = 0; i < vertices.Count; i++)
            {
                Vector3 vertex = vertices[i];

                if (vertex.x > max.x)
                {
                    max.x = vertex.x;
                }
                if (vertex.y > max.y)
                {
                    max.y = vertex.y;
                }
                if (vertex.z > max.z)
                {
                    max.z = vertex.z;
                }

                if (vertex.x < min.x)
                {
                    min.x = vertex.x;
                }
                if (vertex.y < min.y)
                {
                    min.y = vertex.y;
                }
                if (vertex.z < min.z)
                {
                    min.z = vertex.z;
                }
            }

            // offset the vertices to center them around the origin
            Vector3 offset = (max + min) * 0.5f;
            for (int i = 0; i < vertices.Count; i++)
            {
                Vector3 vertex = vertices[i];
                vertex = vertex - offset;
                vertices[i] = vertex;
            }

            // Store the mesh in Unity.
            Mesh theMesh = new Mesh();
            theMesh.name = meshName;

            Vector3[] verticesFinal = new Vector3[vertices.Count];
            vertices.CopyTo(verticesFinal);
            theMesh.vertices = verticesFinal;

            int[] indicesFinal = new int[indices.Count];
            indices.CopyTo(indicesFinal);
            theMesh.triangles = indicesFinal;

            // todo: use the normals from the voxel library
            theMesh.RecalculateNormals();
            theMesh.RecalculateBounds();

            // store the mesh on the mesh filter
            meshFilter.sharedMesh = theMesh;

            Voxel_CPlusPlus.mesh_free(meshMaker);
            meshMaker = IntPtr.Zero;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
