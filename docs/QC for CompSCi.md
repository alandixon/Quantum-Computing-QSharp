# Quantum Computing for Computer Scientists

Microsoft Research, 2018

I found this lecture and decided to work through it.

There are various bits of code to be implemented, so I'm adding it to my existing QuantumLearning solution.

## Creating Q# projects

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

## Unit Circle state machine

Around 31:24 in the video, a state machine is explained that drives a |0> qbit to a |-1> qbit.
The slide is the 2nd one called "The unit circle state machine".

## Drawing Quantum circuits

At this point, I realised I needed a way to draw Quantum gates and circuit diagrams to post into these docs.

While hunting around, I found this [List of QC simulators](https://quantiki.org/wiki/list-qc-simulators).

In the above list is [QuIDE - Quantum IDE, a quantum computer simulation platform written in C#](http://www.quide.eu/).  There are [docs](https://bitbucket.org/quide/quide/downloads/UserManual_EN.pdf) and [source](https://bitbucket.org/quide/quide/). This will create multi-gate circuits with with multiple Qbits, multiple Qbit registers and generate C# from the circuit you've designed. Or, write the C# and generate gates from it. Not that the generated C# calls into the api of a provided custom quantum library, it it not compatible with Q#.  You can easily add and remove gates and single step through the circuit. 
And it's all in C# as well, my favourite language. Nice.

Here's the first circuit I created, based on the state machine described.
![image-20210517224104041](C:\Users\alan\AppData\Roaming\Typora\typora-user-images\image-20210517224104041.png)

### Running the state machine code

The code for this is in `QC4CS\Program.qs` in `operation StateMachine()`.
I use `DumpMachine()` to see the result before it is collapsed

If we run this code, we get 

```
Running state machine.
---------------------------------------------------
# wave function for qubits with ids (least to most significant): 0
│0?:    -1.000000 +  0.000000 i  ==     ********************* [ 1.000000 ] ---     [  3.14159 rad ]
│1?:     0.000000 +  0.000000 i  ==                          [ 0.000000 ]
---------------------------------------------------
Received Zero.
---------------------------------------------------
```

which shows the `DumpMachine()` output at the end of the five quantum gate operation. Specifically, the result is ![image-20210517232356704](C:\Users\alan\AppData\Roaming\Typora\typora-user-images\image-20210517232356704.png) which is the expected one.

The `Received Zero` below is the value after it has collapsed due to measurement. 

