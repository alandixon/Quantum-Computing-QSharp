# Quantum Computing for Computer Scientists

Microsoft Research, 2018

I found this lecture and decided to work through it.



There are various bits of code to be implemented, so I'm adding it to my existing QuantumLearning solution.

My plan was to add another C# console project that called some Q# code. I tried creating a C# console app and just adding a Q# file. Unfortunately, the C# code just couldn't see it although they were both in the same namespace.

If I inspected properties for the original project (where the Q# code was called correctly), Visual Studio was obviously aware it held Q# code.

Properties for the non-working Q# file were completely different and suggested Visual Studio thought it was just a random file to (optionally) be copied to the output directory when building.

Inspection of project files showed this:

**Working project**

```xml
<Project Sdk="Microsoft.Quantum.Sdk/0.15.2104136839-beta">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netcoreapp3.1</TargetFramework>
  </PropertyGroup>

</Project>
```

**Failing project**

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netcoreapp3.1</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.Quantum.CSharpGeneration" Version="0.15.2104136839-beta" />
    <PackageReference Include="Microsoft.Quantum.EntryPointDriver" Version="0.15.2104136839-beta" />
    <PackageReference Include="Microsoft.Quantum.QSharp.Core" Version="0.15.2104136839-beta" />
    <PackageReference Include="Microsoft.Quantum.Runtime.Core" Version="0.15.2104136839-beta" />
    <PackageReference Include="Microsoft.Quantum.Simulators" Version="0.15.2104136839-beta" />
    <PackageReference Include="Microsoft.Quantum.Standard" Version="0.15.2104136839-beta" />
  </ItemGroup>

</Project>
```

So, I took the working project code and pasted it over the non-working code.

That worked, so now I can start coding up some of the examples.



