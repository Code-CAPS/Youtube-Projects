using System;
using System.Runtime.InteropServices;

public static class Voxel_CPlusPlus
{
    [DllImport("voxel_cplusplus")]
    public static extern bool test_boolean();

    [DllImport("voxel_cplusplus")]
    public static extern int test_integer();

    [DllImport("voxel_cplusplus")]
    public static extern IntPtr hello_world();

    [DllImport("voxel_cplusplus")]
    public static extern void hello_world_free(IntPtr theString);
}
