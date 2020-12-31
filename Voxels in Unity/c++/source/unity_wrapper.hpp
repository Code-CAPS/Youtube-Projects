
#pragma once

#ifdef UNITY_WRAPPER_LIBRARY_EXPORTS
#define UNITY_WRAPPER_LIBRARY_EXPORT __declspec(dllexport)
#else
#define UNITY_WRAPPER_LIBRARY_EXPORT __declspec(dllimport)
#endif

extern "C" UNITY_WRAPPER_LIBRARY_EXPORT int test_integer();
extern "C" UNITY_WRAPPER_LIBRARY_EXPORT const char* test_hello_world();
extern "C" UNITY_WRAPPER_LIBRARY_EXPORT void test_hello_world_free(const char* the_string);
extern "C" UNITY_WRAPPER_LIBRARY_EXPORT void test_buffer(unsigned char* buffer, int buffer_length);

struct stbvox_mesh_maker;
extern "C" UNITY_WRAPPER_LIBRARY_EXPORT stbvox_mesh_maker * mesh_init();
extern "C" UNITY_WRAPPER_LIBRARY_EXPORT void mesh_set_input(stbvox_mesh_maker * mm);
extern "C" UNITY_WRAPPER_LIBRARY_EXPORT void mesh_set_input_test_rectangle(stbvox_mesh_maker * mm,
	int width, int height, int depth, int size_world);
extern "C" UNITY_WRAPPER_LIBRARY_EXPORT void mesh_set_input_test_sphere(stbvox_mesh_maker * mm,
	int radius, int size_world);
extern "C" UNITY_WRAPPER_LIBRARY_EXPORT void mesh_set_buffer(stbvox_mesh_maker * mm,
	unsigned char* mesh_buffer, int mesh_buffer_length);
extern "C" UNITY_WRAPPER_LIBRARY_EXPORT int mesh_generate(stbvox_mesh_maker * mm);
extern "C" UNITY_WRAPPER_LIBRARY_EXPORT int mesh_get_quad_count(stbvox_mesh_maker * mm);
extern "C" UNITY_WRAPPER_LIBRARY_EXPORT void mesh_free(stbvox_mesh_maker * mm);
