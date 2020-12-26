using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class DLLTester : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int resultInteger = Voxel_CPlusPlus.test_integer();
        Debug.Log("The test integer is: " + resultInteger.ToString());

        IntPtr resultCharacterPointer = Voxel_CPlusPlus.hello_world();
        if (resultCharacterPointer != IntPtr.Zero)
        {
            string resultString = Marshal.PtrToStringAnsi(resultCharacterPointer);

            Debug.Log("Hello World String Function: " + resultString);

            Voxel_CPlusPlus.hello_world_free(resultCharacterPointer);
        }

        byte[] theBuffer = new byte[256];
        Voxel_CPlusPlus.test_buffer(theBuffer, theBuffer.Length);

        string theBufferString = System.Text.Encoding.Default.GetString(theBuffer);
        Debug.Log("Byte Buffer Function: " + theBufferString);

        IntPtr meshMaker = Voxel_CPlusPlus.mesh_init();
        if (meshMaker != IntPtr.Zero)
        {
            // TODO: We need to expand this implementation to actually give it input.
            Voxel_CPlusPlus.mesh_set_input(meshMaker);

            byte[] theBufferMesh = new byte[65536];
            Voxel_CPlusPlus.mesh_set_buffer(meshMaker, theBufferMesh, theBufferMesh.Length);

            int resultGeneration = Voxel_CPlusPlus.mesh_generate(meshMaker);
            if (resultGeneration == 0)
            {
                // TODO: Implement buffer swaps.
                Debug.LogWarning("TODO: Swapping buffers not implemented yet.");
            }
            else
            {
                // The mesh is fully generated.
                int quadCount = Voxel_CPlusPlus.mesh_get_quad_count(meshMaker);
                Debug.Log("Quad Count: " + quadCount.ToString());
            }

            // Clean up mesh in the DLL.
            Voxel_CPlusPlus.mesh_free(meshMaker);
            meshMaker = IntPtr.Zero;
        }
    }
}
