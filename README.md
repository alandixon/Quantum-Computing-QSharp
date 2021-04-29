# Quantum Computing with Q#

This is my repo for learning QC with Q#.

In April 2021, I took part in the [Quantum Coalition Hack](https://www.quantumcoalition.io/), which immediately showed me that I knew next to nothing about [Quantum Computing](https://en.wikipedia.org/wiki/Quantum_computing), so I looked around for resources to learn the basics of QC with Q#.

I couldn't find what I wanted, apart from [a set of articles](https://www.strathweb.com/category/quantum-computing/) on https://www.strathweb.com/.

The plan is to follow through the articles, starting with [Introduction to quantum computing with Q# – Part 1, The background and the qubit](https://www.strathweb.com/2020/03/intro-to-quantum-computing-with-q-part-1-the-background-and-the-qubit/) and code up the examples here in `src/QuantumLearning/StrathWeb`

The articles recommend using [Visual Studio Code](https://code.visualstudio.com/) but I'm going to use [VS2019](https://visualstudio.microsoft.com/vs/) as I'm very familiar with it.

For each article, I'll put in my notes and any gotchas I found.

Also, my Quantum Glossary may help ...

## 1 - Intro,  background and the qubit

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

  

## Credits

### StrathWeb

All the QC articles at [StrathWeb](https://www.strathweb.com/)

### Typora

For editing Markdown. I used to use this [markdown editor](https://github.com/madskristensen/MarkdownEditor) which [installs as a VS2019 extension](https://marketplace.visualstudio.com/items?itemName=MadsKristensen.MarkdownEditor), but I started using [Typora](https://typora.io/) and I'm convinced.



