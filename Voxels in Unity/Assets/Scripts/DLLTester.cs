using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class DLLTester : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        bool resultBoolean = Voxel_CPlusPlus.test_boolean();
        Debug.Log("The test boolean is: " + resultBoolean.ToString());

        int resultInteger = Voxel_CPlusPlus.test_integer();
        Debug.Log("The test integer is: " + resultInteger.ToString());

        IntPtr resultCharacterPointer = Voxel_CPlusPlus.hello_world();
        if (resultCharacterPointer != IntPtr.Zero)
        {
            string resultString = Marshal.PtrToStringAnsi(resultCharacterPointer);

            Debug.Log(resultString);

            Voxel_CPlusPlus.hello_world_free(resultCharacterPointer);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
