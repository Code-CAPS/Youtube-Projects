
#include "unity_wrapper.hpp"

#define STB_VOXEL_RENDER_IMPLEMENTATION
#define STBVOX_CONFIG_MODE 0
#define STBVOX_CONFIG_PRECISION_Z 0
#include "stb_voxel_render.h"

#include <assert.h>
#include <cstring>
#include <string>

int test_integer()
{
	return 23;
}

const char* test_hello_world()
{
	const char* result = new char[] { "Hello World" };
	return result;
}

void test_hello_world_free(const char* the_string)
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

// todo: these are kind of hacky
//       the caller should probably handle these
const int BUFFER_SIZE = 1000000;
static unsigned char block_type[BUFFER_SIZE]{};
static unsigned char geometry[BUFFER_SIZE]{};

stbvox_mesh_maker* mesh_init()
{
	stbvox_mesh_maker* mm = new stbvox_mesh_maker();
	memset(mm, 0, sizeof(stbvox_mesh_maker));

	stbvox_init_mesh_maker(mm);

	return mm;
}

void mesh_set_input(stbvox_mesh_maker* mm)
{
	assert(mm != nullptr);

	// todo: fully implement later
}

void mesh_set_input_test_rectangle(stbvox_mesh_maker* mm, int width, int height, int depth, int size_world)
{
	assert(mm != nullptr);

	assert(size_world > 0);
	assert(size_world > width);
	assert(size_world > height);
	assert(size_world > depth);

	assert(size_world * size_world * size_world <= BUFFER_SIZE);

	memset(block_type, 0, sizeof(unsigned char) * BUFFER_SIZE);
	memset(geometry, STBVOX_GEOM_empty, sizeof(unsigned char) * BUFFER_SIZE);

	stbvox_input_description* input_description = stbvox_get_input_description(mm);

	stbvox_set_input_stride(mm, size_world * size_world * sizeof(unsigned char), size_world * sizeof(unsigned char));

	int x_start = (size_world - width) / 2;
	int y_start = (size_world - height) / 2;
	int z_start = (size_world - depth) / 2;

	for (int x = x_start; x < x_start + width; x++)
	{
		for (int y = y_start; y < y_start + height; y++)
		{
			for (int z = z_start; z < z_start + depth; z++)
			{
				int index = z + (y * size_world) + (x * size_world * size_world);
				block_type[index] = 1;
				geometry[index] = STBVOX_MAKE_GEOMETRY(STBVOX_GEOM_solid, 0, 0);
			}
		}
	}

	input_description->blocktype = block_type;
	input_description->geometry = geometry;

	stbvox_set_input_range(mm, 0, 0, 0, size_world, size_world, size_world);
	stbvox_set_default_mesh(mm, 0);
}

void mesh_set_input_test_sphere(stbvox_mesh_maker* mm, int radius, int size_world)
{
	assert(mm != nullptr);

	assert(size_world > 0);

	int center_world = size_world / 2;
	assert(center_world > radius);

	assert(size_world * size_world * size_world <= BUFFER_SIZE);

	memset(block_type, 0, sizeof(unsigned char) * BUFFER_SIZE);
	memset(geometry, STBVOX_GEOM_empty, sizeof(unsigned char) * BUFFER_SIZE);

	stbvox_input_description* input_description = stbvox_get_input_description(mm);

	stbvox_set_input_stride(mm, size_world * size_world * sizeof(unsigned char), size_world * sizeof(unsigned char));

	for (int x = 0; x < size_world; x++)
	{
		for (int y = 0; y < size_world; y++)
		{
			for (int z = 0; z < size_world; z++)
			{
				float distance = sqrtf(static_cast<float>((x - center_world) * (x - center_world) +
					(y - center_world) * (y - center_world) +
					(z - center_world) * (z - center_world)));
				if (distance <= radius)
				{
					int index = z + (y * size_world) + (x * size_world * size_world);
					block_type[index] = 1;
					geometry[index] = STBVOX_MAKE_GEOMETRY(STBVOX_GEOM_solid, 0, 0);
				}
			}
		}
	}

	input_description->blocktype = block_type;
	input_description->geometry = geometry;

	stbvox_set_input_range(mm, 0, 0, 0, size_world, size_world, size_world);
}

void mesh_set_buffer(stbvox_mesh_maker* mm, unsigned char* mesh_buffer, int mesh_buffer_length)
{
	assert(mm != nullptr);
	assert(mesh_buffer != nullptr);
	assert(mesh_buffer_length > 0);

	stbvox_set_buffer(mm, 0, 0, mesh_buffer, mesh_buffer_length);
	stbvox_set_default_mesh(mm, 0);
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
