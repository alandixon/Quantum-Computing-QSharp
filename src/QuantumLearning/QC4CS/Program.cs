﻿using Microsoft.Quantum.Simulation.Simulators;
using System;
using System.Threading.Tasks;


// Quantum Computing for Computer Scientists, Microsoft Research, 2018
// page: https://www.microsoft.com/en-us/research/video/quantum-computing-computer-scientists/
// video: https://www.youtube.com/watch?v=F_Riqjdh2oM
// slides: https://www.microsoft.com/en-us/research/uploads/prod/2018/05/40655.compressed.pdf

namespace QC4CS
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {

            await CallMeasureQubitsAsyncPauliZ();

        }

        static async Task CallMeasureQubitsAsyncPauliZ()
        {
            using var qsim = new QuantumSimulator();

            var repeats = 100;
            Console.WriteLine($"Running qubit measurement {repeats} times.");

            var results = await MeasureQubitsPauliZ.Run(qsim, repeats);
            Console.WriteLine($"Received {results} ones.");
            Console.WriteLine($"Received {repeats - results} zeros.");
            Console.WriteLine("---------------------------------------------------");
        }


    }
}
