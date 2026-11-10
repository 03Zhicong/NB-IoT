
#define DllExport   __declspec( dllexport )

extern "C" DllExport void __stdcall aes128_cmac(int keyIndex, int* msg, int len, int* MAC);
extern "C" DllExport void __stdcall Compute_SessionKey(int keyIndex, int AppNonce, int NetID, int DevNonce, int pad, int* ans);
extern "C" DllExport void __stdcall aes128_cmac2(int* key, int* msg, int len, int* MAC);
extern "C" DllExport void __stdcall aes128_encrypt(int keyIndex, int* data, int len, int pad, int* ans);