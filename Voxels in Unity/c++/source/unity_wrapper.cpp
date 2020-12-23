
#include "unity_wrapper.hpp"

bool test_boolean()
{
	return true;
}

int test_integer()
{
	return 23;
}

const char* hello_world()
{
	const char* result = new char[13]{ "Hello World!" };
	return result;
}

void hello_world_free(const char* the_string)
{
	if (the_string != nullptr)
	{
		delete the_string;
		the_string = nullptr;
	}
}
