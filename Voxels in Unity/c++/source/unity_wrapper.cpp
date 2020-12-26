
#include "unity_wrapper.hpp"

#define STB_VOXEL_RENDER_IMPLEMENTATION
#define STBVOX_CONFIG_MODE 0
#include "stb_voxel_render.h"

#include <assert.h>
#include <cstring>
#include <string>

int test_integer()
{
	return 23;
}

const char* hello_world()
{
	const char* result = new char[] { "Hello World" };
	return result;
}

void hello_world_free(const char* the_string)
{
	if (the_string != nullptr)
	{
		delete[] the_string;
		the_string = nullptr;
	}
}

void test_buffer(unsigned char* buffer, int buffer_length)
{
	assert(buffer != nullptr);
	assert(buffer_length > 0);

	const std::string HELLO_WORLD{ "Hello World" };

	for (int i = 0; i < buffer_length; i++)
	{
		if (i < HELLO_WORLD.size())
		{
			buffer[i] = static_cast<unsigned char>(HELLO_WORLD[i]);
		}
		else
		{
			buffer[i] = 0;
		}
	}
}

stbvox_mesh_maker* mesh_init()
{
	stbvox_mesh_maker* mm = new stbvox_mesh_maker();
	memset(mm, 0, sizeof(stbvox_mesh_maker));

	stbvox_init_mesh_maker(mm);
	stbvox_set_default_mesh(mm, 0);

	return mm;
}

void mesh_set_input(stbvox_mesh_maker* mm)
{
	assert(mm != nullptr);

	//
	// TODO: Just creating a simple test mesh for now.

	stbvox_input_description* input_description = stbvox_get_input_description(mm);

	unsigned char block_geometry[4] =
	{
		STBVOX_GEOM_empty,
		STBVOX_GEOM_knockout,
		STBVOX_GEOM_solid,
		STBVOX_GEOM_transp,
	};
	input_description->block_geometry = block_geometry;

	const int WIDTH = 16;
	const int HEIGHT = 16;
	const int DEPTH = 16;
	const int SIZE = WIDTH * HEIGHT * DEPTH;

	stbvox_set_input_stride(mm, WIDTH * HEIGHT, WIDTH);
	stbvox_set_input_range(mm, 1, 1, 1, WIDTH - 1, HEIGHT - 1, DEPTH - 1);

	unsigned char blocktype[SIZE]{};
	memset(blocktype, 0, SIZE);

	// Create a rectangular solid near the center.
	for (int z = 4; z < 12; z++)
	{
		for (int y = 4; y < 12; y++)
		{
			for (int x = 4; x < 12; x++)
			{
				blocktype[x + WIDTH * (y + HEIGHT * z)] = STBVOX_GEOM_solid;
			}
		}
	}
	input_description->blocktype = blocktype;
}

void mesh_set_buffer(stbvox_mesh_maker* mm, unsigned char* mesh_buffer, int mesh_buffer_length)
{
	assert(mm != nullptr);
	assert(mesh_buffer != nullptr);
	assert(mesh_buffer_length > 0);

	stbvox_set_buffer(mm, 0, 0, mesh_buffer, mesh_buffer_length);
}

int mesh_generate(stbvox_mesh_maker* mm)
{
	assert(mm != nullptr);

	// 1 is done
	// 0 is more data
	int result = stbvox_make_mesh(mm);
	return result;
}

int mesh_get_quad_count(stbvox_mesh_maker* mm)
{
	assert(mm != nullptr);

	int quad_count = stbvox_get_quad_count(mm, 0);
	return quad_count;
}

void mesh_free(stbvox_mesh_maker* mm)
{
	if (mm != nullptr)
	{
		delete mm;
		mm = nullptr;
	}
}
