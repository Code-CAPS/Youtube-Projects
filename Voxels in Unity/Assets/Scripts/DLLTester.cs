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
    }
}
