using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class DLLTester : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int resultInteger = Voxel_CPlusPlus.test_integer();
        Debug.Log("The test integer is " + resultInteger.ToString() + ".");

        IntPtr helloWorldString = Voxel_CPlusPlus.test_hello_world();
        if (helloWorldString != null)
        {
            string resultString = Marshal.PtrToStringAnsi(helloWorldString);

            Debug.Log("Test Hello World: " + resultString);

            Voxel_CPlusPlus.test_hello_world_free(helloWorldString);
            helloWorldString = IntPtr.Zero;
        }

        byte[] theBuffer = new byte[256];
        Voxel_CPlusPlus.test_buffer(theBuffer, theBuffer.Length);

        string bufferString = System.Text.Encoding.Default.GetString(theBuffer);

        Debug.Log("Test Buffer: " + bufferString);
    }
}
