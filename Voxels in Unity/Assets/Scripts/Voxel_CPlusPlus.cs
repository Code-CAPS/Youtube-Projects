using System;
using System.Runtime.InteropServices;

public static class Voxel_CPlusPlus
{
    [DllImport("voxel_cplusplus")]
    public static extern int test_integer();

    [DllImport("voxel_cplusplus")]
    public static extern IntPtr hello_world();

    [DllImport("voxel_cplusplus")]
    public static extern void hello_world_free(IntPtr the_string);

    [DllImport("voxel_cplusplus")]
    public static extern void test_buffer(byte[] buffer, int buffer_length);

    [DllImport("voxel_cplusplus")]
    public static extern IntPtr mesh_init();

    [DllImport("voxel_cplusplus")]
    public static extern void mesh_set_input(IntPtr mm);

    [DllImport("voxel_cplusplus")]
    public static extern void mesh_set_input_test_rectangle(IntPtr mm, int width, int height, int depth, int size_world);

    [DllImport("voxel_cplusplus")]
    public static extern void mesh_set_input_test_sphere(IntPtr mm, int radius, int size_world);

    [DllImport("voxel_cplusplus")]
    public static extern void mesh_set_buffer(IntPtr mm, byte[] mesh_buffer, int mesh_buffer_length);

    [DllImport("voxel_cplusplus")]
    public static extern int mesh_generate(IntPtr mm);

    [DllImport("voxel_cplusplus")]
    public static extern int mesh_get_quad_count(IntPtr mm);

    [DllImport("voxel_cplusplus")]
    public static extern void mesh_free(IntPtr mm);
}
