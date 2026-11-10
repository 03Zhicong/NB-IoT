# NB-IoT Source Code

## Environment

- Windows 10 or 11 (64-bit)
- Visual Studio 2022 with the Desktop development with C++ workload, MSVC v143, and Windows SDK
- .NET Framework 4.8 Developer Pack
- PAT 3.5.1 (64-bit)

## Dependencies

- The CSP models import the PAT libraries `Queue`, `Array`, and `NBIoT`. Their source files are included under `PAT/LibrarySource`; make them available to PAT as custom libraries.
- `PAT.Lib.NBIoT.cs` requires `AES.dll` and PAT's `random.dll`. The AES source project is included; `random.dll` comes from PAT and is not included.
- The separate `NB_IOT_CSharp/NBIoT.cs` wrapper requires `NB_IOT.dll` and `random.dll`. Its matching C++ source project is included.
- The wrappers use `C:\PAT\Lib` as the DLL directory. Install the DLLs there or update the `DllImport` paths.
- Both C++ project files currently target an application. To produce DLLs for the wrappers, set **Configuration Type** to **Dynamic Library (.dll)** for the x64 configuration before building.
- The queue extension uses PAT runtime types supplied by PAT; the PAT installation is not included.

## Run

1. Install the required tools and make the PAT C# library sources available to PAT.
2. For CSP model checking, build `AES.dll`, provide PAT's `random.dll`, and ensure both are discoverable through the paths above.
3. Open `PAT/Models/NB-IoT v1.csp` or `PAT/Models/NB-IoT v2.csp` in PAT and run the model checker.
4. `NB_IOT_CSharp/NBIoT.cs` is an alternate wrapper using `NB_IOT.dll`; it is not directly imported by the included CSP models.
