## Part 1 - Intro,  background and the qubit

#### Hello quantum world

`src\QuantumLearning\StrathWeb\Program.qs`

Because I'm running in VS2019, I dispensed with the C# boot framework program and annotated the method:

```qsharp
[@EntryPoint()]()
HelloQ()
```

Without this, the runtime wouldn't know where to start. It's a bit like a C/C++ main() method.

#### MeasureQubits

Q# is new and constantly evolving. I found two things in the StrathWeb code that were deprecated / needed changing.

- The "using" keyword has been replaced with "use", and qubits may now be allocated without a block.	

- Brackets are deprecated in certain circumstances.

  ```qsharp
  using (qubit = Qubit())
    {for (idx in 0..count)
  ```

  Becomes

  ```qsharp
  use qubit = Qubit()
    {for idx in 0..count
  ```

  

If you are just looking at latest code, jump past the next paragraph to **PauliZ / PauliX measurements**.

#### Change of direction

I said I was dispensing with the C# boot framework program, but the next part of the article changed the `Main()` method in the C# code quite a bit. So I backtracked and followed the approach proposed: I used VS Code to generate a new C# / Q# project, as described in "*Getting started with qubits in Q*".

Specifically:

- I start up VS Code

- `File` > `Open Folder`, move to / create a HelloWorld folder somewhere and click `Select Folder`

- `View` > `Terminal`. This opens the terminal in the HelloWorld folder. [This may help](https://docs.microsoft.com/en-us/dotnet/core/tutorials/with-visual-studio-code).

- `dotnet new console -lang "Q#"`  This creates a default Q# file called `Program.qs` and a project file called `HelloWorld.csproj`

- Unfortunately, despite the suggestion in the article, no C# file was created, so I created my own called `HelloWorld.cs` and populated it with the code shown.

- I need to change the namespace in `Program.qs` from `HelloWorld` to `QubitExample` to match the namespace in `HelloWorld.cs`

- I also remove `@EntryPoint()` by commenting it out.

- Using `ls` (or `dir`) in the terminal, my folder now looks like this:
  `Mode                 LastWriteTime         Length Name`

  ----                 -------------         ------ ----

  `d-----        07/05/2021     23:17                .vscode`
  `d-----        07/05/2021     23:17                bin`
  `d-----        07/05/2021     23:17                obj`
  `-a----        07/05/2021     23:18            361 HelloWorld.cs`
  `-a----        07/05/2021     23:14            203 HelloWorld.csproj`
  `-a----        07/05/2021     23:14            217 Program.qs`

- I can now run the program from the terminal with
  `dotnet run HelloWorld.cs`
  and if all is well, I get
  `Hello quantum world!`

I wanted to have my `HelloWorld.cs` call various Q# operations one after another, so  I had to fiddle around with the C# `async` usage a bit.

I plan to still use Visual Studio (rather than VS Code), but I will stay with the C# bootstrapper. 

I removed the `StrathWeb` project and put all my new code in `src\QuantumLearning\HelloWorld`

#### PauliZ / PauliX measurements

With these two operations, we initialise and measure state 100 times.

As the article says, we "*allocate some qubits, measure their values and print the results*"

We use [Pauli gates](https://en.wikipedia.org/wiki/Quantum_logic_gate#Pauli_gates), specifically [PauliZ](https://en.wikipedia.org/wiki/Quantum_logic_gate#Z_gate) and [PauliX](https://en.wikipedia.org/wiki/Quantum_logic_gate#X_gate).

In the first case, we measure the "*qubit in the computational basis, known as Pauli-Z basis*".

In the second case, we measure with Pauli-X. The aim here is to prove that "*a quantum state is always in superposition with respect to certain bases and not in superposition to others*"

#### Combining Measurement and Reset

```qsharp
    let result = Measure([PauliX], [qubit]);
    set resultsTotal += result == One ? 1 | 0;
    Reset(qubit);
```

can be compacted to

```qsharp
    let result = MResetZ(qubit);
    set resultsTotal += result == One ? 1 | 0;
```

