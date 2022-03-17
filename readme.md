This project shows how to override NuGet's algorithm of determining the framework version of MSAL. This is useful if you have a confidential client application and need to target net5.0-windows10.x
because MSAL uses WinForms on this platforms, which leads to build errors in some environments (e.g. Azure Functions).

## Architecture

This assumes an application `App`, built for `net5.0-windows10.x` which references a library `LibraryForApp` build for `netstandard2.0` which references MSAL. 
For simplicity, this uses a `FakeMsal` library, because it's not easy to understand the framework used by MSAL at runtime. 

## Run the sample

### Repro the issue

1. Build and *pack* FakeMsal 

Confirm that you see `~\Tfm\FakeMsal\bin\Debug\FakeMsal.1.1.0.nupkg`

2. Manually restore the packages for the app 

via a command line `dotnet restore` in the LibraryForApp folder

3. Run the app 

You should see the following output: 

`Hello world from net5.0-windows10.x`

### Fix the issue

1. Edit the App.csproj (not the library csproj) and uncomment this section...

```xml
    <ItemGroup>
		<PackageReference Include="FakeMsal" Version="1.1.0" GeneratePathProperty="true" ExcludeAssets="Compile" />		
		<Reference Include="FakeMsal">
			<HintPath>$(PkgFakeMsal)\lib\netcoreapp2.1\FakeMsal.dll</HintPath>
		</Reference>
	</ItemGroup>
```

2. Run the app

You should see the following output: 

`Hello world from netcore2.1`
