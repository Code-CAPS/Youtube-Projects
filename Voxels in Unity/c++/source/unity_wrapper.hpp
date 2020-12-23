
#pragma once

#ifdef UNITY_WRAPPER_LIBRARY_EXPORTS
#define UNITY_WRAPPER_LIBRARY_EXPORT __declspec(dllexport)
#else
#define UNITY_WRAPPER_LIBRARY_EXPORT __declspec(dllimport)
#endif

extern "C" UNITY_WRAPPER_LIBRARY_EXPORT bool test_boolean();
extern "C" UNITY_WRAPPER_LIBRARY_EXPORT int test_integer();
extern "C" UNITY_WRAPPER_LIBRARY_EXPORT const char* hello_world();
extern "C" UNITY_WRAPPER_LIBRARY_EXPORT void hello_world_free(const char* the_string);
