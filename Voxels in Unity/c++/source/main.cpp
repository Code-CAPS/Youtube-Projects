﻿
#if defined(_WIN32)

#include <windows.h>

extern "C" __declspec(dllexport)
BOOL APIENTRY DllMain(HINSTANCE hInst, DWORD reason, LPVOID lpReserved)
{
	switch (reason)
	{
	case DLL_PROCESS_ATTACH:
		break;
	case DLL_PROCESS_DETACH:
		break;
	case DLL_THREAD_ATTACH:
		break;
	case DLL_THREAD_DETACH:
		break;
	}

	return TRUE;
}

#endif 


/*

"   vec3 offset;\n"
"   offset.x = float( (attr_vertex       ) & 127u );\n"             // a[0..6]
"   offset.y = float( (attr_vertex >>  7u) & 127u );\n"             // a[7..13]
"   offset.z = float( (attr_vertex >> 14u) & 511u );\n"             // a[14..22]
"   amb_occ  = float( (attr_vertex >> 23u) &  63u ) / 63.0;\n"      // a[23..28]
"   texlerp  = float( (attr_vertex >> 29u)        ) /  7.0;\n"      // a[29..31]

vnormal = normal_table[(facedata.w>>2u) & 31u];

static float stbvox_default_normals[32][3] =
{
   { 1,0,0 },  // east
   { 0,1,0 },  // north
   { -1,0,0 }, // west
   { 0,-1,0 }, // south
   { 0,0,1 },  // up
   { 0,0,-1 }, // down
   {  STBVOX_RSQRT2,0, STBVOX_RSQRT2 }, // east & up
   {  STBVOX_RSQRT2,0, -STBVOX_RSQRT2 }, // east & down

   {  STBVOX_RSQRT2,0, STBVOX_RSQRT2 }, // east & up
   { 0, STBVOX_RSQRT2, STBVOX_RSQRT2 }, // north & up
   { -STBVOX_RSQRT2,0, STBVOX_RSQRT2 }, // west & up
   { 0,-STBVOX_RSQRT2, STBVOX_RSQRT2 }, // south & up
   {  STBVOX_RSQRT3, STBVOX_RSQRT3, STBVOX_RSQRT3 }, // ne & up
   {  STBVOX_RSQRT3, STBVOX_RSQRT3,-STBVOX_RSQRT3 }, // ne & down
   { 0, STBVOX_RSQRT2, STBVOX_RSQRT2 }, // north & up
   { 0, STBVOX_RSQRT2, -STBVOX_RSQRT2 }, // north & down

   {  STBVOX_RSQRT2,0, -STBVOX_RSQRT2 }, // east & down
   { 0, STBVOX_RSQRT2, -STBVOX_RSQRT2 }, // north & down
   { -STBVOX_RSQRT2,0, -STBVOX_RSQRT2 }, // west & down
   { 0,-STBVOX_RSQRT2, -STBVOX_RSQRT2 }, // south & down
   { -STBVOX_RSQRT3, STBVOX_RSQRT3, STBVOX_RSQRT3 }, // NW & up
   { -STBVOX_RSQRT3, STBVOX_RSQRT3,-STBVOX_RSQRT3 }, // NW & down
   { -STBVOX_RSQRT2,0, STBVOX_RSQRT2 }, // west & up
   { -STBVOX_RSQRT2,0, -STBVOX_RSQRT2 }, // west & down

   {  STBVOX_RSQRT3, STBVOX_RSQRT3,STBVOX_RSQRT3 }, // NE & up crossed
   { -STBVOX_RSQRT3, STBVOX_RSQRT3,STBVOX_RSQRT3 }, // NW & up crossed
   { -STBVOX_RSQRT3,-STBVOX_RSQRT3,STBVOX_RSQRT3 }, // SW & up crossed
   {  STBVOX_RSQRT3,-STBVOX_RSQRT3,STBVOX_RSQRT3 }, // SE & up crossed
   { -STBVOX_RSQRT3,-STBVOX_RSQRT3, STBVOX_RSQRT3 }, // SW & up
   { -STBVOX_RSQRT3,-STBVOX_RSQRT3,-STBVOX_RSQRT3 }, // SW & up
   { 0,-STBVOX_RSQRT2, STBVOX_RSQRT2 }, // south & up
   { 0,-STBVOX_RSQRT2, -STBVOX_RSQRT2 }, // south & down
};

*/
