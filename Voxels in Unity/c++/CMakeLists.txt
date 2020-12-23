
cmake_minimum_required(VERSION 3.9)

project(voxel_cplusplus)

set(ALL_FILES
    source/main.cpp
    source/unity_wrapper.hpp
    source/unity_wrapper.cpp

    source/stb.h
    source/stb_c_lexer.h
    source/stb_connected_components.h
    source/stb_divide.h
    source/stb_ds.h
    source/stb_dxt.h
    source/stb_easy_font.h
    source/stb_herringbone_wang_tile.h
    source/stb_image.h
    source/stb_image_resize.h
    source/stb_image_write.h
    source/stb_include.h
    source/stb_leakcheck.h
    source/stb_perlin.h
    source/stb_rect_pack.h
    source/stb_sprintf.h
    source/stb_textedit.h
    source/stb_tilemap_editor.h
    source/stb_truetype.h
    source/stb_vorbis.c
    source/stb_voxel_render.h
    source/stretchy_buffer.h
)

add_library(voxel_cplusplus SHARED ${ALL_FILES})

target_compile_definitions(voxel_cplusplus PRIVATE UNITY_WRAPPER_LIBRARY_EXPORTS)
target_compile_features(voxel_cplusplus PRIVATE cxx_std_17)
